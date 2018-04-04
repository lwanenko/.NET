using Duality;
using SnowyPeak.Duality.Plugin.Frozen.Procedural;
using System;
using System.Collections.Generic;
using System.Text;

namespace Triangulator
{
    public class Triangulation
    {
        public static List<KeyValuePair<int, int>> Get(List<KeyValuePair<float, float>> points)
        {
            var p = points.ToArray();
            var _graph = new Graph<Node>();
            foreach (var v in points )
            {
                float x = Convert.ToSingle( v.Key);
                float y = Convert.ToSingle(v.Value);
                _graph.Nodes.Add(new Node(new Vector2(x , y)));
            }
            _graph.Triangulate();
            List<KeyValuePair<int, int>> links = new List<KeyValuePair<int, int>>();
            foreach (var cur in _graph.Links)
            {
                var from = new KeyValuePair<float, float>(cur.From.Position.X, cur.From.Position.Y);
                var to = new KeyValuePair<float, float>(cur.To.Position.X, cur.To.Position.Y);

                var predicate1 = new Predicate<KeyValuePair<float, float>>((k) => 
                    { if (k.Key == from.Key && k.Value == from.Value) return true; return false; });
                var predicate2 = new Predicate<KeyValuePair<float, float>>((k) =>
                    { if (k.Key == to.Key && k.Value == to.Value) return true; return false; });

                links.Add(new KeyValuePair<int, int>(points.FindIndex(0, predicate1), 
                                                     points.FindIndex(0, predicate2)));
            }
            return links;
        }
    }
}
