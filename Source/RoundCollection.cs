////////////////////////////////////
// Theme Tune Quiz (TTQ)          //
// Copyright (C) Ted John 2012    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System.Collections;

namespace IntelOrca.TTQ
{
	class RoundCollection : CollectionBase
	{
		public void Add(Round round)
		{
			this.List.Add(round);
		}

		public Round this[int index]
		{
			get
			{
				return this.List[index] as Round;
			}
			set
			{
				this.List[index] = value;
			}
		}
	}
}
