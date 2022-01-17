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

            Assert.True(false);
            // Arrange
            Point[] points = new Point[]
            {
                new Point(0, 0),
                new Point(2, 4),
                new Point(3, 6),
                new Point(1, 3)
            };

            SmallestDistanceBetweenPoints smallestDistanceBetweenPoints = new SmallestDistanceBetweenPoints();

            int expectedOutput = 5;

            // Act
            int actualOutput = smallestDistanceBetweenPoints.FindSmallestDistanceBetweenPoints(points);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
