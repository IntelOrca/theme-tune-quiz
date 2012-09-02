namespace TTQ
{
	partial class TestPlayer
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
			this.ttqPlayer1 = new TTQ.TTQPlayer();
			this.SuspendLayout();
			// 
			// ttqPlayer1
			// 
			this.ttqPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ttqPlayer1.Location = new System.Drawing.Point(12, 12);
			this.ttqPlayer1.Name = "ttqPlayer1";
			this.ttqPlayer1.Size = new System.Drawing.Size(347, 61);
			this.ttqPlayer1.TabIndex = 0;
			// 
			// TestPlayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(371, 114);
			this.Controls.Add(this.ttqPlayer1);
			this.Name = "TestPlayer";
			this.Text = "TestPlayer";
			this.ResumeLayout(false);

		}

		#endregion

		private TTQ.TTQPlayer ttqPlayer1;

	}
}