/*
LinqBegin4. Дан символ С и строковая последовательность A.
Если A содержит единственный элемент, оканчивающийся
символом C, то вывести этот элемент; если требуемых строк
в A нет, то вывести пустую строку; если требуемых строк
больше одной, то вывести строку «Error».
Указание. Использовать try-блок для перехвата возможного
исключения. 
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LINQBegin4
{
    class Program
    {
        static void Main(string[] args)
        {
            char c = 'c';
            String[] a = { "qwe asd", "qwe asdc", "asdc", "qwec"};
            String reg = @"^\w*" + c + "$";
            try
            {
                Console.WriteLine(a.Single(s=>Regex.IsMatch(s, reg, RegexOptions.IgnoreCase)));
            }
            catch(Exception ex)
            {
                if (ex.Message.Equals("Последовательность содержит более одного соответствующего элемента"))
                {
                    Console.WriteLine("Error!");
                } else {
                    Console.WriteLine("");
                }
            }
            Console.ReadKey();
        }
    }
}
