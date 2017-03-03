/*
LinqBegin20. Дана целочисленная последовательность. Из-
влечь из нее все положительные двузначные числа, отсорти-
ровав их по возрастанию. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQBegin20
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 0, -8, 2, -7, 4, 94, -4, 7, 85, 99 };
            var query = from x in numbers
                        where (x >= 10) && (x <= 99)
                        orderby x
                        select x;
            foreach (var item in query)
            {
                Console.Write("{0} ", item);
            }
            Console.ReadKey();
        }
    }
}
