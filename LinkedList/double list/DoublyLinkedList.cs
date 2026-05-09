using System;
using System.Collections.Generic;
using System.Text;

namespace double_list;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public DoublyLinkedList()
    {
        _head = null;
        _tail = null;
    }

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);

        // Empty list
        if (_head == null)
        {
            _head = _tail = newNode;
            return;
        }

        // Insert at start
        if (data.CompareTo(_head.Data) < 0)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
            return;
        }

        Node<T>? current = _head;

        // Find correct position
        while (current.Next != null &&
               current.Next.Data.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        // Insert at the end
        if (current.Next == null)
        {
            current.Next = newNode;
            newNode.Prev = current;
            _tail = newNode;
        }
        else
        {
            // Insert in middle
            newNode.Next = current.Next;
            newNode.Prev = current;

            current.Next.Prev = newNode;
            current.Next = newNode;
        }
    }

    // SHOW FORWARD


    public void ShowForward()
    {
        Node<T>? current = _head;

        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }

        Console.WriteLine();
    }

    // SHOW BACK
    public void ShowBackward()
    {
        Node<T>? current = _tail;

        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Prev;
        }

        Console.WriteLine();
    }

    // ORDER IN DESCENDING ORDER

    public void SortDescending()
    {
        Node<T>? current = _head;
        Node<T>? temp = null;

        while (current != null)
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;

            current = current.Prev;
        }

        // Swap head and tail
        temp = _head;
        _head = _tail;
        _tail = temp;
    }

    //EXISTS

    public bool Exists(T data)
    {
        Node<T>? current = _head;

        while (current != null)
        {
            if (current.Data!.Equals(data))
                return true;

            current = current.Next;
        }

        return false;
    }

    // DELETE AN OCCURRENCE

    public void RemoveOne(T data)
    {
        Node<T>? current = _head;

        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                // If it is head
                if (current == _head)
                {
                    _head = _head.Next;

                    if (_head != null)
                        _head.Prev = null;
                }
                // If it is tail
                else if (current == _tail)
                {
                    _tail = _tail.Prev;

                    if (_tail != null)
                        _tail.Next = null;
                }
                else
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }

                return;
            }

            current = current.Next;
        }
    }

    // DELETE ALL OCCURRENCES

    public void RemoveAll(T data)
    {
        while (Exists(data))
        {
            RemoveOne(data);
        }
    }


    // SHOW FASHION(S)

    public void ShowModes()
    {
        if (_head == null)
        {
            Console.WriteLine("Lista vacía.");
            return;
        }

        Dictionary<T, int> frequencies = new Dictionary<T, int>();

        Node<T>? current = _head;

        while (current != null)
        {
            if (frequencies.ContainsKey(current.Data))
                frequencies[current.Data]++;
            else
                frequencies[current.Data] = 1;

            current = current.Next;
        }

        int max = 0;

        foreach (var item in frequencies)
        {
            if (item.Value > max)
                max = item.Value;
        }

        Console.WriteLine("Moda(s):");

        foreach (var item in frequencies)
        {
            if (item.Value == max)
            {
                Console.WriteLine(item.Key);
            }
        }
    }

    // SHOW GRAPHIC

    public void ShowGraph()
    {
        Dictionary<T, int> frequencies = new Dictionary<T, int>();

        Node<T>? current = _head;

        while (current != null)
        {
            if (frequencies.ContainsKey(current.Data))
                frequencies[current.Data]++;
            else
                frequencies[current.Data] = 1;

            current = current.Next;
        }

        Console.WriteLine("Gráfico:");

        foreach (var item in frequencies)
        {
            Console.Write(item.Key + " ");

            for (int i = 0; i < item.Value; i++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }

}


