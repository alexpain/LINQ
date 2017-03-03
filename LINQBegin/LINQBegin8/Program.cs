/*
LinqBegin8. Дана целочисленная последовательность. Найти
количество ее положительных двузначных элементов, а так-
же их среднее арифметическое (как вещественное число).
Если требуемые элементы отсутствуют, то дважды вывести 0
(первый раз как целое, второй — как вещественное). 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQBegin8
{
    class Program
    {
        static Boolean twoBigit(int n)
        {
            if((n >= 10) && (n <= 99))
            return true;
            return false;

        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 10, 20, -96, 30, 855 };
            Console.WriteLine(arr.Count(a => (a >= 10) && (a <= 99)));
            var query = from x in arr
                        where (x >= 10) && (x <= 99)
                        select x;
            Console.WriteLine(query.Average());
            Console.ReadKey();
        }
    }
}
