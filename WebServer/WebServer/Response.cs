using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebServer
{
    public class Response
    {     
        public void Post(TcpClient client,string Url)
        {
            //Add http response header 

            string filePath = HttpServer.directory + Url;
            byte[] msg = Encoding.UTF8.GetBytes(File.ReadAllText(filePath));
            NetworkStream stream = client.GetStream();
            stream.Write(msg, 0, msg.Length);
        }
    }
}
