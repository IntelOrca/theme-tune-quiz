using System;

namespace IntelOrca.TTQ
{
	class StopWatch
	{
		private long mStart;
		private long mEnd;
		private long mPauseTime;
		private bool mTicking;

		public StopWatch()
		{
			mStart = 0;
			mEnd = 0;

			mPauseTime = 0;
		}

		public void Start()
		{
			mStart = DateTime.Now.Ticks;

			mTicking = true;
		}

		public void Continue()
		{
			if (mTicking)
				return;

			mPauseTime += DateTime.Now.Ticks - mEnd;
			mTicking = true;
		}

		public void Stop()
		{
			mEnd = DateTime.Now.Ticks;

			mTicking = false;
		}

		public void Reset()
		{
			if (mTicking)
				Start();

			mPauseTime = 0;
		}

		public long ElapsedTicks
		{
			get
			{
				if (mTicking)
					return (long)(DateTime.Now.Ticks - mStart - mPauseTime);
				else
					return (long)(mEnd - mStart - mPauseTime);
			}
		}

		public double ElapsedSeconds
		{
			get
			{
				return (double)(ElapsedTicks) / TimeSpan.TicksPerSecond;
			}
		}

        public TimeSpan ElapsedTime
        {
            get
            {
                return new TimeSpan(ElapsedTicks);
            }
        }
	}
}
