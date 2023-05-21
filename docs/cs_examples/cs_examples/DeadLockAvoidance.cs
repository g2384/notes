using System;
using System.Threading;

namespace cs_examples
{
    public class DeadLockAvoidance
    {
        private static object lockA = new object();
        private static object lockB = new object();

        private static void MyWork1()
        {
            lock (lockA)
            {
                Console.WriteLine("Trying to acquire lock on lockB");

                // This will try to acquire lock for 5 seconds.  
                if (Monitor.TryEnter(lockB, 5000))
                {
                    try
                    {
                        // This block will never be executed.  
                        Console.WriteLine("In DoWork1 Critical Section.");
                        // Access some shared resource here.  
                    }
                    finally
                    {
                        Monitor.Exit(lockB);
                    }
                }
                else
                {
                    // Print lock not able to acquire message.  
                    Console.WriteLine("Unable to acquire lock, exiting MyWork1.");
                }
            }
        }

        private static void MyWork2()
        {
            lock (lockB)
            {
                Console.WriteLine("Trying to acquire lock on lockA");
                lock (lockA)
                {
                    Console.WriteLine("In MyWork2 Critical Section.");
                    // Access some shared resource here.  
                }
            }
        }

        public static void Start()
        {
            // Initialize thread with address of DoWork1  
            Thread thread1 = new Thread(MyWork1);

            // Initilaize thread with address of DoWork2  
            Thread thread2 = new Thread(MyWork2);

            // Start the Threads.  
            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Done Processing...");
        }
    }
}