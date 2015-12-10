using System;
using System.Collections.Generic;
using NUnit.Framework;
using Triangles;

namespace TrianglesUnitTests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test, TestCaseSource("TriangleConstructorExceptionDataCases")]
        public void Triangle_ExceptionTriangleSides_ThrowsException(double a, double b, double c)
        {
            GetTriangle(a, b, c);
        }

        private static IEnumerable<TestCaseData> TriangleConstructorExceptionDataCases()
        {
            yield return new TestCaseData(0, 3, 3).Throws(typeof(ArgumentOutOfRangeException));
            yield return new TestCaseData(3, -0.5, 3).Throws(typeof(ArgumentOutOfRangeException));
            yield return new TestCaseData(3, 5, -3).Throws(typeof(ArgumentOutOfRangeException));

            yield return new TestCaseData(8, 5, 2).Throws(typeof(TriangleException));
            yield return new TestCaseData(1, 6, 2).Throws(typeof(TriangleException));
            yield return new TestCaseData(3, 5, 8).Throws(typeof(TriangleException));
        }

        [Test, TestCaseSource("TriangleCheckPropertiesCases")]
        public void Triangle_ValidTriangleSides_CheckProperties(double a, double b, double c, 
            double expectedPerimeter, double expectedArea)
        {
            ITriangle triangle = GetTriangle(a, b, c);

            Assert.AreEqual(expectedPerimeter, triangle.Perimeter);
            Assert.AreEqual(expectedArea, triangle.Area, 0.0001);
            Assert.That(triangle.SideCollection[0] == a);
            Assert.That(triangle.SideCollection[1] == b);
            Assert.That(triangle.SideCollection[2] == c);
        }

        private static IEnumerable<TestCaseData> TriangleCheckPropertiesCases()
        {
            yield return new TestCaseData(1, 1, 1, 3.0, 0.433);
            yield return new TestCaseData(3.5, 4.5, 7.1, 15.1, 6.47824);
        }

        [Test, TestCaseSource("TestTrianglePairsForEquals")]
        public void Equals_TestTriangles_Correct(Triangle triangle1, Triangle triangle2, bool isEquals)
        {
            object objTriangle1 = triangle1;
            object objTriangle2 = triangle2;
            string errorMessage = triangle1 + "; " + triangle2;

            bool result1 = triangle1.Equals(triangle2);
            bool result2 = triangle2.Equals(triangle1);
            bool result3 = triangle1.Equals(objTriangle2);
            bool result4 = triangle2.Equals(objTriangle1);

            Assert.That(result1 == isEquals, errorMessage);
            Assert.That(result2 == isEquals, errorMessage);
            Assert.That(result3 == isEquals, errorMessage);
            Assert.That(result4 == isEquals, errorMessage);
        }

        private static IEnumerable<TestCaseData> TestTrianglePairsForEquals()
        {
            ITriangle triangle = GetTriangle(2, 2.5, 3);
            yield return new TestCaseData(triangle, triangle, true);
            yield return new TestCaseData(GetTriangle(2, 2.5, 3), GetTriangle(2, 2.5, 3), true);
            yield return new TestCaseData(GetTriangle(2, 2.5, 3), GetTriangle(2, 2.5, 3.000001), true);
            yield return new TestCaseData(GetTriangle(2, 2.5, 3), GetTriangle(2, 2.5, 3.00001), false);
            yield return new TestCaseData(GetTriangle(1.5, 2, 3), GetTriangle(2, 3, 1.5), false);
        }

        [Test]
        public void Equality_NullTriangles_False()
        {
            Triangle triangle1 = new Triangle(2, 2.5, 4);
            Triangle triangle2 = null;
            object objTriangle2 = null;

            bool result1 = triangle1.Equals(triangle2);
            bool result2 = triangle1.Equals(objTriangle2);

            Assert.That(result1 == false);
            Assert.That(result2 == false);
        }

        [Test, TestCaseSource("TestTrianglePairsForCongruent")]
        public void Congruent_TestTriangles_Correct(Triangle triangle1, Triangle triangle2, bool isEquals)
        {
            string errorMessage = triangle1 + "; " + triangle2;

            bool result1 = triangle1 == triangle2;
            bool result2 = triangle2 == triangle1;

            Assert.That(result1 == isEquals, errorMessage);
            Assert.That(result2 == isEquals, errorMessage);
        }

        [Test, TestCaseSource("TestTrianglePairsForCongruent")]
        public void NotCongruent_TestTriangles_Correct(Triangle triangle1, Triangle triangle2, bool isEquals)
        {
            string errorMessage = triangle1 + "; " + triangle2;

            bool result1 = triangle1 != triangle2;
            bool result2 = triangle2 != triangle1;

            Assert.That(result1 != isEquals, errorMessage);
            Assert.That(result2 != isEquals, errorMessage);
        }

        private static IEnumerable<TestCaseData> TestTrianglePairsForCongruent()
        {
            ITriangle triangle = GetTriangle(2, 2.5, 3);
            yield return new TestCaseData(triangle, triangle, true);
            yield return new TestCaseData(GetTriangle(2, 2.5, 3), GetTriangle(2, 2.5, 3), true);
            yield return new TestCaseData(GetTriangle(2, 2.5, 3), GetTriangle(2, 2.5, 3.000001), true);
            yield return new TestCaseData(GetTriangle(2, 2.5, 3), GetTriangle(2, 2.5, 3.00001), false);
            yield return new TestCaseData(GetTriangle(1.5, 2, 3), GetTriangle(2, 3, 1.5), true);
            yield return new TestCaseData(GetTriangle(1.5, 2, 3), null, false);
        }

        private static Triangle GetTriangle(double a, double b, double c)
        {
            return new Triangle(a, b, c);
        }
    }
}
