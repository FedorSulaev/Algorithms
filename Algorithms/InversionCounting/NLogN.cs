using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.InversionCounting
{
	public class NLogN
	{
		public long Count(int[] elements)
		{
			return SortAndCount(elements.ToList()).Item1;
		}

		public Tuple<long, List<int>> SortAndCount(List<int> list)
		{
			if (list.Count <= 1)
				return new Tuple<long, List<int>>(0, list);

			int middle = list.Count / 2;
			var leftList = list.GetRange(0, middle);
			var rightList = list.GetRange(middle, list.Count - leftList.Count);

			Tuple<long, List<int>> leftResult = SortAndCount(leftList);
			Tuple<long, List<int>> rightResult = SortAndCount(rightList);

			Tuple<long, List<int>> mergeResult = MergeAndCount(leftResult.Item2, rightResult.Item2);

			return new Tuple<long, List<int>>(leftResult.Item1 + rightResult.Item1 + mergeResult.Item1,
			mergeResult.Item2);
		}

		private Tuple<long, List<int>> MergeAndCount(List<int> leftList, List<int> rightList)
		{
			long inversions = 0;
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

			return new Tuple<long, List<int>>(inversions, outputList);
		}
	}
}
