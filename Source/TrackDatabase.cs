////////////////////////////////////
// Theme Tune Quiz (TTQ)          //
// Copyright (C) Ted John 2012    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using HundredMilesSoftware.UltraID3Lib;

namespace IntelOrca.TTQ
{
	class TrackDatabase
	{
		private const string EXTENSION_MP3 = ".mp3";
		private const string MESSAGE_MISSING_MP3S = "'{0}' does not exist! Would you like to remove it from the database? (Cancel to ignore all)";
		private const string MESSAGE_UNRECORDED_MP3S = "There are {0} unrecorded MP3s, would you like to add them?";

		TrackCollection mTracks = new TrackCollection();

		private void AddTuneNode(XmlNode node)
		{
			Track tune = new Track();
			List<XmlNode> properties = new List<XmlNode>();
			tune.CloseAnswer = "";
			XmlNode filename = node.Attributes.GetNamedItem("Filename");
			if (filename != null)
				tune.Filename = filename.InnerText;
			foreach (XmlNode element in node.ChildNodes) {
				switch (element.Name) {
					case "Genre":
						tune.Genre = element.InnerText;
						break;
					case "Title":
						tune.Title = element.InnerText;
						break;
					case "Song":
						tune.Song = element.InnerText;
						break;
					case "Theme":
						tune.IsTheme = XMLBool(element.InnerText);
						break;
					case "TrackLength":
						tune.TrackLength = Convert.ToInt32(element.InnerText);
						break;
					case "Skipsecs":
						tune.SkipSecs = Convert.ToDouble(element.InnerText);
						break;
					case "Playsecs":
						tune.PlaySecs = Convert.ToDouble(element.InnerText);
						break;
					case "CloseAnswer":
						tune.CloseAnswer += element.InnerText + "|";
						break;
                    case "TimesPlayed":
                        tune.TimesPlayed = Convert.ToInt32(element.InnerText);
                        break;
				}
			}
			tune.CloseAnswer = tune.CloseAnswer.TrimEnd('|');
			mTracks.Add(tune);
		}

		private bool HasContent(object o)
		{
			if (o == null)
				return false;
			if (o is string) {
				if (((string)o).Length > 0)
					return true;
			} else if (o is int) {
				if ((int)o != 0)
					return true;
			} else if (o is double) {
				if ((double)o != 0)
					return true;
			} else if (o is bool) {
				if ((bool)o)
					return true;
			}
			return false;
		}

		private void WritePlainElement(XmlWriter xmlWriter, string name, string value)
		{
			if (value == null)
				value = "";
			xmlWriter.WriteStartElement(name);
			xmlWriter.WriteValue(value);
			xmlWriter.WriteEndElement();
		}

		private void WriteTuneNode(XmlWriter xmlWriter, Track tune)
		{
			xmlWriter.WriteStartElement("Tune");
			xmlWriter.WriteAttributeString("Filename", tune.Filename);

			WritePlainElement(xmlWriter, "Genre", tune.Genre);
			WritePlainElement(xmlWriter, "Title", tune.Title);
			if (HasContent(tune.Song))
				WritePlainElement(xmlWriter, "Song", tune.Song);
			if (tune.IsTheme)
				WritePlainElement(xmlWriter, "Theme", "Yes");
			WritePlainElement(xmlWriter, "TrackLength", tune.TrackLength.ToString());
			if (HasContent(tune.SkipSecs))
				WritePlainElement(xmlWriter, "Skipsecs", tune.SkipSecs.ToString());
			if (HasContent(tune.PlaySecs))
                WritePlainElement(xmlWriter, "Playsecs", tune.PlaySecs.ToString());
			if (HasContent(tune.CloseAnswer)) {
				foreach (string answer in tune.CloseAnswer.Split('|')) {
					if (HasContent(answer))
						WritePlainElement(xmlWriter, "CloseAnswer", answer);
				}
			}
            WritePlainElement(xmlWriter, "TimesPlayed", tune.TimesPlayed.ToString());
			xmlWriter.WriteFullEndElement();
		}

		private bool XMLBool(string s)
		{
			return (s.ToLower() == "yes");
		}

