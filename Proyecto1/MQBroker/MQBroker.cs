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
        
        // Crear socket
        Socket mqBroker = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Crear punto de conexión
        IPAddress serverIp = IPAddress.Parse("192.168.0.107");
        IPEndPoint endPoint = new IPEndPoint(serverIp, 1234);
        mqBroker.Bind(endPoint);
        mqBroker.Listen(5);

        Console.WriteLine("MQBroker escuchando en el puerto 1234");

        // Aceptar conexiones
        while (true)
        {
            //Aceptar la conexión
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
        {   //procesar el mensaje
            byte[] buffer = new byte[1024];
            int bytesRecibidos = cliente.Receive(buffer);
            string mensaje = Encoding.UTF8.GetString(buffer, 0, bytesRecibidos);
            string[] Data = mensaje.Split(';');
            // separarlo para revisar los datos que vienen separados por ";"
            string Petition = Data[0];
            string appid = Data[1];
            string topic = Data[2];
            
            //Escribir lo recibido en la Consola 
            Console.WriteLine(Petition + " : " + appid + " : " + topic);
            
            //Si la petición es Subscribe, se suscribe al tema
            if (Petition == "Subscribe") 
            {
                string Result = queueList.Subscribe(topic, appid);
                Console.WriteLine("A ver");
                string respuesta = "Servidor envía: " + Result; ;
                cliente.Send(Encoding.UTF8.GetBytes(respuesta));
            }
            //Si la petición es Subscribe, se desuscribe al tema
            else if (Petition == "Unsubscribe")
            {
                queueList.Unsubscribe(topic, appid);
                string Result = queueList.Unsubscribe(topic, appid);
                string respuesta = "Servidor envía: " + Result;
                cliente.Send(Encoding.UTF8.GetBytes(respuesta));
            }
            //Si la petición es Publish, se publica un mensaje 
            else if (Petition == "Publish")
            {
                queueList.Publish(topic, appid);
                string Result = "Published in " + topic;
                //string respuesta = "Servidor envía: " + Result;
                string respuesta =  Result;

                cliente.Send(Encoding.UTF8.GetBytes(respuesta));
            }
            //si la peticion es Receive, recibe los mensajes en la cola del tema
            else if (Petition == "Receive")
            {
                string Result = queueList.Receive(topic, appid);
                //string respuesta = "Servidor envía: " + Result;
                string respuesta = Result;

                if (respuesta == null || respuesta == "") {
                    respuesta = "La cola está vacía";
                    
                }

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

