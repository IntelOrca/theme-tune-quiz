using System.Threading.Tasks;
using System.Xml;

namespace IntelOrca.TTQ.Core
{
	/// <summary>
	/// Provides utility and extension methods.
	/// </summary>
	public static class Util
	{
		#region Xml Extension

		public static Task WriteStartElementAsync(this XmlWriter xmlWriter, string localName)
		{
			return xmlWriter.WriteStartElementAsync(null, localName, null);
		}

		public static Task WriteAttributeStringAsync(this XmlWriter xmlWriter, string localName, object value)
		{
			return xmlWriter.WriteAttributeStringAsync(null, localName, null, value.ToString());
		}

		public static Task WriteElementStringAsync(this XmlWriter xmlWriter, string localName, object value)
		{
			return xmlWriter.WriteElementStringAsync(null, localName, null, value.ToString());
		}		

		#endregion
	}
}
