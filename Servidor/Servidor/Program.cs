using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Servidor
{
    static void Main()
    {
        
        string ipAddress = "127.0.0.1"; 
        int port = 12345; 

        TcpListener listener = new TcpListener(IPAddress.Parse(ipAddress), port);

        listener.Start();
        Console.WriteLine($"Servidor conectado a {ipAddress}:{port}");

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Conexión entrante...");

            NetworkStream stream = client.GetStream();

            byte[] data = new byte[1024];
            int bytesRead = stream.Read(data, 0, data.Length);
            string message = Encoding.ASCII.GetString(data, 0, bytesRead);
            Console.WriteLine($"Mensaje recibido: {message}");

            string response = "Mensaje recibido: " + message;
            byte[] responseData = Encoding.ASCII.GetBytes(response);

            stream.Write(responseData, 0, responseData.Length);
            Console.WriteLine("Respuesta enviada.");

            client.Close();
        }
    }
}
