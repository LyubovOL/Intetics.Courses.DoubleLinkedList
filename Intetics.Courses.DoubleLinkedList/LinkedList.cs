using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Intetics.Courses.DoubleLinkedList
{
    /// <summary>
    /// Description of the double linked list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : IEnumerable<T>
    {
        public int Count { get; set; }
        public LinkedListElement<T> CurrentElement { get; set; }
        public LinkedListElement<T> HeadElement { get; set; }
        public LinkedListElement<T> TailElement { get; set; }

        public LinkedListElement<T> this[int i]
        {
            get
            {
                if (i < 1 && i > Count)
                {
                    throw new ArgumentException();
                }
                return GetLinkedListElement(i);
            }
        }

        public LinkedList()
        {
            Count = 0;
            HeadElement = null;
            TailElement = null;
            CurrentElement = null;
        }

        public bool IsEmpty()
        {
            if (Count == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Added new element 
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            InsertBack(new LinkedListElement<T>(item));
        }

        /// <summary>
        /// Adding an element to the end of list
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public LinkedList<T> InsertBack(LinkedListElement<T> element)
        {
            return Join(this, InsertEmpty(element));
        }

        /// <summary>
        /// Remove element by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public LinkedList<T> Delete(int index)
        {
            if (index < 1 || index > Count)
            {
                throw new ArgumentException();
            }

            if (IsEmpty())
            {
                throw new InvalidOperationException();
            }

            LinkedList<T> rightList;
            var leftList = Split(this, index, out rightList);
            leftList.TailElement = leftList.TailElement.PrevElement;
            leftList.Count--;

            if (rightList.IsEmpty())
            {
                leftList.TailElement.NextElement = null;
                return leftList;
            }

            return Join(leftList, rightList);
        }

        /// <summary>
        /// Sorted list
        /// </summary>
        /// <param name="comparer"></param>
        public void Sort(IComparer<T> comparer)
        {

            for (var i = 0; i < Count - 1; i++)
            {
                CurrentElement = HeadElement;
                for (var j = Count - 1; j > i; j--)
                {
                    if (comparer.Compare(CurrentElement.Item, CurrentElement.NextElement.Item) >= 0)
                    {
                        Swap(CurrentElement, CurrentElement.NextElement);
                    }
                    CurrentElement = CurrentElement.NextElement;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            CurrentElement = HeadElement;
            while (CurrentElement != null)
            {
                yield return CurrentElement.Item;
                CurrentElement = CurrentElement.NextElement;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region Helper methods for working with lists
        /// <summary>
        /// Swapping
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private void Swap(LinkedListElement<T> left, LinkedListElement<T> right)
        {
            var temp = left.Item;
            left.Item = right.Item;
            right.Item = temp;
        }

        /// <summary>
        /// Getting a list item by index
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private LinkedListElement<T> GetLinkedListElement(int i)
        {
            int count = 1;
            CurrentElement = HeadElement;
            while (CurrentElement != null && count != i)
            {
                CurrentElement = CurrentElement.NextElement;
                count++;
            }
            return CurrentElement;
        }

        /// <summary>
        /// Inserting an element to an empty list
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private static LinkedList<T> InsertEmpty(LinkedListElement<T> element)
        {
            var empty = new LinkedList<T>
            {
                Count = 1,
                HeadElement = element,
                TailElement = element
            };
            return empty;
        }

        /// <summary>
        /// Splitting the list at the specified index. Element to the index - in the left list
        /// </summary>
        /// <param name="leftList"></param>
        /// <param name="index"></param>
        /// <param name="rightList"></param>
        /// <returns></returns>
        private static LinkedList<T> Split(LinkedList<T> leftList, int index, out LinkedList<T> rightList)
        {
            rightList = new LinkedList<T>();

            if (index == leftList.Count)
            {
                return leftList;
            }

            var element = leftList[index];
            rightList.Count = leftList.Count - index;
            leftList.Count = index;

            if (element != null)
            {
                rightList.HeadElement = element.NextElement;
                rightList.HeadElement.PrevElement = null;
                rightList.TailElement = leftList.TailElement;
                leftList.TailElement = element;
            }

            leftList.TailElement.NextElement = null;
            return leftList;
        }

        /// <summary>
        /// Merging two lists
        /// </summary>
        /// <param name="leftList"></param>
        /// <param name="rightList"></param>
        /// <returns></returns>
        private static LinkedList<T> Join(LinkedList<T> leftList, LinkedList<T> rightList)
        {
            if (leftList.IsEmpty())
            {
                leftList.HeadElement = rightList.HeadElement;
                leftList.TailElement = rightList.TailElement;
                leftList.Count = rightList.Count;
                return leftList;
            }

            if (rightList.IsEmpty())
            {
                return leftList;
            }

            leftList.Count += rightList.Count;
            leftList.TailElement.NextElement = rightList.HeadElement;
            rightList.HeadElement.PrevElement = leftList.TailElement;
            leftList.TailElement = rightList.TailElement;
            return leftList;
        }

        #endregion
    }
}
