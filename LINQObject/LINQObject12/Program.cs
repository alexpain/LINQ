using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
    LinqObj12. Дано целое число P (10 < P < 50). Исходная после-
    довательность содержит сведения о клиентах фитнес-центра.
    Каждый элемент последовательности включает следующие
    целочисленные поля:
        <Продолжительность занятий (в часах)> <Код
        клиента> <Номер месяца> <Год>
    Для каждого года, присутствующего в исходных данных, оп-
    ределить количество месяцев, в которых суммарная длитель-
    ность занятий всех клиентов составляла более P процентов
    от суммарной длительности за этот год (вначале выводить
    количество месяцев, затем год). Если в некотором году ни
    для одного месяца не выполнялось требуемое условие, то
    вывести для него 0. Сведения о каждом годе выводить на но-
    вой строке и упорядочивать по убыванию количества меся-
    цев, а для одинакового количества — по возрастанию номера
    года. 
*/

namespace LINQObject12
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

            

            file.Close();

            Console.ReadKey();

        }
    }
}
