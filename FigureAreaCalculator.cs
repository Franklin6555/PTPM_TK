using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTPM_TK
{
    /// <summary>
    /// Класс, отвечающий только за расчёт площади фигур (чистая логика)
    /// </summary>
    public class FigureAreaCalculator
    {
        /// <summary>
        /// Расчёт площади прямоугольника
        /// </summary>
        /// <param name="sideA">Длина первой стороны</param>
        /// <param name="sideB">Длина второй стороны</param>
        /// <returns>Площадь прямоугольника</returns>
        public double CalculateRectangleArea(double sideA, double sideB)
        {
            return sideA * sideB;
        }

        /// <summary>
        /// Расчёт площади круга
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        /// <returns>Площадь круга</returns>
        public double CalculateCircleArea(double radius)
        {
            return Math.PI * radius * radius;
        }

        /// <summary>
        /// Расчёт площади треугольника по формуле Герона
        /// </summary>
        /// <param name="a">Первая сторона</param>
        /// <param name="b">Вторая сторона</param>
        /// <param name="c">Третья сторона</param>
        /// <returns>Площадь треугольника</returns>
        public double CalculateTriangleArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;                    // полупериметр
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            if (double.IsNaN(area) || area <= 0)
                throw new ArgumentException("Треугольник с такими сторонами не существует");

            return area;
        }   
    }
}
