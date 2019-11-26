using System;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace UseConcurrentCollections
{
    class Program
    {
        static void Main(string[] args)
        {

            // A stack is a last in, first out (LIFO) collection. 
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            stack.Push(42);

            int result;
            if (stack.TryPop(out result))
                Console.WriteLine("Popped: {0}", result);

            stack.PushRange(new int[] { 1, 2, 3 });

            int[] values = new int[2];
            stack.TryPopRange(values);

            foreach (int i in values)
                Console.WriteLine(i);


            //  A queue is a first in, first out (FIFO) collection
            ConcurrentQueue<int> stackqueue = new ConcurrentQueue<int>();
            stackqueue.Enqueue(42);
            stackqueue.Enqueue(36);

            int resultqueue;

            if (stackqueue.TryDequeue(out resultqueue))
                Console.WriteLine("Dequeue: {0}", resultqueue);


            BlockingCollection<string> collection = new BlockingCollection<string>();

            Task read = Task.Run(() => {
                while (true)
                {
                    Console.WriteLine("You writed: " + collection.Take());
                }
            });

            Task write = Task.Run(() => {
                while (true)
                {
                    string text = Console.ReadLine();
                    if (string.IsNullOrEmpty(text)) break;

                    collection.Add(text);
                }
            });

            write.Wait();
        }
    }
}
