using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class ShapeFactory
    {
        public static Shape getShape(string type, params double[] side)
        {
            Shape shape = null;
            switch (type)
            {
                case "Ractangle":
                    shape = new Ractangle(side[0], side[1]);break;
                case "Square":
                    shape = new Square(side[0]);break;
                case "Triangle":
                    shape = new Triangle(side[0], side[1], side[2]);break;
                default:
                    throw new Exception("形状无效");
            }
            return shape;
        }
    }
}
