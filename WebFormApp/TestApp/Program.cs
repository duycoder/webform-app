using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Button openFileButton = new Button("OpenFile");
            Button saveFileButton = new Button("SaveFile");

            openFileButton.OnButtonClick += OnOpenFileClicked;
            saveFileButton.OnButtonClick += OnSaveFileClicked;

            openFileButton.Clicked();
            saveFileButton.Clicked();

            Console.ReadLine();
        }

        static void OnOpenFileClicked(Button button, int x, int y)
        {
            string message = string.Format("We open the file at ({0},{1})", x, y);
            Console.WriteLine(message);
        }

        static void OnSaveFileClicked(Button button, int x, int y)
        {
            string message = string.Format("We save the file at ({0},{1})", x, y);
            Console.WriteLine(message);
        }
    }

    interface IClickEvent
    {
        event EventHandler myHandler;
    }

    class Button
    {
        private string label;

        public delegate void ClickHandler(Button source, int x, int y);

        /*
         * khai báo sự kiện và không gán giá trị
         */
        public event ClickHandler OnButtonClick;

        public Button(string label)
        {
            this.label = label;
        }

        //sự kiện khi nhấn vào button
        public void Clicked()
        {
            Random random = new Random();
            int x = random.Next(1, 100);
            int y = random.Next(1, 20);

            OnButtonClick?.Invoke(this, x, y);
        }
    }
}
