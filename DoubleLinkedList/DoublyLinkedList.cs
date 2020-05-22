﻿using System;


namespace DoubleLinkedList

{
    internal class dNode<T>
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

    }

    internal class DoublyLinkedList<T>
    {
        private dNode<T> head;
        private dNode<T> tail;
        private int size = 0;
        
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

        public dNode<T> getNode(int index)
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
        public int GetSize()
        {
            return size;
        }
        
    }
}