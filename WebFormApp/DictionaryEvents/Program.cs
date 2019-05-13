using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryEvents
{
    /*
     * - khai báo các delegate
     */
    public delegate void EventHandler1(int i);
    public delegate void EventHandler2(string s);

    public class PropertyEvent
    {
        private const string Event1Key = nameof(Event1);
        private const string Event2Key = nameof(Event2);
        private readonly Dictionary<string, Delegate> handlers;

        public PropertyEvent()
        {
            handlers = new Dictionary<string, Delegate>()
            {
                [Event1Key] = null,
                [Event2Key] = null
            };
        }

        public event EventHandler1 Event1
        {
            add
            {
                lock (handlers)
                {
                    handlers[Event1Key] = (EventHandler1)handlers[Event1Key] + value;
                }
            }
            remove
            {
                lock (handlers)
                {
                    handlers[Event1Key] = (EventHandler1)handlers[Event1Key] - value;
                }
            }
        }

        public event EventHandler2 Event2
        {
            add
            {
                lock (handlers)
                {
                    handlers[Event2Key] = (EventHandler2)handlers[Event2Key] + value;
                }
            }
            remove
            {
                lock (handlers)
                {
                    handlers[Event2Key] = (EventHandler2)handlers[Event2Key] - value;
                }
            }
        }

        internal void RaiseEvent1(int i)
        {
            EventHandler1 handler;
            lock (handlers)
            {
                handler = (EventHandler1)handlers[Event1Key];
                handler.Invoke(i);
            }
        }

        internal void RaiseEvent2(string s)
        {
            EventHandler2 handler;
            lock (handlers)
            {
                handler = (EventHandler2)handlers[Event2Key];
                handler.Invoke(s);
            }
        }

    }

    public class Program
    {
        static void Delegate1Method(int i) => Console.WriteLine(i);
        static void Delegate11Method(int i) => Console.WriteLine("This is {0}", i);
        static void Delegate2Method(string s) => Console.WriteLine(s);
        static void Delegate22Method(string s) => Console.WriteLine("This is {0}", s);


        static void Main(string[] args)
        {
            PropertyEvent pe = new PropertyEvent();
            pe.Event1 += Delegate1Method;
            pe.Event1 += Delegate11Method;

            pe.Event2 += Delegate2Method;
            pe.Event2 += Delegate22Method;

            pe.RaiseEvent1(1);
            pe.RaiseEvent2("Nguyễn Ngọc Duy");

            Console.ReadKey();
        }
    }


}
