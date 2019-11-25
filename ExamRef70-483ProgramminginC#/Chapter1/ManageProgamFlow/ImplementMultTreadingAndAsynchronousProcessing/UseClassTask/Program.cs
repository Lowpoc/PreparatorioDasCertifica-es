using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UseClassTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("*");
                }
            });

            task.Wait();

            Console.WriteLine("\nSee below task with method continuewith:");

            Task<int> task2 = Task.Run(() =>
            {
                return 10;
            }).ContinueWith((value) =>
            {
                Console.WriteLine("10 x 2 : {0}", value.Result * 2);
                return 20;
            });

            task2.Wait();

            Console.WriteLine("\nSee below task with multiple continuewith in differents status:");

            Task<int> task3 = Task.Run(() =>
            {
                return 42;
            });

            task3.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            task3.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = task3.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);


            completedTask.Wait();

            Console.WriteLine("Using WaitAny..");
            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });

            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> finshedTask = tasks[i];
                Console.WriteLine(finshedTask.Result);
                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }

            tasks = new Task<int>[3];

            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 3; });

            Console.WriteLine("Using WaitAll..");
            Task.WaitAll(tasks);

            Console.WriteLine("Finshed all task :)");
      
        }
    }
}
