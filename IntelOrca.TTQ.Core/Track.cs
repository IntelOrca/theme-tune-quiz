using System;

namespace IntelOrca.TTQ.Core
{
	/// <summary>
	/// Represents a single track and all its metadata.
	/// </summary>
    public class Track : IEquatable<Track>
    {
		public string Filename { get; set; }
		public string Genre { get; set; }
		public string Category { get; set; }
		public bool IsTheme { get; set; }
		public string Title { get; set; }
		public string CloseAnswer { get; set; }
		public string Song { get; set; }
		public double TacticalStart { get; set; }
		public double TacticalDuration { get; set; }
		public int TrackLength { get; set; }
		public int TimesPlayed { get; set; }

		public bool HasCloseAnswer { get { return !String.IsNullOrEmpty(CloseAnswer); } }

		public bool HasSong { get { return !String.IsNullOrEmpty(Song); } }

		public int TotalScore { get { return HasSong ? 3 : 2; } }

		/// <summary>
		/// Determines whether the specified <see cref="System.Object" }, is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
		/// <returns>
		///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			return Equals((Track)obj);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
		/// </returns>
		public bool Equals(Track other)
		{
			return Filename == other.Filename;
		}

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode()
		{
			return Filename.GetHashCode();
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return String.Format("{0}, {1}", Title, Genre);
		}
	}
}
