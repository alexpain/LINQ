/*
LinqBegin24. Дано целое число K (> 0) и строковая последова-
тельность A. Из элементов A, предшествующих элементу с
порядковым номером K, извлечь те строки, которые имеют
нечетную длину и начинаются с заглавной латинской буквы,
изменив порядок следования извлеченных строк на обрат-
ный. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LINQBegin24
{
    class Program
    {
        static void Main(string[] args)
        {
            int K = 5;
            String[] str = { "QWE","ASD123", "12345", "QWEQWE", "ZXCAS", "74185", "QWE", "EDFG", "ASDZ5", "ASD22", "QWEA2", "ZXC" };
            String reg = @"^[A-Z].*";
            var q = str.Take(5);
            
            var query = from x in q
                        where ((x.Length % 2) != 0) && (true == Regex.IsMatch(x, reg, RegexOptions.IgnoreCase))
                        select x;
            var tmp = query.Reverse();
            foreach (var item in tmp)
            {
                Console.Write("{0} ", item);
            }
            Console.ReadKey();
        }
    }
}
