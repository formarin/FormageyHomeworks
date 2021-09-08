using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //Реализовать очередь задач, которая позволит добавлять задачи на исполнение из разных
            //потоков одновременно и регулировать кол-во одновременно выполняемых задач.

            var taskRecieverAndExecutor = new TaskRecieverAndExecutor()
            {
                TaskQueue = new List<Task>(),
                CancelTokenSource = new CancellationTokenSource()
            };
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
