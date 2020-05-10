using System;
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

    public class EdgeCycleComparer : IEqualityComparer<Edge[]>
    {
        public bool Equals([AllowNull] Edge[] x, [AllowNull] Edge[] y)
        {
            if(x is object && y is object && x.Length == y.Length)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    if (!Equals(x[i], y[i]))
                        return false;
                }
                return true;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] Edge[] obj)
        {
            int hash = 0;
            for (int i = 0; i < obj.Length; i++)
            {
                hash *= obj[i].GetHashCode() + i;
            }
            return hash;
        }
    }

    public static class GraphExt
    {
        public static List<Edge[]> Oriented3Cycles(this Graph g)
        {
            //var res = new List<Edge[]>();
            var res = new HashSet<Edge[]>(new EdgeCycleComparer());

            var edges = g.Edges;


            for (int i = 0; i < g.EdgesCount; i++)
            {
                for (int j = 0; j < g.EdgesCount; j++)
                {
                    if (i != j)
                    {
                        for (int k = 0; k < g.EdgesCount; k++)
                        {
                            if (j != k && i != k
                                && edges[i].B == edges[j].A && edges[j].B == edges[k].A && edges[k].B == edges[i].A)
                            {
                                res.Add(new[] { edges[i], edges[j], edges[k] }.OrderBy(x=> x.Id).ToArray());
                            }
                        }
                    }
                }
            }
            return res.ToList();
        }

        public static List<Edge[]> Oriented4Cycles(this Graph g)
        {
            //var res = new List<Edge[]>();
            var res = new HashSet<Edge[]>(new EdgeCycleComparer());

            var edges = g.Edges;

            for (int i = 0; i < g.EdgesCount; i++)
            {
                for (int j = 0; j < g.EdgesCount; j++)
                {
                    //i,j
                    if (i != j && edges[i].B == edges[j].A)
                    {
                        for (int k = 0; k < g.EdgesCount; k++)
                        {
                            //i,j,k
                            if ( j != k && edges[j].B == edges[k].A)
                            {
                                for (int l = 0; l < g.EdgesCount; l++)
                                {
                                    //i,j,k,l
                                    if (i != l && l != i &&(
                                    (edges[i].B == edges[j].A && edges[j].B == edges[k].A && edges[k].B == edges[l].A && edges[l].B == edges[i].A)))
                                    {
                                        res.Add(new[] { edges[i], edges[j], edges[k], edges[l] }.OrderBy(x => x.Id).ToArray());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return res.ToList();
        }
    }
}
