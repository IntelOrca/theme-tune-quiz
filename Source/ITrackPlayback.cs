////////////////////////////////////
// Theme Tune Quiz (TTQ)          //
// Copyright (C) Ted John 2012    //
// http://intelorca.co.uk         //
////////////////////////////////////

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
