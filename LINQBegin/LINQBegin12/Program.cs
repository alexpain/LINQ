/*
LinqBegin12. Дана целочисленная последовательность. Ис-
пользуя метод Aggregate, найти произведение последних
цифр всех элементов последовательности. Чтобы избежать
целочисленного переполнения, при вычислении произведе-
ния использовать вещественный числовой тип. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQBegin12
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 123, 654, 789, 852, 4444, 85256, 1231 };
            var query = from s in arr
                        select s % 10;
            Double result = 1;
            foreach (var item in query)
            {
                result *= item;
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
