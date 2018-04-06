using MinSpanningTree.Services;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Prim_s;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MinSpanningTree.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty ModelProperty;

        public List< List<DataPoint> > Lines { get; private set; }
        public HashSet<DataPoint> Points { get; set; }

        public PlotModel Model { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Lines = new List<List<DataPoint>>();
            Points = PointService.GetPoints();

            while (Points.Count < 1000)
                AddRandCommand(null, null);

            ReloadCommand(null,null);
            this.DataContext = this;
            
        }

        private void AddLines()
        {
            var plot = new PlotModel();

            plot.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Maximum = 200,
                Minimum = 0,
                TickStyle = TickStyle.Inside
            });
            plot.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Maximum = 200,
                Minimum = 0,
                TickStyle = TickStyle.Inside
            });

            foreach (var cur in Lines)
            {
                var line = new LineSeries();

                line.ItemsSource = new List<DataPoint>(cur);
                line.LineStyle = LineStyle.Solid;
                line.BrokenLineStyle = LineStyle.Solid;
                plot.Series.Add(line);            
            }
            Model = plot;
            
        }

        private void NewLine(DataPoint point1, DataPoint point2)
        {
            var line = new List<DataPoint>();
            line.Add(point1);
            line.Add(point2);
            
            Lines.Add(line);
        }

        #region PointService
        public void AddPointCommand(object sender, RoutedEventArgs e)
        {
            try
            {
                var _x = Convert.ToDouble(x.Text);
                var _y = Convert.ToDouble(y.Text);
                if (Points.Add(new DataPoint(_x, _y)))
                    MessageBox.Show($"Точку ({_x}, {_y}) додано");
                else MessageBox.Show($"Точка ({_x}, {_y}) існує");
                x.Text = "0,0";
                y.Text = "0,0";
            }
            catch { }
        }

        Random random  = new Random();
        public void AddRandCommand(object sender, RoutedEventArgs e)
        {
            if (Points == null) Points = new HashSet<DataPoint>();
            var _x = random.Next(200);
            var _y = random.Next(200);
            if (Points.Add(new DataPoint(_x, _y)))
                ;// MessageBox.Show($"Точку ({_x}, {_y}) додано");
            else AddRandCommand(sender, e);

        }

        public void SaveCommand(object sender, RoutedEventArgs e)
        {
            PointService.Save(Points);
        }
        #endregion

        public void ReloadCommand(object sender, RoutedEventArgs e)
        {
            StartMST();
            AddLines();           
        }

        private void StartMST()
        {
            if (Points.Count == 0) return;
            
            var points = new List<DataPoint>(Points);
         
            var p = new List<KeyValuePair<float, float>>();
            foreach (var cur in points)
            {
                p.Add(new KeyValuePair<float, float>(
                    Convert.ToSingle(cur.X),
                    Convert.ToSingle(cur.Y)
                    ));
            }

            var links = Triangulator.Triangulation.Get(p);

            var adjacency = new List<Edge>();
            foreach (var cur in links)
            {
                this.NewLine(points[cur.Key], points[cur.Value]);
                adjacency.Add(new Edge ( cur.Key, cur.Value,
                                         Weight(points[cur.Key], points[cur.Value]) 
                                       ) 
                             );
            }
            var edges = MST.algorithmByPrim(Points.Count, adjacency);

            Lines.Clear();

            //виведення ребер
            foreach (var cur in edges)
                if (cur != null)
                    this.NewLine(points[cur.v1], points[cur.v2]);
        }

        private double Weight(DataPoint point1, DataPoint point2)
        {
            return Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) +
                (point1.Y - point2.Y) * (point1.Y - point2.Y));
        }

    }
}
