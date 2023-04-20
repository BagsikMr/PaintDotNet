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
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace LabyPT5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Brush my_color = Brushes.White;
        private Point startPoint;
        private List<Line> lines = new List<Line>();
        private bool isDrawing = false;
        public MainWindow()
        {
            InitializeComponent();
            slider.ValueChanged += Slider_ValueChanged;
            
        }
        private void myCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(isDrawing)
            {
                Point currentPoint = e.GetPosition(this);

                Line line = new Line();
                line.Stroke = my_color;
                line.StrokeThickness = (int)slider.Value;
                line.X1 = startPoint.X;
                line.Y1 = startPoint.Y;
                line.X2 = currentPoint.X;
                line.Y2 = currentPoint.Y;

                lines.Add(line);

                myCanvas.Children.Add(line);
                startPoint = currentPoint;
            }
        }
        private void myCanvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(this);
            isDrawing = true;
        }
        private void myCanvas_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isDrawing = false; 
        }
        private void myCanvas_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Obsługa zdarzenia opuszczenia myszy z Canvas
        }
        private void myCanvas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Obsługa zdarzenia wejścia myszy na Canvas
        }
        private void myCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Obsługa zdarzenia pokrętła myszy na Canvas
        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int value = (int)e.NewValue;
            textBox.Text = value.ToString();
        }
        private void OpenColorDialogButton_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                Brush brush = new SolidColorBrush(System.Windows.Media.Color.FromRgb(
                    colorDialog.Color.R,
                    colorDialog.Color.G,
                    colorDialog.Color.B
                    ));

                ColorPalet.Background = brush;
                my_color = brush;
            }
            
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            lines.Clear();
            myCanvas.Children.Clear();
        }
        private void ReverseButton_Click(object sender, RoutedEventArgs e)
        {
            if(myCanvas.Background == Brushes.Black)
            myCanvas.Background = Brushes.White;
            else
            {
                myCanvas.Background = Brushes.Black;
            }
        }
    }
}
