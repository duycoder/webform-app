using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tut12.Threading.ProducerConsumer
{
    class Program
    {
        static Queue<int> numbers = new Queue<int>();
        static Random rand = new Random();

        const int threadNumbers = 3;
        static int[] groupSums = new int[threadNumbers];
        static void SumNumbers(object index)
        {
            DateTime startTime = DateTime.Now;
            int sumResult = 0;
            while ((DateTime.Now - startTime).Seconds < 10)
            {
                lock (numbers)
                {
                    if (numbers.Count != 0)
                    {
                        int numb = numbers.Dequeue();
                        sumResult += numb;
                        Console.WriteLine("Consuming thread {0} adding {1} to total sum.", index, numb);
                    }
                }
            }

            groupSums[(int)index] = sumResult;
        }

        static void ProducerNumber()
        {
            for (int i = 0; i < 11; i++)
            {
                int number = rand.Next(10);
                Console.WriteLine("Add {0} to the Queue", number);

                //thêm một phần tử vào đằng sau vị trí cuối cùng của "queue"
                numbers.Enqueue(number);
                Thread.Sleep(rand.Next(1000));
            }
        }

        static void Main(string[] args)
        {
            var produceThread = new Thread(ProducerNumber);
            produceThread.Start();

            Thread[] threads = new Thread[threadNumbers];
            for (int i = 0; i < threadNumbers; i++)
            {
                threads[i] = new Thread(SumNumbers);
                threads[i].Start(i);
            }

            for (int i = 0; i < threadNumbers; i++)
            {
                threads[i].Join();
            }

            int totalSum = groupSums.Sum();
            Console.WriteLine("total is {0}", totalSum);
        }
    }
}
