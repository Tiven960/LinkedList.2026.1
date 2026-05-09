using System;
using System.Collections.Generic;
using System.Text;

namespace double_list;

public class DoublyLinkedList<T>
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

        // Lista vacía
        if (_head == null)
        {
            _head = _tail = newNode;
            return;
        }

        // Insertar al inicio
        if (data.CompareTo(_head.Data) < 0)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
            return;
        }

        Node<T>? current = _head;

        // Buscar posición correcta
        while (current.Next != null &&
               current.Next.Data.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        // Insertar al final
        if (current.Next == null)
        {
            current.Next = newNode;
            newNode.Prev = current;
            _tail = newNode;
        }
        else
        {
            // Insertar en medio
            newNode.Next = current.Next;
            newNode.Prev = current;

            current.Next.Prev = newNode;
            current.Next = newNode;
        }
    }

    // MOSTRAR HACIA ADELANTE
    // =========================
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

    // MOSTRAR HACIA ATRÁS
    // =========================
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

    // ORDENAR DESCENDENTEMENTE
    // =========================
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

        // Intercambiar head y tail
        temp = _head;
        _head = _tail;
        _tail = temp;
    }

    // EXISTE
    // =========================
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

    // ELIMINAR UNA OCURRENCIA
    // =========================
    public void RemoveOne(T data)
    {
        Node<T>? current = _head;

        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                // Si es cabeza
                if (current == _head)
                {
                    _head = _head.Next;

                    if (_head != null)
                        _head.Prev = null;
                }
                // Si es cola
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

    // =========================
    // ELIMINAR TODAS LAS OCURRENCIAS
    // =========================
    public void RemoveAll(T data)
    {
        while (Exists(data))
        {
            RemoveOne(data);
        }
    }

    // =========================
    // MOSTRAR MODA(S)
    // =========================
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

    // =========================
    // MOSTRAR GRÁFICO
    // =========================
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


