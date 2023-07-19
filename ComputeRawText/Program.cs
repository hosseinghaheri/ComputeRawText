using ComputeRawText.Extensions;
using System;

namespace ComputeRawText
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var eq = "2+2";
            var simpleCompute = eq.SimpleCompute();
            Console.WriteLine($"Simple Compute:\r\n\t{eq}= {simpleCompute}");

            eq = "x < 0 ? Abs(x) : x * 2";
            string result1 = eq.Compute(new { x = -4 });
            string result2 = eq.Compute(new { x = 7 });

            Console.WriteLine($"Ultra Compute:\r\n\t{eq}");
            Console.WriteLine($"\t\tx=-4 -> {result1}");
            Console.WriteLine($"\t\tx=7 -> {result2}");

            Console.ReadKey();
        }
    }
}
