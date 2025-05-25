using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoublyLinkedListProject
{
    public class DoublyLinkedList
    {
        private Node head;
        private Node tail;

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
        }

        // Додавання елемента в кінець списку
        public void Add(double data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        // Видалення елемента за значенням
        public bool Remove(double data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data == data)
                {
                    if (current == head)
                    {
                        head = current.Next;
                        if (head != null)
                            head.Prev = null;
                        else
                            tail = null;
                    }
                    else if (current == tail)
                    {
                        tail = current.Prev;
                        tail.Next = null;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        // Пошук елемента за значенням
        public Node Search(double data)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data == data)
                    return current;
                current = current.Next;
            }
            return null;
        }

        // Виведення списку
        public void Print()
        {
            if (head == null)
            {
                Console.WriteLine("Список порожній.");
                return;
            }
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        // Завдання 1: Вставка останнього парного елемента після кожного непарного
        public void InsertLastEvenAfterOdd()
        {
            if (head == null || head == tail)
                return;

            // Знаходимо останній парний елемент
            Node lastEven = null;
            Node current = head;
            while (current != null)
            {
                if ((int)current.Data % 2 == 0)
                    lastEven = current;
                current = current.Next;
            }

            if (lastEven == null)
                return;

            // Вставляємо останній парний елемент після кожного непарного
            current = head;
            while (current != null)
            {
                if ((int)current.Data % 2 != 0) // Непарний елемент
                {
                    Node newNode = new Node(lastEven.Data);
                    newNode.Next = current.Next;
                    newNode.Prev = current;
                    if (current.Next != null)
                        current.Next.Prev = newNode;
                    current.Next = newNode;
                    if (current == tail)
                        tail = newNode;
                }
                current = current.Next;
            }
        }

        // Завдання 2: Обчислення суми елементів >= 15
        public double SumElementsGreaterOrEqual15()
        {
            double sum = 0;
            Node current = head;
            while (current != null)
            {
                if (current.Data >= 15)
                    sum += current.Data;
                current = current.Next;
            }
            return sum;
        }
    }
}