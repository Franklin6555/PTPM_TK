using PTPM_TK;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class FigureAreaCalculatorTests
    {
        private readonly FigureAreaCalculator _calculator;

        public FigureAreaCalculatorTests()
        {
            _calculator = new FigureAreaCalculator();
        }

        // Прямоугольник 

        [TestMethod]
        public void CalculateRectangleArea_ValidSides_ReturnsCorrectArea()
        {
            // Arrange
            double a = 5.0;
            double b = 10.0;
            double expected = 50.0;

            // Act
            double result = _calculator.CalculateRectangleArea(a, b);

            // Assert
            Assert.AreEqual(expected, result, 0.001); // допускаем небольшую погрешность
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateRectangleArea_NegativeSide_ThrowsException()
        {
            _calculator.CalculateRectangleArea(-5, 10);
        }

        // Круг

        [TestMethod]
        public void CalculateCircleArea_ValidRadius_ReturnsCorrectArea()
        {
            double radius = 10.0;
            double expected = Math.PI * 100;   // π * r²

            double result = _calculator.CalculateCircleArea(radius);

            Assert.AreEqual(expected, result, 0.001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateCircleArea_ZeroRadius_ThrowsException()
        {
            _calculator.CalculateCircleArea(0);
        }

        // Треугольник

        [TestMethod]
        public void CalculateTriangleArea_ValidSides_ReturnsCorrectArea()
        {
            // Равносторонний треугольник со стороной 6 → площадь ≈ 15.588
            double a = 6;
            double b = 6;
            double c = 6;
            double expected = 15.588457268119896;

            double result = _calculator.CalculateTriangleArea(a, b, c);

            Assert.AreEqual(expected, result, 0.001);
        }

        [TestMethod]
        public void CalculateTriangleArea_RightTriangle_ReturnsCorrectArea()
        {
            // Прямоугольный треугольник 3-4-5 → площадь = 6
            double result = _calculator.CalculateTriangleArea(3, 4, 5);
            Assert.AreEqual(6.0, result, 0.001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateTriangleArea_InvalidTriangle_ThrowsException()
        {
            // 1 + 2 не может быть больше 4 → треугольник не существует
            _calculator.CalculateTriangleArea(1, 2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateTriangleArea_NegativeSide_ThrowsException()
        {
            _calculator.CalculateTriangleArea(5, 5, -3);
        }
    }
}
