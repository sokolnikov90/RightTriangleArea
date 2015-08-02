using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangles;

namespace TriangleTests
{
    [TestClass]
    public class TriangleUnitTests
    {
        #region CreateTriangle_NegativeNumberParams
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTriangle_NegativeNumberAs1stParam_ExceptionThrown()
        {
            // arrange
            double side_a = 0.0;
            double side_b = 4.0;
            double side_c = 5.0;

            // act
            Triangle triangle = new Triangle(side_a, side_b, side_c);

            // assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTriangle_NegativeNumberAs2ndParam_ExceptionThrown()
        {
            // arrange
            double side_a = 3.0;
            double side_b = -1.0;
            double side_c = 5.0;

            // act
            Triangle triangle = new Triangle(side_a, side_b, side_c);

            // assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTriangle_NegativeNumberAs3rdParam_ExceptionThrown()
        {
            // arrange
            double side_a = 3.0;
            double side_b = 4.0;
            double side_c = -1.0;

            // act
            Triangle triangle = new Triangle(side_a, side_b, side_c);

            // assert
        }

        #endregion

        #region CreateTriangle_NotSatisfyNumberParams
        [TestMethod]
        [ExpectedException(typeof(Triangles.Triangle.TriangleException))]
        public void CreateTriangle_NotSatisfyNumberAs1rdParam_ExceptionThrown()
        {
            // arrange
            double side_a = 10.0;
            double side_b = 4.0;
            double side_c = 5.0;

            // act
            Triangle triangle = new Triangle(side_a, side_b, side_c);

            // assert
        }

        [TestMethod]
        [ExpectedException(typeof(Triangles.Triangle.TriangleException))]
        public void CreateTriangle_NotSatisfyNumberAs2ndParam_ExceptionThrown()
        {
            // arrange
            double side_a = 3.0;
            double side_b = 10.0;
            double side_c = 5.0;

            // act
            Triangle triangle = new Triangle(side_a, side_b, side_c);

            // assert
        }

        [TestMethod]
        [ExpectedException(typeof(Triangles.Triangle.TriangleException))]
        public void CreateTriangle_NotSatisfyNumberAs3rdParam_ExceptionThrown()
        {
            // arrange
            double side_a = 3.0;
            double side_b = 4.0;
            double side_c = 10.0;

            // act
            Triangle triangle = new Triangle(side_a, side_b, side_c);

            // assert
        }
        #endregion

        [TestMethod]
        public void GetPerimeter_Triangle_Calculated()
        {
            // arrange
            double side_a = 3.0;
            double side_b = 4.0;
            double side_c = 5.0;
            double expected = 12.0;
            Triangle triangle = new Triangle(side_a, side_b, side_c);

            // act
            double perimeter = triangle.Perimeter;

            // assert
            Assert.AreEqual(expected, perimeter, 0.0001, "Perimeter not calculated correctly");
        }

        [TestMethod]
        public void GetArea_Triangle_Calculated()
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
