using System;
using System.Collections;

namespace Algorithms.ArraySort
{
	public class QuickSort
	{
		public ICollection Sort(int[] input)
		{
			SortRecursive(input, 0, input.Length - 1);
			return input;
		}

		private void SortRecursive(int[] elements, int left, int right)
		{
			int i = left, j = right;
			int pivot = elements[(left + right)/2];

			while (i <= j)
			{
				while (elements[i] < pivot)
				{
					i++;
				}
				while (elements[j] > pivot)
				{
					j--;
				}
				if (i <= j)
				{
					int tmp = elements[i];
					elements[i] = elements[j];
					elements[j] = tmp;
					i++;
					j--;
				}
			}

			if (left < j)
			{
				SortRecursive(elements, left, j);
			}
			if (i < right)
			{
				SortRecursive(elements, i, right);
			}
		}
	}
}
