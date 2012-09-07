////////////////////////////////////
// Theme Tune Quiz (TTQ)          //
// Copyright (C) Ted John 2012    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Xml;

namespace IntelOrca.TTQ
{
	class Round
	{
		string mName;
		int mPlayMode;
		TrackCollection mTracks = new TrackCollection();

		public int GetMaximumScore()
		{
			int maxscore = 0;
			foreach (Track t in mTracks)
				maxscore += t.PointsAvailable;
			return maxscore;
		}

		public void SaveXMLRound(XmlWriter xmlWriter)
		{
			xmlWriter.WriteStartElement("Round");
			xmlWriter.WriteAttributeString("Name", mName);
			xmlWriter.WriteAttributeString("PlayMode", mPlayMode.ToString());
			mTracks.SaveXML(xmlWriter);
			xmlWriter.WriteEndElement();
		}

		public override string ToString()
		{
			return String.Format("Name = {0} Count = {1}", mName, mTracks.Count);
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

		public int PlayMode
		{
			get
			{
				return mPlayMode;
			}
			set
			{
				mPlayMode = value;
			}
		}

		public TrackCollection Tracks
		{
			get
			{
				return mTracks;
			}
		}
	}
}