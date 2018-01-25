namespace ShapeAreaTests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using ShapeArea;

    /// <summary>
    /// Тесты фигуры Круг
    /// </summary>
    [TestFixture]
    public class СircleTests
    {
        /// <summary>
        /// Радиус не может быть отрицательным или равняться NaN, -∞, ∞
        /// </summary>
        /// <param name="expectedExceptionMessage">Ожидаемое сообщение в Exception</param>
        /// <param name="radius">Радиус</param>
        [Test]
        [TestCaseSource(nameof(TriangleConstructorBadRadius))]
        public void СircleConstructor_BadRadius_ArgumentOutOfRangeException(string expectedExceptionMessage, double radius)
        {
            Assert.Throws(Is.TypeOf<ArgumentOutOfRangeException>().And.Message.EqualTo(expectedExceptionMessage), () => new Сircle(radius));
        }

        /// <summary>
        /// Проверка площади круга
        /// </summary>
        [Test]
        public void СircleArea_ValidRadius_CorrectArea()
        {
            var circle = new Сircle(3);

            var area = circle.Area;

            Assert.AreEqual(28.27d, area, 0.01);
        }

        private static IEnumerable<TestCaseData> TriangleConstructorBadRadius()
        {
            yield return new TestCaseData("Side must be greater then 0" + Environment.NewLine + "Parameter name: radius", 0);
            yield return new TestCaseData("Side must be greater then 0" + Environment.NewLine + "Parameter name: radius", -1);
            yield return new TestCaseData("Side can't be equal to values NaN, -∞, ∞" + Environment.NewLine + "Parameter name: radius", double.NaN);
            yield return new TestCaseData("Side can't be equal to values NaN, -∞, ∞" + Environment.NewLine + "Parameter name: radius", double.NegativeInfinity);
            yield return new TestCaseData("Side can't be equal to values NaN, -∞, ∞" + Environment.NewLine + "Parameter name: radius", double.PositiveInfinity);
        }
    }
}