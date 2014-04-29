using Algorithms.ArraySort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests.ArraySort
{
	[TestClass]
	public class MergeTests
	{
		Merge _merge = new Merge();

		[TestMethod]
		public void Sort_1Element_Return1Element()
		{
			int[] input = {1};
			CollectionAssert.AreEqual(input, _merge.Sort(input));
		}

		[TestMethod]
		public void Sort_2UnsortedElements_ReturnSame2SortedElements()
		{
			CollectionAssert.AreEqual(new[]{1,2}, _merge.Sort(new []{2,1}));
		}

		[TestMethod]
		public void Sort_5UnsortedElements_ReturnSame5SortedElements()
		{
			CollectionAssert.AreEqual(new[]{1,2,3,4,5}, _merge.Sort(new [] {3,4,2,5,1}));
		}
	}
}
