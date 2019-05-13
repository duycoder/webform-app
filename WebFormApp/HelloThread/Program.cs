using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Write1);
            thread1.Priority = ThreadPriority.Highest;
            

            Thread thread2 = new Thread(Write2);
            thread2.Priority = ThreadPriority.Lowest;
            thread2.Start(); thread1.Start();

            //Console.WriteLine("Call Write('-') in main Thread...\n");
            //for (int i = 0; i < 50; i++)
            //{
            //    Console.WriteLine("================= WRITING MAIN THREAD");
            //    Thread.Sleep(70);
            //}
            ////thread.Join();
            //Console.WriteLine("==================== DONE MAIN THREAD ====================");
        }

        static void Write1()
        {
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine("============== WRITING CHILD THREADS111");
                //Thread.Sleep(100);
            }
        }

        static void Write2()
        {
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine("============== WRITING CHILD THREADS222");
                //Thread.Sleep(100);
            }
        }
    }
}
