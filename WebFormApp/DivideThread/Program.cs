using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DivideThread
{
    class Program
    {
        static byte[] bytes = new byte[600000000];
        static int portionSize = bytes.Length / Environment.ProcessorCount;
        static long[] portionResults = new long[portionSize];

        static void GenerateBytes()
        {
            Random rand = new Random();
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)rand.Next(10000);
            }
        }

        static void SumPortion(object index)
        {
            long sum = 0;
            int baseIndex = (int)index;
            long start = baseIndex * portionSize;
            long end = (baseIndex + 1) * portionSize;
            for (long i = start; i < end; i++)
            {
                sum += bytes[i];
            }
            portionResults[baseIndex] = sum;
        }


        static void Main(string[] args)
        {
            long sum = 0;
            Stopwatch watch = new Stopwatch();
            watch.Start();
            GenerateBytes();
            for (int i = 0; i < bytes.Length; i++)
                sum += (int)bytes[i];
            Console.WriteLine("The total result is {0}", sum);

            watch.Stop();
            Console.WriteLine("The total time is {0}", watch.Elapsed);

            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //GenerateBytes();

            //Thread[] threads = new Thread[Environment.ProcessorCount];
            //for (int i = 0; i < Environment.ProcessorCount; i++)
            //{
            //    threads[i] = new Thread(SumPortion);
            //    threads[i].Start(i);
            //}

            //for (int i = 0; i < Environment.ProcessorCount; i++)
            //{
            //    threads[i].Join();
            //}

            //long sum = portionResults.Sum();
            //Console.WriteLine("Total is {0}", sum);
            //watch.Stop();
            //Console.WriteLine("The total time is {0}", watch.Elapsed);
        }
    }
}
