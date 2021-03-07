using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Array
{
    class Program
    {
        static int Max(int length, int[] arry)
        {
            int max = arry[0];
            for (int i = 1; i < length; i++)
            {
                if (arry[i] > max) max = arry[i];
            }
            return max;
        }
        static int Min(int length, int[] arry)
        {
            int min = arry[0];
            for (int i = 1; i < length; i++)
            {
                if (arry[i] < min) min = arry[i];
            }
            return min;
        }
        static int Average(int length, int[] arry)
        {
            int sum = Summation(length, arry);
            return sum / length;
        }
        static int Summation(int length, int[] arry)
        {
            int sum = 0;
            for(int i=0; i < length; i++)
            {
                sum += arry[i];
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组长度");
            int length;
            try
            {
                length = int.Parse((Console.ReadLine()));
            }
            catch (System.FormatException)
            {
                Console.WriteLine("格式错误");
                return;
            }
            int[] arry = new int[length];
            Console.WriteLine("请输入数组元素，回车隔开");
            try
            {
                for (int i = 0; i < length; i++)
                {
                    arry[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("格式错误");
                return;
            }
            Console.WriteLine($"最大值为{Max(length, arry)}");
            Console.WriteLine($"最小值为{Min(length, arry)}");
            Console.WriteLine($"平均值为{Average(length, arry)}");
            Console.WriteLine($"合为{Summation(length,arry)}");
            Console.ReadLine();
        }
    }
}
