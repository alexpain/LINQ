/*
LinqBegin14. Даны целые числа A и B (A < B). Используя ме-
тоды Range и Average, найти среднее арифметическое квад-
ратов всех целых чисел от A до B включительно:
(A2 + (A+1)2 + … + B2)/(B − A + 1) (как вещественное число). 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQBegin14
{
    class Program
    {
        static void Main(string[] args)
        {
            int A = 2;
            int B = 20;
            IEnumerable<int> squares = Enumerable.Range(A, B).Select(x => x * x);
            int sum = 0; 
            foreach (int num in squares)
            {
                sum += num;
            }
            Console.WriteLine((sum/(B - A + 1)));
            Console.ReadKey();

        }
    }
}
