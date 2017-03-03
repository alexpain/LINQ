/*
LinqBegin26. Даны целые числа K1 и K2 и последовательность
непустых строк A; 1 < K1 < K2 ≤ N, где N — размер последо-
вательности A. Найти среднее арифметическое длин всех
элементов последовательности, кроме элементов с порядко-
выми номерами от K1 до K2 включительно, и вывести его как
вещественное число
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQBegin26
{
    class Program
    {
        static void Main(string[] args)
        {
            int K1 = 3;
            int K2 = 8;
            String[] str = { "QWE", "ASD123", "12345", "QWEQWE", "ZXCAS", "74185", "QWE", "EDFG", "ASDZ5", "ASD22", "QWEA2", "ZXC" };

            var tmp1 = str.Take(K1-1);
            var tmp2 = str.Skip(K2);
            tmp2.Union(tmp1);
            Console.WriteLine(tmp2.Average(x => x.Length));
            Console.ReadKey();

        }
    }
}
