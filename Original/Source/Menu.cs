////////////////////////////////////
// Theme Tune Quiz (TTQ)          //
// Copyright (C) Ted John 2012    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.IO;
using System.Windows.Forms;

namespace IntelOrca.TTQ
{
	partial class Menu : Form
	{
		TrackDatabase mDatabase;
		string mLastQuizFilename = "";

		public Menu()
		{
			InitializeComponent();

			mDatabase = new TrackDatabase();
			mDatabase.Open();
		}

		private void btnNewQuiz_Click(object sender, EventArgs e)
		{
			Hide();
			using (SetupForm form = new SetupForm(mDatabase))
				if (form.ShowDialog() == DialogResult.OK)
					mLastQuizFilename = form.Filename;
			Show();
		}

		private void btnPlayQuiz_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			//Restore last filename
			if (mLastQuizFilename.Length > 0) {
				dialog.InitialDirectory = Path.GetDirectoryName(mLastQuizFilename);
				dialog.FileName = Path.GetFileName(mLastQuizFilename);
			}

			dialog.Filter = "Quiz Files (*.ttq)|*.ttq";
			if (dialog.ShowDialog() == DialogResult.OK) {
				mLastQuizFilename = dialog.FileName;

				Hide();
				Quiz quiz = new Quiz(mDatabase, dialog.FileName);
				using (QuizForm form = new QuizForm(quiz))
					form.ShowDialog();
				Show();
			}
		}

		private void btnAnswerQuiz_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			//Restore last filename
			if (mLastQuizFilename.Length > 0) {
				dialog.InitialDirectory = Path.GetDirectoryName(mLastQuizFilename);
				dialog.FileName = Path.GetFileName(mLastQuizFilename);
			}

			dialog.Filter = "Quiz Files (*.ttq)|*.ttq";
			if (dialog.ShowDialog() == DialogResult.OK) {
				mLastQuizFilename = dialog.FileName;

				Hide();
				Quiz quiz = new Quiz(mDatabase, dialog.FileName);
				using (QuizForm form = new QuizForm(quiz)) {
					form.ShowAnswers = true;
					form.ShowDialog();
				}
				Show();
			}
		}

		private void btnFastAnswer_Click(object sender, EventArgs e)
		{
			Hide();
			GenreSelectorDialog gsdialog = new GenreSelectorDialog(mDatabase);
			if (gsdialog.ShowDialog() == DialogResult.OK) {
				using (FastAnswerForm form = new FastAnswerForm(mDatabase, gsdialog.SelectedGenres))
					form.ShowDialog();
			}
			Show();
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			Hide();
			using (EditForm form = new EditForm(mDatabase))
				form.ShowDialog();
			Show();
		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}