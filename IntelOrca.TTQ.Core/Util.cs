using System;
using System.Linq;
using System.Reflection;
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
		#region Attributes

		/// <summary>
		/// Gets an attribute from the given type or enum member.
		/// </summary>
		/// <typeparam name="T">The <see cref="Attribute"/> type.</typeparam>
		/// <param name="value">The type or enum member.</param>
		/// <returns>The attribute or null if there is no defined attribute.</returns>
		public static T GetAttribute<T>(object value) where T : Attribute
		{
			// Get type
			Type type = value as Type;
			if (type == null) {
				// Expecting an enum type
				type = value.GetType();
				if (!type.GetTypeInfo().IsEnum)
					throw new ArgumentException("Value must be a Type or Enum value.", "value");

				return type.GetTypeInfo().DeclaredMembers.First(x => x.Name == value.ToString()).GetCustomAttribute<T>();
			} else {
				return type.GetTypeInfo().GetCustomAttribute<T>();
			}
		}

		#endregion

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
