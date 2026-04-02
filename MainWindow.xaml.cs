using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PTPM_TK
{
    /// <summary>
    /// Главное окно приложения для расчёта площади геометрических фигур
    /// Поддерживаемые фигуры: прямоугольник, круг, треугольник
    /// </summary>
    public partial class MainWindow : Window
    {
        FigureAreaCalculator figureAreaCalculator = new FigureAreaCalculator();
        public MainWindow()
        {
            InitializeComponent();
            // По умолчанию выбираем прямоугольник
            rbRectangle.IsChecked = true;
        }

        /// <summary>
        /// Обработчик события при выборе радиокнопки (смене типа фигуры)
        /// Автоматически показывает/скрывает нужные поля ввода
        /// </summary>
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }

        /// <summary>
        /// Обновляет видимость полей ввода в зависимости от выбранной фигуры
        /// </summary
        private void UpdateUI()
        {
            // Скрываем все поля
            tblockSide1.Visibility = Visibility.Collapsed;
            tblockSide2.Visibility = Visibility.Collapsed;
            tblockSide3.Visibility = Visibility.Collapsed;
            tblockRadius.Visibility = Visibility.Collapsed;

            tbSide1.Visibility = Visibility.Collapsed;
            tbSide2.Visibility = Visibility.Collapsed;
            tbSide3.Visibility = Visibility.Collapsed;
            tbRadius.Visibility = Visibility.Collapsed;

            // Показываем нужные поля
            if (rbRectangle.IsChecked == true)
            {
                // Для прямоугольника нужны две стороны (длина и ширина)
                tblockSide1.Visibility = Visibility.Visible;
                tblockSide2.Visibility = Visibility.Visible;

                tbSide1.Visibility = Visibility.Visible;
                tbSide2.Visibility = Visibility.Visible;
            }
            else if (rbCircle.IsChecked == true)
            {
                // Для круга нужен только радиус
                tblockRadius.Visibility = Visibility.Visible;
                tbRadius.Visibility = Visibility.Visible;
            }
            else if (rbTriangle.IsChecked == true)
            {
                // Для треугольника нужны три стороны
                tblockSide1.Visibility = Visibility.Visible;
                tblockSide2.Visibility = Visibility.Visible;
                tblockSide3.Visibility = Visibility.Visible;

                tbSide1.Visibility = Visibility.Visible;
                tbSide2.Visibility = Visibility.Visible;
                tbSide3.Visibility = Visibility.Visible;
            }
        }


        /// <summary>
        /// Обработчик нажатия кнопки "Вычислить"
        /// </summary>
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double area = 0;

                if (rbRectangle.IsChecked == true)
                {
                    double a = double.Parse(tbSide1.Text);
                    double b = double.Parse(tbSide2.Text);
                    area = figureAreaCalculator.CalculateRectangleArea(a, b);
                }
                else if (rbCircle.IsChecked == true)
                {
                    double r = double.Parse(tbRadius.Text);
                    area = figureAreaCalculator.CalculateCircleArea(r);
                }
                else if (rbTriangle.IsChecked == true)
                {
                    double a = double.Parse(tbSide1.Text);
                    double b = double.Parse(tbSide2.Text);
                    double c = double.Parse(tbSide3.Text);
                    area = figureAreaCalculator.CalculateTriangleArea(a, b, c);
                }

                tbResult.Text = $"Площадь = {area:F2}";
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения!",
                    "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}",
                    "Ошибка расчёта", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
