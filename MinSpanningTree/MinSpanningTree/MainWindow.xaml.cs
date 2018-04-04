using Kruskal;
using MinSpanningTree.Services;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
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

            ReloadCommand(null,null);
            this.DataContext = this;
            
        }

        private void AddLines()
        {
            var plot = new PlotModel();

            plot.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Maximum = 50,
                Minimum = -50,
                TickStyle = TickStyle.Inside
            });
            plot.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Maximum = 50,
                Minimum = -50,
                TickStyle = TickStyle.Inside
            });

            foreach (var cur in Lines)
            {
                var line = new LineSeries();

                line.ItemsSource = new List<DataPoint>(cur);
                //var about = "";
                //foreach (var i in cur)
                //{
                //    about += $"({i.X},{i.Y})";
                //}
                //line.TrackerFormatString = about;
                plot.Series.Add(line);            
            }
            Model = plot;
            
        }

        private void NewLine(DataPoint point1, DataPoint point2)
        {
            var line = new List<DataPoint>();
            line.Add(point1);
            line.Add(point2);
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
        #endregion

        public void ReloadCommand(object sender, RoutedEventArgs e)
        {
            StartKruskal();
            AddLines();           
        }

        private void StartKruskal()
        {
            if (Points.Count == 0) return;
            Adjacency adjacency = new Adjacency(Points.Count);
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
            foreach (var cur in links)
            {
                adjacency.setWeight(cur.Key, cur.Value,
                                    Weight(points[cur.Key], points[cur.Value]) );
            }

            KruskalMST mst = new KruskalMST();
            var A = mst.MSTKruskal(points.Count, adjacency);

            Lines.Clear();

            //виведення ребер
            foreach(var cur in A)
                if (cur != null)
                    this.NewLine(points[cur.U], points[cur.V]);
        }

        private double Weight(DataPoint point1, DataPoint point2)
        {
            return Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X) +
                (point1.Y - point2.Y) * (point1.Y - point2.Y));
        }

    }
}
