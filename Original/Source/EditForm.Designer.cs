namespace IntelOrca.TTQ
{
	partial class EditForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.grdMetadata = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tmrMusicCheck = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblTotalSongs = new System.Windows.Forms.Label();
            this.lblPTime = new System.Windows.Forms.Label();
            this.chkPlayFullSong = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortAlphabeticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.ttqPlayer = new IntelOrca.TTQ.TTQPlayer();
            this.resetTimesPlayedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdMetadata)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdMetadata
            // 
            this.grdMetadata.AllowUserToAddRows = false;
            this.grdMetadata.AllowUserToResizeColumns = false;
            this.grdMetadata.AllowUserToResizeRows = false;
            this.grdMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMetadata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdMetadata.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdMetadata.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.grdMetadata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMetadata.Location = new System.Drawing.Point(12, 27);
            this.grdMetadata.Name = "grdMetadata";
            this.grdMetadata.RowHeadersVisible = false;
            this.grdMetadata.RowHeadersWidth = 50;
            this.grdMetadata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdMetadata.Size = new System.Drawing.Size(746, 396);
            this.grdMetadata.TabIndex = 0;
            this.grdMetadata.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMetadata_CellValueChanged);
            this.grdMetadata.DoubleClick += new System.EventHandler(this.grdMetadata_DoubleClick);
            this.grdMetadata.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdMetadata_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Green;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(650, 461);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(422, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tmrMusicCheck
            // 
            this.tmrMusicCheck.Enabled = true;
            this.tmrMusicCheck.Interval = 50;
            this.tmrMusicCheck.Tick += new System.EventHandler(this.tmrMusicCheck_Tick);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(265, 467);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(34, 13);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTime.Visible = false;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.Green;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(536, 461);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(108, 25);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblTotalSongs
            // 
            this.lblTotalSongs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSongs.Location = new System.Drawing.Point(521, 426);
            this.lblTotalSongs.Name = "lblTotalSongs";
            this.lblTotalSongs.Size = new System.Drawing.Size(237, 32);
            this.lblTotalSongs.TabIndex = 7;
            this.lblTotalSongs.Text = "Total Songs: 0";
            this.lblTotalSongs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPTime
            // 
            this.lblPTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPTime.AutoSize = true;
            this.lblPTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPTime.Location = new System.Drawing.Point(357, 467);
            this.lblPTime.Name = "lblPTime";
            this.lblPTime.Size = new System.Drawing.Size(30, 15);
            this.lblPTime.TabIndex = 9;
            this.lblPTime.Text = "0.00";
            // 
            // chkPlayFullSong
            // 
            this.chkPlayFullSong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPlayFullSong.AutoSize = true;
            this.chkPlayFullSong.Location = new System.Drawing.Point(422, 441);
            this.chkPlayFullSong.Name = "chkPlayFullSong";
            this.chkPlayFullSong.Size = new System.Drawing.Size(93, 17);
            this.chkPlayFullSong.TabIndex = 10;
            this.chkPlayFullSong.Text = "Play Full Song";
            this.chkPlayFullSong.UseVisualStyleBackColor = true;
            this.chkPlayFullSong.CheckedChanged += new System.EventHandler(this.chkPlayFullSong_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.findNextToolStripMenuItem,
            this.findToolStripTextBox});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(770, 27);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortAlphabeticallyToolStripMenuItem,
            this.resetTimesPlayedToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded;
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 23);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // sortAlphabeticallyToolStripMenuItem
            // 
            this.sortAlphabeticallyToolStripMenuItem.Name = "sortAlphabeticallyToolStripMenuItem";
            this.sortAlphabeticallyToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.sortAlphabeticallyToolStripMenuItem.Text = "Sort alphabetically";
            this.sortAlphabeticallyToolStripMenuItem.Click += new System.EventHandler(this.sortAlphabeticallyToolStripMenuItem_Click);
            // 
            // findNextToolStripMenuItem
            // 
            this.findNextToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            this.findNextToolStripMenuItem.Size = new System.Drawing.Size(69, 23);
            this.findNextToolStripMenuItem.Text = "Find Next";
            this.findNextToolStripMenuItem.Click += new System.EventHandler(this.findNextToolStripMenuItem_Click);
            // 
            // findToolStripTextBox
            // 
            this.findToolStripTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.findToolStripTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.findToolStripTextBox.Name = "findToolStripTextBox";
            this.findToolStripTextBox.Size = new System.Drawing.Size(200, 23);
            this.findToolStripTextBox.Text = "Enter your search string...";
            this.findToolStripTextBox.Enter += new System.EventHandler(this.findToolStripTextBox_Enter);
            this.findToolStripTextBox.Leave += new System.EventHandler(this.findToolStripTextBox_Leave);
            this.findToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.findToolStripTextBox_KeyPress);
            // 
            // ttqPlayer
            // 
            this.ttqPlayer.AllowSeeking = true;
            this.ttqPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ttqPlayer.CurrentPosition = 0D;
            this.ttqPlayer.Location = new System.Drawing.Point(12, 426);
            this.ttqPlayer.Name = "ttqPlayer";
            this.ttqPlayer.Size = new System.Drawing.Size(404, 60);
            this.ttqPlayer.TabIndex = 13;
            this.ttqPlayer.Track = null;
            // 
            // resetTimesPlayedToolStripMenuItem
            // 
            this.resetTimesPlayedToolStripMenuItem.Name = "resetTimesPlayedToolStripMenuItem";
            this.resetTimesPlayedToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.resetTimesPlayedToolStripMenuItem.Text = "Reset times played";
            this.resetTimesPlayedToolStripMenuItem.Click += new System.EventHandler(this.resetTimesPlayedToolStripMenuItem_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 493);
            this.Controls.Add(this.chkPlayFullSong);
            this.Controls.Add(this.lblPTime);
            this.Controls.Add(this.lblTotalSongs);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grdMetadata);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ttqPlayer);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TTQ Edit Theme Tune Metadata";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grdMetadata)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView grdMetadata;
		private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Timer tmrMusicCheck;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Label lblTotalSongs;
		private System.Windows.Forms.Label lblPTime;
        private System.Windows.Forms.CheckBox chkPlayFullSong;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sortAlphabeticallyToolStripMenuItem;
		private System.Windows.Forms.ToolStripTextBox findToolStripTextBox;
		private System.Windows.Forms.ToolStripMenuItem findNextToolStripMenuItem;
        private TTQPlayer ttqPlayer;
        private System.Windows.Forms.ToolStripMenuItem resetTimesPlayedToolStripMenuItem;
	}
}