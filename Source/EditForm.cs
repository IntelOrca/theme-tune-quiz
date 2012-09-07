////////////////////////////////////
// Theme Tune Quiz (TTQ)          //
// Copyright (C) Ted John 2012    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace IntelOrca.TTQ
{
	partial class EditForm : Form
	{
		int mRowPlayingSong = -1;
		double mSkipsecs, mPlaysecs, mTrackLength;
		TrackDatabase mDatabase;
		Track mCurrentTrack;

		private bool mNoSearch = true;

		public EditForm(TrackDatabase db)
		{
			mDatabase = db;

			InitializeComponent();
			InitalizeGrid();
			WindowState = FormWindowState.Maximized;
		}

		private void InitalizeGrid()
		{
			grdMetadata.Columns.Add("colFilename", "Filename");
			grdMetadata.Columns.Add("colGenre", "Genre");
			grdMetadata.Columns.Add("colTitle", "Title");
			grdMetadata.Columns.Add("colSongName", "Song Name");
			grdMetadata.Columns.Add("colTheme", "Theme");
			grdMetadata.Columns.Add("colTracklength", "Tracklength");
			grdMetadata.Columns.Add("colSkipSecs", "SkipSecs");
			grdMetadata.Columns.Add("colPlaySecs", "PlaySecs");
			grdMetadata.Columns.Add("colCloseAnswer", "CloseAnswer");
			grdMetadata.Columns["colTracklength"].ReadOnly = true;
			mDatabase.Open();
			mDatabase.AllSongsExist();
			mDatabase.DetectUnrecordedMP3S();

			PopulateGrid();
		}

		private void DeleteTune(int index)
		{
			mDatabase.RemoveFile(index);
			int rowIndex = grdMetadata.SelectedCells[0].RowIndex;
			int tag = (int)grdMetadata.Rows[rowIndex].Tag;
			grdMetadata.Rows.RemoveAt(rowIndex);
			ReTagRows(index + 1, tag);
			if (mRowPlayingSong == rowIndex) {
				mRowPlayingSong = -1;
				ttqPlayer.Stop();
			}
			RefreshTotalSongs();
		}

		private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			ttqPlayer.Close();
		}

		private bool IsPositiveReal(string text)
		{
			try {
				double value = Convert.ToDouble(text);
				if (value < 0.0f)
					return false;
				else
					return true;
			} catch {
				return false;
			}
		}

		private void PasteCell()
		{
			if (grdMetadata.SelectedCells.Count == 1) {
				grdMetadata.SelectedCells[0].Value = Clipboard.GetText();
			}
		}

		private void PopulateGrid()
		{
			grdMetadata.Rows.Clear();
			int index = 0;
			foreach (Track tune in mDatabase.Tracks) {
				string theme = "No";
				if (tune.IsTheme)
					theme = "Yes";
				grdMetadata.Rows.Add(tune.Filename,
					tune.Genre,
					tune.Title,
					tune.Song,
					theme,
					tune.TrackLength,
					tune.SkipSecs,
					tune.PlaySecs,
					tune.CloseAnswer);
				grdMetadata.Rows[grdMetadata.Rows.Count - 1].Tag = index;
				index++;
			}
			RefreshTotalSongs();
		}

		private void ReTagRows(int startPos, int startIndex)
		{
			if (startPos < 0 || startPos >= grdMetadata.Rows.Count)
				return;

			int pos = startPos;
			int index = startIndex;
			while (pos < grdMetadata.Rows.Count) {
				for (int i = 0; i < grdMetadata.Rows.Count; i++) {
					if ((int)grdMetadata.Rows[i].Tag == pos) {
						grdMetadata.Rows[i].Tag = index;
						++index;
						++pos;
						break;
					}
				}
			}
		}

		private void RefreshPlayingTime()
		{
			//Refresh Time
			string time;
			time = TimeSpan.FromSeconds(ttqPlayer.CurrentPosition).ToString();
			if (time == null || time.Length == 0)
				time = "00:00";
			if (lblTime.Text != time)
				lblTime.Text = time;
			lblPTime.Text = ttqPlayer.CurrentPosition.ToString("0.00");
		}

		private void RefreshTotalSongs()
		{
			lblTotalSongs.Text = String.Format("Total Songs: {0}", grdMetadata.Rows.Count);
		}

		private bool Search(string query, int start, int end)
		{
			for (int i = start; i < end; i++) {
				string title = (string)grdMetadata["colTitle", i].Value;
				title = title.ToLower();

				if (title.Contains(query)) {
					SelectedColumnIndex = 2;
					SelectedRowIndex = i;
					return true;
				}
			}
			return false;
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			mDatabase.Save();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			mDatabase.Save();
			Close();
		}

		private void chkPlayFullSong_CheckedChanged(object sender, EventArgs e)
		{
			double cpos = ttqPlayer.CurrentPosition;

			Track t = mCurrentTrack;
			if (chkPlayFullSong.Checked) {
				t.SkipSecs = 0;
				t.PlaySecs = 0;
			}
			ttqPlayer.Track = t;
			ttqPlayer.CurrentPosition = cpos;
			ttqPlayer.Play();
		}

		private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string query = findToolStripTextBox.Text.ToLower();

			if (query.Length > 0 && !mNoSearch)
				if (!Search(query, SelectedRowIndex + 1, grdMetadata.RowCount))
					if (!Search(query, 0, SelectedRowIndex))
						MessageBox.Show("No matches were found!");
		}

		private void findToolStripTextBox_Enter(object sender, EventArgs e)
		{
			if (mNoSearch) {
				findToolStripTextBox.Text = "";
				findToolStripTextBox.ForeColor = SystemColors.WindowText;
				mNoSearch = false;
			}
		}

		private void findToolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter) {
				findNextToolStripMenuItem_Click(this, EventArgs.Empty);
				e.Handled = true;
			}
		}

		private void findToolStripTextBox_Leave(object sender, EventArgs e)
		{
			if (findToolStripTextBox.Text.Length == 0) {
				findToolStripTextBox.Text = "Enter your search string...";
				findToolStripTextBox.ForeColor = SystemColors.GrayText;
				mNoSearch = true;
			}
		}

		private void grdMetadata_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			Color defaultColour = Color.White;
			if (e.RowIndex == mRowPlayingSong)
				defaultColour = Color.Yellow;

			Track tune = mDatabase.Tracks[SelectedRow];
			string newValue = Convert.ToString(grdMetadata[e.ColumnIndex, e.RowIndex].Value);
			switch (e.ColumnIndex) {
				case 0: // Filename
					string oldValue = mDatabase.Tracks[SelectedRow].Filename;
					if (!mDatabase.RenameFile(SelectedRow, newValue)) {
						MessageBox.Show("Error renaming file!", "Error", MessageBoxButtons.OK,
							MessageBoxIcon.Error);
						grdMetadata[e.ColumnIndex, e.RowIndex].Value = oldValue;
					}
					return;
				case 1: // Genre
					tune.Genre = newValue;
					break;
				case 2: // Title
					tune.Title = newValue;
					break;
				case 3: // Song
					tune.Song = newValue;
					break;
				case 4: // Theme
					tune.IsTheme = (newValue.ToLower() == "yes");
					break;
				case 6: // SkipSecs
					if (IsPositiveReal(newValue)) {
						tune.SkipSecs = Convert.ToDouble(newValue);
						if (tune.SkipSecs > tune.TrackLength)
							grdMetadata[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
						else
							grdMetadata[e.ColumnIndex, e.RowIndex].Style.BackColor = defaultColour;
					} else {
						grdMetadata[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
					}
					break;
				case 7: // PlaySecs
					if (IsPositiveReal(newValue)) {
						tune.PlaySecs = Convert.ToDouble(newValue);
						if (tune.PlaySecs > tune.TrackLength)
							grdMetadata[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
						else
							grdMetadata[e.ColumnIndex, e.RowIndex].Style.BackColor = defaultColour;
					} else {
						grdMetadata[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
					}
					break;
				case 8: // CloseAnswer
					tune.CloseAnswer = newValue;
					break;
			}
			mDatabase.Tracks[SelectedRow] = tune;
		}

		private void grdMetadata_DoubleClick(object sender, EventArgs e)
		{
			if (grdMetadata.SelectedCells.Count > 0) {
				//Set playing song backcolor
				if (mRowPlayingSong >= 0)
					PlayingSongBackcolor = Color.White;
				mRowPlayingSong = grdMetadata.SelectedCells[0].RowIndex;
				//PlayingSongBackcolor = Color.Yellow;


				mCurrentTrack = mDatabase.Tracks[SelectedRow];

				try {
					mCurrentTrack.SkipSecs = mSkipsecs = Convert.ToDouble(grdMetadata["colSkipSecs", SelectedRowIndex].Value);
				} catch {
					mCurrentTrack.SkipSecs = mSkipsecs = 0;
				}
				try {
					mCurrentTrack.PlaySecs = mPlaysecs = Convert.ToDouble(grdMetadata["colPlaySecs", SelectedRowIndex].Value);
				} catch {
					mCurrentTrack.PlaySecs = mPlaysecs = 0;
				}

				mTrackLength = mCurrentTrack.TrackLength;

				Track t = mCurrentTrack;
				if (chkPlayFullSong.Checked) {
					t.SkipSecs = 0;
					t.PlaySecs = 0;
				}
				ttqPlayer.Track = t;
				ttqPlayer.PlayFromStart();
			}
		}

		private void grdMetadata_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.V) {
				PasteCell();
			} else if (e.KeyCode == Keys.Delete) {
				//Check if any song is selected
				int selTune = SelectedRow;
				if (selTune >= 0) {
					ttqPlayer.Stop();
					if (mRowPlayingSong >= 0) {
						PlayingSongBackcolor = Color.White;
						mRowPlayingSong = -1;
					}

					int[] selTunes = SelectedRows;
					int rowSelCount = selTunes.Length;

					string msg;
					if (rowSelCount > 1)
						msg = "Are you sure you want to delete these songs permanently!";
					else
						msg = "Are you sure you want to delete this song permanently!";

					if (MessageBox.Show(msg, "Delete Confirmation", MessageBoxButtons.OKCancel,
						MessageBoxIcon.Question) == DialogResult.OK)
						foreach (int tuneIndex in selTunes)
							DeleteTune(tuneIndex);

					grdMetadata.ClearSelection();
				}
			} else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.Z && e.Shift) {
				char key = (char)e.KeyCode;

				int selColumn = grdMetadata.SelectedCells[0].ColumnIndex;
				int selRow = grdMetadata.SelectedCells[0].RowIndex;
				for (int i = selRow + 1; i < grdMetadata.Rows.Count; i++) {
					string value = (string)grdMetadata[selColumn, i].Value;
					if (value != null && value.Length > 0) {
						if (Char.ToLower(value[0]) == Char.ToLower(key)) {
							grdMetadata[selColumn, selRow].Selected = false;
							grdMetadata[selColumn, i].Selected = true;
							break;
						}
					}
				}
			}
		}

		private void setAllTo30ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < grdMetadata.Rows.Count; i++) {
				DataGridViewCell cell = grdMetadata["colPlaySecs", i];
				string s = Convert.ToString(cell.Value);
				if (IsPositiveReal(s)) {
					if ((double)cell.Value == 0) {
						Track tune = mDatabase.Tracks[Convert.ToInt16(grdMetadata.Rows[i].Tag)];
						tune.PlaySecs = 30;
						mDatabase.Tracks[Convert.ToInt16(grdMetadata.Rows[i].Tag)] = tune;
						cell.Value = 30;
					}
				}
			}
		}

		private void sortAlphabeticallyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			mDatabase.SortAlphabetically();
			PopulateGrid();
		}

        private void resetTimesPlayedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Track t in mDatabase.Tracks)
                t.TimesPlayed = 0;
        }

		private void tmrMusicCheck_Tick(object sender, EventArgs e)
		{
			RefreshPlayingTime();
		}

		private Color PlayingSongBackcolor
		{
			set
			{
				for (int c = 0; c < grdMetadata.Columns.Count; c++)
					grdMetadata[c, mRowPlayingSong].Style.BackColor = value;
			}
		}

		private int SelectedColumnIndex
		{
			get
			{
				return grdMetadata.SelectedCells[0].ColumnIndex;
			}
			set
			{
				int rowIndex = SelectedRowIndex;
				int colIndex = value;

				//Clear old selection
				grdMetadata.SelectedCells[0].Selected = false;

				//Select new selection
				grdMetadata[colIndex, rowIndex].Selected = true;
			}
		}

		private int SelectedRow
		{
			get
			{
				int rowIndex = grdMetadata.SelectedCells[0].RowIndex;
				if (grdMetadata.Rows[rowIndex].Tag != null)
					return (int)grdMetadata.Rows[rowIndex].Tag;
				else
					return -1;
			}
		}

		private int[] SelectedRows
		{
			get
			{
				List<int> rowIndexs = new List<int>();
				foreach (DataGridViewCell cell in grdMetadata.SelectedCells) {
					int rowIndex = cell.RowIndex;
					if (grdMetadata.Rows[rowIndex].Tag != null) {
						int newIndex = (int)grdMetadata.Rows[rowIndex].Tag;
						if (!rowIndexs.Contains(newIndex))
							rowIndexs.Add(newIndex);
					}
				}

				return rowIndexs.ToArray();
			}
		}

		private int SelectedRowIndex
		{
			get
			{
				return grdMetadata.SelectedCells[0].RowIndex;
			}
			set
			{
				int rowIndex = value;
				int colIndex = SelectedColumnIndex;

				//Clear old selection
				grdMetadata.SelectedCells[0].Selected = false;

				//Select new selection
				grdMetadata[colIndex, rowIndex].Selected = true;
				grdMetadata.FirstDisplayedScrollingRowIndex = rowIndex;
			}
		}
	}
}