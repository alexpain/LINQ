﻿/*
    LinqObj2. Исходная последовательность содержит сведения о
    клиентах фитнес-центра. Каждый элемент последовательно-
    сти включает следующие целочисленные поля:
        <Номер месяца> <Год> <Код клиента>
        <Продолжительность занятий (в часах)>
    Найти элемент последовательности с максимальной продол-
    жительностью занятий. Вывести эту продолжительность, а
    также соответствующие ей год и номер месяца (в указанном
    порядке на той же строке). Если имеется несколько элемен-
    тов с максимальной продолжительностью, то вывести дан-
    ные, соответствующие самой поздней дате.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LINQObject
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

            int minTimeTraining = clients.Max(client => client.durationTraining);
            var selectClient = clients.Where(client => client.durationTraining == minTimeTraining);
            foreach (var client in selectClient)
            {
                Console.WriteLine("ID = {0}, YEAR = {1}, MONTH = {2}, TIME TRAINING = {3}",
                                    client.customerId, client.year, client.numberMonth, client.durationTraining);
            }


            file.Close();
            Console.ReadKey();




        }
    }
}
