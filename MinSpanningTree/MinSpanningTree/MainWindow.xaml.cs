using MinSpanningTree.Services;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MinSpanningTree.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Title { get; private set; }
        public List< List<DataPoint> > Lines { get; private set; }
        public HashSet<DataPoint> Points { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            
            Lines = new List<List<DataPoint>>();
            Points = PointService.GetPoints();
            ReloadCommand(null,null);
        }

        private void AddLines()
        {
            foreach (var cur in Lines)
            {
                var line = new OxyPlot.Wpf.LineSeries();

                line.ItemsSource = cur;
                var about = "";
                foreach (var i in cur)
                {
                    about += $"({i.X},{i.Y})";
                }
                line.TrackerFormatString = about;
                plot.Series.Add(line);
            }
        }

        private void NewLine(DataPoint point1, DataPoint point2)
        {
            var line = new List<DataPoint>();
            line.Add(point1);
            line.Add(point2);
        }

        private void NewLine(double x1, double y1,double x2, double y2)
        {
            var point1 = new DataPoint(x1, y1);
            var point2 = new DataPoint(x2, y2);
            NewLine(point1, point2);
        }

        public void AddPointCommand(object sender, RoutedEventArgs e)
        {
            try
            {
                var _x = Convert.ToDouble(x.Text);
                var _y = Convert.ToDouble(y.Text);
                if (Points.Add(new DataPoint(_x, _y)))
                    MessageBox.Show($"Точку ({_x}, {_y}) додано");
                else MessageBox.Show($"Точка ({_x}, {_y}) існує");
                x.Text = "";
                y.Text = "";
            }
            catch { }
        }

        public void AddRandCommand(object sender, RoutedEventArgs e)
        {
            if (Points == null) Points = new HashSet<DataPoint>();
            Random random = new Random();
            var _x = random.NextDouble()* random.Next(50);
            var _y = random.NextDouble() * random.Next(50);
            if (Points.Add(new DataPoint(_x, _y)))
                MessageBox.Show($"Точку ({_x}, {_y}) додано");
            else AddRandCommand(sender, e);

        }

        public void SaveCommand(object sender, RoutedEventArgs e)
        {
            PointService.Save(Points);
        }

        public void ReloadCommand(object sender, RoutedEventArgs e)
        {
            Lines.Clear();

            var list = new List<DataPoint>();
            list.Add(new DataPoint(0, 0));
            list.Add(new DataPoint(1, 2));
            Lines.Add(list);
            AddLines();
            
        }

    }
}
