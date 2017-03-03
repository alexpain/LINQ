/*
LinqBegin6. Дана строковая последовательность. Найти сумму
длин всех строк, входящих в данную последовательность. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQBegin6
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] a = { "qwe asd", "qwe asdc", "asdc", "qwec" };
            Console.WriteLine(a.Sum(s => s.Length));
            Console.ReadKey();
        }
        
    }
}
