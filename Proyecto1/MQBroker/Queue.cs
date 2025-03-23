using System;

namespace MQBroker;

class Node
{
    public string Value { get; set; }
    public Node Next { get; set; }
    

    public Node(string value)
    {
        Value = value;
        Next = null;
    }
}

class Queue
{
    private Node first;
    private Node last;
    public Queue nextQueue; // Puede ser útil para encadenar colas
    public string topic { get; }
    public string user;   
    

    public Queue(string topic, string user)
    {
        this.topic = topic;
        this.user = user;
        first = last = null;
        nextQueue = null;
    }

    public void Enqueue(string value)
    {
        Node newNode = new Node(value);
        if (last == null)
        {
            first = last = newNode;
        }
        else
        {
            last.Next = newNode;
            last = newNode;
        }
    }

    public string Dequeue()
    {
        if (first == null)
        {
            Console.WriteLine("La cola está vacía.");
            return null;
        }

        string value = last.Value;

        // Si solo hay un elemento
        if (first == last)
        {
            first = null;
            last = null;
        }
        else
        {
            // Recorremos hasta llegar al nodo anterior al 'last'
            Node actual = first;
            while (actual.Next != last)
            {
                actual = actual.Next;
            }

            // Actualizamos 'last' al nodo anterior
            last = actual;
            last.Next = null;
        }

        return value;
    }



    public void PrintQueue()
    {
        Node temp = first;
        Console.Write($"Cola ({topic}): ");
        while (temp != null)
        {
            Console.Write(temp.Value + " -> ");
            temp = temp.Next;
        }
        Console.WriteLine("null");
    }
}