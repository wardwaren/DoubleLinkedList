﻿using System;
 using System.Collections;
 using System.Collections.Concurrent;
 using System.Collections.Generic;
 using System.ComponentModel;
 using System.Runtime.InteropServices;

 namespace DoubleLinkedList

{
    internal class dNode<T> where T: IComparable<T>
    {
        internal dNode<T> next;
        internal dNode<T> prev;
        private T val;

        public dNode (T value)
        {
            val = value;
            next = null;
            prev = null;
        }
        
        public override string ToString()
        {
            return $"{val}";
        }

        internal T GetValue()
        {
            return val;
        }

    }

    internal class DoublyLinkedList<T> : IEnumerator, IEnumerable where T: IComparable<T>
    {
        private dNode<T> head;
        private dNode<T> tail;
        private int size = 0;
        private int pos = -1;
        //Constructors for DoublyLinkedList 
        public DoublyLinkedList()
        {
            head = null;
            tail = null;
        }
        
        public DoublyLinkedList(T value)
        {
            head = new dNode<T>(value);
            tail = head;
            size = 1;
        }

        //Insert element into the beginning of DLL
        public void InsertHead(T value)
        {
            dNode<T> newNode = new dNode<T>(value);
            if (size == 0)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            }
            size += 1;
        }
        
        //Insert element into the end of the DLL 
        public void InsertTail(T value)
        {
            dNode<T> newNode = new dNode<T>(value);
            if (size == 0)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            size += 1;
        }

        //Insert element T into certain position of the DLL. Throws exception if element is out of range. 
        public void InsertAtIndex(int index, T value)
        {
            dNode<T> newNode = new dNode<T>(value);
            dNode<T> positionNode = head;
            int position = 0;
            
            if(index < 0 || index > size)
            {
                throw new System.ArgumentException("Index out of bounds", "original");
            }
            else if (size == 0)
            {
                head = newNode;
                tail = head;
                size += 1;
            }
            else if (index == 0)
            {
                InsertHead(value);
            }
            else if (index == size)
            {
                InsertTail(value);
            }
            else 
            {
                while (position != index)
                {
                    positionNode = positionNode.next;
                    position += 1;
                }
                dNode<T> prevNode = positionNode.prev;
                prevNode.next = newNode;
                positionNode.prev = newNode;
                newNode.next = positionNode;
                newNode.prev = prevNode;
                size += 1;
            }
                        
        }
        
        //Delete element located at the given index. Throws exception if element is out of range.
        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new System.ArgumentException("Index out of bounds", "original");
            }
            else if (size == 1)
            {
                head = null;
                tail = null;
                size -= 1;
            }
            else if (index == 0)
            {
                head = head.next;
                head.prev = null;
                size -= 1;
            }
            else
            {
                dNode<T> positionNode = head;
                int position = 0;
                while (position != index)
                {
                    positionNode = positionNode.next;
                    position += 1;
                }
                dNode<T> nextNode = positionNode.next;
                dNode<T> prevNode = positionNode.prev;
                //Delete at middle
                if (nextNode != null)
                {
                    prevNode.next = nextNode;
                    nextNode.prev = prevNode;
                    positionNode = null;
                }
                //Delete at tail
                else
                {
                    prevNode.next = null;
                    positionNode = null;
                }
                size--;
            }
        }
        //Return node at the given index
        public dNode<T> GetNode(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new System.ArgumentException("Index out of bounds", "original");
            }
            else if (index == 0)
            {
                return head;
            }
            else if (index == size - 1)
            {
                return tail;
            }
            else
            {
                dNode<T> positionNode = head;
                int position = 0;
                while (position != index)
                {
                    positionNode = positionNode.next;
                    position += 1;
                }
                return positionNode;
            }
        }
        
        
        //Get size
        public int GetSize()
        {
            return size;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator) this;
        }

        //IENumerator
        public bool MoveNext()
        {
            pos++;
            return (pos < size);
        }
        
        //IENumerable
        public void Reset()
        {
            pos = 0;
        }
        
        //IENumberable
        public object Current
        {
            get
            {
                try
                {
                    return GetNode(pos);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
                
            }
        }

        //Swap two elements in the DLL
        public void Swap(int first, int second)
        {
            //If one of the elements is out of range throw exception
            if (first < 0 || second < 0 || first >= size || second >= size)
            {
                throw new System.ArgumentException("Index out of bounds", "original");
            }
            //If elements are equal no swap required
            else if (first != second)
            {
                dNode<T> firstNode =  GetNode(first);
                dNode<T> secondNode = GetNode(second);
                dNode<T> temp = new dNode<T>(firstNode.GetValue());
                temp.next = firstNode.next;
                temp.prev = firstNode.prev;
                
                //If elements are consecutive 
                if (firstNode.prev == secondNode)
                {
                    if (secondNode.prev != null)
                    {
                        if (firstNode.next != null)
                        {
                            firstNode.next.prev = secondNode;
                        }
                        firstNode.prev = secondNode.prev;
                        secondNode.prev.next = firstNode;
                        secondNode.next = firstNode.next;
                        secondNode.prev = firstNode;
                        firstNode.next = secondNode;
                    }
                    else
                    {
                        if (firstNode.next != null)
                        {
                            firstNode.next.prev = secondNode;
                        }
                        secondNode.next = firstNode.next;
                        secondNode.prev = firstNode;
                        firstNode.next = secondNode;
                        firstNode.prev = null;
                        head = firstNode;
                    }
                }
                else if (firstNode.next == secondNode)
                {
                    Swap(second, first);
                }
                //If elements are different
                else
                {
                    if (firstNode.prev != null)
                    {
                        dNode<T> firstPrev = firstNode.prev;
                        firstPrev.next = secondNode;
                    }
                    else 
                    {
                        head = secondNode;
                    }

                    if (firstNode.next != null)
                    {
                        dNode<T> firstNext = firstNode.next;
                        firstNext.prev = secondNode;
                    }
                    else
                    {
                        tail = secondNode;
                    }
                    if (secondNode.prev != null)
                    {
                        dNode<T> secondPrev = secondNode.prev;
                        secondPrev.next = firstNode;
                    }
                    else
                    {
                        head = firstNode;
                    }

                    if (secondNode.next != null)
                    {
                        dNode<T> secondNext = secondNode.next;
                        secondNext.prev = firstNode;
                    }
                    else
                    {
                        tail = firstNode;
                    }
                
                    firstNode.next = secondNode.next;
                    firstNode.prev = secondNode.prev;
                    secondNode.next = temp.next;
                    secondNode.prev = temp.prev;
                }

                
            }
        }
        
        //Quicksort algorithm, that will sort the DLL in ascending order.
        public void Sort()
        {    
            SortHelper(0,size-1);
        }

        private void SortHelper(int begin, int end)
        {
            if (begin < end)
            {
                int index = Partition(begin, end);
                SortHelper(begin, index - 1);
                SortHelper(index + 1, end);
            }
        }

        private int Partition(int begin, int end)
        {
            dNode<T> pivot = GetNode(end);

            int i = begin - 1;

            for (int j = begin; j < end; j++)
            {
                if (GetNode(j).GetValue().CompareTo(pivot.GetValue()) < 0)
                {
                    i++;
                    Swap(i, j);
                }
                
            }
            Swap(i + 1, end);
            
            return i + 1;
        }
        
    }
}