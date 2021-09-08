using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            //Генерировать и считать среднее арифметическое для массива размером в 10М и 100М элементов.
            //Реализовать 2 варианта, параллельные вычисления и без них, оценить результаты.
            {
                //var locker = new object();
                //var rnd = new Random();
                //int l = 10_000/*_000*/, w = 100_000/*_000*/;
                //int i, j;
                //var completed = 0;

                //var intArray = new int[l, w];
                //double average;
                //int sum = 0;

                ////вариант 1
                ////параллельная генерация массива и вычисления

                ////генерирует содержимое массива
                //ThreadPool.QueueUserWorkItem(_ =>
                //{
                //    for (i = 0; i < intArray.Length; i++)
                //    {
                //        lock (locker)
                //        {
                //            intArray[i % l, i / l] = rnd.Next(5, 10);
                //            Console.WriteLine($"{i + 1} elements");
                //        }
                //    }
                //    Interlocked.Increment(ref completed);
                //});

                ////считает среднее арифметическое
                //ThreadPool.QueueUserWorkItem(_ =>
                //{
                //    for (j = 0; j < intArray.Length; j++)
                //    {
                //        lock (locker)
                //        {
                //            sum += intArray[j % l, j / l];
                //            average = Convert.ToDouble(sum) / (j + 1);
                //            Console.WriteLine($"current average:  {average:n4}");
                //        }
                //    }
                //    Interlocked.Increment(ref completed);
                //});

                ////ожидает завершение работы потоков
                //while (completed < 2)
                //{
                //    Thread.Sleep(500);
                //}

                ////вариант 2
                ////считает среднее арифметическое после генерации массива
                ////(т.к. массив уже сгенерирован, осталось лишь посчитать среднее арифметическое)
                //sum = 0;
                //foreach (var item in intArray)
                //{
                //    sum += item;
                //}
                //average = Convert.ToDouble(sum) / intArray.Length;
                //Console.WriteLine($"\nreal average:  {average}");

                ////Оценка результата: при параллельных генерации и вычислениях поток, вычисляющий среднее арифметическое
                ////элементов массива, может "уйти вперёд" => результат вычислений исказится 
            }

            //Реализовать очередь задач, которая позволит добавлять задачи на исполнение из разных
            //потоков одновременно и регулировать кол-во одновременно выполняемых задач.

            var taskRecieverAndExecutor = new TaskRecieverAndExecutor() { TaskQueue = new List<Task>(),
                CancelTokenSource= new CancellationTokenSource()};
            taskRecieverAndExecutor.Token = taskRecieverAndExecutor.CancelTokenSource.Token;

            ThreadPool.QueueUserWorkItem(_ =>
            {
                while (true)
                {
                    if (taskRecieverAndExecutor.TaskQueue.Count < 100)
                    {
                        taskRecieverAndExecutor.AddTask(() => 
                        {
                            Console.WriteLine($"New task started executing..");
                            Thread.Sleep(50);
                            Console.WriteLine($"      Task finished executing");
                        });
                    }
                }
            });

            ThreadPool.QueueUserWorkItem(_ =>
            {
                taskRecieverAndExecutor.Start(20);
            });

            ThreadPool.QueueUserWorkItem(_ =>
            {
                Thread.Sleep(1000);
                taskRecieverAndExecutor.Stop();
                taskRecieverAndExecutor.Clear();

                Console.WriteLine($"-----------------Stop---------------");
            });

            Console.ReadKey();
        }
    }
}
