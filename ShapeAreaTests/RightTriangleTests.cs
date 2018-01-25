namespace ShapeAreaTests
{
    using System;

    using NUnit.Framework;
    using ShapeArea;

    /// <summary>
    /// Тесты фигуры Прямоугольный треугольник
    /// </summary>
    [TestFixture]
    public class RightTriangleTests
    {
        /// <summary>
        /// Стороны не могут являться сторонами треугольника
        /// </summary>
        [Test]
        public void RightTriangleConstructor_BadSizes_ArgumentException()
        {
            double a = 1;
            double b = 1;
            double c = 1;

            Assert.Throws(Is.TypeOf<ArgumentException>().And.Message.EqualTo("The square of the hypotenuse isn't equal to the sum of the squares of the other two sides"), () => new RightTriangle(a, b, c));
        }

        /// <summary>
        /// Проверка площади прямоугольного треугольника
        /// </summary>
        [Test]
        public void RightTriangleArea_ValidSides_CorrectArea()
        {
            var rightTriangle = new RightTriangle(3, 4, 5);
            var triangle = new Triangle(3, 4, 5);
           
            Assert.AreEqual(triangle.Area, rightTriangle.Area);
            Assert.AreEqual(6d, rightTriangle.Area);
        }
    }
}