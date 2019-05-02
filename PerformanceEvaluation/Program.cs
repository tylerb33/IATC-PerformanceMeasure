using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceEvaluation
{
    class Program
    {
        static void Main(string[] args)
        {

            //int[] iterations = new int[] { 500, 5000, 50000 };

            //CalculateSpeed(AppendTextTest, iterations, "Append Text");
            //CalculateSpeed(StringBuilderTest, iterations, "Stringbuilder Text");

            int[] iterations = new int[] { 500000, 5000000 };
            CalculateSpeed(DoubleTest, iterations, "Double");
            CalculateSpeed(DecimalTest, iterations, "Decimal");

            Console.ReadLine();
        }

        public static void DoubleTest(int repetitions)
        {
            double x = 4.25;
            double y = 25.75;

            for (int i = 0; i < repetitions; i++)
            {
                x += y;
            }
        }

        public static void DecimalTest(int repetitions)
        {
            decimal x = 4.25M;
            decimal y = 25.75M;

            for (int i = 0; i < repetitions; i++)
            {
                x += y;
            }
        }

        public static void AppendTextTest(int iterations)
        {
            string test = "";
            for (int i = 0; i < iterations; i++)
            {

                test += "testing";

            }
        }

        static void StringBuilderTest(int iterations)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < iterations; i++)
            {
                stringBuilder.Append("testing");
            }
            string sbOutput = stringBuilder.ToString();
        }


        public static void CalculateSpeed(Action<int> methodToTest, int[] repetitions, string testName)
        {
            for (int i = 0; i < repetitions.Length; i++)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                stopwatch.Start();

                methodToTest(repetitions[i]);

                stopwatch.Stop();
                Console.WriteLine($"{ testName } { repetitions[i]} reps: { stopwatch.ElapsedMilliseconds} ms");

            }
        }



    }
}
