using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
    LinqObj8. Дано целое число K — код одного из клиентов фит-
    нес-центра. Исходная последовательность содержит сведе-
    ния о клиентах этого фитнес-центра. Каждый элемент после-
    довательности включает следующие целочисленные поля:
        <Продолжительность занятий (в часах)> <Код
        клиента> <Год> <Номер месяца>
    Для каждого года, в котором клиент с кодом K посещал
    центр, определить месяц, в котором продолжительность за-
    нятий данного клиента была наименьшей для данного года
    (если таких месяцев несколько, то выбирать первый из этих
    месяцев в исходном наборе; месяцы с нулевой продолжи-
    тельностью занятий не учитывать). Сведения о каждом годе
    выводить на новой строке в следующем порядке: наимень-
    шая продолжительность занятий, год, номер месяца. Упоря-
    дочивать сведения по возрастанию продолжительности заня-
    тий, а при равной продолжительности — по возрастанию
    номера года. Если данные о клиенте с кодом K отсутствуют,
    то записать в результирующий файл строку «Нет данных». 
*/
namespace LINQObject8
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
            int K = int.Parse(Console.ReadLine());

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

            try
            {
                var monthAndSum = clients.Where(client => client.customerId == K)
                                     .GroupBy(client => client.numberMonth)
                                     .Select(groupClient => new
                                     {
                                         month = groupClient.Key,
                                         sumMonthTraining = groupClient.Sum(client => client.durationTraining),
                                         
                                     });
                var minTimeTraining = monthAndSum.Min(client => client.sumMonthTraining);
                var year = from x in clients
                           where (x.durationTraining == minTimeTraining) && (x.customerId == K)
                           select x;
                foreach (var item in monthAndSum)
                {
                    Console.WriteLine("{0} {1} {2} {3}",item.sumMonthTraining, item.month, minTimeTraining, year);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error!!");
                
            }

            file.Close();


            Console.ReadKey();

        }
    }
}
