/*
LinqBegin16. Дана целочисленная последовательность. Из-
влечь из нее все положительные числа, сохранив их исход-
ный порядок следования. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQBegin16
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 0, -8, 2, -7, 4, 5, -4, 7, 8, 9 };

            var query = from x in numbers
                        where x > 0
                        select x;

            foreach (int elem in numbers)
                Console.Write("{0}", elem);
            Console.Write("\n");
            foreach (int elem in query)
                Console.Write("{0}", elem);
            Console.ReadKey();
        }
    }
}
