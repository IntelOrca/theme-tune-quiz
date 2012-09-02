using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TTQ
{
	public partial class TestPlayer : Form
	{
		TuneDatabase tuneDB = new TuneDatabase();

		public TestPlayer()
		{
			InitializeComponent();

			tuneDB.Open();
			Tune tune = tuneDB.GetTune("Star Trek 2009.mp3");

			ttqPlayer1.Tune = tune;

			ttqPlayer1.PlayFromStart();
		}
	}
}
