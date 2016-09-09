using BenchmarkDotNet.Running;
using System;

namespace ForEachTimings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1: Construct Benchmarks");
            Console.WriteLine("2: LINQ Benchmarks");
            Console.WriteLine("3: Structure Benchmarks");
            Console.Write("Mode? ");
            var mode = int.Parse(Console.ReadLine());

            switch (mode)
            {
                case 1:
                    BenchmarkRunner.Run<ConstructBenchmarks>();
                    return;
                case 2:
                    BenchmarkRunner.Run<LinqBenchmarks>();
                    return;
                case 3:
                    BenchmarkRunner.Run<StructureBenchmarks>();
                    return;
            }
        }


    }

}
