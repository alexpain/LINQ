using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
    LinqObj18. Исходная последовательность содержит сведения
    об абитуриентах. Каждый элемент последовательности
    включает следующие поля:
        <Год поступления> <Номер школы> <Фамилия>
    Найти годы, для которых число абитуриентов было не мень-
    ше среднего значения по всем годам (вначале указывать чис-
    ло абитуриентов для данного года, затем год). Сведения о
    каждом годе выводить на новой строке и упорядочивать по
    убыванию числа абитуриентов, а для совпадающих чисел —
    по возрастанию номера года. 
*/

namespace LINQObject18
{
    class School
    {
        public int year { get; set; }
        public int nSchool { get; set; }
        public String lastName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var schools = new List<School>();

            FileStream file = new FileStream(@"..\..\..\school.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(file);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] attrClient = line.Split(' ');
                schools.Add(new School
                {
                    year = int.Parse(attrClient[0]),
                    nSchool = int.Parse(attrClient[1]),
                    lastName = attrClient[2],
                });
            }
            

            var query = schools.GroupBy(school => school.year)
                                .Select(groupByYear => new
                                {
                                    year = groupByYear.Key,
                                    count = groupByYear.Count()
                                })
                                .OrderByDescending(count => count.count);
            var average = query.Average(enrollee => enrollee.count);

            foreach (var item in query)
            {
                if (item.count >= average)
                {
                    Console.WriteLine("{0} {1}", item.year, item.count);
                }
               
            }
            file.Close();

            Console.ReadKey();

        }
    }
}
