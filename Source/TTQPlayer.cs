////////////////////////////////////
// Theme Tune Quiz (TTQ)          //
// Copyright (C) Ted John 2012    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System.Drawing;
using System.Windows.Forms;

namespace IntelOrca.TTQ
{
	enum TTQPlayerStatus
	{
		Stopped,
		Playing,
		Paused,
		Seeking,
	}

	class TTQPlayer : Control
	{
		//
		private ITrackPlayback mPlayback;
		private Track mTrack;
		private bool mAllowSeeking;
		TTQPlayerStatus mStatus;

		// UI
		private Timer mUpdateTimer;
		private Label mTrackBar;
		private Label mSkipBar;
		private Button mTrackBarButton;
		private Button mPlayButton;
		private Button mStopButton;

		private int mTrackDelta;

		public TTQPlayer()
		{
			mPlayback = new MCITrackPlayback();

			mAllowSeeking = true;
			mStatus = TTQPlayerStatus.Stopped;

			InitialiseGUI();
		}

		private void InitialiseGUI()
		{
			this.SuspendLayout();

			mUpdateTimer = new Timer();
			mUpdateTimer.Tick += new System.EventHandler(mUpdateTimer_Tick);
			mUpdateTimer.Interval = 100;
			mUpdateTimer.Enabled = true;

			mTrackBarButton = new Button();
			mTrackBarButton.Location = new Point(3, 3);
			mTrackBarButton.Size = new Size(18, 23);
			mTrackBarButton.Anchor = AnchorStyles.Left | AnchorStyles.Top;
			mTrackBarButton.MouseDown += new MouseEventHandler(mTrackBarButton_MouseDown);
			mTrackBarButton.MouseMove += new MouseEventHandler(mTrackBarButton_MouseMove);
			mTrackBarButton.MouseUp += new MouseEventHandler(mTrackBarButton_MouseUp);
			this.Controls.Add(mTrackBarButton);

			mTrackBar = new Label();
			mTrackBar.BorderStyle = BorderStyle.Fixed3D;
			mTrackBar.Location = new Point(9, 9);
			mTrackBar.Size = new Size(Width - 18, 6);
			mTrackBar.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
			mTrackBar.MouseDown += new MouseEventHandler(mTrackBar_MouseDown);
			this.Controls.Add(mTrackBar);

			mSkipBar = new Label();
			mSkipBar.BorderStyle = BorderStyle.Fixed3D;
			mSkipBar.BackColor = Color.Yellow;
			mSkipBar.Location = new Point(9, 15);
			mSkipBar.Size = new Size(Width - 18, 6);
			mSkipBar.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
			this.Controls.Add(mSkipBar);

			mPlayButton = new Button();
			mPlayButton.Text = "Play";
			mPlayButton.Location = new Point(9, 32);
			mPlayButton.Size = new Size(75, 23);
			mPlayButton.Anchor = AnchorStyles.Left | AnchorStyles.Top;
			mPlayButton.Click += new System.EventHandler(mPlayButton_Click);
			this.Controls.Add(mPlayButton);

			mStopButton = new Button();
			mStopButton.Text = "Stop";
			mStopButton.Location = new Point(90, 32);
			mStopButton.Size = new Size(75, 23);
			mStopButton.Anchor = AnchorStyles.Left | AnchorStyles.Top;
			mStopButton.Click += new System.EventHandler(mStopButton_Click);
			this.Controls.Add(mStopButton);

			this.ResumeLayout();
		}

		private void UpdateButtons()
		{
			if (mStatus == TTQPlayerStatus.Playing)
				mPlayButton.Text = "Pause";
			else
				mPlayButton.Text = "Play";

			mStopButton.Enabled = (mStatus != TTQPlayerStatus.Stopped);
		}

		private void InitTrackBar()
		{
			if (mTrack == null)
				return;

			double skipSecs = mTrack.SkipSecs;
			double playSecs = mTrack.PlaySecs;
			if (playSecs == 0)
				playSecs = mTrack.TrackLength - skipSecs;

			double start = skipSecs / mTrack.TrackLength;
			double duration = playSecs / mTrack.TrackLength;

			mSkipBar.Left = (int)(mTrackBar.Left + (start * mTrackBar.Width));
			mSkipBar.Top = 15;
			mSkipBar.Width = (int)(duration * mTrackBar.Width);
			mSkipBar.Height = 6;
		}

