using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    public class TaskRecieverAndExecutor : IJobExecutor
    {
        public CancellationTokenSource CancelTokenSource { get; set; }
        public CancellationToken Token
        {
            get
            {
                return CancelTokenSource.Token;
            }
            set { }
        }

        public List<Task> TaskQueue { get; set; }

        public int TaskAmount //Кол-во задач в очереди на обработку
        {
            get
            {
                return TaskQueue.Count();
            }
        }

        public void Start(int maxConcurrent) //Запустить обработку очереди и установить максимальное кол-во параллельных задач
        {
            while (!Token.IsCancellationRequested)
            {
                var semaphore = new Semaphore(maxConcurrent, maxConcurrent);
                while (TaskAmount >= maxConcurrent && !Token.IsCancellationRequested)
                {
                    if (!TaskQueue[0].IsCompleted)
                        TaskQueue[0].Start();
                    semaphore.WaitOne();
                    TaskQueue.RemoveAt(0);
                }
            }
        }

        public void AddTask(Action action) //Добавить задачу в очередь
        {
            TaskQueue.Add(new Task(action));
        }

        public void Stop() //Остановить обработку очереди и выполнять задачи
        {
            CancelTokenSource.Cancel();
        }

        public void Clear() //Очистить очередь задач
        {
            TaskQueue.Clear();
        }
    }
}
