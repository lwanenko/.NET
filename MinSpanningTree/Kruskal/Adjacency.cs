﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kruskal
{
    public class Adjacency
    {
        bool[,] matrix;
        int n;
        double[,] weight;

        public Adjacency(int n)
        {
            this.n = n;
            matrix = new bool[n, n];
            weight = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = false;
                    weight[i, j] = 0;
                }
            }
        }

        public bool getElementAt(int i, int j)
        {
            return matrix[i, j];
        }

        public double getWeight(int i, int j)
        {
            return weight[i, j];
        }

        public void setElementAt(bool element, int i, int j)
        {
            matrix[i, j] = element;
        }

        public void setWeight(int i, int j, double weight)
        {
            matrix[i, j] = true;
            this.weight[i, j] = weight;
        }
    }
}
