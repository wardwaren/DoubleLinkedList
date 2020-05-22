using System;
using System.Linq;

namespace DoubleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> dList = new DoublyLinkedList<int>(1);
            for (int i = 0; i < 10; i++)
            {
                dList.InsertAtIndex(0,i);
               
                Console.WriteLine("Size: " + dList.GetSize());
            }

            for (int i = 0; i < dList.GetSize(); i++)
            {
                Console.Write(dList.GetNode(i) + " ");
            }
            Console.WriteLine();
            dList.Swap(0,1);
            foreach (dNode<int> node in dList)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
            dList.Sort();
            for (int i = 0; i < dList.GetSize(); i++)
            {
                Console.Write(dList.GetNode(i) + " ");
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
            DoublyLinkedList<String> newList = new DoublyLinkedList<String>();
            for (int i = 0; i < 10; i++)
            {
                newList.InsertHead(i.ToString());
            }
            Console.WriteLine(newList.GetSize());
            newList.Sort();
            foreach (dNode<String> node in newList)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
            var nodes = from list in newList where (list.GetValue().Equals("2")) select list;
            
            foreach (dNode<String> node in nodes)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
            
        }
        
    }
}