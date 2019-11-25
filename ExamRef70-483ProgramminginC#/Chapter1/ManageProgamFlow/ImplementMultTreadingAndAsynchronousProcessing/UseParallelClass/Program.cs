using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace UseParallelClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
            });

            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
            });

            ParallelLoopResult result = Parallel.For(0, 600, (int i, ParallelLoopState loopstate) =>
            {
                if (i == 500)
                {
                    Console.WriteLine("Break loop parellel.");
                    loopstate.Break();
                }

                return;
            });
        }
    }
}
