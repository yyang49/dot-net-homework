using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    interface Shape
    {
        double getArea();
        bool isValid();
    }
    class Ractangle : Shape
    {
        private double length, width;
        virtual public double Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }
        virtual public double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        public Ractangle(double a, double b)
        {
            length = a;
            width = b;
        }
        public double getArea()
        {
            if (isValid())
            {
                return length * width;
            }
            else
            {
                throw new Exception("形状不合法");
            }
        }
        public bool isValid()
        {
            if (length > 0 && width > 0)
            {
                return true;
            }
            else return false;
        }
    }
    class Square : Shape
    {
        private double side;
        public double Side
        {
            get { return side; }
            set { side = value; }
        }
        public Square(double a)
        {
            side = a;
        }
        public bool isValid()
        {
            if (side > 0) { return true; }
            else return false;
        }
        public double getArea()
        {
            if (isValid())
            {
                return side * side;
            }
            else
            {
                throw new Exception("形状不合法");
            }
        }
    }
    class Triangle : Shape
    {
        private double sideA, sideB, sideC;
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
            get { return sideC; }
            set { sideC = value; }
        }
        public Triangle(double a, double b, double c)
        {
            sideA = a; sideB = b; sideC = c;
        }
        public bool isValid()
        {
            if (sideA + sideB > sideC && sideB + sideC > sideA && sideA + sideC > sideB) { return true; }
            else return false;
        }
        public double getArea()
        {
            if (isValid())
            {
                double p = 0.5 * (sideA + sideB + sideC);
                return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
            }
            else
            {
                throw new Exception("形状不合法");
            }
        }
    }
}
