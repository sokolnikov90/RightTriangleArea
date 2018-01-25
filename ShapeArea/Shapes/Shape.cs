namespace ShapeArea
{
    using System;
    using System.Linq;

    /// <summary>
    /// Фигура
    /// Абстрактный класс для всех фигур
    /// </summary>
    public abstract class Shape : IArea
    {
        /// <summary>
        /// Недопустымие значения для длины
        /// </summary>
        protected static readonly double[] BadSideValues = { double.NaN, double.NegativeInfinity, double.PositiveInfinity };

        /// <summary>
        /// Площадь
        /// </summary>
        public abstract double Area { get; }

        /// <summary>
        /// Проверить значение длины стороны фигуры
        /// </summary>
        /// <param name="sideName">Название стороны фигуры</param>
        /// <param name="sideValue">Значение стороны фигуры</param>
        protected void CheckShapeSideValue(string sideName, double sideValue)
        {
            if (BadSideValues.Contains(sideValue))
            {
                throw new ArgumentOutOfRangeException(sideName, $"Side can't be equal to values {string.Join(", ", BadSideValues)}");
            }

            if (sideValue <= 0d)
            {
                throw new ArgumentOutOfRangeException(sideName, $"Side must be greater then 0");
            }
        }
    }
}