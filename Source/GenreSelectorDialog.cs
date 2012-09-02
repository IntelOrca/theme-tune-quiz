using System;
using System.Drawing;
using System.Windows.Forms;

namespace IntelOrca.TTQ
{
	class GenreSelectorDialog
	{
		private TrackDatabase mDatabase;
		private Form mForm;
		private CheckedListBox mGenreCheckList;
		private Button mOKButton;
		private string[] mGenres;
		private string[] mSelectedGenres;

		public GenreSelectorDialog(TrackDatabase db)
		{
			mDatabase = db;
			mGenres = mDatabase.GetGenres();
			mSelectedGenres = new string[0];

			mForm = new Form();
			mForm.SuspendLayout();

			mForm.Text = "Genre Selection";
			mForm.MinimizeBox = false;
			mForm.MaximizeBox = false;
			mForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			mForm.StartPosition = FormStartPosition.CenterScreen;
			mForm.Size = new Size(200, 250);

			mGenreCheckList = new CheckedListBox();
			mGenreCheckList.CheckOnClick = true;
			mGenreCheckList.IntegralHeight = false;
			mGenreCheckList.Location = new Point(3, 3);
			mGenreCheckList.Size = new Size(mForm.ClientSize.Width - 6, mForm.ClientSize.Height - 32);
			mGenreCheckList.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

			foreach (string genre in mGenres)
				mGenreCheckList.Items.Add(String.Format("{0} ({1})", genre, mDatabase.GetGenreTrackCount(genre)), true);

			mForm.Controls.Add(mGenreCheckList);

			mOKButton = new Button();
			//mOKButton.DialogResult = DialogResult.OK;
			mOKButton.Text = "OK";
			mOKButton.Location = new Point(mForm.ClientSize.Width - 78, mForm.ClientSize.Height - 26);
			mOKButton.Size = new Size(75, 23);
			mOKButton.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			mOKButton.Click += new EventHandler(mOKButton_Click);
			mForm.Controls.Add(mOKButton);

			mForm.AcceptButton = mOKButton;

			mForm.ResumeLayout();
		}

		void mOKButton_Click(object sender, EventArgs e)
		{
			if (mGenreCheckList.CheckedItems.Count == 0)
				return;

			mForm.DialogResult = DialogResult.OK;
			mForm.Close();
		}

		public DialogResult ShowDialog()
		{
			DialogResult result = mForm.ShowDialog();
			if (result == DialogResult.OK) {
				mSelectedGenres = new string[mGenreCheckList.CheckedItems.Count];
				for (int i = 0; i < mSelectedGenres.Length; i++)
					mSelectedGenres[i] = mGenres[mGenreCheckList.CheckedIndices[i]];
			}

			return result;
		}

		public string[] SelectedGenres
		{
			get
			{
				return mSelectedGenres;
			}
			set
			{
				mSelectedGenres = value;
			}
		}
	}
}
