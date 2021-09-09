using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        public static int length = 100_000_000;
        public static int[] array = new int[length];
        public static int sum = 0;

        static void Main(string[] args)
        {
            //Генерировать и считать среднее арифметическое для массива размером в 10М и 100М элементов.
            //Реализовать 2 варианта, параллельные вычисления и без них, оценить результаты.

            int i, n = 10;
            Random rnd = new Random();
            double average1, average2;
            var stopwatch = new Stopwatch();
            TimeSpan sequentialCalculationsTime, parallelCalculationsTime;

            for (i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(5, 10);
            }

            //последовательные вычисления
            stopwatch.Start();
            for (i = 0; i < n; i++)
            {
                sum = 0;
                foreach (var item in array)
                {
                    sum += item;
                }
                average1 = Convert.ToDouble(sum) / length;
            }
            stopwatch.Stop();
            sequentialCalculationsTime = stopwatch.Elapsed / n;

            stopwatch = new Stopwatch();

            //параллельные вычисления
            stopwatch.Start();

            for (i = 0; i < n; i++)
            {
                sum = 0;
                Parallel.For(0, length / 4 - 1, GetSum);
                Parallel.For(length / 4, length / 2 - 1, GetSum);
                Parallel.For(length / 2, length / 4 * 3 - 1, GetSum);
                Parallel.For(length / 4 * 3, length - 1, GetSum);
                average2 = Convert.ToDouble(sum) / length;
            }
            stopwatch.Stop();
            parallelCalculationsTime = stopwatch.Elapsed / n;

            Console.WriteLine($"{sequentialCalculationsTime} - время последовательных вычислений" +
                $"\n{parallelCalculationsTime} - время параллельных вычислений");

            Console.ReadKey();
        }

        public static void GetSum(int i)
        {
            sum += array[i];
        }
    }
}
