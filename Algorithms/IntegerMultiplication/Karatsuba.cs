using System;

namespace Algorithms.IntegerMultiplication
{
	public class Karatsuba
	{
		public int Multiply(int int1, int int2)
		{
			if (int1 < 10 || int2 < 10)
			{
				return int1*int2;
			}
			int n = Math.Min(int1.ToString().Length, int2.ToString().Length);
			int b;
			int a = Math.DivRem(int1, (int) Math.Pow(10, (int) (n/2)), out b);
			int d;
			int c = Math.DivRem(int2, (int) Math.Pow(10, (int) (n/2)), out d);
			int step1 = Multiply(a, c);
			int step2 = Multiply(b, d);
			int step3 = Multiply((a + b), (c + d));
			int step4 = step3 - step2 - step1;
			return step1*(int) Math.Pow(10, n) + step2 + step4*(int) Math.Pow(10, n/2);
		}
	}
}
