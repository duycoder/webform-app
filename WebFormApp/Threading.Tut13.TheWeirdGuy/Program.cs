using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.Tut13.TheWeirdGuy
{

    class Basic
    {
        public void Running(int id)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Running in by {0}", id);
                //Thread.Sleep(500);
            }
        }
    }

    class Program
    {
        static Basic basic = new Basic();

        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                new Thread(RegularRunning).Start();
            }
            new Thread(WeirdRunning).Start();
        }

        static void RegularRunning()
        {
            lock (basic)
            {
                basic.Running(Thread.CurrentThread.ManagedThreadId);
            }
        }

        static void WeirdRunning()
        {
            basic.Running(99);
        }
    }
}
