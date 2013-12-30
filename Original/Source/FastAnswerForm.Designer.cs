namespace IntelOrca.TTQ
{
	partial class FastAnswerForm
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
			if (disposing && (components != null))
			{
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
			this.pnlQuestions = new System.Windows.Forms.Panel();
			this.cmbAnswer = new System.Windows.Forms.ComboBox();
			this.lblCategory = new System.Windows.Forms.Label();
			this.lblOutcome = new System.Windows.Forms.Label();
			this.btnFinish = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.lblSongName = new System.Windows.Forms.Label();
			this.lblThemeOf = new System.Windows.Forms.Label();
			this.btnReplay = new System.Windows.Forms.Button();
			this.btnIKnowIt = new System.Windows.Forms.Button();
			this.btnDunno = new System.Windows.Forms.Button();
			this.ttqPlayer = new IntelOrca.TTQ.TTQPlayer();
			this.pnlConclusion = new System.Windows.Forms.Panel();
			this.btnExit = new System.Windows.Forms.Button();
			this.lblDunnoAverageTime = new System.Windows.Forms.Label();
			this.lblWrongAverageTime = new System.Windows.Forms.Label();
			this.lblCorrectAverageTime = new System.Windows.Forms.Label();
			this.lblSessionTime = new System.Windows.Forms.Label();
			this.lblDunno = new System.Windows.Forms.Label();
			this.lblWrong = new System.Windows.Forms.Label();
			this.lblCorrect = new System.Windows.Forms.Label();
			this.lblPercentage = new System.Windows.Forms.Label();
			this.pnlQuestions.SuspendLayout();
			this.pnlConclusion.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlQuestions
			// 
			this.pnlQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlQuestions.Controls.Add(this.cmbAnswer);
			this.pnlQuestions.Controls.Add(this.lblCategory);
			this.pnlQuestions.Controls.Add(this.lblOutcome);
			this.pnlQuestions.Controls.Add(this.btnFinish);
			this.pnlQuestions.Controls.Add(this.btnNext);
			this.pnlQuestions.Controls.Add(this.lblSongName);
			this.pnlQuestions.Controls.Add(this.lblThemeOf);
			this.pnlQuestions.Controls.Add(this.btnReplay);
			this.pnlQuestions.Controls.Add(this.btnIKnowIt);
			this.pnlQuestions.Controls.Add(this.btnDunno);
			this.pnlQuestions.Controls.Add(this.ttqPlayer);
			this.pnlQuestions.Location = new System.Drawing.Point(0, 0);
			this.pnlQuestions.Name = "pnlQuestions";
			this.pnlQuestions.Size = new System.Drawing.Size(443, 206);
			this.pnlQuestions.TabIndex = 0;
			// 
			// cmbAnswer
			// 
			this.cmbAnswer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbAnswer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cmbAnswer.FormattingEnabled = true;
			this.cmbAnswer.Location = new System.Drawing.Point(14, 109);
			this.cmbAnswer.Name = "cmbAnswer";
			this.cmbAnswer.Size = new System.Drawing.Size(416, 21);
			this.cmbAnswer.TabIndex = 5;
			this.cmbAnswer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAnswer_KeyDown);
			// 
			// lblCategory
			// 
			this.lblCategory.AutoSize = true;
			this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCategory.Location = new System.Drawing.Point(15, 58);
			this.lblCategory.Name = "lblCategory";
			this.lblCategory.Size = new System.Drawing.Size(48, 16);
			this.lblCategory.TabIndex = 2;
			this.lblCategory.Text = "Genre:";
			this.lblCategory.UseMnemonic = false;
			// 
			// lblOutcome
			// 
			this.lblOutcome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblOutcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOutcome.Location = new System.Drawing.Point(14, 109);
			this.lblOutcome.Name = "lblOutcome";
			this.lblOutcome.Size = new System.Drawing.Size(416, 23);
			this.lblOutcome.TabIndex = 20;
			this.lblOutcome.Text = "Outcome";
			this.lblOutcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnFinish
			// 
			this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFinish.Location = new System.Drawing.Point(229, 136);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.Size = new System.Drawing.Size(201, 60);
			this.btnFinish.TabIndex = 7;
			this.btnFinish.Text = "FINISH";
			this.btnFinish.UseVisualStyleBackColor = true;
			this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
			// 
			// btnNext
			// 
			this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNext.Location = new System.Drawing.Point(14, 136);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(201, 60);
			this.btnNext.TabIndex = 6;
			this.btnNext.Text = "NEXT";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// lblSongName
			// 
			this.lblSongName.AutoSize = true;
			this.lblSongName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSongName.Location = new System.Drawing.Point(14, 36);
			this.lblSongName.Name = "lblSongName";
			this.lblSongName.Size = new System.Drawing.Size(80, 16);
			this.lblSongName.TabIndex = 1;
			this.lblSongName.Text = "Song name:";
			this.lblSongName.UseMnemonic = false;
			// 
			// lblThemeOf
			// 
			this.lblThemeOf.AutoSize = true;
			this.lblThemeOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblThemeOf.Location = new System.Drawing.Point(14, 12);
			this.lblThemeOf.Name = "lblThemeOf";
			this.lblThemeOf.Size = new System.Drawing.Size(93, 20);
			this.lblThemeOf.TabIndex = 0;
			this.lblThemeOf.Text = "Theme of: ?";
			this.lblThemeOf.UseMnemonic = false;
			// 
			// btnReplay
			// 
			this.btnReplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnReplay.Location = new System.Drawing.Point(14, 79);
			this.btnReplay.Name = "btnReplay";
			this.btnReplay.Size = new System.Drawing.Size(26, 23);
			this.btnReplay.TabIndex = 3;
			this.btnReplay.Text = "Replay";
			this.btnReplay.UseVisualStyleBackColor = true;
			this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
			// 
			// btnIKnowIt
			// 
			this.btnIKnowIt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnIKnowIt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnIKnowIt.Location = new System.Drawing.Point(14, 136);
			this.btnIKnowIt.Name = "btnIKnowIt";
			this.btnIKnowIt.Size = new System.Drawing.Size(201, 60);
			this.btnIKnowIt.TabIndex = 13;
			this.btnIKnowIt.Text = "I KNOW IT";
			this.btnIKnowIt.UseVisualStyleBackColor = true;
			this.btnIKnowIt.Click += new System.EventHandler(this.btnIKnowIt_Click);
			// 
			// btnDunno
			// 
			this.btnDunno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDunno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDunno.Location = new System.Drawing.Point(229, 136);
			this.btnDunno.Name = "btnDunno";
			this.btnDunno.Size = new System.Drawing.Size(201, 60);
			this.btnDunno.TabIndex = 12;
			this.btnDunno.Text = "DUNNO";
			this.btnDunno.UseVisualStyleBackColor = true;
			this.btnDunno.Click += new System.EventHandler(this.btnDunno_Click);
			// 
			// ttqPlayer
			// 
			this.ttqPlayer.AllowSeeking = true;
			this.ttqPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ttqPlayer.CurrentPosition = 0D;
			this.ttqPlayer.Location = new System.Drawing.Point(46, 76);
			this.ttqPlayer.Name = "ttqPlayer";
			this.ttqPlayer.Size = new System.Drawing.Size(384, 30);
			this.ttqPlayer.TabIndex = 4;
			this.ttqPlayer.Track = null;
			// 
			// pnlConclusion
			// 
			this.pnlConclusion.Controls.Add(this.btnExit);
			this.pnlConclusion.Controls.Add(this.lblDunnoAverageTime);
			this.pnlConclusion.Controls.Add(this.lblWrongAverageTime);
			this.pnlConclusion.Controls.Add(this.lblCorrectAverageTime);
			this.pnlConclusion.Controls.Add(this.lblSessionTime);
			this.pnlConclusion.Controls.Add(this.lblDunno);
			this.pnlConclusion.Controls.Add(this.lblWrong);
			this.pnlConclusion.Controls.Add(this.lblCorrect);
			this.pnlConclusion.Controls.Add(this.lblPercentage);
			this.pnlConclusion.Location = new System.Drawing.Point(0, 0);
			this.pnlConclusion.Name = "pnlConclusion";
			this.pnlConclusion.Size = new System.Drawing.Size(443, 206);
			this.pnlConclusion.TabIndex = 1;
			// 
			// btnExit
			// 
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExit.Location = new System.Drawing.Point(12, 136);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(419, 60);
			this.btnExit.TabIndex = 8;
			this.btnExit.Text = "FINISH";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// lblDunnoAverageTime
			// 
			this.lblDunnoAverageTime.AutoSize = true;
			this.lblDunnoAverageTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDunnoAverageTime.Location = new System.Drawing.Point(190, 90);
			this.lblDunnoAverageTime.Name = "lblDunnoAverageTime";
			this.lblDunnoAverageTime.Size = new System.Drawing.Size(173, 16);
			this.lblDunnoAverageTime.TabIndex = 3;
			this.lblDunnoAverageTime.Text = "Average Dunno Time: 12:00";
			// 
			// lblWrongAverageTime
			// 
			this.lblWrongAverageTime.AutoSize = true;
			this.lblWrongAverageTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWrongAverageTime.Location = new System.Drawing.Point(190, 62);
			this.lblWrongAverageTime.Name = "lblWrongAverageTime";
			this.lblWrongAverageTime.Size = new System.Drawing.Size(174, 16);
			this.lblWrongAverageTime.TabIndex = 2;
			this.lblWrongAverageTime.Text = "Average Wrong Time: 12:00";
			// 
			// lblCorrectAverageTime
			// 
			this.lblCorrectAverageTime.AutoSize = true;
			this.lblCorrectAverageTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCorrectAverageTime.Location = new System.Drawing.Point(190, 37);
			this.lblCorrectAverageTime.Name = "lblCorrectAverageTime";
			this.lblCorrectAverageTime.Size = new System.Drawing.Size(177, 16);
			this.lblCorrectAverageTime.TabIndex = 1;
			this.lblCorrectAverageTime.Text = "Average Correct Time: 12:00";
			// 
			// lblSessionTime
			// 
			this.lblSessionTime.AutoSize = true;
			this.lblSessionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSessionTime.Location = new System.Drawing.Point(190, 9);
			this.lblSessionTime.Name = "lblSessionTime";
			this.lblSessionTime.Size = new System.Drawing.Size(128, 16);
			this.lblSessionTime.TabIndex = 0;
			this.lblSessionTime.Text = "Session Time: 12:00";
			// 
			// lblDunno
			// 
			this.lblDunno.AutoSize = true;
			this.lblDunno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDunno.Location = new System.Drawing.Point(5, 87);
			this.lblDunno.Name = "lblDunno";
			this.lblDunno.Size = new System.Drawing.Size(84, 16);
			this.lblDunno.TabIndex = 4;
			this.lblDunno.Text = "Dunno: 5 / 20";
			this.lblDunno.Click += new System.EventHandler(this.btnDunno_Click);
			// 
			// lblWrong
			// 
			this.lblWrong.AutoSize = true;
			this.lblWrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWrong.Location = new System.Drawing.Point(5, 62);
			this.lblWrong.Name = "lblWrong";
			this.lblWrong.Size = new System.Drawing.Size(85, 16);
			this.lblWrong.TabIndex = 5;
			this.lblWrong.Text = "Wrong: 5 / 20";
			// 
			// lblCorrect
			// 
			this.lblCorrect.AutoSize = true;
			this.lblCorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCorrect.Location = new System.Drawing.Point(5, 37);
			this.lblCorrect.Name = "lblCorrect";
			this.lblCorrect.Size = new System.Drawing.Size(88, 16);
			this.lblCorrect.TabIndex = 6;
			this.lblCorrect.Text = "Correct: 5 / 20";
			// 
			// lblPercentage
			// 
			this.lblPercentage.AutoSize = true;
			this.lblPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPercentage.Location = new System.Drawing.Point(5, 9);
			this.lblPercentage.Name = "lblPercentage";
			this.lblPercentage.Size = new System.Drawing.Size(126, 20);
			this.lblPercentage.TabIndex = 7;
			this.lblPercentage.Text = "You scored 58%";
			// 
			// FastAnswerForm
			// 
			this.AcceptButton = this.btnNext;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(443, 206);
			this.Controls.Add(this.pnlQuestions);
			this.Controls.Add(this.pnlConclusion);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FastAnswerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Fast Answer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FastAnswerForm_FormClosing);
			this.pnlQuestions.ResumeLayout(false);
			this.pnlQuestions.PerformLayout();
			this.pnlConclusion.ResumeLayout(false);
			this.pnlConclusion.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Panel pnlQuestions;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblOutcome;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblSongName;
        private System.Windows.Forms.Label lblThemeOf;
        private System.Windows.Forms.Button btnReplay;
        private System.Windows.Forms.Button btnIKnowIt;
        private System.Windows.Forms.Button btnDunno;
        private TTQPlayer ttqPlayer;
        private System.Windows.Forms.ComboBox cmbAnswer;
        private System.Windows.Forms.Panel pnlConclusion;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Label lblCorrect;
        private System.Windows.Forms.Label lblWrong;
        private System.Windows.Forms.Label lblDunno;
        private System.Windows.Forms.Label lblSessionTime;
        private System.Windows.Forms.Label lblCorrectAverageTime;
        private System.Windows.Forms.Label lblDunnoAverageTime;
        private System.Windows.Forms.Label lblWrongAverageTime;
        private System.Windows.Forms.Button btnExit;

    }
}