using System;

public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }
    public Node Prev { get; set; }

    public Node(int data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}

public class DoublyLinkedList
{
    private Node head = null;
    private Node tail = null;

    public void Add(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
    }

    public void Remove(int data)
    {
        if (head == null) return;

        Node current = head;
        while (current != null)
        {
            if (current.Data == data)
            {
                if (current == head && current == tail)
                {
                    head = null;
                    tail = null;
                }
                else if (current == head)
                {
                    head = head.Next;
                    head.Prev = null;
                }
                else if (current == tail)
                {
                    tail = tail.Prev;
                    tail.Next = null;
                }
                else
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                }
                return;
            }
            current = current.Next;
        }
        Console.WriteLine($"Елемент {data} не знайдено.");
    }

    public Node Search(int data)
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
            Console.Write($"{current.Data} ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    private Node FindLastEven()
    {
        Node current = tail;
        while (current != null)
        {
            if (current.Data % 2 == 0)
                return current;
            current = current.Prev;
        }
        return null;
    }

    public void InsertLastEvenAfterOdd()
    {
        if (head == null) return;

        Node lastEven = FindLastEven();
        if (lastEven == null)
        {
            Console.WriteLine("Парних елементів немає.");
            return;
        }

        Node current = head;
        while (current != null)
        {
            if (current.Data % 2 != 0) 
            {
                Node newNode = new Node(lastEven.Data);
                newNode.Next = current.Next;
                newNode.Prev = current;
                if (current.Next != null)
                    current.Next.Prev = newNode;
                else
                    tail = newNode;
                current.Next = newNode;
                current = newNode.Next; 
            }
            else
            {
                current = current.Next;
            }
        }
    }
}


class Program
{
    static void Main()
    {
        DoublyLinkedList list = new DoublyLinkedList();

        list.Add(1);
        list.Add(4);
        list.Add(7);
        list.Add(8);
        list.Add(3);

        Console.WriteLine("Початковий список:");
        list.Print();

        int searchValue = 7;
        Node found = list.Search(searchValue);
        if (found != null)
            Console.WriteLine($"Елемент {searchValue} знайдено.");
        else
            Console.WriteLine($"Елемент {searchValue} не знайдено.");

        list.Remove(4);
        Console.WriteLine("Список після видалення 4:");
        list.Print();

        list.InsertLastEvenAfterOdd();
        Console.WriteLine("Список після вставки останнього парного елемента після непарних:");
        list.Print();
    }
}