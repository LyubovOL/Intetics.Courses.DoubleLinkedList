using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intetics.Courses.DoubleLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var values = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var list = new LinkedList<int>();
            foreach (var i in values)
            {
                list = list.InsertBack(new LinkedListElement<int>(i));
            }
            list = list.Delete(10);
            
            foreach (var l in list)
            {
                Console.WriteLine(l);
            }
            Console.ReadLine();
        }
    }
}
