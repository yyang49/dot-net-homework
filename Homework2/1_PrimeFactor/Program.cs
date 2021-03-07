using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_PrimeFactor
{
    class Program
    {
        static void print(int n)
        {
            Console.WriteLine(n);
        }
        static void getPrimeFactor(int n)
        {
            while (n != 1)
            {
                for(int i = 2; i <= n; i++)
                {
                    if (n % i == 0)
                    {
                        print(i);
                        n /= i;
                        break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("输入一个整数：");
            int a;
            try
            {
                a = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("不是整数");
                Console.ReadLine();
                return;
            }
            getPrimeFactor(a);
            Console.ReadLine();
        }
    }
}
