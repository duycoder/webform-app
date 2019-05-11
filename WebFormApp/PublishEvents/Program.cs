using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }

    //tạo một class kế thừa "EventArgs" để lưu trữ thông tin của sự kiện
    class CustomEventArgs : EventArgs
    {
        private string msg;
        public CustomEventArgs(string s)
        {
            msg = s;
        }
        public string Message
        {
            get { return msg; }
            set { msg = value; }
        }
    }

    //định nghĩa một lớp sẽ   xuất bản "sự kiện"
    class Publisher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">đối tượng "phát ra" sự kiện</param>
        /// <param name="e">thông tin sự kiện</param>
        public delegate void CustomEventHandler(object sender, CustomEventArgs e);

        /// <summary>
        /// khai báo đối tượng "event" chứa các delegate
        /// </summary>
        public event CustomEventHandler RaiseEventHandler;

        public void DoSomething()
        {
            OnRaiseCustomEvent(new CustomEventArgs("Do SomeThing"));
        }

        //wrap event invocations inside a protected virtual methdo
        //allows derived classes to override the event invocation behavior
        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            if (RaiseEventHandler != null)
            {
                e.Message += $" at {DateTime.Now}";
                RaiseEventHandler(this, e);
            }
        }
    }
}
