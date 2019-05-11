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
            //Button openFileButton = new Button("OpenFile");
            //Button saveFileButton = new Button("SaveFile");

            //openFileButton.OnButtonClick += OnOpenFileClicked;
            //saveFileButton.OnButtonClick += OnSaveFileClicked;

            //openFileButton.Clicked();
            //saveFileButton.Clicked();

            //Console.ReadLine();

            Safe safe = new Safe();
            Owner owner = new Owner();

            JewelThief thief = new JewelThief();
            thief.OpenSafe(safe, owner);

            Console.ReadKey();

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

    class Jewels
    {
        public string Sparkle()
        {
            return "Sparkle, sparkle";
        }
    }

    class Safe
    {
        private Jewels contents = new Jewels();
        private string safeCobination = "123456";

        public Jewels Open(string combination)
        {
            return (combination == safeCobination) ? contents : null;
        }

        public void PickLock(Locksmith lockPicker)
        {
            lockPicker.WriteDownCombination(safeCobination);
        }
    }

    class Owner
    {
        private Jewels returnedContents;
        public void ReceiveContents(Jewels safeContents)
        {
            returnedContents = safeContents;
            Console.WriteLine("Thank you for returning my jewels!" + safeContents.Sparkle());
        }
    }
    
    class Locksmith
    {
        public void OpenSafe(Safe safe, Owner owner)
        {
            safe.PickLock(this);
            Jewels safeContents = safe.Open(writtenCombination);
            ReturnContents(safeContents, owner);
        }

        private string writtenCombination = null;

        public void WriteDownCombination(string combination)
        {
            writtenCombination = combination;
        }

        public virtual void ReturnContents(Jewels safeContents, Owner owner)
        {
            owner.ReceiveContents(safeContents);
        }
    }

    class JewelThief : Locksmith
    {
        private Jewels stolenJewels = null;
        public override void ReturnContents(Jewels safeContents, Owner owner)
        {
            stolenJewels = safeContents;
            Console.WriteLine("I'm stealing the content " + stolenJewels.Sparkle());
        }
    }




}
