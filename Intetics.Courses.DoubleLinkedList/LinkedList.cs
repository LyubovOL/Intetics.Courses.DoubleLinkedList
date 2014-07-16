using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Intetics.Courses.DoubleLinkedList
{
    /// <summary>
    /// Description of the double linked list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T>
    {
        public int Count { get; set; }
        public LinkedListElement<T> CurrentElement { get; set; }
        public LinkedListElement<T> HeadElement { get; set; }
        public LinkedListElement<T> TailElement { get; set; }
        
        public LinkedList()
        {
            Count = 0;
            HeadElement = null;
            TailElement = null;
            CurrentElement = null;
        }

        public bool IsEmpty()
        {
            if (this.Count == 0)
                return true;
            return false;
        }

        public override String ToString()
        {
            if (this.HeadElement == null)
            {
                Console.WriteLine("Doubly Linked List is empty");
            }
            else
            {
                Console.WriteLine(String.Format("Count element:{0}", this.Count));
                this.CurrentElement = this.HeadElement;
                int count = 1;
                while (this.CurrentElement != null)
                {
                    Console.WriteLine(String.Format("{0} : {1}{2}",count, this.CurrentElement.Item.ToString(), Environment.NewLine));
                    count++;
                    this.CurrentElement = this.CurrentElement.NextElement;
                }
            }
            return String.Empty;
        }
    }
}
