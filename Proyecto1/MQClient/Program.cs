namespace MQClient;
using System.Net;
using System.Net.Sockets;


class MQClient
{   
    IPAddress ipAddress;
    private int port;
    private int AppID;
    
    public MQClient( string ipAddress, int port, int AppID)
    {   
        IPAddress serverIp = IPAddress.Parse(ipAddress);
        this.ipAddress = serverIp;
        this.port = port;
        this.AppID = AppID;
    }

    public bool Subscribe(string topic)
    {
        // Crear socket
        Socket mqClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
        mqClient.Connect(endPoint);
        string mensaje = "Subscribe;" + AppID + ";" + topic;
        mqClient.Send(System.Text.Encoding.UTF8.GetBytes(mensaje));
        
        byte[] buffer = new byte[1024];
        int bytesRecibidos = mqClient.Receive(buffer);
        string respuesta = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRecibidos);
        mqClient.Close();
        Console.WriteLine(respuesta);
        return true;
    }
    
    public bool Unsubscribe(string topic)
    {
        // Crear socket
        Socket mqClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
        mqClient.Connect(endPoint);
        string mensaje = "Unsubscribe;" + AppID + ";" + topic;
        mqClient.Send(System.Text.Encoding.UTF8.GetBytes(mensaje));
        
        byte[] buffer = new byte[1024];
        int bytesRecibidos = mqClient.Receive(buffer);
        string respuesta = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRecibidos);
        mqClient.Close();
        Console.WriteLine(respuesta);
        return true;
    }
    public bool publish(string topic, string message)
    {
        // Crear socket
        Socket mqClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint endPoint = new IPEndPoint(ipAddress, port);
        mqClient.Connect(endPoint);
        string mensaje = "Publish;" + message + ";" + topic;
        mqClient.Send(System.Text.Encoding.UTF8.GetBytes(mensaje));
        
        byte[] buffer = new byte[1024];
        int bytesRecibidos = mqClient.Receive(buffer);
        string respuesta = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRecibidos);
        mqClient.Close();
        Console.WriteLine(respuesta);
        return true;
    }
    public bool receive(string topic)
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
        return true;
    }
}

class program
{
    static void Main(string[] args)
    {   
        
        MQClient client = new MQClient("192.168.1.163",1234, 416);
        client.Subscribe("Comida");
        MQClient client1 = new MQClient("192.168.1.163",1234, 123);
        client1.Subscribe("Comida");
        client.publish("Comida", "Salsa");
        client.publish("Comida", "Picante");
        client.receive("Comida");
        client1.receive("Comida");
        client.receive("Comida");
        client1.receive("Comida");
    }
}