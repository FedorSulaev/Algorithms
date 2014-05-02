using Algorithms.InversionCounting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests.InversionCounting
{
	[TestClass]
	public class NLogNTests
	{
		private NLogN _nLogN = new NLogN();

		[TestMethod]
		public void Count_2Elements12_Return0()
		{
			Assert.AreEqual(0, _nLogN.Count(new []{1,2}));
		}

		[TestMethod]
		public void Count_2Elements21_Return1()
		{
			Assert.AreEqual(1, _nLogN.Count(new []{2,1}));
		}

		[TestMethod]
		public void Count_3Elements132_Return1()
		{
			Assert.AreEqual(1, _nLogN.Count(new []{1,3,2}));
		}

		[TestMethod]
		public void Count_6Elements135246_Return3()
		{
			Assert.AreEqual(3, _nLogN.Count(new []{1,3,5,2,4,6}));
		}
	}
}
