using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace IntelOrca.TTQ
{
	partial class FastAnswerForm : Form
	{
		private TrackDatabase mDatabase;
		private TrackCollection mPlaylist;
		private Track mCurrentTrack;

		private StopWatch mSessionTime = new StopWatch();
		private StopWatch mQuestionTime = new StopWatch();
		private StopWatch mAnswerTime = new StopWatch();

		private int mNoQuestions;
		private int mCorrectAnswers;
		private int mWrongAnswers;
		private int mDunnoAnswers;

		private long mCorrectTicks;
		private long mWrongTicks;
		private long mDunnoTicks;

		private bool mFinished;

		public FastAnswerForm(TrackDatabase db, string[] genres = null)
		{
			mDatabase = db;

			// Initialise the form
			InitializeComponent();
			pnlQuestions.Visible = true;
			pnlConclusion.Visible = false;

			// Create playlist
			mPlaylist = mDatabase.Tracks.GetFromGenre(genres);
			mPlaylist.Shuffle();

			// Now sort by times played
			mPlaylist.Sort(new Track.TrackTimesPlayedComparer());

			// Start the session
			mSessionTime.Start();
			NextTrack();
		}

		private void PopulateAnswerList()
		{
			cmbAnswer.AutoCompleteCustomSource.Clear();
			foreach (Track track in mPlaylist.GetFromGenre(mCurrentTrack.Genre))
				AddPossibleAnswerToList(track);
			AddPossibleAnswerToList(mCurrentTrack);
		}

		private void AddPossibleAnswerToList(Track track)
		{
			AutoCompleteStringCollection list = cmbAnswer.AutoCompleteCustomSource;
			string simple = SimplifyTitle(track.Title);
			if (simple != track.Title)
				list.Add(simple);

			list.Add(track.Title);
		}

		private void NextTrack()
		{
			if (mPlaylist.Count > 0) {
				//Use the track at index 0
				mCurrentTrack = mPlaylist[0];
				mPlaylist.RemoveAt(0);

                // Increment times played on database
                mCurrentTrack.TimesPlayed++;
                mDatabase.Save();
			} else {
				Finish();
			}

			ttqPlayer.Track = mCurrentTrack;

			cmbAnswer.Visible = false;
			cmbAnswer.Text = String.Empty;

			lblGenre.Text = String.Format("Genre: {0}", mCurrentTrack.Genre);
			lblThemeOf.Text = String.Empty;
			lblSongName.Text = String.Empty;

			lblOutcome.Visible = false;

			btnIKnowIt.Visible = true;
			btnDunno.Visible = true;
			btnNext.Visible = false;
			btnFinish.Visible = false;

			ttqPlayer.AllowSeeking = false;
			ttqPlayer.PlayFromStart();

			btnIKnowIt.Focus();

			mNoQuestions++;

			mQuestionTime.Start();
		}

		private void ShowAnswer()
		{
			if (mCurrentTrack.IsTheme)
				lblThemeOf.Text = "Theme of " + mCurrentTrack.Title;
			else
				lblThemeOf.Text = "Tune from " + mCurrentTrack.Title;

			if (mCurrentTrack.HasSong)
				lblSongName.Text = mCurrentTrack.Song;

			btnReplay.Enabled = true;

			lblOutcome.Visible = true;

			btnIKnowIt.Visible = false;
			btnDunno.Visible = false;
			btnNext.Visible = true;
			btnFinish.Visible = true;

			cmbAnswer.Visible = false;

			ttqPlayer.AllowSeeking = true;

			double pos = ttqPlayer.CurrentPosition;

			Track t = mCurrentTrack;
			t.SkipSecs = 0;
			t.PlaySecs = 0;
			ttqPlayer.Track = t;

			ttqPlayer.CurrentPosition = pos;
			ttqPlayer.Play();
		}

		private string SimplifyTitle(string title)
		{
			//Remove 'the'
			if (title.StartsWith("the ", true, CultureInfo.CurrentCulture))
				title = title.Remove(0, 4);

			return title;
		}

		private bool IsValidAnswer(string answer)
		{
			foreach (string s in cmbAnswer.AutoCompleteCustomSource)
				if (String.Compare(s, answer, true) == 0)
					return true;

			return false;
		}

		private void btnIKnowIt_Click(object sender, EventArgs e)
		{
			if (cmbAnswer.Visible) {
				mAnswerTime.Stop();

				if (IsValidAnswer(cmbAnswer.Text)) {
					if (String.Compare(mCurrentTrack.Title, cmbAnswer.Text, true) == 0 ||
						String.Compare(SimplifyTitle(mCurrentTrack.Title), cmbAnswer.Text, true) == 0) {
						mCorrectAnswers++;
						mCorrectTicks += mQuestionTime.ElapsedTicks;
						lblOutcome.Text = "CORRECT!";
					} else {
						mWrongAnswers++;
						mWrongTicks += mQuestionTime.ElapsedTicks;
						lblOutcome.Text = "WRONG!";
					}

					ShowAnswer();
				} else {
					MessageBox.Show("Your answer does not exist!");
				}
			} else {
				mQuestionTime.Stop();

				PopulateAnswerList();

				cmbAnswer.Visible = true;
				btnReplay.Enabled = false;
				ttqPlayer.Pause();

				cmbAnswer.Focus();

				mAnswerTime.Start();
			}
		}

		private void btnDunno_Click(object sender, EventArgs e)
		{
			mDunnoAnswers++;
			mQuestionTime.Stop();
			mDunnoTicks += mQuestionTime.ElapsedTicks;
			lblOutcome.Text = "DIDN'T KNOW";

			ShowAnswer();
		}

		private void btnReplay_Click(object sender, EventArgs e)
		{
			ttqPlayer.PlayFromStart();
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			NextTrack();
		}

		private void btnFinish_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Are you sure you want to finish?", "Finish", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.Yes)
				return;

			Finish();
		}

		private void Finish()
		{
			mFinished = true;

			mSessionTime.Stop();

			long averageCorrect = 0;
			long averageWrong = 0;
			long averageDunno = 0;

			if (mCorrectAnswers != 0)
				averageCorrect = mCorrectTicks / mCorrectAnswers;

			if (mWrongAnswers != 0)
				averageWrong = mWrongTicks / mWrongAnswers;

			if (mDunnoAnswers != 0)
				averageDunno = mDunnoTicks / mDunnoAnswers;

			lblPercentage.Text = String.Format("You scored {0}%", Math.Ceiling(((float)mCorrectAnswers / (float)mNoQuestions) * 100));
			lblCorrect.Text = String.Format("Correct: {0} / {1}", mCorrectAnswers, mNoQuestions);
			lblWrong.Text = String.Format("Wrong: {0} / {1}", mWrongAnswers, mNoQuestions);
			lblDunno.Text = String.Format("Dunno: {0} / {1}", mDunnoAnswers, mNoQuestions);

			lblSessionTime.Text = String.Format("Session Time: {0}", GetTimeFormat(mSessionTime.ElapsedTicks));
			lblCorrectAverageTime.Text = String.Format("Average Time for Correct: {0}", GetTimeFormat(averageCorrect));
			lblWrongAverageTime.Text = String.Format("Average Time for Wrong: {0}", GetTimeFormat(averageWrong));
			lblDunnoAverageTime.Text = String.Format("Average Time for Dunno: {0}", GetTimeFormat(averageDunno));

			pnlQuestions.Visible = false;
			pnlConclusion.Visible = true;

			ttqPlayer.Stop();
			ttqPlayer.Close();
		}

		private string GetTimeFormat(long ticks)
		{
			TimeSpan ts = new TimeSpan(ticks);
			return String.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
		}

		private void cmbAnswer_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter && cmbAnswer.Visible)
				btnIKnowIt_Click(sender, EventArgs.Empty);
		}

		private void FastAnswerForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!mFinished) {
				e.Cancel = true;
				btnFinish_Click(sender, EventArgs.Empty);
			} else {
				ttqPlayer.Close();
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
