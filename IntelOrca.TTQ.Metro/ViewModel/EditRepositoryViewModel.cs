using IntelOrca.TTQ.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelOrca.TTQ.Metro.ViewModel
{
	public class EditRepositoryViewModel : ViewModel
	{
		private Track _selectedTrack;

		public IReadOnlyList<Track> Tracks { get; set; }
		public Track SelectedTrack
		{
			get { return _selectedTrack; }
			set
			{
				_selectedTrack = value;
				RaisePropertyChangedEvent("SelectedTrack");
			}
		}
	}
}
