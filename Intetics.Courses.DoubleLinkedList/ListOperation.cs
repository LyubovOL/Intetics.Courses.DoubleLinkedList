using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intetics.Courses.DoubleLinkedList
{
    /// <summary>
    /// Methods for working with double linked list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class ListOperation<T>
    {
        /// <summary>
        /// Adding an element to the end of list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static LinkedList<T> InsertBack(LinkedList<T> list, LinkedListElement<T> element)
        {
            return Join(list, InsertEmpty(element));
        }

        /// <summary>
        /// Remove element by index
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static LinkedList<T> Delete(LinkedList<T> list, int index)
        {
            if(list.IsEmpty())
                throw new InvalidOperationException();
            LinkedList<T> rightList;
            var leftList = Split(list, index, out rightList);
            leftList.TailElement = leftList.TailElement.PrevElement;
            leftList.Count--;
            if (rightList.IsEmpty())
            {
                leftList.TailElement.NextElement = null;
                return leftList;
            }
            return Join(leftList, rightList);
        }
        
        
        #region Helper methods for working with lists
        /// <summary>
        /// Inserting an element to an empty list
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private static LinkedList<T> InsertEmpty(LinkedListElement<T> element)
        {
            var empty = new LinkedList<T> { Count = 1, HeadElement = element, TailElement = element };
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
            if (index < 1 || index > leftList.Count)
            {
                throw new InvalidOperationException();
            }
            else if (index == leftList.Count)
                return leftList;
            else
            {
                int count = 1;
                leftList.CurrentElement = leftList.HeadElement;
                while (leftList.CurrentElement != null && count != index)
                {
                    leftList.CurrentElement = leftList.CurrentElement.NextElement;
                    count++;
                }
                rightList.Count = leftList.Count - index;
                leftList.Count = index;
                if (leftList.CurrentElement != null)
                {
                    rightList.HeadElement = leftList.CurrentElement.NextElement;
                    rightList.HeadElement.PrevElement = null;
                    rightList.TailElement = leftList.TailElement;
                    leftList.TailElement = leftList.CurrentElement;
                }
                leftList.TailElement.NextElement = null;
                return leftList;
            }
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
                return rightList;
            if (rightList.IsEmpty())
                return leftList;
            leftList.Count += rightList.Count;
            leftList.TailElement.NextElement = rightList.HeadElement;
            rightList.HeadElement.PrevElement = leftList.TailElement;
            leftList.TailElement = rightList.TailElement;
            return leftList;
        }
        #endregion
    }
}
