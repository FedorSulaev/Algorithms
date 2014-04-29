using System;

namespace Algorithms.ArraySort
{
	public class Merge
	{
		public int[] Sort(int[] input)
		{
			if (input.Length <= 1)
			{
				return input;
			}
			int firstHalfLength = input.Length/2;
			int secondHalfLength = input.Length - firstHalfLength;
			int[] firstHalf = new int[firstHalfLength];
			int[] secondHalf = new int[secondHalfLength];
			Array.Copy(input, 0, firstHalf, 0, firstHalfLength);
			Array.Copy(input, firstHalfLength, secondHalf, 0, secondHalfLength);
			int[] A = Sort(firstHalf);
			int[] B = Sort(secondHalf);
			return MergeArrays(A, B);
		}

		private int[] MergeArrays(int[] firstHalf, int[] secondHalf)
		{
			int firstHalfLength = firstHalf.Length;
			int secondHalfLength = secondHalf.Length;
			int[] mergedArray = new int[firstHalfLength + secondHalfLength];
			int i = 0;
			int j = 0;
			for (int k = 0; k < mergedArray.Length; k++)
			{
				if (i >= firstHalfLength)
				{
					mergedArray[k] = secondHalf[j];
					continue;
				}
				if (j >= secondHalfLength)
				{
					mergedArray[k] = firstHalf[i];
					continue;
				}

				if (firstHalf[i] <= secondHalf[j])
				{
					mergedArray[k] = firstHalf[i];
					i++;
				}
				else if (secondHalf[j] < firstHalf[i])
				{
					mergedArray[k] = secondHalf[j];
					j++;
				}
			}
			return mergedArray;
		}
	}
}