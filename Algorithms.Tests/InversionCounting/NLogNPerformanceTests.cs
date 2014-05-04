using System.IO;
using System.Linq;
using Algorithms.InversionCounting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests.InversionCounting
{
	[TestClass]
	public class NLogNPerformanceTests
	{
		[TestMethod]
		public void Count_LargeArray_CountInReasonableTime()
		{
			NLogN nLogN = new NLogN();
			int[] input = File.ReadAllLines(@"D:\IntegerArray.txt").Select(int.Parse).ToArray();
			Assert.AreEqual(2407905288, nLogN.Count(input));
		}
	}
}