		private void UpdatePosition()
		{
			if (mTrack == null)
				return;

			if (mStatus != TTQPlayerStatus.Playing)
				return;

			double progress = mPlayback.CurrentPosition / mTrack.TrackLength;
			if (progress > 1.0f)
				progress = 1.0f;

			mTrackBarButton.Left = mTrackBar.Left + (int)(progress * mTrackBar.Width) - (mTrackBarButton.Width / 2);
		}

		private void DoStopCheck()
		{
			if (mTrack == null)
				return;

			if (mStatus != TTQPlayerStatus.Playing)
				return;

			if (!mPlayback.Playing) {
				mStatus = TTQPlayerStatus.Stopped;
				UpdateButtons();
			}

			if (mTrack.PlaySecs != 0 && mPlayback.CurrentPosition > mTrack.SkipSecs + mTrack.PlaySecs)
				Stop();
		}

		public void PlayFromStart()
		{
			if (mTrack == null)
				return;

			mPlayback.CurrentPosition = mTrack.SkipSecs;

			Play();
		}

		public void Play()
		{
			mPlayback.Playing = true;

			mStatus = TTQPlayerStatus.Playing;
			UpdateButtons();
		}

		public void Pause()
		{
			mPlayback.Playing = false;

			mStatus = TTQPlayerStatus.Paused;
			UpdateButtons();
		}

		public void Stop()
		{
			mPlayback.Playing = false;

			mStatus = TTQPlayerStatus.Stopped;
			UpdateButtons();
		}

		public void Close()
		{
			Stop();
			mPlayback.Close();
		}

		protected override void OnResize(System.EventArgs e)
		{
			base.OnResize(e);

			InitTrackBar();
			UpdatePosition();
		}

		private void mUpdateTimer_Tick(object sender, System.EventArgs e)
		{
			UpdatePosition();
			DoStopCheck();
		}

		private void mTrackBar_MouseDown(object sender, MouseEventArgs e)
		{
			if (!mAllowSeeking)
				return;

			mPlayback.CurrentPosition = ((double)e.X / (double)mTrackBar.Width) * (double)mTrack.TrackLength;
			Play();
		}

		private void mTrackBarButton_MouseDown(object sender, MouseEventArgs e)
		{
			if (mTrack == null)
				return;

			if (!mAllowSeeking)
				return;

			Pause();
			mStatus = TTQPlayerStatus.Seeking;

			mTrackDelta = e.X;
		}

		private void mTrackBarButton_MouseMove(object sender, MouseEventArgs e)
		{
			if (mTrack == null)
				return;

			if (!mAllowSeeking)
				return;

			if (e.Button == MouseButtons.Left) {
				int delta = e.X - mTrackDelta;

				if ((mTrackBarButton.Left + delta) + (mTrackBarButton.Width / 2) < mTrackBar.Left)
					mTrackBarButton.Left = mTrackBar.Left - (mTrackBarButton.Width / 2);
				else if ((mTrackBarButton.Left + delta) + (mTrackBarButton.Width / 2) > mTrackBar.Right)
					mTrackBarButton.Left = mTrackBar.Right - (mTrackBarButton.Width / 2);
				else
					mTrackBarButton.Left += delta;
			}
		}

		private void mTrackBarButton_MouseUp(object sender, MouseEventArgs e)
		{
			if (mTrack == null)
				return;

			if (!mAllowSeeking)
				return;

			mPlayback.CurrentPosition = ((double)(mTrackBarButton.Left + (mTrackBarButton.Width / 2) - mTrackBar.Left) / (double)mTrackBar.Width) * (double)mTrack.TrackLength;
			Play();
		}

		private void mPlayButton_Click(object sender, System.EventArgs e)
		{
			if (mStatus == TTQPlayerStatus.Playing)
				Pause();
			else if (mStatus == TTQPlayerStatus.Paused)
				Play();
			else
				PlayFromStart();
		}

		private void mStopButton_Click(object sender, System.EventArgs e)
		{
			Stop();
		}

		public bool AllowSeeking
		{
			get
			{
				return mAllowSeeking;
			}
			set
			{
				mAllowSeeking = value;
			}
		}

		public TTQPlayerStatus Status
		{
			get
			{
				return mStatus;
			}
		}

		public double CurrentPosition
		{
			get
			{
				return mPlayback.CurrentPosition;
			}
			set
			{
				mPlayback.CurrentPosition = value;
				Play();
			}
		}

		public Track Track
		{
			get
			{
				return mTrack;
			}
			set
			{
				mTrack = value;
                if (mTrack == null)
                    mPlayback.Close();
                else
    				mPlayback.Load(Application.StartupPath + "\\Music\\" + mTrack.Filename);
				InitTrackBar();
			}
		}
	}
}
