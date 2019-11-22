using System;
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

            Task<int> task2 = Task.Run(() => {
                return 10;
            }).ContinueWith((value) => {
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
        }
    }
}
