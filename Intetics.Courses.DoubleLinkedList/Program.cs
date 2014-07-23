using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Intetics.Courses.DoubleLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listPerson = new LinkedList<IPerson>
            {
                new Student("Вася", "Иванов", 20),
                new Student("Антон", "Сидоров", 24),
                new Student("Никита", "Емельянов", 19),
                new Student("Семен", "Поддубный", 18)
            };

            foreach (var person in listPerson)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine(Environment.NewLine);

            listPerson.Sort(new SortedByAge<IPerson>());

            foreach (var person in listPerson)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine(Environment.NewLine);

            listPerson.Sort(new SortedByFirstName<IPerson>());

            foreach (var person in listPerson)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine(Environment.NewLine);

            listPerson.Sort(new SortedByLastName<IPerson>());

            foreach (var person in listPerson)
            {
                Console.WriteLine(person);
            }

            Console.ReadLine();
        }
    }
}
