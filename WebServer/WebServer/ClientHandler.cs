using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace WebServer
{
    class ClientHandler
    {
        public  void HandleClient(TcpClient client)
        {
            StreamReader reader = new StreamReader(client.GetStream());
            string message = "";
            while (reader.Peek() != -1)
            {
                message = message + reader.ReadLine() + "\n";
            }

            Request request = Request.GetRequest(message);
            Response response = new Response();
            response.Post(client,request.Url);   
        }
    }
}
