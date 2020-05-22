using System;

namespace DoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> dList = new DoublyLinkedList<int>(1);
            Console.WriteLine("Size: " + dList.GetSize());
        }
        
    }
}