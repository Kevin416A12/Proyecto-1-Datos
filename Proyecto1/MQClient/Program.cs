using System;
using System.Net;
using System.Net.Sockets;
using System.Text;




/// <summary>
/// El mensaje va a tener el siguiente formato "Petition,AppID,Topic"
/// </summary>

class Cliente

{
    static void Main()
    {
        // Crear socket
        Socket cliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Conectar al servidor
        cliente.Connect("127.0.0.1", 1234);

        // Enviar mensaje
        string mensaje4 = "Receive,416,Comida";
        cliente.Send(Encoding.UTF8.GetBytes(mensaje4));
         
        // Recibir respuesta
        byte[] buffer = new byte[1024];
        int bytesRecibidos = cliente.Receive(buffer);
        string respuesta = Encoding.UTF8.GetString(buffer, 0, bytesRecibidos);
        Console.WriteLine("Respuesta del servidor: " + respuesta);
        
        
        
        
        
        

        // Cerrar
        cliente.Close();
    }
}