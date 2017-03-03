using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
LinqBegin2. Дана цифра D (однозначное целое число) и цело-
численная последовательность A. Вывести первый положи-
тельный элемент последовательности A, оканчивающийся
цифрой D. Если требуемых элементов в последовательности
A нет, то вывести 0. 
*/
namespace LINQBegin2
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 123, -23, 654, 85, -85, 453, -852, -657 };
            int d = int.Parse(Console.ReadLine());
            Console.WriteLine(a.FirstOrDefault(n=>(n > 0 ) && (d == n%10)));
            Console.ReadKey();
        }
        
    }
}
