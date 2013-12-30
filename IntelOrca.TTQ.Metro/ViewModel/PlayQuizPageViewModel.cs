using IntelOrca.TTQ.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelOrca.TTQ.Metro.ViewModel
{
	public class PlayQuizPageViewModel : ViewModel
	{
		public string QuizName { get; set; }

		public int[] Rounds { get; set; }
		public int[] Tracks { get; set; }
		public string CurrentRoundName { get; set; }

		public bool HasCloseAnswer { get; set; }
		public bool HasSong { get; set; }
	}
}
