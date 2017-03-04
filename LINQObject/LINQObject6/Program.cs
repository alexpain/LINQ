/*
    LinqObj6. Исходная последовательность содержит сведения о
    клиентах фитнес-центра. Каждый элемент последовательно-
    сти включает следующие целочисленные поля:
        <Код клиента> <Продолжительность занятий (в
        часах)> <Год> <Номер месяца>
    Для каждого месяца определить суммарную продолжитель-
    ность занятий всех клиентов за все годы (вначале выводить
    суммарную продолжительность, затем номер месяца). Если
    данные о некотором месяце отсутствуют, то для этого месяца
    вывести 0. Сведения о каждом месяце выводить на новой
    строке и упорядочивать по убыванию суммарной продолжи-
    тельности, а при равной продолжительности — по возраста-
    нию номера месяца.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LINQObject6
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

            var query = clients.GroupBy(client => client.numberMonth)
                                     .Select(groupClient => new {
                                         sum = groupClient.Sum(client => client.durationTraining),
                                         month = groupClient.Key
                                     })
                                     .OrderByDescending(x => x.sum);
         
            foreach (var item in query)
            {
                Console.WriteLine("{0} - {1}", item.sum, item.month);
            }
            file.Close();

            Console.ReadKey();

        }
    }
}
