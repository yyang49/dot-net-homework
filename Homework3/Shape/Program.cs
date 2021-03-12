using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[10];
            Random rd = new Random();
            for(int i = 0; i < 10; i++)
            {
                switch (rd.Next(3))
                {
                    case 0:
                        shapes[i] = ShapeFactory.getShape("Ractangle", rd.Next(1, 10), rd.Next(1, 10)); break;
                    case 1:
                        shapes[i] = ShapeFactory.getShape("Square", rd.Next(1, 10)); break;
                    case 2:
                        double a, b, c;
                        do { a = rd.Next(1, 10); b = rd.Next(1, 10); c = rd.Next(1, 10); } while (!(a + b > c && b + c > a && a + c > b));
                        shapes[i] = ShapeFactory.getShape("Triangle", a, b, c); break;
                }
            }
            double area = 0;
            foreach(Shape shape in shapes)
            {
                area = area + shape.getArea();
            }
            Console.WriteLine(area);
            Console.ReadKey();
        }
    }
}
