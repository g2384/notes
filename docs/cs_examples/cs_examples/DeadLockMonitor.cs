using System;
using System.Threading;

namespace cs_examples
{
    internal class DeadLockMonitor
    {
        private static object lock1 = new object();
        private static object lock2 = new object();

        private static void AcquireLocks1()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;

            while (true)
            {
                if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(1)))
                {
                    try
                    {
                        Console.WriteLine($"Thread {threadId} acquired lock 1.");
                        Thread.Sleep(1000);
                        Console.WriteLine($"Thread {threadId} attempted to acquire lock 2.");

                        if (Monitor.TryEnter(lock2, TimeSpan.FromSeconds(1)))
                        {
                            try
                            {
                                Console.WriteLine($"Thread {threadId} acquired lock 2.");
                                break; // exit the loop if both locks are acquired
                            }
                            finally
                            {
                                Monitor.Exit(lock2);
                            }
                        }
                    }
                    finally
                    {
                        Monitor.Exit(lock1);
                    }
                }
            }

            Console.WriteLine($"Thread {threadId} is done.");
        }

        private static void AcquireLocks2()
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;

            while (true)
            {
                if (Monitor.TryEnter(lock2, TimeSpan.FromSeconds(1)))
                {
                    try
                    {
                        Console.WriteLine($"Thread {threadId} acquired lock 2.");
                        Thread.Sleep(1000);
                        Console.WriteLine($"Thread {threadId} attempted to acquire lock 1.");

                        if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(1)))
                        {
                            try
                            {
                                Console.WriteLine($"Thread {threadId} acquired lock 1.");
                                break; // exit the loop if both locks are acquired
                            }
                            finally
                            {
                                Monitor.Exit(lock1);
                            }
                        }
                    }
                    finally
                    {
                        Monitor.Exit(lock2);
                    }
                }
            }

            Console.WriteLine($"Thread {threadId} is done.");
        }

        public static void Start()
        {
            // Create two new threads that compete for the locks
            var thread1 = new Thread(AcquireLocks1);
            var thread2 = new Thread(AcquireLocks2);

            // Start the threads
            thread1.Start();
            thread2.Start();

            // Wait for the threads to complete
            thread1.Join();
            thread2.Join();

            Console.WriteLine("Finished.");
            Console.ReadLine();
        }
    }
}