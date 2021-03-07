using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Toplitz
{
    class Program
    {
        static bool isToplitz(int row,int column, int[,] a)
        {
            for(int i = 0; i < row - 1; i++)
            {
                for(int j = 0; j < column - 1; j++)
                {
                    if (a[i + 1, j + 1] != a[i, j]) return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入矩阵的行数：");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入矩阵的列数：");
            int column = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入矩阵：");
            int[,] a = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                string onerow = Console.ReadLine();
                string[] singlerow = onerow.Split(" ".ToCharArray());
                for (int j = 0; j < column; j++)
                {
                    a[i, j] = int.Parse(singlerow[j]);
                }
            }
            Console.WriteLine(isToplitz(row, column, a));
            Console.ReadLine();
        }
    }
}
