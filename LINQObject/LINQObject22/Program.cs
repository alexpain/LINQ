using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
    LinqObj22. Исходная последовательность содержит сведения
    об абитуриентах. Каждый элемент последовательности
    включает следующие поля:
        <Фамилия> <Номер школы> <Год поступления>
    Для каждой школы найти годы поступления абитуриентов из
    этой школы и вывести номер школы и найденные для нее го-
    ды (годы располагаются на той же строке, что и номер шко-
    лы, и упорядочиваются по возрастанию). Сведения о каждой
    школе выводить на новой строке и упорядочивать по возрас-
    танию номеров школ. 
*/

namespace LINQObject22
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
                    lastName = attrClient[2]
                });
            }


            var query = schools.GroupBy(school => school.nSchool)
                                .Select(groupByYear => new
                                {
                                    scool = groupByYear.Key,
                                    
                                });


            foreach (var item in query)
            {
                Console.WriteLine("{0} ", item.scool);
            }

            file.Close();

            Console.ReadKey();

        }
    }
}
