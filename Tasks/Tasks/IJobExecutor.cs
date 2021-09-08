using System;

namespace Tasks
{
    public interface IJobExecutor
    {
        public int TaskAmount { get; } 
        public void Start(int maxConcurrent); 
        public void Stop(); 
        public void AddTask(Action action); 
        public void Clear(); 
    }
}
