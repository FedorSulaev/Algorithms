using System;
using Algorithms.ClosestPairOfPoints;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests.ClosestPairOfPoints
{
	[TestClass]
	public class NLogNTests
	{
		private NLogN _nlogN = new NLogN();

		[TestMethod]
		public void GetClosestPair_4Points_ReturnClosest()
		{
			float[] point1 = {1, 1};
			float[] point2 = {2, 2};
			float[] point3 = {10, 10};
			float[] point4 = {5, 5};
			float[][] result = _nlogN.GetClosestPair(new []{point1, point2, point3, point4});
			Assert.AreEqual(1f, result[0][0]);
			Assert.AreEqual(1f, result[0][1]);
			Assert.AreEqual(2f, result[1][0]);
			Assert.AreEqual(2f, result[1][1]);
		}
	}
}
