namespace Algorithms.Part1.Search
{
    public partial class SmallestDistanceBetweenPoints
    {
        // It's assumed that no two points have the same x or y coordinate
        public int FindSmallestDistanceBetweenPoints(Point[] points)
        {
            var xCoordinateSorted = points.OrderBy(p => p.xCoordinate).ToList();
            var yCoordinateSorted = points.OrderBy(p => p.yCoordinate).ToList();

            return CalculateSmallestDistance(xCoordinateSorted, yCoordinateSorted);
        }

        private int CalculateSmallestDistance(List<Point> xCoordinateSorted, List<Point> yCoordinateSorted)
        {
            if (xCoordinateSorted.Count() <= 3)
            {
                return CalculateBaseCaseDistance(xCoordinateSorted);
            }

            int middleIndex = xCoordinateSorted.Count() / 2;

            var leftHalfXSorted = xCoordinateSorted.Take(middleIndex).ToList();
            var rightHalfXSorted = xCoordinateSorted.Skip(middleIndex).ToList();

            var leftHalfYSorted = yCoordinateSorted.Where(point => leftHalfXSorted.Contains(point)).ToList();
            var rightHalfYSorted = yCoordinateSorted.Where(point => rightHalfXSorted.Contains(point)).ToList();

            int leftSmallestDistance = CalculateSmallestDistance(leftHalfXSorted, leftHalfYSorted);
            int rightSmallestDistance = CalculateSmallestDistance(rightHalfXSorted, rightHalfYSorted);

            int delta = Math.Min(leftSmallestDistance, rightSmallestDistance);

            int minSplitPairDistance = CalculateClosestSplitDistance(xCoordinateSorted, yCoordinateSorted, delta);

            return Math.Min(minSplitPairDistance, delta);
        }

        private int CalculateBaseCaseDistance(List<Point> xCoordinateSorted)
        {
            if (xCoordinateSorted.Count() == 2)
            {
                return CalculateDistanceBetweenPoints(xCoordinateSorted[0], xCoordinateSorted[1]);
            }

            else
            {
                int dist1 = CalculateDistanceBetweenPoints(xCoordinateSorted[0], xCoordinateSorted[1]);
                int dist2 = CalculateDistanceBetweenPoints(xCoordinateSorted[0], xCoordinateSorted[2]);
                int dist3 = CalculateDistanceBetweenPoints(xCoordinateSorted[1], xCoordinateSorted[2]);

                int minDist1 = Math.Min(dist1, dist2);

                return Math.Min(minDist1, dist3);
            }
        }

        private int CalculateClosestSplitDistance(List<Point> xCoordinateSorted, List<Point> yCoordinateSorted, int delta)
        {
            int middleIndex = xCoordinateSorted.Count() / 2 - 1;
            Point middlePoint = xCoordinateSorted[middleIndex];

            // Find y-sorted points that are delta away from the middle point
            List<Point> candidatePoints = yCoordinateSorted.
                Where((point) => Math.Abs(point.xCoordinate - middlePoint.xCoordinate) <= delta).ToList();

            int minDist = int.MaxValue;

            for (int firstPointIndex = 0; firstPointIndex < candidatePoints.Count() - 1; firstPointIndex++)
            {
                int endingIndex = Math.Min(firstPointIndex + 7, candidatePoints.Count());

                for (int secondPointIndex = firstPointIndex + 1; secondPointIndex < endingIndex; secondPointIndex++)
                {
                    int dist = CalculateDistanceBetweenPoints(candidatePoints[firstPointIndex], candidatePoints[secondPointIndex]);

                    if (minDist > dist)
                    {
                        minDist = dist;
                    }
                }
            }

            return minDist;
        }

        private int CalculateDistanceBetweenPoints(Point point1, Point point2)
        {
            int xCoordDistance = Math.Abs(point1.xCoordinate - point2.xCoordinate);
            int yCoordDistance = Math.Abs(point1.yCoordinate - point2.yCoordinate);

            return xCoordDistance * xCoordDistance + yCoordDistance * yCoordDistance;
        }
    }
}
