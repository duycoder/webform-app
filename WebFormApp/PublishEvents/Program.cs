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
            Circle c1 = new Circle(4.45);
            Rectangle r1 = new Rectangle(4.66, 500.1);
            var shapes = new ShapeContainer();
            shapes.AddShape(c1);
            shapes.AddShape(r1);
            c1.Update(445.4);
            r1.Update(404.6, 500.144);
            Console.ReadKey();
        }
    }

    public class ShapeEventArgs : EventArgs
    {
        double area;
        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        public ShapeEventArgs(double area)
        {
            this.area = area;
        }
    }

    public abstract class Shape
    {
        double area;
        protected double Area
        {
            get { return area; }
            set { area = value; }
        }
        public abstract void Draw();

        public virtual event EventHandler<ShapeEventArgs> ShapeEventHandler;

        protected void OnShapeChanged(ShapeEventArgs e)
        {
            ShapeEventHandler?.Invoke(this, e);
        }
    }

    public class Rectangle : Shape
    {
        double width, height;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
            this.Area = this.width * this.height;
        }

        public void Update(double width, double height)
        {
            Console.WriteLine("The old area is {0} \n", this.Area);

            this.width = width;
            this.height = height;
            this.Area = this.width * this.height;

            this.OnShapeChanged(new ShapeEventArgs(this.Area));
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle \n");
        }
    }

    public class Circle : Shape
    {
        double radius;
        public Circle(double radius)
        {
            this.radius = radius;
            this.Area = Math.PI * radius * radius;
        }

        public void Update(double radius)
        {
            Console.WriteLine("The old area is {0} \n", this.Area);

            this.radius = radius;
            this.Area = Math.PI * radius * radius;
            this.OnShapeChanged(new ShapeEventArgs(this.Area));
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a circle \n");
        }
    }

    public class ShapeContainer
    {
        List<Shape> groupShape;

        public ShapeContainer()
        {
            groupShape = new List<Shape>();
        }

        public void AddShape(Shape shape)
        {
            shape.ShapeEventHandler += OnShapeChanged;
            groupShape.Add(shape);
        }

        public void OnShapeChanged(object sender, ShapeEventArgs e)
        {
            Shape shape = (Shape)sender;
            shape.Draw();
            Console.WriteLine("This shape's area is {0} \n", e.Area);
        }
    }

}
