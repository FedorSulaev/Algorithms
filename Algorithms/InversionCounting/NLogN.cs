using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.InversionCounting
{
	public class NLogN
	{
		public int Count(int[] elements)
		{
			return SortAndCount(elements.ToList()).Item1;
		}

		public Tuple<int, List<int>> SortAndCount(List<int> list)
		{
			if (list.Count <= 1)
				return new Tuple<int, List<int>>(0, list);

			int middle = list.Count / 2;
			var leftList = list.GetRange(0, middle);
			var rightList = list.GetRange(middle, list.Count - leftList.Count);

			Tuple<int, List<int>> leftResult = SortAndCount(leftList);
			Tuple<int, List<int>> rightResult = SortAndCount(rightList);

			Tuple<int, List<int>> mergeResult = MergeAndCount(leftResult.Item2, rightResult.Item2);

			return new Tuple<int, List<int>>(leftResult.Item1 + rightResult.Item1 + mergeResult.Item1,
			mergeResult.Item2);
		}

		private Tuple<int, List<int>> MergeAndCount(List<int> leftList, List<int> rightList)
		{
			int inversions = 0;
			var outputList = new List<int>();
			int i = 0, j = 0;

			while (i < leftList.Count && j < rightList.Count)
			{
				if (leftList[i] < rightList[j])
				{
					outputList.Add(leftList[i]);
					i++;
				}
				else
				{
					outputList.Add(rightList[j]);
					j++;
					inversions += leftList.Count - i;
				}
			}

			if (i < leftList.Count)
				outputList.AddRange(leftList.GetRange(i, leftList.Count - i));
			else if (j < rightList.Count)
				outputList.AddRange(rightList.GetRange(j, rightList.Count - j));

			return new Tuple<int, List<int>>(inversions, outputList);
		}
	}
}
