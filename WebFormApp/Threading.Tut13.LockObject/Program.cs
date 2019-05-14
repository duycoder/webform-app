using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.Tut13.LockObject
{
    class Program
    {
        static SyncQueue<int> numbers = new SyncQueue<int>();
        static int threadNumbers = Environment.ProcessorCount;
        static int[] groupSums = new int[threadNumbers];
        static Random rand = new Random();

        static void GenerateNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                int valueToAdd = rand.Next(1000);
                //lock (numbers)
                    numbers.Enqueue(valueToAdd);
                Console.WriteLine("Write {0} to the queue", valueToAdd);
            }
        }

        static void CalculateSum(object index)
        {
            int baseIndex = (int)index;
            var baseTime = DateTime.Now;
            int sum = 0;
            while (numbers.Count != 0)
            {
                int valueFromQueue = 0;
                //lock (numbers)
                {
                    if (numbers.Count != 0)
                    {
                        valueFromQueue = numbers.Dequeue();
                    }
                }
                sum += valueFromQueue;
                Console.WriteLine("Thread #{0} getting {1} from the queue to add.", baseIndex, valueFromQueue);
            }
            groupSums[baseIndex] = sum;
        }

        static void Main(string[] args)
        {
            Thread generateThread = new Thread(GenerateNumbers);
            generateThread.Start();
            generateThread.Join();

            Thread[] threads = new Thread[threadNumbers];

            for (int i = 0; i < threadNumbers; i++)
            {
                threads[i] = new Thread(CalculateSum);
                threads[i].Start(i);
            }

            for (int i = 0; i < threadNumbers; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine("============== The total sum is {0} ==============", groupSums.Sum());
            Console.ReadKey();
        }
    }

    class SyncQueue<T>
    {
        Queue<T> items = new Queue<T>();

        public void Enqueue(T item)
        {
            lock (items)
                items.Enqueue(item);
        }

        public T Dequeue()
        {
            lock (items)
                return items.Dequeue();
        }

        public int Count
        {
            get
            {
                lock (items)
                    return items.Count;
            }
        }
    }
}
