using System;
using System.Linq;

namespace Algorithms.IntegerMultiplication
{
	public class ThirdGrade
	{
		public int Multiply(int a, int b)
		{
			byte[] aNums = a.ToString().Select(c => byte.Parse(c.ToString())).ToArray();
			byte[] bNums = b.ToString().Select(c => byte.Parse(c.ToString())).ToArray();
			return Multiply(aNums, bNums);
		}

		private int Multiply(byte[] aNums, byte[] bNums)
		{
			int result = 0;
			for (int i = bNums.Count()-1; i >= 0; i--)
			{
				result += Multiply(aNums, bNums[i]*(int)(Math.Pow(10, (bNums.Count() - (i+1)))));
			}
			return result;
		}

		private int Multiply(byte[] aNums, int bNum)
		{
			int result = 0;
			for (int i = aNums.Count()-1; i >= 0; i--)
			{
				result += bNum*aNums[i]*(int)(Math.Pow(10, (aNums.Count() - (i+1))));
			}
			return result;
		}
	}
}
