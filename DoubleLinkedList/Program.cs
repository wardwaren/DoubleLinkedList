using System;

namespace DoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> dList = new DoublyLinkedList<int>(1);
            for (int i = 0; i < 10; i++)
            {
                dList.InsertAtIndex(dList.GetSize(),i);
               
                Console.WriteLine("Size: " + dList.GetSize());
            }

            for (int i = 0; i < dList.GetSize(); i++)
            {
                Console.Write(dList.getNode(i) + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    dList.DeleteAtIndex(0);
                    Console.WriteLine("Size: " + dList.GetSize());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            
        }
        
    }
}