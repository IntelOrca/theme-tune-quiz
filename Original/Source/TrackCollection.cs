////////////////////////////////////
// Theme Tune Quiz (TTQ)          //
// Copyright (C) Ted John 2012    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace IntelOrca.TTQ
{
	class TrackCollection : CollectionBase
	{
		public void AddRandomTracks(TrackDatabase database, HashSet<Track> ignoreTracks, string[] categories, int tracks, bool themesonly)
		{
			//Create a random generator
			Random random = new Random();

			// Create list of tracks for selection (ignoring tracks in previous playlists)
			TrackCollection picklist = new TrackCollection();
			foreach (Track track in database.Tracks) {
			 	foreach (string s in categories) {
					// Category in Round and track not already used
					if (String.Compare(track.Category, s, true) == 0 && !ignoreTracks.Contains(track)) {
						// Check whether only themes to be chosen
						if (track.IsTheme || !themesonly) {
							//Add to pick list
							picklist.Add(track);
						}
					}
				}
			}

            // Shuffle the order first
            picklist.Shuffle();

            // Now sort by times played
            picklist.Sort(new Track.TrackTimesPlayedComparer());

            // Pick random tracks
			for (int i = 0; i < tracks; i++) {
				//Check if the list has any tunes
				if (picklist.Count == 0)
					break;

				//Pick a random track from the selection list
				int ri = random.Next(0, picklist.Count);

				//Save in playlist
				Add(picklist[ri]);

				//Remove track from selection list
				picklist.RemoveAt(ri);
			}
		}

		public void Add(Track track)
		{
			this.List.Add(track);
		}

		public void AddRange(TrackCollection tracks)
		{
			this.InnerList.AddRange(tracks);
		}

		public void AddRange(Track[] tracks)
		{
			this.InnerList.AddRange(tracks);
		}

		public void Remove(Track track)
		{
			this.List.Remove(track);
		}

		public bool Contains(string filename)
		{
			return (GetFromFilename(filename) != null);
		}

		public Track GetFromName(string name)
		{
			foreach (Track t in this) {
				if (t.Title == name)
					return t;
			}

			return null;
		}

		public Track GetFromFilename(string filename)
		{
			foreach (Track t in this)
				if (t.Filename.Equals(filename))
					return t;
			return null;
		}

		public TrackCollection GetFromCategory(string category)
		{
			return GetFromCategory(new string[] { category });
		}

		public TrackCollection GetFromCategory(string[] categories)
		{
			TrackCollection newtc = new TrackCollection();
			foreach (Track t in this)
				foreach (string g in categories)
					if (String.Compare(t.Category, g, true) == 0)
						newtc.Add(t);
			return newtc;
		}

		public void Shuffle()
		{
			Random random = new Random();
			for (int i = 0; i < Count; i++) {
				int swapIndex = random.Next(0, Count);
				Track swapStore = this[i];
				this[i] = this[swapIndex];
				this[swapIndex] = swapStore;
			}
		}

		public void Sort(IComparer comparer)
		{
			this.InnerList.Sort(comparer);
		}

		public void SaveXML(XmlWriter xmlWriter)
		{
			foreach (Track t in this) {
				xmlWriter.WriteStartElement("Track");
				xmlWriter.WriteValue(t.Filename);
				xmlWriter.WriteEndElement();
			}
		}

		public Track this[int index]
		{
			get
			{
				return (Track)this.List[index];
			}
			set
			{
				this.List[index] = value;
			}
		}
	}
}