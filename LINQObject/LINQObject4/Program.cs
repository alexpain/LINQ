/*
    LinqObj4. Исходная последовательность содержит сведения о
    клиентах фитнес-центра. Каждый элемент последовательно-
    сти включает следующие целочисленные поля:
        <Год> <Номер месяца> <Продолжительность
        занятий (в часах)> <Код клиента>
    Для каждого клиента, присутствующего в исходных данных,
    определить суммарную продолжительность занятий в тече-
    ние всех лет (вначале выводить суммарную продолжитель-
    ность, затем код клиента). Сведения о каждом клиенте выво-
    дить на новой строке и упорядочивать по убыванию суммар-
    ной продолжительности, а при их равенстве — по возраста-
    нию кода клиента. 
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace LINQObject4
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

            var groupByClient = clients.GroupBy(client => client.customerId)
                                     .Select(groupClient => {
                                         return groupClient.Sum(client => client.durationTraining) + " " + groupClient.Key;
                                     });
            foreach (var item in groupByClient)
            {
                Console.WriteLine(item);
            }

            file.Close();
            
            Console.ReadKey();
        }
    }
}
