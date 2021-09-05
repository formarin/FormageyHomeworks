using System;
using System.Threading;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            //Генерировать и считать среднее арифметическое для массива размером в 10М и 100М элементов.
            //Реализовать 2 варианта, параллельные вычисления и без них, оценить результаты.
            
            var locker = new object();
            var rnd = new Random();
            int l = 10_000_000, w = 100_000/*_000*/;
            int i, j;
            var completed = 0;

            var intArray = new int[l, w];
            double average;
            int sum = 0;

            //вариант 1
            //параллельная генерация массива и вычисления
            ThreadPool.QueueUserWorkItem(_ =>//генерирует содержимое массива
            {
                for (i = 0; i < intArray.Length; i++)
                {
                    lock (locker)
                    {
                        intArray[i % l, i / l] = rnd.Next(5, 10);
                        Console.WriteLine($"{i + 1} elements");
                    }
                }
                Interlocked.Increment(ref completed);
            });

            ThreadPool.QueueUserWorkItem(_ =>//считает среднее арифметическое
            {
                for (j = 0; j < intArray.Length; j++)
                {
                    lock (locker)
                    {
                        sum += intArray[j % l, j / l];
                        average = Convert.ToDouble(sum) / (j + 1);
                        Console.WriteLine($"current average:  {average:n4}");
                    }
                }
                Interlocked.Increment(ref completed);
            });

            while (completed < 2)//ожидает завершение работы потоков
            {
                Thread.Sleep(500);
            }

            //вариант 2
            //считает среднее арифметическое после генерации массива
            //(т.к. массив уже сгенерирован, осталось лишь посчитать среднее арифметическое)
            sum = 0;
            foreach (var item in intArray)
            {
                sum += item;
            }
            average = Convert.ToDouble(sum) / intArray.Length;
            Console.WriteLine($"\nreal average:  {average}");

            //Оценка результата: при параллельных генерации и вычислениях поток, вычисляющий среднее арифметическое
            //элементов массива, может "уйти вперёд" => результат вычислений исказится 

            Console.ReadKey();
        }
    }
}
