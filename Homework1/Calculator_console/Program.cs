using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_console
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1, num2, num3;
            string op;
            Console.WriteLine("请输入第一个数字");
            try
            {
                num1 = Double.Parse(Console.ReadLine());
            }
            catch(System.FormatException)
            {
                Console.WriteLine("不是一个数字");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("请输入第二个数字");
            try
            {
                num2 = Double.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("不是一个数字");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("请输入运算符");
            op = Console.ReadLine();
            switch (op)
            {
                case "+":
                    num3 = num1 + num2;
                    break;
                case "-":
                    num3 = num1 - num2;
                    break;
                case "*":
                    num3 = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("除数不能为0");
                        Console.ReadLine();
                        return;
                    }
                    num3 = num1 / num2;
                    break;
                default:
                    Console.WriteLine("符号不正确");
                    Console.ReadLine();
                    return;
            }
            Console.WriteLine($"运算结果为{num3}");
            Console.ReadLine();
        }
    }
}
