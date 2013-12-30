using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace IntelOrca.TTQ.Core
{
	/// <summary>
	/// Represents a quiz containing tracks grouped into rounds.
	/// </summary>
	public class Quiz
	{
		private readonly string _name;
		private readonly DateTime _creationTime;
		private readonly IReadOnlyList<Round> _rounds;

		/// <summary>
		/// Initialises a new instance of the <see cref="Quiz"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="creationDate">The creation date.</param>
		/// <param name="rounds">The rounds.</param>
		public Quiz(string name, DateTime creationDate, IEnumerable<Round> rounds)
		{
			_name = name;
			_creationTime = creationDate;
			_rounds = rounds.ToArray();
		}

		/// <summary>
		/// Writes the quiz formatted as XML to the output string.
		/// </summary>
		/// <param name="outputStream">The output stream.</param>
		/// <returns></returns>
		public async Task WriteAsync(Stream outputStream)
		{
			using (var writer = XmlWriter.Create(outputStream, new XmlWriterSettings() {
				Async = true,
				Indent = true
			})) {
				// Write quiz node
				await writer.WriteStartDocumentAsync();
				await writer.WriteStartElementAsync("quiz");
				await writer.WriteAttributeStringAsync("name", _name);

				// Write round nodes
				foreach (Round round in _rounds) {
					await writer.WriteStartElementAsync("round");
					await writer.WriteAttributeStringAsync("name", round.Name);
					await writer.WriteAttributeStringAsync("playmode", (int)round.PlayMode);

					// Write track nodes
					foreach (Track track in round)
						await writer.WriteElementStringAsync("track", track.Filename);

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
		/// Reads a quiz formatted as XML.
		/// </summary>
		/// <param name="trackRepository">The track repository.</param>
		/// <param name="xml">The XML.</param>
		/// <returns>A quiz.</returns>
		public Quiz FromXml(TrackRepository trackRepository, string xml)
		{
			string quizName = null;
			DateTime creationDate = DateTime.UtcNow;
			IEnumerable<Round> rounds;

			// Read quiz XML
			try {
				XDocument document = XDocument.Parse(xml);
				XElement quizNode = document.Element("quiz");

				XAttribute nameAttribute = quizNode.Attribute("name");
				if (nameAttribute != null)
					quizName = nameAttribute.Value;

				rounds = quizNode.Descendants("round")
					.Select(roundNode => new Round(
						roundNode.Attribute("name").Value,
						(PlayMode)Int32.Parse(roundNode.Attribute("playmode").Value),
						roundNode.Descendants("track")
							.Select(trackNode => trackRepository[trackNode.Value])
					));
			} catch (TrackNotFoundException ex) {
				throw new XmlException("Quiz contains a track not present in the track repository. " + ex.Filename);
			} catch (Exception ex) {
				throw new XmlException("Unable to read quiz.", ex);
			}

			// Create the quiz
			return new Quiz(quizName, creationDate, rounds);
		}
	}
}
