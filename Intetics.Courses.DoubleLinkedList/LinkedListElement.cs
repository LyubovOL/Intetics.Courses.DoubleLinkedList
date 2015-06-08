namespace Intetics.Courses.DoubleLinkedList
{
    /// <summary>
    /// Description of element double linked list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedListElement<T> 
    {
        public T Item { get; set; }
        public LinkedListElement<T> NextElement { get; set; }
        public LinkedListElement<T> PrevElement { get; set; }
        
        public LinkedListElement(T item)
        {
            Item = item;
        } 
    }
}
