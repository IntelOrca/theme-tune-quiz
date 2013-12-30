
namespace IntelOrca.TTQ.Core
{
	/// <summary>
	/// Represents the section and length of a track to play.
	/// </summary>
	public enum PlayMode
	{
		Full = -1,
		Normal = 0,

		[FriendlyName("Fast (20 secs)")]
		Fast = 20,

		[FriendlyName("SuperFast (5 secs)")]
		SuperFast = 5,

		[FriendlyName("UltraFast (2 secs)")]
		UltraFast = 2,
	}
}
