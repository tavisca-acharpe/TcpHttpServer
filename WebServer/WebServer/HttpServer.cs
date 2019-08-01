using System;
using System.Net;
using System.Net.Sockets;

namespace WebServer
{

    public class HttpServer
    {
        private int _port;
        private TcpListener tcpListener;
        public const string directory = "C:/Users/acharpe/source/repos/WebServer/WebServer";

        public HttpServer(int port)
        {
            _port = port;
        }

        public void StartServer()
        {
            try
            {      
                tcpListener = new TcpListener(IPAddress.Any, _port);
                tcpListener.Start();

                ClientHandler handler = new ClientHandler();
                Console.WriteLine("waiting connection ... ");

                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    handler.HandleClient(client);
                    client.Close();   
                }
                tcpListener.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}