		public void AllSongsExist()
		{
			List<Track> needRemoving = new List<Track>();
			foreach (Track tune in mTracks) {
				string filename = tune.Filename;
				if (!File.Exists(MusicDirectory + filename)) {
					DialogResult result = MessageBox.Show(String.Format(MESSAGE_MISSING_MP3S, filename),
						"Tune does not exist", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
					switch (result) {
						case DialogResult.Yes:
							needRemoving.Add(tune);
							break;
						case DialogResult.Cancel:
							return;
					}
				}
			}

			//Remove all the items in need removing
			foreach (Track tune in needRemoving) {
				mTracks.Remove(tune);
			}
		}

		public void DetectUnrecordedMP3S()
		{
			List<string> newMP3s = new List<string>();
			string[] files = Directory.GetFiles(MusicDirectory, "*" + EXTENSION_MP3);
			foreach (string f in files)
				if (!mTracks.Contains(Path.GetFileName(f)))
					newMP3s.Add(f);

			if (newMP3s.Count == 0)
				return;

			if (MessageBox.Show(String.Format(MESSAGE_UNRECORDED_MP3S, newMP3s.Count),
				"Unrecorded MP3s", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
				foreach (string f in newMP3s) {
					Track tune = new Track();
					tune.Filename = Path.GetFileName(f);
					tune.Title = Path.GetFileNameWithoutExtension(f);
					tune.IsTheme = true;

					// Get ID3 tags
					UltraID3 ID3 = new UltraID3();
					ID3.Read(f);
					tune.Song = ID3.Title;
					tune.TrackLength = (int)ID3.Duration.TotalSeconds;
					mTracks.Add(tune);
				}
			}
		}

		public string[] GetGenres()
		{
			HashSet<string> genreSet = new HashSet<string>();
			foreach (Track t in mTracks) {
				if (!genreSet.Contains(t.Genre.ToLower()))
					genreSet.Add(t.Genre.ToLower());
			}

			string[] genres = new string[genreSet.Count];
			genreSet.CopyTo(genres);
			return genres;
		}

		public Track GetTune(string filename)
		{
			foreach (Track tune in mTracks) {
				if (tune.Filename == filename)
					return tune;
			}
			Track nullTune = new Track();
			nullTune.Title = "Tune not found in database";
			return nullTune;
		}

		public void Open()
		{
            mTracks.Clear();

			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(XMLFile);
			XmlNode themes = xmlDoc.SelectSingleNode("/Themes");
			foreach (XmlNode node in themes.ChildNodes) {
				AddTuneNode(node);
			}
		}

		public bool RemoveFile(int index)
		{
			string filename = TuneFilename(index);
			try {
				File.Delete(filename);
				mTracks.RemoveAt(index);
				return true;
			} catch {
				return false;
			}
		}

		public bool RenameFile(int index, string newValue)
		{
			string oldValue = TuneFilename(index);
			newValue = String.Format("{0}{1}", MusicDirectory, newValue);
			if (oldValue == newValue)
				return true;
			if (File.Exists(newValue)) {
				return false;
			} else {
				try {
					File.Move(oldValue, newValue);
					Track tune = mTracks[index];
					tune.Filename = Path.GetFileName(newValue);
					mTracks[index] = tune;
					return true;
				} catch {
					return false;
				}
			}
		}

		public void Save()
		{
			//Save project in XML format
			XmlWriter xmlWriter;

			//Set settings
			XmlWriterSettings xmlSettings = new XmlWriterSettings();
			xmlSettings.Indent = true;

			//Backup the database before overwriting
			if (File.Exists(XMLFile)) {
				File.Copy(XMLFile, XMLFile + ".bak", true);
			}

			//Start writing and create project node
			xmlWriter = XmlWriter.Create(XMLFile, xmlSettings);
			xmlWriter.WriteStartElement("Themes");

			//Folders
			foreach (Track tune in mTracks)
				WriteTuneNode(xmlWriter, tune);

			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndDocument();
			xmlWriter.Close();
		}

		public void SortAlphabetically()
		{
			mTracks.Sort(new Track.TrackTitleComparer());
		}

		public int GetGenreTrackCount(string genre)
		{
			int count = 0;
			foreach (Track t in mTracks)
				if (String.Compare(t.Genre, genre, true) == 0)
					count++;
			return count;
		}

		public string TuneFilename(int index)
		{
			return String.Format(MusicDirectory + "{0}", mTracks[index].Filename);
		}

		public TrackCollection Tracks
		{
			get
			{
				return mTracks;
			}
		}

		public string MusicDirectory
		{
			get
			{
				return Application.StartupPath + "\\Music\\";
			}
		}

		public string XMLFile
		{
			get
			{
				return Application.StartupPath + "\\Music.xml";
			}
		}
	}
}