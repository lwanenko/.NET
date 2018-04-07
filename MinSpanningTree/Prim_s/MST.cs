using System;
using System.Collections.Generic;
using System.Text;

namespace Prim_s
{
    public class Edge
    {
        public int v1, v2;

        public double weight;

        public Edge(int v1, int v2, double weight)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.weight = weight;
        }
    }

    public class MST
    {

        public static List<Edge>  algorithmByPrim(int numberV, Edge[] Edges)
        {
            var mst = new List<Edge>();
            //неиспользованные ребра
            List<Edge> notUsedEdges = new List<Edge>(Edges);
            //использованные вершины
            var usedV = new bool [numberV];
            
            for (int i = 0; i < numberV; i++)
                 usedV [i] = false;
            int notUsedV = numberV; // кількість не використаних вершин
            //випадкова початкова точка
            Random rand = new Random();
            usedV[rand.Next(0, numberV)] = true;

            while (notUsedV > 0)
            {
                int minE = -1; //номер найменшого ребра
                               //пошук найменшого ребра
                double minEWeight = 0; // значення на мін ребрі
                int i = 0;
                foreach (var edge in notUsedEdges)
                {
                    if ((usedV[edge.v1] == true) && (usedV[edge.v2] == false) ||
                        (usedV[edge.v2] == true) && (usedV[edge.v1] == false))
                    {
                        if (minE != -1)
                        {
                            if (notUsedEdges[i].weight < notUsedEdges[minE].weight)
                                minE = i;
                        }
                        else if (minEWeight > edge.weight)
                        {
                            minEWeight = edge.weight;
                            minE = i;
                        }
                    }
                    i++;
                }
                //заносим новую вершину в список использованных и удаляем ее из списка неиспользованных
                usedV[notUsedEdges[minE].v1] = true;
                usedV[notUsedEdges[minE].v2] = true;
                notUsedV--;
                //заносим новое ребро в дерево и удаляем его из списка неиспользованных
                mst.Add(notUsedEdges[minE]);
                notUsedEdges.RemoveAt(minE);

            }
            return mst;
        }
    }
    
}
