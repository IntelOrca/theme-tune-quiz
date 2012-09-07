////////////////////////////////////
// Theme Tune Quiz (TTQ)          //
// Copyright (C) Ted John 2012    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;

namespace IntelOrca.TTQ
{
	class Track
	{
		private string mFilename;
		private string mGenre;
		private bool mIsTheme;
		private string mTitle;
		private string mCloseAnswer;
		private string mSong;
		private double mSkipSecs;
		private double mPlaySecs;
		private int mTrackLength;
        private int mTimesPlayed;

		public override int GetHashCode()
		{
			return mFilename.GetHashCode();
		}

		public override string ToString()
		{
			return String.Format("{0}, {1}", mTitle, mGenre);
		}

		public bool HasCloseAnswer
		{
			get
			{
				return !String.IsNullOrEmpty(mCloseAnswer);
			}
		}

		public bool HasSong
		{
			get
			{
				return !String.IsNullOrEmpty(mSong);
			}
		}

		public int PointsAvailable
		{
			get
			{
				return (HasSong ? 3 : 2);
			}
		}

		public string Filename
		{
			get
			{
				return mFilename;
			}
			set
			{
				mFilename = value;
			}
		}

		public string Genre
		{
			get
			{
				return mGenre;
			}
			set
			{
				mGenre = value;
			}
		}

		public bool IsTheme
		{
			get
			{
				return mIsTheme;
			}
			set
			{
				mIsTheme = value;
			}
		}

		public string Title
		{
			get
			{
				return mTitle;
			}
			set
			{
				mTitle = value;
			}
		}

		public string CloseAnswer
		{
			get
			{
				return mCloseAnswer;
			}
			set
			{
				mCloseAnswer = value;
			}
		}

		public string Song
		{
			get
			{
				return mSong;
			}
			set
			{
				mSong = value;
			}
		}

		public double SkipSecs
		{
			get
			{
				return mSkipSecs;
			}
			set
			{
				mSkipSecs = value;
			}
		}

		public double PlaySecs
		{
			get
			{
				return mPlaySecs;
			}
			set
			{
				mPlaySecs = value;
			}
		}

		public int TrackLength
		{
			get
			{
				return mTrackLength;
			}
			set
			{
				mTrackLength = value;
			}
		}

        public int TimesPlayed
        {
            get
            {
                return mTimesPlayed;
            }
            set
            {
                mTimesPlayed = value;
            }
        }

		public class TrackTitleComparer : IComparer<Track>, IComparer
		{
			public int Compare(Track x, Track y)
			{
				return x.Title.CompareTo(y.Title);
			}

			public int Compare(object x, object y)
			{
				if (x == null || y == null)
					throw new ArgumentNullException();
				return Compare((Track)x, (Track)y);
			}
		}

        public class TrackTimesPlayedComparer : IComparer<Track>, IComparer
        {
            public int Compare(Track x, Track y)
            {
                return x.TimesPlayed.CompareTo(y.TimesPlayed);
            }

            public int Compare(object x, object y)
            {
                if (x == null || y == null)
                    throw new ArgumentNullException();
                return Compare((Track)x, (Track)y);
            }
        }
	}
}