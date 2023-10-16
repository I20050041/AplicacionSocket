using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Cliente
{
    static void Main()
    {
        string serverIp = "127.0.0.1";
        int serverPort = 12345; 


        TcpClient client = new TcpClient(serverIp, serverPort);

        NetworkStream stream = client.GetStream();

        string message = "Hola";
        byte[] data = Encoding.ASCII.GetBytes(message);

        stream.Write(data, 0, data.Length);
        Console.WriteLine("Mensaje enviado al servidor.");

        data = new byte[1024];
        int bytesRead = stream.Read(data, 0, data.Length);
        string response = Encoding.ASCII.GetString(data, 0, bytesRead);

        Console.WriteLine("Respuesta del servidor: " + response);

        client.Close();
    }
}
