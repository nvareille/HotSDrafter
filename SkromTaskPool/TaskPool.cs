using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkromTaskPool
{
    public class TaskPool
    {
        public int Max;
        public Task[] Tasks;
        private Queue<Func<Task>> Actions = new Queue<Func<Task>>();
        private int ToProcess;
        private int Processed = 0;
        private object Mutex = new object();

        public TaskPool(int max)
        {
            Max = max;
            Tasks = new Task[max];
        }

        public void AddTask(Func<Task> act)
        {
            Actions.Enqueue(act);
            ++ToProcess;
        }

        public void AddTask<T>(Func<T, Task> act, T parameter)
        {
            Actions.Enqueue(() => act(parameter));
            ++ToProcess;
        }

        public void AddTask<T, U>(Func<T, U, Task> act, T parameter1, U parameter2)
        {
            Actions.Enqueue(() => act(parameter1, parameter2));
            ++ToProcess;
        }

        public void AddTask<T, U, V>(Func<T, U, V, Task> act, T parameter1, U parameter2, V p3)
        {
            Actions.Enqueue(() => act(parameter1, parameter2, p3));
            ++ToProcess;
        }

        public Task Run()
        {
            while (ToProcess != Processed)
            {
                int count = 0;

                while (count < Max)
                {
                    Task available = Tasks[count];

                    if (available == null || available.IsCompleted)
                    {
                        if (available != null && available.IsCompleted)
                        {
                            lock (Mutex)
                            {
                                ++Processed;
                            }
                        }
                        StartAction(count);
                    }

                    ++count;
                }
            }

            return (Task.CompletedTask);
        }

        private bool StartAction(int index)
        {
            if (Actions.Count == 0)
                return (false);

            Func<Task> act = Actions.Dequeue();

            Tasks[index] = Task.Run(async () => await act());
            return (true);
        }
    }
}
