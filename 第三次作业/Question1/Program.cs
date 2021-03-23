using System;
namespace Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Factoy myfactory = new Factoy();
            Shape shape1 = myfactory.CreateShape("Triangle", 1, 1, 1);
            Shape shape2 = myfactory.CreateShape("Triangle", 2, 2, 2);
            Shape shape3 = myfactory.CreateShape("Triangle", 3, 3, 3);
            Shape shape4 = myfactory.CreateShape("Triangle", 4, 4, 4);
            Shape shape5 = myfactory.CreateShape("Rectangle", 1, 2);
            Shape shape6 = myfactory.CreateShape("Rectangle", 3, 4);
            Shape shape7 = myfactory.CreateShape("Rectangle", 5, 6);
            Shape shape8 = myfactory.CreateShape("Square", 1);
            Shape shape9 = myfactory.CreateShape("Square", 2);
            Shape shape10 = myfactory.CreateShape("Square", 3);

            Console.WriteLine( Convert.ToString(shape1.CalArea()+shape2.CalArea()+shape3.CalArea()+shape4.CalArea()
                +shape5.CalArea()+shape6.CalArea()+shape7.CalArea()+shape8.CalArea()+shape9.CalArea()
                +shape10.CalArea())
                );
        }
    }
    public abstract class Shape
    {
        public abstract double CalArea();
        public abstract bool IsIegal();
    }

    class Triangle : Shape
    {
        private double sideA;
        private double sideB;
        private double sideC;
        public Triangle(double sideA, double sideB, double sideC)
        { this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }
        public override double CalArea()
        {
            //throw new NotImplementedException();
            if (IsIegal() == false)
                throw new Exception("该条件不构成三角形！");
            double p = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideA));
            return area;
        }
        public override bool IsIegal()
        {
            //throw new NotImplementedException();
            if (sideA <= 0 || sideB <= 0 || sideC <= 0) return false;
            if (sideA + sideB <= sideC
                || sideB + sideC <= sideA
                || sideA + sideC <= sideB) return false;
            else return true;
        }
        public double SideA
        {
            get { return sideA; }
            set { sideA = value; }
        }
        public double SideB
        {
            get { return sideB; }
            set { sideB = value; }
        }

        public double SideC
        {
            get => sideC;
            set => sideC = value;
        }
    }

    class Rectangle : Shape
    {
        private double length;
        private double width;
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public double Length
        {
            get => length;
            set => length = value;
        }
        public double Width
        {
            get => width;
            set => width = value;
        }

        public override double CalArea()
        {
            if (IsIegal() == false)
                throw new Exception("该条件不构成长方形！");
            return length * width;
        }

        public override bool IsIegal()
        {
            if (length <= 0 || width <= 0)
                //throw new Exception("该条件不构成长方形！");
                return false;
            else return true;
        }
    }

    class Square: Rectangle
    {
        public Square(double length, double width):base(length,width)
        {
        }
        public override bool IsIegal()
        {
            if (Width != Length) return false;
            else return true;
        }
    }
}
