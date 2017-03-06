using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
    LinqObj20. Исходная последовательность содержит сведения
    об абитуриентах. Каждый элемент последовательности
    включает следующие поля:
        <Фамилия> <Номер школы> <Год поступления>
    Определить, для каких школ общее число абитуриентов за
    все годы было наибольшим, и вывести данные об абитуриен-
    тах из этих школ (вначале указывать номер школы, затем
    фамилию абитуриента). Сведения о каждом абитуриенте вы-
    водить на новой строке и упорядочивать по возрастанию но-
    меров школ, а для одинаковых номеров — в порядке следо-
    вания абитуриентов в исходном наборе данных. 
*/

namespace LINQObject20
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


            var query = schools.GroupBy(school => school.nSchool)
                                .Select(groupByYear => new
                                {
                                    year = groupByYear.Key,
                                    count = groupByYear.Count()
                                })
                                .OrderBy(count => count.year);
  

            foreach (var item in query)
            {
                Console.WriteLine("{0} {1}", item.year, item.count);
            }

            file.Close();

            Console.ReadKey();

        }
    }
}
