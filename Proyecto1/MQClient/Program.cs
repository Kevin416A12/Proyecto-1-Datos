namespace MQClientNS;
using System.Net;
using System.Net.Sockets;

public class Topic
{
    private string _topicName;

    public Topic(string topicName)
    {
        // No puede ser nulo ni vacío
        if (string.IsNullOrWhiteSpace(topicName))
        {
            throw new ArgumentException("El nombre del topic no puede ser nulo o vacío");
        }

        _topicName = topicName;
    }

    public string TopicName
    {
        get { return _topicName; }
    }

    public override string ToString()
    {
        return _topicName;
    }
}

public class Message
{
    private string _content;

    public Message(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            throw new ArgumentException("El contenido del mensaje no puede ser nulo o estar en blanco.");
        }
        if (content.Contains(";"))
        {
            throw new ArgumentException("El contenido del mensaje no puede contener el carácter ';'.");
        }
        
        _content = content;
        
    }

    public string Content
    {
        get { return _content; }
    }

    public override string ToString()
    {
        return _content;
    }
}



public class MQClient
{
    IPAddress ipAddress;
    private int port;
    private int AppID;

    public MQClient(string ipAddress, int port, int AppID)
    {
        IPAddress serverIp = IPAddress.Parse(ipAddress);
        this.ipAddress = serverIp;
        this.port = port;
        this.AppID = AppID;
    }

    public bool Subscribe(Topic topic)
    {
        if (topic == null)
        {
            throw new ArgumentNullException(nameof(topic), "El topic no puede ser null");
        }

        string topicName = topic.TopicName;
        // Crear socket
        Socket mqClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
        mqClient.Connect(endPoint);
        string mensaje = "Subscribe;" + AppID + ";" + topicName;
        mqClient.Send(System.Text.Encoding.UTF8.GetBytes(mensaje));

        byte[] buffer = new byte[1024];
        int bytesRecibidos = mqClient.Receive(buffer);
        string respuesta = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRecibidos);
        mqClient.Close();
        Console.WriteLine(respuesta);
        return true;
    }

    public bool Unsubscribe(Topic topic)
    {
        if (topic == null)
        {
            throw new ArgumentNullException(nameof(topic), "El topic no puede ser null");
        }

        string topicName = topic.TopicName;

        // Crear socket
        Socket mqClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
        mqClient.Connect(endPoint);
        string mensaje = "Unsubscribe;" + AppID + ";" + topicName;
        mqClient.Send(System.Text.Encoding.UTF8.GetBytes(mensaje));

        byte[] buffer = new byte[1024];
        int bytesRecibidos = mqClient.Receive(buffer);
        string respuesta = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRecibidos);
        mqClient.Close();
        Console.WriteLine(respuesta);
        return true;
    }
    public bool publish(Topic topic, Message message)
    {
        if (topic == null)
        {
            throw new ArgumentNullException(nameof(topic), "El topic no puede ser null");
        }

        string topicName = topic.TopicName;

        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "El mensaje no puede ser null");
        }
        string messageToSend = message.Content;

        // Crear socket
        Socket mqClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint endPoint = new IPEndPoint(ipAddress, port);

        mqClient.Connect(endPoint);

        string mensaje = "Publish;" + messageToSend + ";" + topicName;
        mqClient.Send(System.Text.Encoding.UTF8.GetBytes(mensaje));
        
        byte[] buffer = new byte[1024];
        int bytesRecibidos = mqClient.Receive(buffer);
        string respuesta = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRecibidos);

        mqClient.Close();

        Console.WriteLine(respuesta);

        return true;
    }
    public Message receive(Topic topic)
    {
        // Crear socket
        Socket mqClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
        mqClient.Connect(endPoint);

        string mensaje = "Receive;" + AppID + ";" + topic;
        mqClient.Send(System.Text.Encoding.UTF8.GetBytes(mensaje));
        
        byte[] buffer = new byte[1024];
        int bytesRecibidos = mqClient.Receive(buffer);
        string respuesta = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRecibidos);
        mqClient.Close();
        Console.WriteLine(respuesta);
        Message message = new Message(respuesta);
        return message;
    }
}

class program
{
    static void Main(string[] args)
    {   
        
        MQClient client = new MQClient("192.168.5.66", 1234, 416);
        Topic topic = new Topic("Comida");
        Topic topic2 = new Topic("holis");
        Message menssage = new Message("Hola, mundo");
        Message menssage1 = new Message("Hola, 1");
        Message menssage2 = new Message("Hola, mundo2");

       
        client.Subscribe(topic);
        client.Subscribe(topic);
        client.Subscribe(topic2);
        client.publish(topic, menssage);
        client.receive(topic);
        client.Unsubscribe(topic);
        client.receive(topic);

    }

   
}