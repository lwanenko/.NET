using Newtonsoft.Json;
using OxyPlot;
using System.Collections.Generic;
using System.IO;

namespace MinSpanningTree.Services
{
    public class PointService
    {
        private static string path = @"F:\VS\.NET\MinSpanningTree\MinSpanningTree\Resources\Points.txt";

        public static void Save(HashSet<DataPoint> points)
        {
            string json = JsonConvert.SerializeObject(points);
                using (var ct = File.CreateText(path))
                {
                    ct.Write(json);
                }
            
        }
        public static HashSet<DataPoint> GetPoints()
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<HashSet<DataPoint>>(json) ?? new HashSet<DataPoint>();
        }
    }
}
