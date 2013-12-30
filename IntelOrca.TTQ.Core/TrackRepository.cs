using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace IntelOrca.TTQ.Core
{
	/// <summary>
	/// Represents a repository / database of tracks uniquely identified by relative filename.
	/// </summary>
	public class TrackRepository : IEnumerable<Track>
	{
		private readonly Dictionary<string, Track> _tracks = new Dictionary<string, Track>();

		/// <summary>
		/// Initialises a new instance of the <see cref="TrackRepository"/> class.
		/// </summary>
		public TrackRepository() { }

		/// <summary>
		/// Initialises a new instance of the <see cref="TrackRepository"/> class.
		/// </summary>
		/// <param name="tracks">The tracks.</param>
		public TrackRepository(IEnumerable<Track> tracks)
		{
			foreach (Track track in tracks)
				_tracks.Add(track.Filename, track);
		}

		/// <summary>
		/// Gets the track with the specified filename.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns>The track.</returns>
		public Track this[string filename]
		{
			get
			{
				Track result;
				if (_tracks.TryGetValue(filename, out result))
					return result;

				throw new TrackNotFoundException(filename);
			}
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
		/// </returns>
		public IEnumerator<Track> GetEnumerator()
		{
			return _tracks.Values.GetEnumerator();
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

		/// <summary>
		/// Writes the track repository formatted as XML to the output string.
		/// </summary>
		/// <param name="outputStream">The output stream.</param>
		/// <returns></returns>
		public async Task WriteAsync(Stream outputStream)
		{
			using (var writer = XmlWriter.Create(outputStream, new XmlWriterSettings() {
				Async = true,
				Indent = true
			})) {
				// Write track repository node
				await writer.WriteStartDocumentAsync();
				await writer.WriteStartElementAsync("repository");

				// Write track nodes
				foreach (Track track in _tracks.Values.OrderBy(x => x.Filename)) {
					await writer.WriteStartElementAsync("track");
					await writer.WriteAttributeStringAsync("filename", track.Filename);

					// Write data
					await writer.WriteElementStringAsync("genre", track.Genre);
					await writer.WriteElementStringAsync("category", track.Category);
					await writer.WriteElementStringAsync("istheme", track.IsTheme);
					await writer.WriteElementStringAsync("title", track.Title);
					await writer.WriteElementStringAsync("closeanswer", track.CloseAnswer);
					await writer.WriteElementStringAsync("song", track.Song);
					await writer.WriteElementStringAsync("tacticalstart", track.TacticalStart);
					await writer.WriteElementStringAsync("tacticalduration", track.TacticalDuration);
					await writer.WriteElementStringAsync("tracklength", track.TrackLength);
					await writer.WriteElementStringAsync("timesplayed", track.TimesPlayed);

					// End round node
					await writer.WriteEndElementAsync();
				}

				// End round node
				await writer.WriteEndElementAsync();

				// End quiz node
				await writer.WriteEndDocumentAsync();
			}
		}

		/// <summary>
		/// Reads a track repository formatted as XML.
		/// </summary>
		/// <param name="inputStream">The XML input stream.</param>
		/// <returns>A track repository.</returns>
		public static TrackRepository FromXml(Stream inputStream)
		{
			IEnumerable<Track> tracks;

			// Read track repository XML
			try {
				XDocument document = XDocument.Load(inputStream);
				XElement repositoryNode = document.Element("repository");

				tracks = repositoryNode.Descendants("track")
					.Select(trackNode => new Track() {
						Filename = trackNode.Attribute("filename").Value,
						Genre = trackNode.GetElementStringValueOrDefault("genre"),
						Category = trackNode.GetElementStringValueOrDefault("category"),
						IsTheme = trackNode.GetElementBooleanValueOrDefault("theme"),
						Title = trackNode.GetElementStringValueOrDefault("title"),
						CloseAnswer = trackNode.GetElementStringValueOrDefault("closeanswer"),
						Song = trackNode.GetElementStringValueOrDefault("song"),
						TacticalStart = trackNode.GetElementDoubleValueOrDefault("tacticalstart"),
						TacticalDuration = trackNode.GetElementDoubleValueOrDefault("tacticalduration"),
						TrackLength = trackNode.GetElementInt32ValueOrDefault("tracklength"),
						TimesPlayed = trackNode.GetElementInt32ValueOrDefault("timesplayed"),
					})
					.ToArray();
			} catch (Exception ex) {
				throw new XmlException("Unable to read track repository.", ex);
			}

			// Create the track repository
			return new TrackRepository(tracks);
		}
	}
}
