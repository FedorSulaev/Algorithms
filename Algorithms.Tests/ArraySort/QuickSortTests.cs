using Algorithms.ArraySort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests.ArraySort
{
	[TestClass]
	public class QuickSortTests
	{
		private QuickSort _quickSort = new QuickSort();

		[TestMethod]
		public void Sort_1Element_Return1Element()
		{
			int[] input = { 1 };
			CollectionAssert.AreEqual(input, _quickSort.Sort(input));
		}

		[TestMethod]
		public void Sort_2UnsortedElements_ReturnSame2SortedElements()
		{
			CollectionAssert.AreEqual(new[] { 1, 2 }, _quickSort.Sort(new[] { 2, 1 }));
		}

		[TestMethod]
		public void Sort_5UnsortedElements_ReturnSame5SortedElements()
		{
			CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, _quickSort.Sort(new[] { 3, 4, 2, 5, 1 }));
		}
	}
}
