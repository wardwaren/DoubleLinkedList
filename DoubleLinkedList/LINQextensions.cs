using System;
using System.Collections;
using System.Collections.Generic;

namespace DoubleLinkedList
{
    public static class LINQextensions
    {
        public static IEnumerable<dNode<T>> Where<T>(this DoublyLinkedList<T> source, Func<dNode<T>, bool> predicate) where T: IComparable<T>
        {
            foreach (dNode<T> node in source)
            {
                if (predicate(node))
                {
                    yield return node;
                }
            }
        }
    }
}