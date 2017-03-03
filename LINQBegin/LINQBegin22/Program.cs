/*
LinqBegin22. Дано целое число K (> 0) и строковая последова-
тельность A. Строки последовательности содержат только
цифры и заглавные буквы латинского алфавита. Извлечь из A
все строки длины K, оканчивающиеся цифрой, отсортировав
их в лексикографическом порядке по возрастанию. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LINQBegin22
{
    class Program
    {
        static void Main(string[] args)
        {
            int K = 5;
            String[] str = { "ASD123", "12345", "QWEQWE", "ZXCAS", "74185", "QWE", "EDFG", "ASDZ5", "ASD22","QWEA2" };
            String reg = @"^\w*[0-9]$";
            var query = from x in str
                        where (x.Length == K) && (true == Regex.IsMatch(x, reg, RegexOptions.IgnoreCase))
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
