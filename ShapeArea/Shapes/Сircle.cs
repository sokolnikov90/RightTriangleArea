namespace ShapeArea
{
    using System;

    /// <summary>
    /// Фигура Круг
    /// </summary>
    [Serializable]
    public class Сircle : Shape
    {
        /// <summary>
        /// Конструктор фигуры Круг
        /// </summary>
        /// <param name="radius">Радиус</param>
        public Сircle(double radius)
        {
            CheckShapeSideValue(nameof(radius), radius);
            Radius = radius;
        }

        /// <summary>
        /// Радиус
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Площадь
        /// </summary>
        public override double Area => Math.PI * Math.Pow(Radius, 2);
    }
}