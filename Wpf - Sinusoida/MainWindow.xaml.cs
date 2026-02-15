using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf___Sinusoida
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AreaCalculation();
        }       

        private void AnimaciaButton_Click(object sender, RoutedEventArgs e)
        {                       

            if (!int.TryParse(TxtBody.Text, out int celkovyPocet))
            {
                MessageBox.Show("Zadaj platné číslo!");
                return;
            }

            Random random = new Random();

            double x;
            double y;
            double xDraw;
            double yDraw;
            bool jePodKrivkou;

            double sirka = 2 * Math.PI;
            double vyska = 2.2;

            for (int i = 0; i < celkovyPocet; i++)
            {
                x = random.NextDouble() * sirka;
                y = random.NextDouble() * vyska;

                double sinusY = Math.Sin(x) + 1.2;

                if (y <= sinusY)
                {
                    jePodKrivkou = true;
                }
                else
                {
                    jePodKrivkou = false;
                }

                xDraw = x * 50;
                yDraw = 200 - y * 50;

                Ellipse bod = new Ellipse
                {
                    Width = 3,
                    Height = 3,
                    Fill = jePodKrivkou ? Brushes.Blue : Brushes.Yellow
                };

                Canvas.SetLeft(bod, xDraw);
                Canvas.SetTop(bod, yDraw);

                Platno.Children.Add(bod);
            }
        }

        private void VymazButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = Platno.Children.Count - 1; i >= 0; i--)
            {
                if (Platno.Children[i] is Ellipse)
                {
                    Platno.Children.RemoveAt(i);
                }
            }
        }

        public void AreaCalculation()
        {
            double area = 0;
            double step = 0.5;
            for (double x = 0; x <= 2 * Math.PI; x += step)
            {
                double y = Math.Sin(x) + 1.2;
                area += y * step;
            }
            MessageBox.Show($"Plocha pod sinusoidou je: {area}");

            Polyline polyline = new Polyline
            {
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            for (double x = 0; x <= 2 * Math.PI; x += 0.5)
            {
                double y = Math.Sin(x) + 1.2;
                polyline.Points.Add(new Point(x * 50, 200 - y * 50));
            }
            Platno.Children.Add(polyline);
        }

        private void TxtBody_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}



/*
y < sin(x) + 1.2
x patri < 0,2Pi >
y patri < 0,2.2 >
*/