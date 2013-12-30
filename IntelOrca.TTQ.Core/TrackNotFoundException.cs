using System;

namespace IntelOrca.TTQ.Core
{
	public class TrackNotFoundException : Exception
	{
		private readonly string _filename;

		/// <summary>
		/// Gets the filename of the track not found.
		/// </summary>
		public string Filename { get { return _filename; } }

		/// <summary>
		/// Initialises a new instance of the <see cref="TrackNotFoundException"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		public TrackNotFoundException(string filename) : base("Track not found. " + filename)
		{
			_filename = filename;
		}
	}
}
