using System;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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

		public static string GetElementStringValueOrDefault(this XElement element, string name, string defaultValue = null)
		{
			element = element.Element(name);
			return element == null ? defaultValue : element.Value;
		}

		public static int GetElementInt32ValueOrDefault(this XElement element, string name, int defaultValue = default(int))
		{
			element = element.Element(name);
			return element == null ? defaultValue : Int32.Parse(element.Value);
		}

		public static double GetElementDoubleValueOrDefault(this XElement element, string name, double defaultValue = default(double))
		{
			element = element.Element(name);
			return element == null ? defaultValue : Double.Parse(element.Value);
		}

		public static bool GetElementBooleanValueOrDefault(this XElement element, string name, bool defaultValue = default(bool))
		{
			element = element.Element(name);
			return element == null ? defaultValue : Boolean.Parse(element.Value);
		}

		#endregion
	}
}
