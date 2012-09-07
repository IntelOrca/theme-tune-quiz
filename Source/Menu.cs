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
			SetupForm form = new SetupForm(mDatabase);
			Hide();
			if (form.ShowDialog() == DialogResult.OK) {
				mLastQuizFilename = form.Filename;
			}
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

				Quiz quiz = new Quiz(mDatabase, dialog.FileName);
				QuizForm form = new QuizForm(quiz);
				Hide();
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

				Quiz quiz = new Quiz(mDatabase, dialog.FileName);
				QuizForm form = new QuizForm(quiz);
				form.ShowAnswers = true;

				Hide();
				form.ShowDialog();
				Show();
			}
		}

		private void btnFastAnswer_Click(object sender, EventArgs e)
		{
			GenreSelectorDialog gsdialog = new GenreSelectorDialog(mDatabase);
			if (gsdialog.ShowDialog() == DialogResult.OK) {
				FastAnswerForm form = new FastAnswerForm(mDatabase, gsdialog.SelectedGenres);
				Hide();
				form.ShowDialog();
				Show();
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			EditForm form = new EditForm(mDatabase);
			Hide();
			form.ShowDialog();
			Show();
		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}