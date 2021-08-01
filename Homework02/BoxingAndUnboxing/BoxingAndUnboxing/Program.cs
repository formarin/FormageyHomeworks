using System;
using System.Diagnostics;

namespace BoxingAndUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            object obj;
            TimeSpan averageBoxingTime, averageUnboxingTime;

            //объявление и заполнение массива
            int m = 10000;
            ulong[,] myArray = new ulong[m, m];
            for (i = 0; i < myArray.Length; i++)
            {
                myArray[i % m, i / m] = ulong.MaxValue;
            }

            //упаковка
            Stopwatch stopwatch = new Stopwatch();
            for (i = 0; i < 100000; i++)
            {
                stopwatch.Start();
                obj = myArray;
                stopwatch.Stop();
            }
            averageBoxingTime = stopwatch.Elapsed / i;

            //распаковка
            obj = myArray;
            stopwatch = new Stopwatch();
            for (i = 0; i < 100000; i++)
            {
                stopwatch.Start();
                myArray = (ulong[,])obj;
                stopwatch.Stop();
            }
            averageUnboxingTime = stopwatch.Elapsed / i;

            Console.WriteLine(
                $"Среднее время упаковки:    {averageBoxingTime}" +
                $"\nСреднее время распаковки:  {averageUnboxingTime}");

            Console.ReadKey();
        }
    }
}
