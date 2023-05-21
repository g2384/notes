using System;
using System.Threading;

namespace cs_examples
{
    public class DeadLock
    {
        private static object lockA = new object();
        private static object lockB = new object();

        private static void CompleteWork1()
        {
            lock (lockA)
            {
                Console.WriteLine("Trying to Acquire lock on lockB");
                lock (lockB)
                {
                    Console.WriteLine("Critical Section of CompleteWork1");
                    //Access some shared critical section.  
                }
            }
        }

        private static void CompleteWork2()
        {
            lock (lockB)
            {
                Console.WriteLine("Trying to Acquire lock on lockA");
                lock (lockA)
                {
                    Console.WriteLine("Critical Section of CompleteWork2");
                    //Access some shared critical section.  
                }
            }
        }

        public static void Start()
        {
            Thread thread1 = new Thread(CompleteWork1);
            Thread thread2 = new Thread(CompleteWork2);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            //Below code section will never execute due to deadlock.  
            Console.WriteLine("Processing Completed....");
        }
    }
}