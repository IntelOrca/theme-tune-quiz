////////////////////////////////////
// Theme Tune Quiz (TTQ)          //
// Copyright (C) Ted John 2012    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IntelOrca.TTQ
{
	partial class SetupForm : Form
	{
		TrackDatabase mDatabase;

		string mFilename;
		string[] mGenres;
		int[] mGenreTrackCount;
		
		public SetupForm(TrackDatabase db)
		{
			mDatabase = db;

			InitializeComponent();
			PopulateLists();
			SetTotalTracks();
		}

		private void PopulateLists()
		{
			// Count Genres and Tracks
			mGenres = mDatabase.GetCategories();
			mGenreTrackCount = new int[mGenres.Length];
			for (int i = 0; i < mGenres.Length; i++)
				mGenreTrackCount[i] = mDatabase.GetCategoryTrackCount(mGenres[i]);

			// Populate lists
			for (int i = 0; i < 5; i++) {
				// Genres
				CheckedListBox clbox = (CheckedListBox)Controls["chkRound" + i];
				for (int j = 0; j < mGenres.Length; j++)
					clbox.Items.Add(String.Format("{0} ({1})", mGenres[j], mGenreTrackCount[j]));

				// Playing times
				ComboBox box = (ComboBox)Controls["cmbMode" + i];
				box.Items.Add("Normal");
				box.Items.Add("Full");
				box.Items.Add("Fast (20 secs)");
				box.Items.Add("SuperFast (5 secs)");
				box.Items.Add("UltraFast (2 secs)");
				box.SelectedIndex = 0;

				// Number of tracks (max)
				SetSpinControlMax();

			}
		}

		private void SetSpinControlMax()
		{
			// Set spincontrol maxima to sum of tracks for checked genres
		}

		private Quiz GenerateTTQ()
		{
			Quiz quiz = new Quiz();
			quiz.Name = txtQuizName.Text;

			HashSet<Track> alltracks = new HashSet<Track>();

			for (int i = 0; i < 5; i++) {
				NumericUpDown nud = (NumericUpDown)(Controls["spnTracks" + i]);
				if (nud.Value > 0) {
					//Create a new round instance
					Round r = new Round();
					TextBox namebox = (TextBox)Controls["txtRoundName" + i];
					r.Name = namebox.Text;
					r.PlayMode = ((ComboBox)Controls["cmbMode" + i]).SelectedIndex;

					//Call make songs or something using rounds.ToArray
					List<string> genres = new List<string>();
					CheckedListBox clbox = (CheckedListBox)Controls["chkRound" + i];
					foreach (int j in clbox.CheckedIndices)
						genres.Add(mGenres[j]);

					r.Tracks.AddRandomTracks(mDatabase, alltracks, genres.ToArray(), Convert.ToInt32(nud.Value), ((CheckBox)Controls["chkTheme" + i]).Checked);

					foreach (Track t in r.Tracks)
						alltracks.Add(t);
					
					//Add this new round to list
					quiz.Rounds.Add(r);
				}
			}

            // Increment times played for each song and save database
            foreach (Track t in alltracks)
                t.TimesPlayed++;
            mDatabase.Save();

			return quiz;
		}

		private void SetTotalTracks()
		{
			int totalTracks = 0;
			for (int i = 0; i < 5; i++) {
				NumericUpDown nup = (NumericUpDown)Controls["spnTracks" + i];
				totalTracks += (int)nup.Value;
			}
			txtTotalTracks.Text = totalTracks.ToString();
		}

		private int GetGenreTrackCount(string genre)
		{
			for (int i = 0; i < mGenres.Length; i++)
				if (String.Compare(mGenres[i], genre, true) == 0)
					return mGenreTrackCount[i];
			return 0;
		}

		private void chkRound_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			CheckedListBox clbox = (CheckedListBox)sender;
			int index = Convert.ToInt32(clbox.Name.Substring(clbox.Name.Length - 1, 1));
			int tracks = 0;
			if (e.NewValue == CheckState.Checked)
				tracks += GetGenreTrackCount(mGenres[e.Index]);

			foreach (int i in clbox.CheckedIndices) {
				if (e.NewValue != CheckState.Checked)
					if (e.Index == i)
						continue;
				tracks += GetGenreTrackCount(mGenres[i]);
			}

			NumericUpDown nup = (NumericUpDown)Controls["spnTracks" + index];
			nup.Maximum = tracks;
			SetTotalTracks();
		}

		private void spnTracks_ValueChanged(object sender, EventArgs e)
		{
			SetTotalTracks();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (txtTotalTracks.Text != "0") {
				SaveFileDialog dialog = new SaveFileDialog();
				dialog.Filter = "Quiz Files (*.ttq)|*.ttq";
				dialog.FileName = String.Format("{0}.ttq", txtQuizName.Text);
				if (dialog.ShowDialog() == DialogResult.OK) {
					mFilename = dialog.FileName;
					GenerateTTQ().SaveXMLQuiz(dialog.FileName);
					DialogResult = DialogResult.OK;
					Close();
				}
			}
		}

		public string Filename
		{
			get
			{
				return mFilename;
			}
		}
	}
}