using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace JFServer
{
    class JFServer
    {
        static void Main(string[] args)
        {
            Socket svrSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Any;
            IPEndPoint point = new IPEndPoint(ip, 8295);
            svrSocket.Bind(point);
            svrSocket.Listen(1000);
        }
        static void Listen(object o)
        {
            var svrSocket = o as Socket;
            while(true)
            {
                var send = svrSocket.Accept();
                var sendIpoint = send.RemoteEndPoint.ToString();

            }
        }
    }
}
