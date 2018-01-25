namespace ShapeAreaTests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using ShapeArea;

    /// <summary>
    /// Тесты фигуры Треугольник
    /// </summary>
    [TestFixture]
    public class TriangleTests
    {
        /// <summary>
        /// Стороны не могут быть отрицательными или равняться NaN, -∞, ∞
        /// </summary>
        /// <param name="expectedExceptionMessage">Ожидаемое сообщение в Exception</param>
        /// <param name="sideA">Сторона 1</param>
        /// <param name="sideB">Сторона 2</param>
        /// <param name="sideC">Сторона 3</param>
        [Test]
        [TestCaseSource(nameof(TriangleConstructorBadSides))]
        public void TriangleConstructor_BadSizes_ArgumentOutOfRangeException(string expectedExceptionMessage, double sideA, double sideB, double sideC)
        {
            Assert.Throws(Is.TypeOf<ArgumentOutOfRangeException>().And.Message.EqualTo(expectedExceptionMessage), () => new Triangle(sideA, sideB, sideC));
        }

        /// <summary>
        /// Сумма двух сторон треугольника всегда больше третей стороны
        /// </summary>
        /// <param name="expectedExceptionMessage">Ожидаемое сообщение в Exception</param>
        /// <param name="sideA">Сторона 1</param>
        /// <param name="sideB">Сторона 2</param>
        /// <param name="sideC">Сторона 3</param>
        [Test]
        [TestCaseSource(nameof(TriangleConstructorImpossibleTriangle))]
        public void TriangleConstructor_BadSizes_ArgumentException(string expectedExceptionMessage, double sideA, double sideB, double sideC)
        {
            var exception = Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.EqualTo(expectedExceptionMessage), () => new Triangle(sideA, sideB, sideC), expectedExceptionMessage);
            Assert.AreEqual(expectedExceptionMessage, exception.Message);
        }

        /// <summary>
        /// Проверка площади треугольника
        /// </summary>
        [Test]
        public void TriangleArea_ValidSides_CorrectArea()
        {
            var triangle = new Triangle(5, 5, 8);

            var area = triangle.Area;

            Assert.AreEqual(12d, area);
        }

        private static IEnumerable<TestCaseData> TriangleConstructorBadSides()
        {
            yield return new TestCaseData("Side must be greater then 0" + Environment.NewLine + "Parameter name: sideA", 0, 3, 3);
            yield return new TestCaseData("Side must be greater then 0" + Environment.NewLine + "Parameter name: sideB", 3, -0.5, 3);
            yield return new TestCaseData("Side must be greater then 0" + Environment.NewLine + "Parameter name: sideC", 3, 5, -3);
            yield return new TestCaseData("Side can't be equal to values NaN, -∞, ∞" + Environment.NewLine + "Parameter name: sideA", double.NaN, 3, 3);
            yield return new TestCaseData("Side can't be equal to values NaN, -∞, ∞" + Environment.NewLine + "Parameter name: sideB", 3, double.NegativeInfinity, 3);
            yield return new TestCaseData("Side can't be equal to values NaN, -∞, ∞" + Environment.NewLine + "Parameter name: sideC", 3, 5, double.PositiveInfinity);
        }

        private static IEnumerable<TestCaseData> TriangleConstructorImpossibleTriangle()
        {
            yield return new TestCaseData("The sum of any 2 sides of a triangle must be greater than the measure of the third side", 8, 5, 2);
            yield return new TestCaseData("The sum of any 2 sides of a triangle must be greater than the measure of the third side", 1, 6, 2);
            yield return new TestCaseData("The sum of any 2 sides of a triangle must be greater than the measure of the third side", 3, 5, 8);
        }
    }
}
