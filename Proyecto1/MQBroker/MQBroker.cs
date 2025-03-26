using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MQBroker;



class Program
{
    static void Main(string[] args)
    {
        QueueList queueList = new QueueList();
        //Console.WriteLine(queueList.Subscribe("Comida", "416"));
        //queueList.Publish("Comida", "Salsa");
        //Console.WriteLine(queueList.Receive("Comida", "416"));
        
        // Crear socket
        Socket mqBroker = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        // Crear punto de conexión
        IPAddress serverIp = IPAddress.Parse("192.168.1.163");
        IPEndPoint endPoint = new IPEndPoint(serverIp, 1234);
        mqBroker.Bind(endPoint);
        mqBroker.Listen(5);

        Console.WriteLine("MQBroker escuchando en el puerto 1234");

        // Aceptar conexiones
        while (true)
        {
            Socket client = mqBroker.Accept();
            Console.WriteLine("Cliente conectado");

            // Manejar al cliente en un hilo separado
            Thread hiloCliente = new Thread(() => ManejarCliente(client, queueList));
            hiloCliente.Start();
        }
        
    }

    static void ManejarCliente(Socket cliente, QueueList queueList)
    {
        try
        {
            byte[] buffer = new byte[1024];
            int bytesRecibidos = cliente.Receive(buffer);
            string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesRecibidos);
            string[] Data = mensaje.Split(';');
            string Petition = Data[0];
            string appid = Data[1];
            string topic = Data[2];
            
            Console.WriteLine(Petition + " : " + appid + " : " + topic);
            
            if (Petition == "Subscribe")
            {
                string Result = queueList.Subscribe(topic, appid);
                string respuesta = "Servidor envía: " + Result; ;
                cliente.Send(Encoding.UTF8.GetBytes(respuesta));
            }
            else if (Petition == "Unsubscribe")
            {
                queueList.Unsubscribe(topic, appid);
                string Result = queueList.Unsubscribe(topic, appid);
                string respuesta = "Servidor envía: " + Result;
                cliente.Send(Encoding.UTF8.GetBytes(respuesta));
            }
            else if (Petition == "Publish")
            {
                queueList.Publish(topic, appid);
                string Result = "Published in " + topic;
                string respuesta = "Servidor envía: " + Result;
                cliente.Send(Encoding.UTF8.GetBytes(respuesta));
            }
            else if (Petition == "Receive")
            {
                string Result = queueList.Receive(topic, appid);
                string respuesta = "Servidor envía: " + Result;
                cliente.Send(Encoding.UTF8.GetBytes(respuesta));
            }
            else
            {
                
                Console.WriteLine("Petition not recognized");
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error con el cliente: " + ex.Message);
        }
        finally
        {
            cliente.Close();
            Console.WriteLine("Cliente desconectado.\n");
        }
    } 
}

