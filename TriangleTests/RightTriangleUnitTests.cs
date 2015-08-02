using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangles;

namespace TriangleTests
{
    [TestClass]
    public class RightTriangleUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(Triangles.Triangle.TriangleException))]
        public void CreateRightTriangle_NotSatisfyNumberParams()
        {
            // arrange
            double side_a = 1.0;
            double side_b = 1.0;
            double side_c = 1.0;

            // act
            RightTriangle rightTriangle = new RightTriangle(side_a, side_b, side_c);

            // assert
        }

        [TestMethod]
        public void GetArea_RightTriangle_Calculated()
        {
            // arrange
            double side_a = 3.0;
            double side_b = 4.0;
            double side_c = 5.0;
            double expected = 6.0;
            Triangle triangle = new Triangle(side_a, side_b, side_c);

            // act
            double area = triangle.Area;

            // assert
            Assert.AreEqual(expected, area, 0.0001, "Area not calculated correctly");
        }
    }
}
