using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Algorithms.Part1.Search;
using static Algorithms.Part1.Search.SmallestDistanceBetweenPoints;

namespace Algorithms.Part1.Tests.Search
{
    public class SmallestDistanceBetweenPointsTests
    {
        [Fact]
        public void ThreePoints()
        {
            // Arrange
            Point[] points = new Point[]
            {
                new Point(0, 0),
                new Point(1, 1),
                new Point(2, 4)
            };

            SmallestDistanceBetweenPoints smallestDistanceBetweenPoints = new SmallestDistanceBetweenPoints();

            int expectedOutput = 2;

            // Act
            int actualOutput = smallestDistanceBetweenPoints.FindSmallestDistanceBetweenPoints(points);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FourPoints_MinDistOnTheLeftSide()
        {
            // Arrange
            Point[] points = new Point[]
            {
                new Point(0, 0),
                new Point(2, 4),
                new Point(3, 6),
                new Point(1, -1)
            };

            SmallestDistanceBetweenPoints smallestDistanceBetweenPoints = new SmallestDistanceBetweenPoints();

            int expectedOutput = 2;

            // Act
            int actualOutput = smallestDistanceBetweenPoints.FindSmallestDistanceBetweenPoints(points);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FourPoints_MinDistOnTheRightSide()
        {
            // Arrange
            Point[] points = new Point[]
            {
                new Point(0, 0),
                new Point(2, 4),
                new Point(3, 6),
                new Point(1, -10)
            };

            SmallestDistanceBetweenPoints smallestDistanceBetweenPoints = new SmallestDistanceBetweenPoints();

            int expectedOutput = 5;

            // Act
            int actualOutput = smallestDistanceBetweenPoints.FindSmallestDistanceBetweenPoints(points);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void FourPoints_MinDistInTheSplit()
        {
            // Arrange
            Point[] points = new Point[]
            {
                new Point(0, 0),
                new Point(2, 4),
                new Point(3, -4),
                new Point(1, -3)
            };

            SmallestDistanceBetweenPoints smallestDistanceBetweenPoints = new SmallestDistanceBetweenPoints();

            int expectedOutput = 5;

            // Act
            int actualOutput = smallestDistanceBetweenPoints.FindSmallestDistanceBetweenPoints(points);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void EvenNumberOfPoints_MinDistInTheBeginning()
        {
            // Arrange
            Point[] points = new Point[100];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(i * 2, i * 2);
            }

            points[0].xCoordinate = points[0].xCoordinate + 1;
            points[0].yCoordinate = points[0].yCoordinate + 1;

            SmallestDistanceBetweenPoints smallestDistanceBetweenPoints = new SmallestDistanceBetweenPoints();

            int expectedOutput = 2;

            // Act
            int actualOutput = smallestDistanceBetweenPoints.FindSmallestDistanceBetweenPoints(points);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void EvenNumberOfPoints_MinDistInTheSplit()
        {
            // Arrange
            Point[] points = new Point[100];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(i * 2, i * 2);
            }

            int midPoint = points.Length / 2 - 1;

            points[midPoint].xCoordinate = points[midPoint].xCoordinate + 1;
            points[midPoint].yCoordinate = points[midPoint].yCoordinate + 1;

            SmallestDistanceBetweenPoints smallestDistanceBetweenPoints = new SmallestDistanceBetweenPoints();

            int expectedOutput = 2;

            // Act
            int actualOutput = smallestDistanceBetweenPoints.FindSmallestDistanceBetweenPoints(points);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void OddNumberOfPoints_MinDistInTheBeginning()
        {
            // Arrange
            Point[] points = new Point[101];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(i * 2, i * 2);
            }

            points[0].xCoordinate = points[0].xCoordinate + 1;
            points[0].yCoordinate = points[0].yCoordinate + 1;

            SmallestDistanceBetweenPoints smallestDistanceBetweenPoints = new SmallestDistanceBetweenPoints();

            int expectedOutput = 2;

            // Act
            int actualOutput = smallestDistanceBetweenPoints.FindSmallestDistanceBetweenPoints(points);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void OddNumberOfPoints_MinDistInTheSplit()
        {
            // Arrange
            Point[] points = new Point[101];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(i * 2, i * 2);
            }

            int midPoint = points.Length / 2 ;

            points[midPoint].xCoordinate = points[midPoint].xCoordinate + 1;
            points[midPoint].yCoordinate = points[midPoint].yCoordinate + 1;

            SmallestDistanceBetweenPoints smallestDistanceBetweenPoints = new SmallestDistanceBetweenPoints();

            int expectedOutput = 2;

            // Act
            int actualOutput = smallestDistanceBetweenPoints.FindSmallestDistanceBetweenPoints(points);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void PointsWithTheSameXValue()
        {
            // Arrange
            Point[] points = new Point[101];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(0, i * 2);
            }

            int midPoint = points.Length / 2;

            points[midPoint].xCoordinate = points[midPoint].xCoordinate + 1;
            points[midPoint].yCoordinate = points[midPoint].yCoordinate + 1;

            SmallestDistanceBetweenPoints smallestDistanceBetweenPoints = new SmallestDistanceBetweenPoints();

            int expectedOutput = 2;

            // Act
            int actualOutput = smallestDistanceBetweenPoints.FindSmallestDistanceBetweenPoints(points);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void PointsWithTheSameYValue()
        {
            // Arrange
            Point[] points = new Point[101];

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(i * 2, 0);
            }

            int midPoint = points.Length / 2;

            points[midPoint].xCoordinate = points[midPoint].xCoordinate + 1;
            points[midPoint].yCoordinate = points[midPoint].yCoordinate + 1;

            SmallestDistanceBetweenPoints smallestDistanceBetweenPoints = new SmallestDistanceBetweenPoints();

            int expectedOutput = 2;

            // Act
            int actualOutput = smallestDistanceBetweenPoints.FindSmallestDistanceBetweenPoints(points);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
