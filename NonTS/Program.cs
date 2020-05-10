using System;
using System.Dynamic;
using System.IO;
using System.Linq;

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
            TextWriter wr = new StreamWriter(File.OpenWrite($"{args[0]}.out"));
            //TextWriter wr = Console.Out;
            DateTime start = DateTime.Now;


            wr.Write(g.Edges.FormateLines(x => string.Format("var x{0}, integer, >= 0, <= 1;", x.Id)));

            Console.WriteLine("Variables created.");

            wr.Write("minimize obj: ");
            wr.Write(g.Edges.FormateLine(x => string.Format("({0} * x{1})", x.Weith, x.Id), " + ", ";\n"));

            Console.WriteLine("Objective function created.");

            var cycles3 = g.Oriented3Cycles();
            cycles3.FormateLines( wr,
                (x,i) => $"s.t. c{i}: x{x[0].Id} + x{x[1].Id} + x{x[2].Id} >= 1;"
                );

            Console.WriteLine("3-cycle constrains created.");

            var cycles4 = g.Oriented4Cycles();
            cycles4.FormateLines( wr,
                (x,i) => $"s.t. c{cycles3.Count + i}: x{x[0].Id} + x{x[1].Id} + x{x[2].Id} + x{x[3].Id} >= 1;"
                );


            Console.WriteLine("4-cycle constrains created.");

            wr.WriteLine("solve;");
            wr.WriteLine("printf \"#OUTPUT:\\n\";");
            wr.Write(g.Edges.FormateLines(
                x => string.Format("printf (if x{0} > 0 then \"{1} --> {2} ({3})\\n\" else \"\"), 3;", x.Id, x.A, x.B, x.Weith)));
            wr.WriteLine("printf \"#OUTPUT END\\n\";");
            wr.WriteLine("end;");
            wr.Flush();


            Console.WriteLine("output code created.");
            Console.WriteLine();
            Console.WriteLine("Total time: {0} sec", (DateTime.Now - start).TotalSeconds);
        }

        static void PrintHelp()
        {

        }
    }
}
