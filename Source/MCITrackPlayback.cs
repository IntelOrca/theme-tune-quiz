using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace IntelOrca.TTQ
{
	class MCITrackPlayback : ITrackPlayback
	{
		[DllImport("winmm.dll")]
		private static extern int mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
		[DllImport("winmm.dll")]
		private static extern int mciGetErrorString(int errCode, StringBuilder errMsg, int buflen);

		private string mMediaKey;

		public MCITrackPlayback()
		{
			Random r = new Random();
			for (int i = 0; i < 8; i++)
				mMediaKey += (char)r.Next('a', 'z');
		}

		public bool Playing
		{
			get
			{
				StringBuilder sb = new StringBuilder(128);
				if (mciSendString("status " + mMediaKey + " mode", sb, sb.Capacity, IntPtr.Zero) == 0)
					return sb.ToString().StartsWith("playing");
				else
					return false;
			}
			set
			{
				if (value)
					mciSendString("play " + mMediaKey, null, 0, IntPtr.Zero);
				else
					mciSendString("stop " + mMediaKey, null, 0, IntPtr.Zero);
			}
		}

		public double CurrentPosition
		{
			get
			{
				StringBuilder sb = new StringBuilder(128);
				if (mciSendString("status " + mMediaKey + " position", sb, sb.Capacity, IntPtr.Zero) == 0)
					return Int32.Parse(sb.ToString()) / 1000.0;
				else
					return 0.0;
			}
			set
			{
				if (Playing) {
					mciSendString("play " + mMediaKey + " from " + (int)(value * 1000.0), null, 0, IntPtr.Zero);
				} else {
					mciSendString("seek " + mMediaKey + " to " + (int)(value * 1000.0), null, 0, IntPtr.Zero);
				}
			}
		}

		public double Length
		{
			get
			{
				StringBuilder sb = new StringBuilder(128);
				if (mciSendString("status " + mMediaKey + " length", sb, sb.Capacity, IntPtr.Zero) == 0)
					return Int32.Parse(sb.ToString()) / 1000.0;
				else
					return 0;
			}
		}

		public void Load(string path)
		{
			Close();
			if (Path.GetExtension(path).ToLower() == ".mp3")
				mciSendString("open \"" + path + "\" type mpegvideo alias " + mMediaKey, null, 0, IntPtr.Zero);
			else if (Path.GetExtension(path).ToLower() == ".wav")
				mciSendString("open \"" + path + "\" type waveaudio alias " + mMediaKey, null, 0, IntPtr.Zero);
		}

		public void Close()
		{
			mciSendString("close " + mMediaKey, null, 0, IntPtr.Zero);
		}
	}
}
