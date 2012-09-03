namespace IntelOrca.TTQ
{
	partial class QuizForm
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
			this.lblRound = new System.Windows.Forms.Label();
			this.lblTrack = new System.Windows.Forms.Label();
			this.spnRound = new System.Windows.Forms.NumericUpDown();
			this.spnTrack = new System.Windows.Forms.NumericUpDown();
			this.lblRoundName = new System.Windows.Forms.Label();
			this.lblAnswer = new System.Windows.Forms.Label();
			this.lblClose = new System.Windows.Forms.Label();
			this.lblSong = new System.Windows.Forms.Label();
			this.lblPlayMode = new System.Windows.Forms.Label();
			this.cmbPlayMode = new System.Windows.Forms.ComboBox();
			this.grpAnswers = new System.Windows.Forms.GroupBox();
			this.lblSongPoints = new System.Windows.Forms.Label();
			this.lblClosePoints = new System.Windows.Forms.Label();
			this.lblAnswerPoints = new System.Windows.Forms.Label();
			this.lblSongPointsDesc = new System.Windows.Forms.Label();
			this.lblAnswerPointsDesc = new System.Windows.Forms.Label();
			this.lblClosePointsDesc = new System.Windows.Forms.Label();
			this.grpPlayer = new System.Windows.Forms.GroupBox();
			this.lblTime = new System.Windows.Forms.Label();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnPlay = new System.Windows.Forms.Button();
			this.tmrMusicCheck = new System.Windows.Forms.Timer(this.components);
			this.btnClose = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.tmrSecond = new System.Windows.Forms.Timer(this.components);
			this.chkAutomated = new System.Windows.Forms.CheckBox();
			this.ttqPlayer = new IntelOrca.TTQ.TTQPlayer();
			((System.ComponentModel.ISupportInitialize)(this.spnRound)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spnTrack)).BeginInit();
			this.grpAnswers.SuspendLayout();
			this.grpPlayer.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblRound
			// 
			this.lblRound.AutoSize = true;
			this.lblRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRound.Location = new System.Drawing.Point(199, 15);
			this.lblRound.Name = "lblRound";
			this.lblRound.Size = new System.Drawing.Size(123, 31);
			this.lblRound.TabIndex = 1;
			this.lblRound.Text = "ROUND:";
			// 
			// lblTrack
			// 
			this.lblTrack.AutoSize = true;
			this.lblTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTrack.Location = new System.Drawing.Point(7, 15);
			this.lblTrack.Name = "lblTrack";
			this.lblTrack.Size = new System.Drawing.Size(115, 31);
			this.lblTrack.TabIndex = 2;
			this.lblTrack.Text = "TRACK:";
			// 
			// spnRound
			// 
			this.spnRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.spnRound.Location = new System.Drawing.Point(323, 11);
			this.spnRound.Name = "spnRound";
			this.spnRound.Size = new System.Drawing.Size(81, 38);
			this.spnRound.TabIndex = 3;
			this.spnRound.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.spnRound.ValueChanged += new System.EventHandler(this.spnRound_ValueChanged);
			// 
			// spnTrack
			// 
			this.spnTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.spnTrack.Location = new System.Drawing.Point(122, 11);
			this.spnTrack.Name = "spnTrack";
			this.spnTrack.Size = new System.Drawing.Size(73, 38);
			this.spnTrack.TabIndex = 4;
			this.spnTrack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.spnTrack.ValueChanged += new System.EventHandler(this.spnTrack_ValueChanged);
			// 
			// lblRoundName
			// 
			this.lblRoundName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRoundName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRoundName.ForeColor = System.Drawing.Color.Blue;
			this.lblRoundName.Location = new System.Drawing.Point(426, 12);
			this.lblRoundName.Name = "lblRoundName";
			this.lblRoundName.Size = new System.Drawing.Size(345, 37);
			this.lblRoundName.TabIndex = 5;
			this.lblRoundName.Text = "RoundName";
			this.lblRoundName.UseMnemonic = false;
			// 
			// lblAnswer
			// 
			this.lblAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAnswer.ForeColor = System.Drawing.Color.Blue;
			this.lblAnswer.Location = new System.Drawing.Point(6, 19);
			this.lblAnswer.Name = "lblAnswer";
			this.lblAnswer.Size = new System.Drawing.Size(491, 35);
			this.lblAnswer.TabIndex = 7;
			this.lblAnswer.Text = "Answer";
			this.lblAnswer.UseMnemonic = false;
			// 
			// lblClose
			// 
			this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblClose.ForeColor = System.Drawing.Color.Blue;
			this.lblClose.Location = new System.Drawing.Point(6, 54);
			this.lblClose.Name = "lblClose";
			this.lblClose.Size = new System.Drawing.Size(491, 35);
			this.lblClose.TabIndex = 9;
			this.lblClose.Text = "Close Answer";
			this.lblClose.UseMnemonic = false;
			// 
			// lblSong
			// 
			this.lblSong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSong.ForeColor = System.Drawing.Color.Blue;
			this.lblSong.Location = new System.Drawing.Point(6, 89);
			this.lblSong.Name = "lblSong";
			this.lblSong.Size = new System.Drawing.Size(491, 35);
			this.lblSong.TabIndex = 10;
			this.lblSong.Text = "Song Name";
			this.lblSong.UseMnemonic = false;
			// 
			// lblPlayMode
			// 
			this.lblPlayMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPlayMode.AutoSize = true;
			this.lblPlayMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayMode.Location = new System.Drawing.Point(565, 44);
			this.lblPlayMode.Name = "lblPlayMode";
			this.lblPlayMode.Size = new System.Drawing.Size(59, 13);
			this.lblPlayMode.TabIndex = 13;
			this.lblPlayMode.Text = "Play mode:";
			// 
			// cmbPlayMode
			// 
			this.cmbPlayMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbPlayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPlayMode.FormattingEnabled = true;
			this.cmbPlayMode.Location = new System.Drawing.Point(628, 40);
			this.cmbPlayMode.Name = "cmbPlayMode";
			this.cmbPlayMode.Size = new System.Drawing.Size(125, 21);
			this.cmbPlayMode.TabIndex = 12;
			this.cmbPlayMode.SelectedIndexChanged += new System.EventHandler(this.cmbPlayMode_SelectedIndexChanged);
			// 
			// grpAnswers
			// 
			this.grpAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpAnswers.Controls.Add(this.lblSongPoints);
			this.grpAnswers.Controls.Add(this.lblClosePoints);
			this.grpAnswers.Controls.Add(this.lblAnswerPoints);
			this.grpAnswers.Controls.Add(this.lblSong);
			this.grpAnswers.Controls.Add(this.lblAnswer);
			this.grpAnswers.Controls.Add(this.lblClose);
			this.grpAnswers.Controls.Add(this.lblSongPointsDesc);
			this.grpAnswers.Controls.Add(this.lblAnswerPointsDesc);
			this.grpAnswers.Controls.Add(this.lblClosePointsDesc);
			this.grpAnswers.Location = new System.Drawing.Point(13, 165);
			this.grpAnswers.Name = "grpAnswers";
			this.grpAnswers.Size = new System.Drawing.Size(760, 132);
			this.grpAnswers.TabIndex = 15;
			this.grpAnswers.TabStop = false;
			this.grpAnswers.Text = "Answers";
			// 
			// lblSongPoints
			// 
			this.lblSongPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSongPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSongPoints.Location = new System.Drawing.Point(518, 89);
			this.lblSongPoints.Name = "lblSongPoints";
			this.lblSongPoints.Size = new System.Drawing.Size(232, 35);
			this.lblSongPoints.TabIndex = 13;
			this.lblSongPoints.Text = "Song Name (Bonus Point)";
			this.lblSongPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblClosePoints
			// 
			this.lblClosePoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblClosePoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblClosePoints.Location = new System.Drawing.Point(518, 54);
			this.lblClosePoints.Name = "lblClosePoints";
			this.lblClosePoints.Size = new System.Drawing.Size(232, 35);
			this.lblClosePoints.TabIndex = 12;
			this.lblClosePoints.Text = "Close Answer (1 Point)";
			this.lblClosePoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblAnswerPoints
			// 
			this.lblAnswerPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAnswerPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAnswerPoints.Location = new System.Drawing.Point(518, 19);
			this.lblAnswerPoints.Name = "lblAnswerPoints";
			this.lblAnswerPoints.Size = new System.Drawing.Size(232, 35);
			this.lblAnswerPoints.TabIndex = 11;
			this.lblAnswerPoints.Text = "Full Answer (2 Points)";
			this.lblAnswerPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSongPointsDesc
			// 
			this.lblSongPointsDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSongPointsDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSongPointsDesc.ForeColor = System.Drawing.Color.Blue;
			this.lblSongPointsDesc.Location = new System.Drawing.Point(9, 89);
			this.lblSongPointsDesc.Name = "lblSongPointsDesc";
			this.lblSongPointsDesc.Size = new System.Drawing.Size(491, 35);
			this.lblSongPointsDesc.TabIndex = 16;
			this.lblSongPointsDesc.Text = "A bonus point for the name of the song";
			this.lblSongPointsDesc.Visible = false;
			// 
			// lblAnswerPointsDesc
			// 
			this.lblAnswerPointsDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAnswerPointsDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAnswerPointsDesc.ForeColor = System.Drawing.Color.Blue;
			this.lblAnswerPointsDesc.Location = new System.Drawing.Point(9, 19);
			this.lblAnswerPointsDesc.Name = "lblAnswerPointsDesc";
			this.lblAnswerPointsDesc.Size = new System.Drawing.Size(491, 35);
			this.lblAnswerPointsDesc.TabIndex = 14;
			this.lblAnswerPointsDesc.Text = "2 points for the full answer";
			this.lblAnswerPointsDesc.Visible = false;
			// 
			// lblClosePointsDesc
			// 
			this.lblClosePointsDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblClosePointsDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblClosePointsDesc.ForeColor = System.Drawing.Color.Blue;
			this.lblClosePointsDesc.Location = new System.Drawing.Point(9, 54);
			this.lblClosePointsDesc.Name = "lblClosePointsDesc";
			this.lblClosePointsDesc.Size = new System.Drawing.Size(491, 35);
			this.lblClosePointsDesc.TabIndex = 15;
			this.lblClosePointsDesc.Text = "1 point for a close answer";
			this.lblClosePointsDesc.Visible = false;
			// 
			// grpPlayer
			// 
			this.grpPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpPlayer.Controls.Add(this.ttqPlayer);
			this.grpPlayer.Controls.Add(this.lblTime);
			this.grpPlayer.Controls.Add(this.btnNext);
			this.grpPlayer.Controls.Add(this.btnStop);
			this.grpPlayer.Controls.Add(this.btnPlay);
			this.grpPlayer.Controls.Add(this.lblPlayMode);
			this.grpPlayer.Controls.Add(this.cmbPlayMode);
			this.grpPlayer.Location = new System.Drawing.Point(13, 56);
			this.grpPlayer.Name = "grpPlayer";
			this.grpPlayer.Size = new System.Drawing.Size(760, 103);
			this.grpPlayer.TabIndex = 0;
			this.grpPlayer.TabStop = false;
			this.grpPlayer.Text = "Player";
			// 
			// lblTime
			// 
			this.lblTime.AutoSize = true;
			this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTime.Location = new System.Drawing.Point(427, 25);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(98, 37);
			this.lblTime.TabIndex = 18;
			this.lblTime.Text = "00:00";
			// 
			// btnNext
			// 
			this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNext.Location = new System.Drawing.Point(275, 21);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(128, 42);
			this.btnNext.TabIndex = 15;
			this.btnNext.Text = "NEXT";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnStop
			// 
			this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStop.Location = new System.Drawing.Point(141, 21);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(128, 42);
			this.btnStop.TabIndex = 17;
			this.btnStop.Text = "STOP";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnPlay
			// 
			this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnPlay.Location = new System.Drawing.Point(7, 21);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(128, 42);
			this.btnPlay.TabIndex = 16;
			this.btnPlay.Text = "PLAY";
			this.btnPlay.UseVisualStyleBackColor = true;
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// tmrMusicCheck
			// 
			this.tmrMusicCheck.Enabled = true;
			this.tmrMusicCheck.Interval = 50;
			this.tmrMusicCheck.Tick += new System.EventHandler(this.tmrMusicCheck_Tick);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(673, 304);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(100, 26);
			this.btnClose.TabIndex = 16;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrint.Location = new System.Drawing.Point(567, 304);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(100, 26);
			this.btnPrint.TabIndex = 17;
			this.btnPrint.Text = "Print Sheet";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// tmrSecond
			// 
			this.tmrSecond.Enabled = true;
			this.tmrSecond.Interval = 1000;
			this.tmrSecond.Tick += new System.EventHandler(this.tmrSecond_Tick);
			// 
			// chkAutomated
			// 
			this.chkAutomated.AutoSize = true;
			this.chkAutomated.Location = new System.Drawing.Point(13, 313);
			this.chkAutomated.Name = "chkAutomated";
			this.chkAutomated.Size = new System.Drawing.Size(77, 17);
			this.chkAutomated.TabIndex = 18;
			this.chkAutomated.Text = "Automated";
			this.chkAutomated.UseVisualStyleBackColor = true;
			this.chkAutomated.CheckedChanged += new System.EventHandler(this.chkAutomated_CheckedChanged);
			// 
			// ttqPlayer
			// 
			this.ttqPlayer.AllowSeeking = true;
			this.ttqPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ttqPlayer.CurrentPosition = 0D;
			this.ttqPlayer.Location = new System.Drawing.Point(6, 69);
			this.ttqPlayer.Name = "ttqPlayer";
			this.ttqPlayer.Size = new System.Drawing.Size(744, 30);
			this.ttqPlayer.TabIndex = 19;
			this.ttqPlayer.Track = null;
			// 
			// QuizForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 342);
			this.Controls.Add(this.chkAutomated);
			this.Controls.Add(this.btnPrint);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.grpPlayer);
			this.Controls.Add(this.spnRound);
			this.Controls.Add(this.lblRound);
			this.Controls.Add(this.grpAnswers);
			this.Controls.Add(this.lblTrack);
			this.Controls.Add(this.lblRoundName);
			this.Controls.Add(this.spnTrack);
			this.Name = "QuizForm";
			this.Text = "QUIZ NAME";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.spnRound)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spnTrack)).EndInit();
			this.grpAnswers.ResumeLayout(false);
			this.grpPlayer.ResumeLayout(false);
			this.grpPlayer.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblRound;
		private System.Windows.Forms.Label lblTrack;
		private System.Windows.Forms.NumericUpDown spnRound;
		private System.Windows.Forms.NumericUpDown spnTrack;
		private System.Windows.Forms.Label lblRoundName;
		private System.Windows.Forms.Label lblAnswer;
		private System.Windows.Forms.Label lblClose;
		private System.Windows.Forms.Label lblSong;
		private System.Windows.Forms.Label lblPlayMode;
		private System.Windows.Forms.ComboBox cmbPlayMode;
		private System.Windows.Forms.GroupBox grpAnswers;
		private System.Windows.Forms.Label lblAnswerPoints;
		private System.Windows.Forms.Label lblSongPoints;
		private System.Windows.Forms.Label lblClosePoints;
		private System.Windows.Forms.GroupBox grpPlayer;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnPlay;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Timer tmrMusicCheck;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.Label lblSongPointsDesc;
		private System.Windows.Forms.Label lblAnswerPointsDesc;
		private System.Windows.Forms.Label lblClosePointsDesc;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Timer tmrSecond;
		private TTQ.TTQPlayer ttqPlayer;
		private System.Windows.Forms.CheckBox chkAutomated;
	}
}