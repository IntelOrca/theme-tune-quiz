using System.IO;
using System.Text;

namespace IntelOrca.TTQ
{
	class WavePCM
	{
		private short mChannels;
		private int mFrequency;
		private short mBitsPerSample;
		private byte[] mData;

		public byte[] ToArray()
		{
			MemoryStream ms = new MemoryStream();
			BinaryWriter bw = new BinaryWriter(ms);

			// riff chunk
			bw.Write(Encoding.UTF8.GetBytes("RIFF"));
			bw.Write(36 + mData.Length);
			bw.Write(Encoding.UTF8.GetBytes("WAVE"));

			// fmt chunk
			bw.Write(Encoding.UTF8.GetBytes("fmt "));
			bw.Write(16);
			bw.Write((short)1);
			bw.Write(mChannels);
			bw.Write(mFrequency);
			bw.Write(mFrequency * mChannels * mBitsPerSample / 8);
			bw.Write((short)(mChannels * mBitsPerSample / 8));
			bw.Write(mBitsPerSample);

			// data chunk
			bw.Write(Encoding.UTF8.GetBytes("data"));
			bw.Write(mData.Length);
			bw.Write(mData);

			bw.Close();

			return ms.ToArray();
		}

		public short Channels
		{
			get
			{
				return mChannels;
			}
			set
			{
				mChannels = value;
			}
		}

		public int Frequency
		{
			get
			{
				return mFrequency;
			}
			set
			{
				mFrequency = value;
			}
		}

		public short BitsPerSample
		{
			get
			{
				return mBitsPerSample;
			}
			set
			{
				mBitsPerSample = value;
			}
		}

		public byte[] Data
		{
			get
			{
				return mData;
			}
			set
			{
				mData = value;
			}
		}
	}
}
