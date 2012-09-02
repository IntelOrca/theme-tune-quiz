
namespace IntelOrca.TTQ
{
	interface ITrackPlayback
	{
		bool Playing { get; set; }
		double CurrentPosition { get; set; }
		double Length { get; }

		void Load(string path);
		void Close();
	}
}
