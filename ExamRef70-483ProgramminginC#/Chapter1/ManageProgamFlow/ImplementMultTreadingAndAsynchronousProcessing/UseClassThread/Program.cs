using System;
using System.Threading;

namespace UseClassThread
{
    class Program
    {
        private static int count = 10;
        private const string Number1 = "1";
        private const string Number2 = "2";
        private const string Number3 = "3";
        private const string Number4 = "4";
        private const string Number5 = "5";
        private const string Number6 = "6";

        [ThreadStatic]
        public static int _field;

        static void ConsoleThread()
        {
            for (int i = 0; i < Program.count * 2; i++)
            {
                Console.WriteLine("ThreadProcessing: {0}", i);
                Thread.Sleep(0);
            }
        }

        static void ConsoleThread(object o)
        {
            for (int i = 0; i < Program.count * 2; i++)
            {
                Console.WriteLine("ThreadProcessing: {0}", i);
                Thread.Sleep(0);
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("1- Foreground \n2- Background \n3- ParameterizedThreadStart \n4- StoppingThread \n5- ThreadStaticAttribute \n6- AttributeThreadLocal");
            var option = Console.ReadLine();

            switch (option)
            {
                case Program.Number1:
                    ForegroundThread();
                    break;
                case Program.Number2:
                    BackgroundThread();
                    break;
                case Program.Number3:
                    WithParameterizedThreadStart();
                    break;
                case Program.Number4:
                    WithStoppingThread();
                    break;
                case Program.Number5:
                    ShowAttributeThread();
                    break;
                case Program.Number6:
                    ShowAttributeThreadLocal();
                    break;
                default:
                    break;
            }

            Console.WriteLine("Press any key to exit console.");
            Console.ReadKey();
        }

        static void ForegroundThread()
        {
            Thread thread = new Thread(new ThreadStart(ConsoleThread));
            thread.Start();

            for (int i = 0; i < Program.count; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }

            thread.Join();
        }

        static void BackgroundThread()
        {
            Thread t = new Thread(new ThreadStart(ConsoleThread));
            t.IsBackground = true;
            t.Start();
        }

        static void WithParameterizedThreadStart()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ConsoleThread));
            t.Start(5);
            t.Join();
        }

        static void WithStoppingThread()
        {
            bool stopped = false;

            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));

            t.Start();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            stopped = true;
            t.Join();
        }

        static void ShowAttributeThread()
        {
            new Thread(() =>
                {
                    for (int x = 0; x < Program.count; x++)
                    {
                        _field++;
                        Console.WriteLine("Thread A: {0}", _field);
                    }
                }).Start();
            new Thread(() =>
                {
                    for (int x = 0; x < Program.count; x++)
                    {
                        _field++;
                        Console.WriteLine("Thread B: {0}", _field);
                    }
                }).Start();

            Console.ReadKey();
        }

        public static ThreadLocal<int> _fieldLocal =
            new ThreadLocal<int>(() =>
            {
                return Thread.CurrentThread.ManagedThreadId;
            });

        static void ShowAttributeThreadLocal()
        {
            new Thread(() =>
                {
                    for (int x = 0; x < _fieldLocal.Value; x++)
                    {
                        _field++;
                        Console.WriteLine("Thread A: {0}", x);
                    }
                }).Start();
            new Thread(() =>
                {
                    for (int x = 0; x < _fieldLocal.Value; x++)
                    {
                        _field++;
                        Console.WriteLine("Thread B: {0}", x);
                    }
                }).Start();

            Console.ReadKey();
        }
    }
}
