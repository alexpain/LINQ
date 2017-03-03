/*
LinqBegin18. Дана целочисленная последовательность. Из-
влечь из нее все четные отрицательные числа, поменяв поря-
док извлеченных чисел на обратный. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQBegin18
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 0, -8, 2, -7, 4, 5, -4, 7, 8, 9 };
            var query = from x in numbers
                        where (x % 2 == 0) && (x < 0)
                        select x;
            query.Reverse();
            foreach (var item in query)
            {
                Console.Write("{0} ",item);
            }
            Console.ReadKey();
        }
    }
}
