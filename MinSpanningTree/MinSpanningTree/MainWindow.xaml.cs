using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public MainWindow()
        {
            InitializeComponent();
            Lines = new List<List<DataPoint>>();

            AddLines();
        }

        public void AddLines()
        {
            foreach (var cur in Lines)
            {
                var line = new OxyPlot.Wpf.LineSeries();
                line.ItemsSource = cur; 
                plot.Series.Add(line);
            }
        }
    }
}
