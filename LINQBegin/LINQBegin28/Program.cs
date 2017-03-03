/*
LinqBegin28. Дано целое число L (> 0) и последовательность
непустых строк A. Строки последовательности содержат
только цифры и заглавные буквы латинского алфавита. Из
элементов A, предшествующих первому элементу, длина ко-
торого превышает L, извлечь строки, оканчивающиеся бук-
вой. Полученную последовательность отсортировать по убы-
ванию длин строк, а строки одинаковой длины — в лексико-
графическом порядке по возрастанию. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LINQBegin28
{
    class Program
    {
        static void Main(string[] args)
        {
            int L = 6;
            String[] str = { "QWE", "DFE", "ASD1D", "12345", "QWEQW41E", "ZXCAS", "74185", "QWE", "EDFG", "ASDZ5", "ASD22", "QWEA2", "ZXC" };

            var tmp = str.TakeWhile(x => x.Length < L);

            /*foreach (var item in tmp)
            {
                Console.WriteLine(item);
            }*/

            String reg = @"^\w*[A-Z]$";

            var query = from x in tmp
                        where true == Regex.IsMatch(x, reg, RegexOptions.IgnoreCase)
                        orderby x.Length
                        select x;
            

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
