using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Triangles;

namespace TrianglesUnitTests
{
    [TestFixture]
    class RightTriangleTests
    {
        public void RightTriangle_ExceptionRightTriangleSides_ThrowsException()
        {
            double a, b, c;
            a = b = c = 1;

            Assert.Throws<TriangleException>(() => GetRightTriangle(a, b, c));
        }

        [Test, TestCaseSource("RightTriangleCheckPropertiesCases")]
        public void Triangle_ValidRightTriangleSides_CheckProperties(double a, double b, double c,
            double expectedPerimeter, double expectedArea)
        {
            var sides = new List<double>(3) { a, b, c };
            double maxSide = sides.Max();
            sides.Remove(maxSide);
            double minSide = sides.Min();
            sides.Remove(minSide);
            double middleSide = sides[0];

            IRightTriangle rightTriangle = GetRightTriangle(a, b, c);

            Assert.AreEqual(expectedPerimeter, rightTriangle.Perimeter);
            Assert.AreEqual(expectedArea, rightTriangle.Area, 0.00001);
            Assert.That(rightTriangle.SideCollection[0] == a);
            Assert.That(rightTriangle.SideCollection[1] == b);
            Assert.That(rightTriangle.SideCollection[2] == c);
            Assert.That(rightTriangle.Cathetus_A == minSide);
            Assert.That(rightTriangle.Cathetus_B == middleSide);
            Assert.That(rightTriangle.Hypotenuse_C ==maxSide);
        }

        private static IEnumerable<TestCaseData> RightTriangleCheckPropertiesCases()
        {
            yield return new TestCaseData(3, 4, 5, 12, 6);
            yield return new TestCaseData(5, 12, 13, 30, 30);
        }

        [Test, TestCaseSource("TestTrianglePairsForCongruent")]
        public void Congruent_TestRightTriangles_Correct(RightTriangle rightTriangle1, RightTriangle rightTriangle2, bool isEquals)
        {
            string errorMessage = rightTriangle1 + "; " + rightTriangle2;

            bool result1 = rightTriangle1 == rightTriangle2;
            bool result2 = rightTriangle2 == rightTriangle1;

            Assert.That(result1 == isEquals, errorMessage);
            Assert.That(result2 == isEquals, errorMessage);
        }

        [Test, TestCaseSource("TestTrianglePairsForCongruent")]
        public void NotCongruent_TestRightTriangles_Correct(RightTriangle rightTriangle1, RightTriangle rightTriangle2, bool isEquals)
        {
            string errorMessage = rightTriangle1 + "; " + rightTriangle2;

            bool result1 = rightTriangle1 != rightTriangle2;
            bool result2 = rightTriangle2 != rightTriangle1;

            Assert.That(result1 != isEquals, errorMessage);
            Assert.That(result2 != isEquals, errorMessage);
        }

        private static IEnumerable<TestCaseData> TestTrianglePairsForCongruent()
        {
            IRightTriangle rightTriangle = GetRightTriangle(3, 4, 5);
            yield return new TestCaseData(rightTriangle, rightTriangle, true);
            yield return new TestCaseData(GetRightTriangle(3, 4, 5), GetRightTriangle(3, 4, 5), true);
            yield return new TestCaseData(GetRightTriangle(5, 3, 4), GetRightTriangle(3, 4, 5), true);
            yield return new TestCaseData(GetRightTriangle(3, 4, 5), null, false);
        }

        private static RightTriangle GetRightTriangle(double a, double b, double c)
        {
            return new RightTriangle(a, b, c);
        }
    }
}
