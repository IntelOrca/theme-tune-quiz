////////////////////////////////////
// Theme Tune Quiz (TTQ)          //
// Copyright (C) Ted John 2012    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace IntelOrca.TTQ
{
	static class Announcer
	{
		private static bool mFirstNumber;

		public static byte[] GetNumber(long number)
		{
			List<byte[]> soundList = new List<byte[]>();

			mFirstNumber = true;

			//Track
			soundList.Add(GetSoundData("track"));

			if (number == 0) {
				soundList.Add(GetSoundData(0));
			} else {
				//Negative
				if (number < 0) {
					soundList.Add(GetSoundData("minus"));
					number = Math.Abs(number);
				}

				string sNumber = number.ToString();
				string digits = sNumber.Substring(sNumber.Length - sNumber.Length, sNumber.Length);

				switch (sNumber.Length) {
					case 1:
					case 2:
						soundList.AddRange(GetTensAndUnits(digits));
						break;
					case 3:
						soundList.AddRange(GetHundreds(digits));
						break;
					case 4:
					case 5:
					case 6:
						soundList.AddRange(GetThousands(digits));
						break;
					case 7:
					case 8:
					case 9:
						soundList.AddRange(GetMillions(digits));
						break;
					case 10:
					case 11:
					case 12:
						soundList.AddRange(GetBillions(digits));
						break;
					case 13:
					case 14:
					case 15:
						soundList.AddRange(GetTrillions(digits));
						break;
				}
			}

			return CreateSample(soundList.ToArray());
		}

		private static byte[] CreateSample(byte[][] soundList)
		{
			byte[] output;
			byte[] startHeader = File.ReadAllBytes(GetSoundFilename("header"));

			//Calculate sound data chunk size
			long chunkSize = 0;
			for (long i = 0; i < soundList.Length; i++) {
				chunkSize += soundList[i].Length;
			}

			//Write data
			MemoryStream ms = new MemoryStream();
			BinaryWriter bw = new BinaryWriter(ms);

			bw.Write(startHeader);
			bw.Write(chunkSize);

			for (long i = 0; i < soundList.Length; i++) {
				bw.Write(soundList[i]);
			}

			bw.Close();

			output = ms.ToArray();
			ms.Close();

			return output;
		}

		private static byte[][] GetTrillions(string digits)
		{
			List<byte[]> soundList = new List<byte[]>();

			long number = Convert.ToInt64(digits);

			if (digits.Length < 15)
				digits = digits.Insert(0, new String('0', 15 - digits.Length));

			//Add the first hundred
			if (number / 100000000000 > 0) {
				soundList.AddRange(GetHundreds(digits.Substring(0, 3)));
				soundList.Add(GetSoundData("trillion"));
			}

			//Add the second million
			soundList.AddRange(GetBillions(digits.Substring(3, 12)));

			return soundList.ToArray();
		}

		private static byte[][] GetBillions(string digits)
		{
			List<byte[]> soundList = new List<byte[]>();

			long number = Convert.ToInt64(digits);

			if (digits.Length < 12)
				digits = digits.Insert(0, new String('0', 12 - digits.Length));

			//Add the first hundred
			if (number / 100000000 > 0) {
				soundList.AddRange(GetHundreds(digits.Substring(0, 3)));
				soundList.Add(GetSoundData("billion"));
			}

			//Add the second million
			soundList.AddRange(GetMillions(digits.Substring(3, 9)));

			return soundList.ToArray();
		}

		private static byte[][] GetMillions(string digits)
		{
			List<byte[]> soundList = new List<byte[]>();

			long number = Convert.ToInt64(digits);

			if (digits.Length < 9)
				digits = digits.Insert(0, new String('0', 9 - digits.Length));

			//Add the first hundred
			if (number / 1000000 > 0) {
				soundList.AddRange(GetHundreds(digits.Substring(0, 3)));
				soundList.Add(GetSoundData("million"));
			}

			//Add the second thousand
			soundList.AddRange(GetThousands(digits.Substring(3, 6)));

			return soundList.ToArray();
		}

		private static byte[][] GetThousands(string digits)
		{
			List<byte[]> soundList = new List<byte[]>();

			long number = Convert.ToInt64(digits);

			if (digits.Length < 6)
				digits = digits.Insert(0, new String('0', 6 - digits.Length));

			//Add the first lot of hundreds
			if (number / 1000 > 0) {
				soundList.AddRange(GetHundreds(digits.Substring(0, 3)));
				soundList.Add(GetSoundData("thousand"));
			}

			//Add the second lot of hundreds
			soundList.AddRange(GetHundreds(digits.Substring(3, 3)));

			return soundList.ToArray();
		}

		private static byte[][] GetHundreds(string digits)
		{
			List<byte[]> soundList = new List<byte[]>();

			long number = Convert.ToInt64(digits);

			//Add the hundreds
			long n1 = number / 100;
			if (number / 100 > 0) {
				soundList.Add(GetSoundData(n1));
				soundList.Add(GetSoundData("hundred"));
			}

			if (number % 100 > 0 && !mFirstNumber) {
				//Add the 'and'
				soundList.Add(GetSoundData("and"));
			}

			//Add the tens and units
			soundList.AddRange(GetTensAndUnits(digits.Substring(1, 2)));

			//Return the sounds
			return soundList.ToArray();
		}

		private static byte[][] GetTensAndUnits(string digits)
		{
			long number = Convert.ToInt64(digits);
			if (digits.Length > 1) {
				if (number == 0)
					return new byte[][] { };

				if (number < 20 || number % 10 == 0) {
					return new byte[][] { GetSoundData(number) };
				} else {
					long n1 = (number / 10) * 10;
					long n2 = number % 10;

					return new byte[][] { GetSoundData(n1), GetSoundData(n2) };
				}
			} else {
				return new byte[][] { GetSoundData(number) };
			}
		}

		private static byte[] GetSoundData(long name)
		{
			mFirstNumber = false;

			return GetSoundData(name.ToString());
		}

		private static byte[] GetSoundData(string name)
		{
			return File.ReadAllBytes(GetSoundFilename(name));
		}

		private static string GetSoundFilename(string name)
		{
			return String.Format(Application.StartupPath + "\\Announcer\\{0}.dat", name);
		}

		public static void PlaySound(string filename)
		{
			SoundPlayer sp = new SoundPlayer(GetSoundFilename(filename));
			sp.PlaySync();
		}

		public static void PlaySound(byte[] data)
		{
			MemoryStream ms = new MemoryStream(data);
			SoundPlayer sp = new SoundPlayer(ms);
			sp.PlaySync();
		}
	}
}
