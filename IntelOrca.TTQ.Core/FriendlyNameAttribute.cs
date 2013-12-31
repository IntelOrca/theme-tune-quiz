using System;

namespace IntelOrca.TTQ.Core
{
	/// <summary>
	/// Represents a friendly name for a type which can contain spaces etc.
	/// </summary>
	public class FriendlyNameAttribute : Attribute
	{
		public readonly string _value;

		/// <summary>
		/// Gets the friendly name.
		/// </summary>
		public string Value { get { return _value; } }

		/// <summary>
		/// Initialises a new instance of the <see cref="FriendlyNameAttribute"/> class.
		/// </summary>
		/// <param name="value">The value.</param>
		public FriendlyNameAttribute(string value)
		{
			_value = value;
		}

		/// <summary>
		/// Gets the friendly name of a type or enum member if it defines a FriendlyNameAttribute otherwise calls ToString.
		/// </summary>
		/// <param name="input">The input object or enum value.</param>
		/// <returns>The friendly name.</returns>
		public static string GetFriendlyNameOrTypeName(object input)
		{
			FriendlyNameAttribute attribute = Util.GetAttribute<FriendlyNameAttribute>(input);
			return attribute == null ? input.ToString() : attribute.Value;
		}
	}
}
