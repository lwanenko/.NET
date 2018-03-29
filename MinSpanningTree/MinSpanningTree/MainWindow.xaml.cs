using MinSpanningTree.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MinSpanningTree.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<BLL.Models.Point> Points = new List<BLL.Models.Point>();
            for (int i = 0; i < 5; i++)
            {
                var point = new BLL.Models.Point(0, 0);
                Points.Add(point);
            }
            var tree = new MinSpanningTree.BLL.SpanningTree(Points);

        }
    }
}
