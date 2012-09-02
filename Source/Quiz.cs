using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace IntelOrca.TTQ
{
	class Quiz
	{
		private string mName;
		private DateTime mCreationTime;
		private RoundCollection mRounds = new RoundCollection();

		public Quiz()
		{
		}

		public Quiz(TrackDatabase db, string path)
		{
			LoadXMLQuiz(db, path);
		}

		public int GetMaximumScore()
		{
			int maxscore = 0;
			foreach (Round r in mRounds)
				maxscore += r.GetMaximumScore();
			return maxscore;
		}

		private bool IsPositiveInt(string text)
		{
			try {
				int value = Convert.ToInt32(text);
				if (value < 0)
					return false;
				else
					return true;
			} catch {
				return false;
			}
		}

		private void LoadXMLQuiz(TrackDatabase db, string path)
		{
			Round r = null;
			bool inQuiz = false;
			bool inRound = false;
			bool inTrack = false;
			int missingtunes = 0;
			string name;
			string playMode;
			string text;

			XmlReader xmlReader;
			xmlReader = XmlReader.Create(path);
			mCreationTime = File.GetCreationTime(path);
			missingtunes = 0;
			while (xmlReader.Read()) {
				switch (xmlReader.NodeType) {
					case XmlNodeType.Element:
						switch (xmlReader.Name) {
							case "Quiz":
								inQuiz = true;
								name = xmlReader.GetAttribute("Name");
								if (name != null)
									Name = name;
								break;
							case "Round":
								if (inQuiz) {
									inRound = true;
									name = xmlReader.GetAttribute("Name");
									playMode = xmlReader.GetAttribute("PlayMode");

									r = new Round();
									if (name != null)
										r.Name = name;
									if (playMode != null) {
										if (IsPositiveInt(playMode))
											r.PlayMode = Convert.ToInt32(playMode);
									}
								}
								break;
							case "Track":
								if (inRound) {
									inTrack = true;
								}
								break;
						}
						break;
					case XmlNodeType.Text:
						if (inTrack) {
							text = xmlReader.Value;
							if (text != null) {
								// Check whether track is found in the database
								if (db.Tracks.Contains(text))
									r.Tracks.Add(db.GetTune(text));
								else
									missingtunes++;
							}
						}
						break;
					case XmlNodeType.EndElement:
						switch (xmlReader.Name) {
							case "Quiz":
								inQuiz = false;
								break;
							case "Round":
								if (r != null) {
									mRounds.Add(r);
									r = null;
								}
								inRound = false;
								break;
							case "Track":
								inTrack = false;
								break;
						}
						break;
				}
			}
			if (missingtunes > 0) {
				MessageBox.Show(missingtunes.ToString() + " tunes were not in database and have been removed from the quiz.", "Missing Tunes", MessageBoxButtons.OK);
			}
		}

		public void SaveXMLQuiz(string filename)
		{
			XmlWriter xmlWriter;
			XmlWriterSettings xmlSettings = new XmlWriterSettings();
			xmlSettings.Indent = true;
			xmlWriter = XmlWriter.Create(filename, xmlSettings);
			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("Quiz");
			xmlWriter.WriteAttributeString("Name", mName);
			foreach (Round round in mRounds)
				round.SaveXMLRound(xmlWriter);
			xmlWriter.WriteEndDocument();
			xmlWriter.Close();
		}

		public override string ToString()
		{
			return String.Format("Name = \"{0}\" Rounds = {1}", Name, mRounds.Count);
		}

		public string Name
		{
			get
			{
				return mName;
			}
			set
			{
				mName = value;
			}
		}

		public DateTime DateCreated
		{
			get
			{
				return mCreationTime;
			}
		}

		public RoundCollection Rounds
		{
			get
			{
				return mRounds;
			}
		}
	}
}