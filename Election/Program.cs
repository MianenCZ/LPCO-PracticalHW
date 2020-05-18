using System;
using System.Collections.Generic;
using System.IO;
using Utils;

namespace Election
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                PrintHelp();
                Environment.Exit(-1);
            }

            if (args[0] == "-h" || args[0] == "--help" || args[0] == "?")
            {
                PrintHelp();
                Environment.Exit(0);
            }

            Graph g = null;
            TextWriter wr = null;
            try
            {
                g = Graph.Parse(File.ReadAllLines(args[0]));
                wr = new StreamWriter(File.OpenWrite($"{args[0]}.mod"));
                //wr = Console.Out;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File error: {ex.Message}");
                Environment.Exit(1);
            }


            HashSet<Tuple<int,int>> non_edges = new HashSet<Tuple<int, int>>();
            for (int i = 0; i < g.VerticesCount; i++)
                for (int j = i+1; j < g.VerticesCount; j++)
                    non_edges.Add(new Tuple<int,int>(i,j));

            foreach (var e in g.Edges)
                if(non_edges.Contains(new Tuple<int, int>(e.A, e.B)))
                    non_edges.Remove(new Tuple<int, int>(e.A, e.B));

            wr.WriteLine("param N := {0};", g.VerticesCount);
            wr.Write("set Ne := {");
            wr.Write(non_edges.FormateLine(x => $"({x.Item1},{x.Item2})", ", ", ""));
            wr.Write("};\n");
            wr.WriteLine("set V := (0 .. N-1);");
            wr.WriteLine("var x{k in (0 .. N-1)}, >= 0, integer;");
            wr.WriteLine("var y{v in V, k in (0 .. N-1)}, >= 0, integer;");
            wr.WriteLine("minimize obj: sum{k in (0 .. N-1)}x[k];");
            wr.WriteLine("s.t. c1{(u,v) in Ne, k in (0 .. N-1)}: y[u,k] + y[v,k] <= 1;");
            wr.WriteLine("s.t. c2{v in V}: sum{k in (0 .. N-1)}y[v,k]>=1;");
            wr.WriteLine("s.t. c3{k in (0 .. N-1)}: x[k] >= (1/N) * sum{v in V}y[v,k];");
            wr.WriteLine("solve;");
            wr.WriteLine("printf \"#OUTPUT: %d\\n\", sum{k in (0 .. N-1)}x[k];");
            wr.WriteLine("printf{v in V, k in (0 .. N-1): y[v,k] == 1} \"v_%d: %d\\n\", v, k;");
            wr.WriteLine("printf \"#OUTPUT END\\n\";");
            wr.WriteLine("end;");
            wr.Flush();

            Console.WriteLine($"Model file \"{args[0]}.mod\" created");
        }

        static void PrintHelp()
        {
            Console.WriteLine("Usage: election.exe filename");
            Console.WriteLine("       Reads graph from <filename> inputfile and converts it to Linear Program for glpsol(.exe) linear program solver.");
            Console.WriteLine("       Result is written into <filename>.mod file ");
            Console.WriteLine();
            Console.WriteLine("Options: ");
            Console.WriteLine("\t-h --help         Show this help");
            Console.WriteLine("\t?                 Show this help");
        }
    }
}
