/*
LinqBegin10. Дано целое число L (> 0) и строковая последова-
тельность A. Строки последовательности A содержат только
заглавные буквы латинского алфавита. Среди всех строк из
A, имеющих длину L, найти наибольшую (в смысле лексико-
графического порядка). Вывести эту строку или пустую
строку, если последовательность не содержит строк длины L. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQBegin10
{
    class Program
    {
        static void Main(string[] args)
        {
            int L = int.Parse(Console.ReadLine());
            String[] A = { "QWE", "ASD", "ZXC", "ASDA", "OLKJ", "ZXF" };

            var query = from s in A
                        where s.Length == L
                        select s;

            Console.WriteLine(query.Max());
    
            Console.ReadKey();
        }
    }
}
