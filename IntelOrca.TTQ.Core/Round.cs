using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IntelOrca.TTQ.Core
{
	/// <summary>
	/// Represents a round in a quiz.
	/// </summary>
	public class Round : IEnumerable<Track>
	{
		private readonly string _name;
		private readonly PlayMode _playMode;
		private readonly IReadOnlyList<Track> _tracks;

		/// <summary>
		/// Gets the name.
		/// </summary>
		public string Name { get { return _name; } }

		/// <summary>
		/// Gets the play mode.
		/// </summary>
		public PlayMode PlayMode { get { return _playMode; } }

		/// <summary>
		/// Gets the tracks.
		/// </summary>
		public IReadOnlyList<Track> Tracks { get { return _tracks; } }

		/// <summary>
		/// Initialises a new instance of the <see cref="Round"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="playMode">The play mode.</param>
		/// <param name="tracks">The tracks.</param>
		public Round(string name, PlayMode playMode, IEnumerable<Track> tracks)
		{
			_name = name;
			_playMode = playMode;
			_tracks = tracks.ToArray();
		}

		/// <summary>
		/// Calculates the total possible score in the round.
		/// </summary>
		/// <returns></returns>
		public int CalculateTotalScore()
		{
			return _tracks.Sum(x => x.TotalScore);
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return String.Format("Name = {0} Count = {1}", _name, _tracks.Count);
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator<Track> GetEnumerator()
		{
			return _tracks.GetEnumerator();
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
		/// </returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
