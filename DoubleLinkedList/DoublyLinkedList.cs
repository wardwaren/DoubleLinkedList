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

    }

    internal class DoublyLinkedList<T>
    {
        private dNode<T> head;
        private dNode<T> tail;
        private int size = 0;
        
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

        public void InsertAtIndex(int index, T value)
        {
            dNode<T> newNode = new dNode<T>(value);
            dNode<T> positionNode = head;
            int position = 0;
            if (size == 0 && index == 0)
            {
                head = newNode;
                tail = head;
                size += 1;
            }
            else if (index >= 0 && index < size)
            {
                while (position != index)
                {
                    positionNode = positionNode.next;
                    position += 1;
                }
                dNode<T> prevNode = positionNode.prev;
                prevNode.next = newNode;
                positionNode.prev = newNode;
                size += 1;
            }
            else if (index == size)
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
                size += 1;
            }
            else
            {
                throw new System.ArgumentException("Out of bounds", "original");
            }
                        
        }

        public int GetSize()
        {
            return size;
        }
        
    }
}