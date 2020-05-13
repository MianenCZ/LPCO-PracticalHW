using System;
using System.Dynamic;
using System.IO;
using System.Linq;
using Utils;

namespace NonTS
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                PrintHelp();
                Environment.Exit(-1);
            }

            if(args[0] == "-h" || args[0] == "--help" || args[0] == "?")
            {
                PrintHelp();
                Environment.Exit(0);
            }


            Graph g = Graph.Parse(File.ReadAllLines(args[0]));
            TextWriter wr = new StreamWriter(File.OpenWrite($"{args[0]}.mod"));
            //TextWriter wr = Console.Out;
            wr.Write("set Edges := {");
            wr.Write(g.Edges.FormateLine(x => $"({x.A},{x.B},{x.Weith})", ", ", ""));
            wr.Write("};\n");
            wr.WriteLine("var x{ (i, j, w) in Edges}, binary;");
            wr.WriteLine("minimize obj: sum{ (i, j, w) in Edges}");
            wr.WriteLine("x[i, j, w] * w;");
            wr.WriteLine("s.t.cycle3{ (i, j, a) in Edges, (j, k, b) in Edges, (k, l, c) in Edges: l == i }: x[i, j, a] + x[j, k, b] + x[k, l, c] >= 1;");
            wr.WriteLine("s.t.cycle4{ (i, j, a) in Edges, (j, k, b) in Edges, (k, l, c) in Edges, (l, m, d) in Edges: m == i }: x[i, j, a] + x[j, k, b] + x[k, l, c] + x[l, m, d] >= 1;");
            wr.WriteLine("solve;");
            wr.WriteLine("printf \"#OUTPUT:\\n\";");
            wr.WriteLine("printf \"OPTIMUM = %d\\nz\", sum{(i,j,w) in Edges: x[i,j,w]>0} w;");
            wr.WriteLine("printf{(i,j,w) in Edges : x[i,j,w]>0} \"Edge %d --> %d (%d)\\n\", i, j, w;");
            wr.WriteLine("printf \"#OUTPUT END\\n\";");
            wr.WriteLine("end;");
            wr.Flush();
        }

        static void PrintHelp()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("\tnonTS.exe filename");
            Console.WriteLine();
            Console.WriteLine("Reads directed weighed graph from <filename> inputfile and converts it to Linear Program for glpsol(.exe) linear program solver.");
            Console.WriteLine("Result is wrote into <filename>.mod file ");
        }
    }
}
