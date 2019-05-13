using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            //Shape shape = new Shape();
            //Subscriber1 sub1 = new Subscriber1(shape);
            //Subscriber2 sub2 = new Subscriber2(shape);

            //sub1.Draw();

            //Publisher pub = new Publisher();
            //Suber sb = new Suber(pub);

            //pub.OnPublisherEvent();

            //Console.ReadKey();


            UserController contrl = new UserController(new UserBusiness());
            contrl.OnControllerEvent();
        }
    }

    public interface IDrawingObject
    {
        event EventHandler OnDraw;
    }

    public interface IShape
    {
        event EventHandler OnDraw;
    }

    public class Shape : IDrawingObject, IShape
    {
        public event EventHandler ObjectEventHander;
        public event EventHandler ShapeEventHander;

        object objectLock = new object();

        //explicit interface implement

        event EventHandler IDrawingObject.OnDraw
        {
            add
            {
                lock (objectLock)
                {
                    ObjectEventHander += value;
                }
            }

            remove
            {
                lock (objectLock)
                {
                    ObjectEventHander -= value;
                }
            }
        }

        event EventHandler IShape.OnDraw
        {
            add
            {
                lock (objectLock)
                {
                    ShapeEventHander += value;
                }
            }

            remove
            {
                lock (objectLock)
                {
                    ShapeEventHander -= value;
                }
            }
        }

        public void Draw()
        {
            ObjectEventHander?.Invoke(this, EventArgs.Empty);

            Console.WriteLine("==== DRAWING ====");

            ShapeEventHander?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Subscriber1 : Shape
    {
        public Subscriber1(Shape sh)
        {
            IDrawingObject drawObj = (IDrawingObject)sh;
            drawObj.OnDraw += OnDraw;
        }

        void OnDraw(object sender, EventArgs e)
        {
            Console.WriteLine("DRAING AN OBJECT");
        }
    }

    public class Subscriber2 : Shape
    {
        public Subscriber2(Shape sh)
        {
            IShape drawObj = (IShape)sh;
            drawObj.OnDraw += OnDraw;
        }

        void OnDraw(object sender, EventArgs e)
        {
            Console.WriteLine("DRAING A SHAPE");
        }
    }



    public interface IBusinessEvent
    {
        event EventHandler BusinessEventHandler;
        void Subscribe();

        void RaiseEvent();
    }

    public class UserBusiness : IBusinessEvent
    {
        public event EventHandler BusinessEventHandler;

        public void Subscribe()
        {
            BusinessEventHandler += OnEvent;
        }

        public void RaiseEvent()
        {
            BusinessEventHandler?.Invoke(this, EventArgs.Empty);
        }

        void OnEvent(object sender, EventArgs e)
        {
            Console.WriteLine("TESTING UserBusiness");
        }
    }

    public class UserController
    {
        IBusinessEvent _userBusinessEvent;
        public UserController(IBusinessEvent userBusinessEvent)
        {
            this._userBusinessEvent = userBusinessEvent;
            this._userBusinessEvent.Subscribe();
        }

        public void OnControllerEvent()
        {
            this._userBusinessEvent.RaiseEvent();
        }
    }
}
