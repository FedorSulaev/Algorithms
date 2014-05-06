using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Algorithms.ClosestPairOfPoints
{
	class Segment
	{
		public Segment(PointF p1, PointF p2)
		{
			P1 = p1;
			P2 = p2;
		}

		public readonly PointF P1;
		public readonly PointF P2;

		public float Length()
		{
			return (float)Math.Sqrt(LengthSquared());
		}

		public float LengthSquared()
		{
			return (P1.X - P2.X) * (P1.X - P2.X)
				+ (P1.Y - P2.Y) * (P1.Y - P2.Y);
		}
	}

	public class NLogN
	{
		public float[][] GetClosestPair(float[][] points)
		{
			List<PointF> input = points.Select(p => new PointF(p[0], p[1])).ToList();
			Segment result = ClosestRecursive(input.OrderBy(p => p.X).ToList());
			return new[] { new [] { result.P1.X, result.P1.Y }, new [] { result.P2.X, result.P2.Y } };
		}

		private Segment ClosestRecursive(List<PointF> pointsByX)
		{
			int count = pointsByX.Count;
			if (count <= 4)
			{
				return ClosestBruteForce(pointsByX);
			}
			List<PointF> leftByX = pointsByX.Take(count/2).ToList();
			Segment leftResult = ClosestRecursive(leftByX);
			List<PointF> rightByX = pointsByX.Skip(count/2).ToList();
			Segment rightResult = ClosestRecursive(rightByX);
			Segment result = rightResult.Length() < leftResult.Length() ? rightResult : leftResult;
			float midX = leftByX.Last().X;
			var bandWidth = result.Length();
			var inBandByX = pointsByX.Where(p => Math.Abs(midX - p.X) <= bandWidth);
			var inBandByY = inBandByX.OrderBy(p => p.Y).ToArray();
			int iLast = inBandByY.Length - 1;
			for (int i = 0; i < iLast; i++)
			{
				var pLower = inBandByY[i];

				for (int j = i + 1; j <= iLast; j++)
				{
					var pUpper = inBandByY[j];
					if ((pUpper.Y - pLower.Y) >= result.Length())
						break;

					if (new Segment(pLower, pUpper).Length() < result.Length())
						result = new Segment(pLower, pUpper);
				}
			}

			return result;
		}

		private Segment ClosestBruteForce(List<PointF> points)
		{
			int n = points.Count;
			Segment result = Enumerable.Range(0, n - 1).SelectMany(i => Enumerable.Range(i + 1, n - (i + 1))
				.Select(j => new Segment(points[i], points[j])))
				.OrderBy(seg => seg.LengthSquared()).First();
			return result;
		}
	}
}
