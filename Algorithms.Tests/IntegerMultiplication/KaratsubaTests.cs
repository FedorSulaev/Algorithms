using System;
using Algorithms.IntegerMultiplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests.IntegerMultiplication
{
	[TestClass]
	public class KaratsubaTests
	{
		private readonly Karatsuba _karatsuba = new Karatsuba();

		[TestMethod]
		public void Multiply_1Times1_Return1()
		{
			Assert.AreEqual(1, _karatsuba.Multiply(1, 1));
		}

		[TestMethod]
		public void Multiply_2Times3_Return6()
		{
			Assert.AreEqual(6, _karatsuba.Multiply(2, 3));
		}

		[TestMethod]
		public void Multiply_10Times10_Return100()
		{
			Assert.AreEqual(100, _karatsuba.Multiply(10, 10));
		}

		[TestMethod]
		public void Multiply_5678Times1234_Return7006652()
		{
			Assert.AreEqual(7006652, _karatsuba.Multiply(5678, 1234));
		}
	}
}
