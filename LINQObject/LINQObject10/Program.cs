using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
    LinqObj10. Исходная последовательность содержит сведения о
    клиентах фитнес-центра. Каждый элемент последовательно-
    сти включает следующие целочисленные поля:
        <Год> <Номер месяца> <Код клиента>
        <Продолжительность занятий (в часах)>
    Для каждой пары «год–месяц», присутствующей в исходных
    данных, определить количество клиентов, которые посещали
    центр в указанное время (вначале выводится год, затем ме-
    сяц, затем количество клиентов). Сведения о каждой паре
    «год–месяц» выводить на новой строке и упорядочивать по
    убыванию номера года, а для одинакового номера года — по
    возрастанию номера месяца. 
*/

namespace LINQObject10
{
    public class Client
    {
        public int numberMonth { get; set; }
        public int year { get; set; }
        public int customerId { get; set; }
        public int durationTraining { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var clients = new List<Client>();

            FileStream file = new FileStream(@"..\..\..\Client.txt", FileMode.Open, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(file);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] attrClient = line.Split(' ');
                clients.Add(new Client
                {
                    numberMonth = int.Parse(attrClient[0]),
                    year = int.Parse(attrClient[1]),
                    customerId = int.Parse(attrClient[2]),
                    durationTraining = int.Parse(attrClient[3])
                });
            }

            var clientTrainingHoursForYear = clients.GroupBy(client => client.year)
                                                    .Select(groupByYear => new
                                                    {
                                                        year = groupByYear.Key,
                                                        monthArray = groupByYear.GroupBy(client => client.numberMonth)
                                                                                .Select(groupByMonth => new
                                                                                {
                                                                                    year = groupByYear.Key,
                                                                                    month = groupByMonth.Key,
                                                                                    clientCount = groupByMonth.Count()
                                                                                })
                                                    })
                                                    .SelectMany(group => group.monthArray)
                                                    .OrderBy(client => client.month)
                                                    .OrderByDescending(client => client.year)
                                                    .OrderBy(client => client.clientCount);
            foreach (var client in clientTrainingHoursForYear)
            {
                Console.WriteLine("Клиенты: {0} месяц: {2} год: {1} ", client.clientCount, client.year, client.month);
            }

            
            
            file.Close();

            Console.ReadKey();
        }
    }
}
