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

        #region Identity methods

        [TestMethod]
        public void Identity_NullAsBothParams_ResultTrue()
        {
            // arrange
            Triangle triangle1 = null;
            Triangle triangle2 = null;
            bool expected = true;

            // act
            bool result1 = triangle1 == triangle2;
            bool result2 = triangle2 == triangle1;

            // assert
            Assert.AreEqual(expected, result1);
            Assert.AreEqual(expected, result2);
        }

        [TestMethod]
        public void Identity_OneNullParam_ResultFalse()
        {
            // arrange
            Triangle triangle1 = null;
            Triangle triangle2 = new Triangle(1, 1, 1);
            bool expected = false;

            // act
            bool result1 = triangle1 == triangle2;
            bool result2 = triangle2 == triangle1;

            // assert
            Assert.AreEqual(expected, result1);
            Assert.AreEqual(expected, result2);
        }

        [TestMethod]
        public void Identity_CorrectBothParams__ReturnTrue()
        {
            // arrange
            Triangle triangle1 = new Triangle(1, 2, 3);
            Triangle triangle2 = new Triangle(1, 2, 3);
            bool expected = true;

            // act
            bool result1 = triangle1 == triangle2;
            bool result2 = triangle2 == triangle1;

            // assert
            Assert.AreEqual(expected, result1);
            Assert.AreEqual(expected, result2);
        }

        [TestMethod]
        public void Identity_CorrectBothParams__ReturnFalse()
        {
            // arrange
            Triangle triangle1 = new Triangle(1, 2, 3);
            Triangle triangle2 = new Triangle(2, 3, 1);
            bool expected = false;

            // act
            bool result1 = triangle1 == triangle2;
            bool result2 = triangle2 == triangle1;

            // assert
            Assert.AreEqual(expected, result1);
            Assert.AreEqual(expected, result2);
        }
        #endregion

        #region Equals (congruent) methods

        [TestMethod]
        public void Equals_NullParam_ResultFalse()
        {
            // arrange
            Triangle triangle1 = new Triangle(1, 1, 1);
            Triangle triangle2 = null;
            bool expected = false;

            // act
            bool result1 = triangle1.Equals(triangle2);

            // assert
            Assert.AreEqual(expected, result1);
        }

        [TestMethod]
        public void Equals_CorrectParam__ReturnTrue()
        {
            // arrange
            Triangle triangle1 = new Triangle(1, 2, 3);
            Triangle triangle2 = new Triangle(3, 1, 2);
            bool expected = true;

            // act
            bool result1 = triangle1.Equals(triangle2);
            bool result2 = triangle2.Equals(triangle1);
            bool result3 = triangle1.Equals(triangle1);

            // assert
            Assert.AreEqual(expected, result1);
            Assert.AreEqual(expected, result2);
            Assert.AreEqual(expected, result3);
        }

        [TestMethod]
        public void Identity_CorrectParam__ReturnFalse()
        {
            // arrange
            Triangle triangle1 = new Triangle(1, 2, 3);
            Triangle triangle2 = new Triangle(2, 3, 2);
            bool expected = false;

            // act
            bool result1 = triangle1.Equals(triangle2);
            bool result2 = triangle2.Equals(triangle1);

            // assert
            Assert.AreEqual(expected, result1);
            Assert.AreEqual(expected, result2);
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
