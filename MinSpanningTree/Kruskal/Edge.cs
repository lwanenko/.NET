using System;
using System.Collections.Generic;
using System.Text;

namespace Kruskal
{
    public class Edge
    {
        int u, v;
        double weight;

        public Edge()
        {
            u = v = 0;
            weight = 0;
        }

        public Edge(int u, int v, double weight)
        {
            this.u = u;
            this.v = v;
            this.weight = weight;
        }

        public int U {
            get {
                return u;
            }
            set {
                u = value;
            }
        }

        public int V {
            get {
                return v;
            }
            set {
                v = value;
            }
        }

        public double Weight {
            get {
                return weight;
            }
            set {
                weight = value;
            }
        }
    }
}
