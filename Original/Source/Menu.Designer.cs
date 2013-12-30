namespace IntelOrca.TTQ
{
	partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btnNewQuiz = new System.Windows.Forms.Button();
            this.btnPlayQuiz = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAnswerQuiz = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFastAnswer = new System.Windows.Forms.Button();
            this.tmrNew = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnNewQuiz
            // 
            this.btnNewQuiz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNewQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewQuiz.Location = new System.Drawing.Point(17, 20);
            this.btnNewQuiz.Name = "btnNewQuiz";
            this.btnNewQuiz.Size = new System.Drawing.Size(286, 40);
            this.btnNewQuiz.TabIndex = 0;
            this.btnNewQuiz.Text = "New quiz";
            this.btnNewQuiz.UseVisualStyleBackColor = false;
            this.btnNewQuiz.Click += new System.EventHandler(this.btnNewQuiz_Click);
            // 
            // btnPlayQuiz
            // 
            this.btnPlayQuiz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPlayQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayQuiz.Location = new System.Drawing.Point(17, 87);
            this.btnPlayQuiz.Name = "btnPlayQuiz";
            this.btnPlayQuiz.Size = new System.Drawing.Size(286, 40);
            this.btnPlayQuiz.TabIndex = 1;
            this.btnPlayQuiz.Text = "Play quiz";
            this.btnPlayQuiz.UseVisualStyleBackColor = false;
            this.btnPlayQuiz.Click += new System.EventHandler(this.btnPlayQuiz_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(17, 288);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(286, 40);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit theme tunes";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAnswerQuiz
            // 
            this.btnAnswerQuiz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAnswerQuiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswerQuiz.Location = new System.Drawing.Point(17, 154);
            this.btnAnswerQuiz.Name = "btnAnswerQuiz";
            this.btnAnswerQuiz.Size = new System.Drawing.Size(286, 40);
            this.btnAnswerQuiz.TabIndex = 3;
            this.btnAnswerQuiz.Text = "Answer quiz";
            this.btnAnswerQuiz.UseVisualStyleBackColor = false;
            this.btnAnswerQuiz.Click += new System.EventHandler(this.btnAnswerQuiz_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(17, 355);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(286, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit TTQ";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnFastAnswer
            // 
            this.btnFastAnswer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFastAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFastAnswer.Location = new System.Drawing.Point(17, 221);
            this.btnFastAnswer.Name = "btnFastAnswer";
            this.btnFastAnswer.Size = new System.Drawing.Size(286, 40);
            this.btnFastAnswer.TabIndex = 5;
            this.btnFastAnswer.Text = "Fast answer";
            this.btnFastAnswer.UseVisualStyleBackColor = false;
            this.btnFastAnswer.Click += new System.EventHandler(this.btnFastAnswer_Click);
            // 
            // tmrNew
            // 
            this.tmrNew.Enabled = true;
            this.tmrNew.Interval = 250;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 414);
            this.Controls.Add(this.btnFastAnswer);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAnswerQuiz);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnPlayQuiz);
            this.Controls.Add(this.btnNewQuiz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Theme Tune Quiz";
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnNewQuiz;
		private System.Windows.Forms.Button btnPlayQuiz;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAnswerQuiz;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnFastAnswer;
		private System.Windows.Forms.Timer tmrNew;
	}
}

