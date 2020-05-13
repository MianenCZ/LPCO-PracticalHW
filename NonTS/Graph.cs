﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NonTS
{
    public class Graph
    {
        public int VerticesCount { get; private set; }
        public int EdgesCount => Edges.Count;
        public List<Edge> Edges = new List<Edge>();

        public static Graph Parse(string[] data)
        {
            Graph g = new Graph();
            if(data[0].StartsWith("WEIGHTED DIGRAPH"))
            {
                string[] line = data[0].Split(' ', ':');

                int vertices = int.Parse(line[2]);
                int edges = int.Parse(line[3]);
                g.VerticesCount = vertices;

                for (int i = 0; i < edges; i++)
                {
                    line = data[i + 1].Split(new[] { "-->", "(", ")" }, StringSplitOptions.RemoveEmptyEntries);
                    int a = int.Parse(line[0]);
                    int b = int.Parse(line[1]);
                    int w = int.Parse(line[2]);
                    g.Edges.Add(
                        new Edge()
                        {
                            Id = i,
                            A = a,
                            B = b,
                            Oriented = true,
                            Weith = w,
                            Weithed = true
                        }) ;
                }
            }
            return g;
        }
    }

    public class Edge
    {
        public int Id { get; set; }
        public int A{ get; set; }
        public int B{ get; set; }
        public int Weith { get; set; }
        public bool Oriented { get; set; }
        public bool Weithed { get; set; }

        public override string ToString()
        {
            return string.Format("{0} --{3} {1} {2}", A, B, (Weithed) ? $"({Weithed})" : "", (Oriented) ? ">" : "");
        }
    }
}
