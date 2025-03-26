using System.Net.Sockets;

namespace MQBroker;

public class QueueList
{
    private Queue head; 
    private int size;
    

    public QueueList ()
    {
        head = null;
        size = 0;
    }

    public bool ChecIfSubs(string topic, string user)
    {
        Queue current = head;

        if (current == null) 
        {
            Console.WriteLine("DA NULL");
            return false;
        }

        while (current != null)
        {
            if (current.topic == topic && current.user == user)
            {
                Console.WriteLine(current.topic + " : " + current.user);
                return true;
            }

            current = current.nextQueue;
        }
        return false;
    }

    public string Subscribe(string topic, string user)
    {
        if (ChecIfSubs(topic, user) == false)
        {
            Queue newQueue = new Queue(topic, user);
            
            if (head == null)
            {
                head = newQueue;
            }
            else
            {
                Queue current = head;
            
                while (current.nextQueue != null)
                {
                    current = current.nextQueue;
                }
                
                current.nextQueue = newQueue;
            }
            size++;
            return "El usuario se ha subscrito al tema";
        }
        
        else 
        {
            return "El usuario ya estaba subscrito a este tema";
        }
        
    }

    public string Unsubscribe(string topic, string user)
    {
        if (head == null)
        {
            return "El usuario no está subscrito a ningún tema";
        }

        if (head.topic == topic && head.user == user)
        {
            head = head.nextQueue;
            size--;
            return "";
        }
        
        Queue current = head;
        while (current.nextQueue != null)
        {
            if (current.nextQueue.topic == topic && current.nextQueue.user == user)
            {
                current.nextQueue = current.nextQueue.nextQueue;
                size--;
                return "";
            }
            current = current.nextQueue;
        }

        return "";
    }

    public string Receive(string topic, string user)
    {
        string message = "";

        if (ChecIfSubs(topic, user)== false)
        {
            return "El usuario no se ha subscrito a este tema";
        }
        
        Queue current = head;
        while (current != null)
        {
            if (current.topic == topic && current.user == user)
            {
                message = current.Dequeue();
            }
            current = current.nextQueue;
        }
        return message;

    }
    
    public bool TopicExists(string topic)
    {
        Queue current = head;
        while (current != null)
        {
            if (current.topic == topic)
            {
                return true;
            }
            current = current.nextQueue;
        }
        return false;
    }

    public bool Publish(string topic, string message)
    {
        if (TopicExists(topic) == false)
        {
            return false;
        }

        Queue current = head;

       while (current != null)
       {
           if (current.topic == topic)
           {
               current.Enqueue(message);
           }
           current = current.nextQueue;
       }
       return true;
    }
    
}