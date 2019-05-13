using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicThread
{
    class Program
    {
        static byte[] values = new byte[600000000];
        static void GenerateInts()
        {
            var rand = new Random();
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = (byte)rand.Next(10);
            }
        }

        static int count = 0;
        static object baton = new object();
        static Random rand = new Random();

        static long[] portionResults;
        static int portionSize;

        static void SumPortion(int portionNumber)
        {
            long sum = 0;

            for(int i = portionNumber * portionSize; i < (portionNumber + 1) * portionSize; i ++)
            {
                sum += values[i];
            }
            portionResults[portionNumber] = sum;
        }

        static void Main(string[] args)
        {
            portionResults = new long[Environment.ProcessorCount];
            portionSize = values.Length / Environment.ProcessorCount;

            Stopwatch watch = new Stopwatch();
            watch.Start();
            GenerateInts();
            Console.WriteLine("Summming ....");
            long total = 0;

            for (int i = 0; i < values.Length; i++)
            {
                total += values[i];
            }

            Console.WriteLine("Total is {0}", total);
            watch.Stop();
            Console.WriteLine("Time to sum: " + watch.Elapsed);


            //for (int i = 0; i < 10; i++)
            //{
            //    var thread = new Thread(DifferentMethod);
            //    thread.IsBackground = true;
            //    thread.Start(i);
            //}

            //var thread1 = new Thread(IncrementCount);

            //var thread2 = new Thread(IncrementCount);

            //thread1.Start();
            //Thread.Sleep(500);
            //thread2.Start();

            //for (int i = 0; i < 5; i++)
            //{
            //    var thread = new Thread(UseRestRoomStall);
            //    thread.Start();
            //}
        }

        static void UseRestRoomStall()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " trying to obtain the bathroom stall ...");
            //lock (baton)
            bool lockTaken = false;
            Monitor.Enter(baton, ref lockTaken);
            try
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " obtained the lock. Doing the business ...");
                Thread.Sleep(rand.Next(2000));
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " leaving the stall ...");
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(baton);
            }
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " leaving the restaurent ...");
        }

        static void IncrementCount()
        {
            while (true)
            {
                //lock (baton)
                //{
                int temp = count;

                Thread.Sleep(1000);

                count = temp + 1;
                Console.WriteLine("Thread Id: " + Thread.CurrentThread.ManagedThreadId + " increment to " + count);
                //}

                Thread.Sleep(1000);
            }
        }

        static void DifferentMethod(object threadId)
        {
            Console.WriteLine("Hello with thread id: {0}", threadId);
        }
    }
}
