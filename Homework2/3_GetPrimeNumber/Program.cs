using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_GetPrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {   
            for(int i = 2; i <= 100; i++)
            {
                bool flag=true;
                for(int j = 2; j <= i / 2; j++)
                {
                    for(int k = 2; j * k <= i; k++)
                    {
                        if (i % (j * k) == 0) flag = false;
                    }
                }
                if (flag) Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
