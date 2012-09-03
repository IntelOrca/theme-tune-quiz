using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace IntelOrca.TTQ
{
	partial class QuizForm : Form
	{
		Quiz mQuiz;
		bool mShowingAnswers;
		double mSkipsecs, mPlaysecs;

		bool mAutomated = true;

		public QuizForm(Quiz quiz)
		{
			InitializeComponent();

			mQuiz = quiz;

			// Show quiz name in title bar
			this.Text = "Theme Tune Quiz - " + mQuiz.Name;
			//this.WindowState = FormWindowState.Maximized;
			
			cmbPlayMode.Items.Add("Normal");
			cmbPlayMode.Items.Add("Full");
			cmbPlayMode.Items.Add("Fast (20 secs)");
			cmbPlayMode.Items.Add("SuperFast (5 secs)");
			cmbPlayMode.Items.Add("UltraFast (2 secs)");
			cmbPlayMode.SelectedIndex = 0;

			// Set number of Rounds and start with Round 1
			spnRound.Maximum = mQuiz.Rounds.Count;
			spnRound.Minimum = 1;
			spnRound.Value = 1;

			mShowingAnswers = false;
			lblAnswer.Visible = false;
			lblClose.Visible = false;
			lblSong.Visible = false;
			lblAnswerPoints.Visible = false;
			lblClosePoints.Visible = false;
			lblSongPoints.Visible = false;
			lblAnswerPointsDesc.Visible = true;
			lblClosePointsDesc.Visible = true;
			lblSongPointsDesc.Visible = true;

			RefreshForRound();

			// Automation
			mAutomated = true;
			chkAutomated.Checked = mAutomated;
			//if (automated)
			//	Announcer.PlaySound("intro");
		}

		private void PlayForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ttqPlayer.Close();
		}

		private void RefreshPlayingTime()
		{
			// Refresh Time
			int elapsedTime = (int)(ttqPlayer.CurrentPosition - mSkipsecs);
			string time = TimeFormat(elapsedTime);
			if (time == null || time.Length == 0)
				time = "00:00";
			if (lblTime.Text != time)
				lblTime.Text = time;
		}

		private string TimeFormat(int secs)
		{
			int mins = secs / 60;
			secs = secs % 60;
			return String.Format("{0:D2}:{1:D2}", mins, secs);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			if (spnTrack.Value == spnTrack.Maximum) {
				// switch to next round
				if (spnRound.Value == spnRound.Maximum) {
					// Display 'End of Quiz'
					Announcer.PlaySound("quiz_has_finished");
					//automated = false;
				} else {
					spnRound.Value += 1;
					spnTrack.Value = 1;

					if (mAutomated) {
						Announcer.PlaySound("next_round");
						starting = true;
						countdownToNextTrack = 10;
					}
				}
			} else {
				spnTrack.Value += 1;
				btnPlay_Click(sender, e);
			}
		}

		private void btnPlay_Click(object sender, EventArgs e)
		{
			if (spnRound.Value <= 0)
				return;
			if (spnTrack.Value <= 0)
				return;

			Round round = mQuiz.Rounds[Convert.ToInt32(spnRound.Value) - 1];
			Track track = round.Tracks[Convert.ToInt32(spnTrack.Value) - 1];
			mSkipsecs = track.SkipSecs;
			switch (cmbPlayMode.SelectedIndex) {
				case 0:  // Normal
					if (track.PlaySecs == 0)
						mPlaysecs = 9999;
					else
						mPlaysecs = track.PlaySecs;
					break;
				case 1: // Full
					mSkipsecs = 0;
					mPlaysecs = 9999;
					break;
				case 2: // Fast
					mPlaysecs = track.PlaySecs;
					if (mPlaysecs > 20 || mPlaysecs == 0)
						mPlaysecs = 20;
					break;
				case 3: // Super
					mPlaysecs = track.PlaySecs;
					if (mPlaysecs > 5 || mPlaysecs == 0)
						mPlaysecs = 5;
					break;
				case 4: // Ultra
					mPlaysecs = track.PlaySecs;
					if (mPlaysecs > 2 || mPlaysecs == 0)
						mPlaysecs = 2;
					break;
			}

			track.SkipSecs = mSkipsecs;
			track.PlaySecs = mPlaysecs;
			ttqPlayer.Track = track;

			if (mAutomated) {
				if (!mShowingAnswers) {
					if (track.HasCloseAnswer)
						Announcer.PlaySound("track_has_close");
					if (track.HasSong)
						Announcer.PlaySound("track_has_song");
				}

				Announcer.PlaySound(Announcer.GetNumber((int)spnTrack.Value));
			}

			countdownToNextTrack = 10;

			ttqPlayer.CurrentPosition = mSkipsecs;
			ttqPlayer.Play();
		}

		private void btnPrint_Click(object sender, EventArgs e)
		{
			//Generate HTML
			AnswerSheet sheet = new AnswerSheet(mQuiz);
			sheet.GenerateHTML(sheet.SheetPath + "PrintOut.htm", mShowingAnswers);
			Process.Start(sheet.SheetPath + "PrintOut.htm");
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			ttqPlayer.Stop();
		}

		private void spnRound_ValueChanged(object sender, EventArgs e)
		{
			RefreshForRound();
		}

		private void spnTrack_ValueChanged(object sender, EventArgs e)
		{
			RefreshForTrack();
		}

		private void tmrMusicCheck_Tick(object sender, EventArgs e)
		{
			RefreshPlayingTime();
		}

		public bool ShowAnswers
		{
			get
			{
				return mShowingAnswers;
			}
			set
			{
				mShowingAnswers = value;
				lblAnswer.Visible = value;
				lblClose.Visible = value;
				lblSong.Visible = value;
				lblAnswerPoints.Visible = value;
				lblClosePoints.Visible = value;
				lblSongPoints.Visible = value;

				mAutomated = !value;
				lblAnswerPointsDesc.Visible = !value;
				lblClosePointsDesc.Visible = !value;
				lblSongPointsDesc.Visible = !value;

				chkAutomated.Checked = mAutomated;
			}
		}

		public bool Automated
		{
			get
			{
				return mAutomated;
			}
			set
			{
				mAutomated = value;
				chkAutomated.Checked = mAutomated;
			}
		}

		private int countdownToNextTrack = 5;
		private bool starting = true;

		private void tmrSecond_Tick(object sender, EventArgs e)
		{
			if (!mAutomated)
				return;

			if (ttqPlayer.Status != TTQPlayerStatus.Stopped)
				return;

			countdownToNextTrack--;
			if (countdownToNextTrack == 0) {
				if (starting) {
					starting = false;
					btnPlay_Click(this, EventArgs.Empty);
				} else {
					btnNext_Click(this, EventArgs.Empty);
				}
			}
		}

		private void chkAutomated_CheckedChanged(object sender, EventArgs e)
		{
			mAutomated = chkAutomated.Checked;
		}

		private void RefreshForRound()
		{
			Round round = mQuiz.Rounds[Convert.ToInt32(spnRound.Value) - 1];
			RefreshForRound(round);
		}

		private void RefreshForRound(Round round)
		{
			// Set Round Name & Play Mode
			lblRoundName.Text = round.Name;
			cmbPlayMode.SelectedIndex = round.PlayMode;

			//Set Number of Tracks and start with Track 1
			spnTrack.Maximum = round.Tracks.Count;
			spnTrack.Minimum = 1;
			spnTrack.Value = 1;

			RefreshForTrack();
		}

		private void RefreshForTrack()
		{
			// Get round and track
			Round round = mQuiz.Rounds[Convert.ToInt32(spnRound.Value) - 1];
			Track track = round.Tracks[Convert.ToInt32(spnTrack.Value) - 1];

			// Refresh form for track
			RefreshForTrack(track);
		}

		private void RefreshForTrack(Track track)
		{
			// Stop Media Player
			ttqPlayer.Stop();

			lblAnswer.Text = track.Title;
			lblClose.Text = track.CloseAnswer;
			lblSong.Text = track.Song;

			// Show whether there is a close answer or Song title for the song
			if (!track.HasCloseAnswer)
				lblClosePointsDesc.Visible = false;
			else if (lblAnswerPointsDesc.Visible == true)
				lblClosePointsDesc.Visible = true;
			if (!track.HasSong)
				lblSongPointsDesc.Visible = false;
			else if (lblAnswerPointsDesc.Visible == true)
				lblSongPointsDesc.Visible = true;
		}

		private void cmbPlayMode_SelectedIndexChanged(object sender, EventArgs e)
		{
			btnPlay_Click(sender, e);
		}
	}
}