﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
    LinqObj14. Исходная последовательность содержит сведения
    об абитуриентах. Каждый элемент последовательности
    включает следующие поля:
        <Год поступления> <Номер школы> <Фамилия>
    Определить, в какие годы общее число абитуриентов для
    всех школ было наибольшим, и вывести это число, а также
    количество таких лет. Каждое число выводить на новой
    строке. 
*/
namespace LINQObject14
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
                                .Select(groupByYear => new {
                                    year = groupByYear.Key,
                                    count = groupByYear.Count()
                                });
            foreach (var item in query)
            {
                Console.WriteLine("{0} {1}",item.year,item.count);
            }
            file.Close();

            Console.ReadKey();
        }
    }
}
