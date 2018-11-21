using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Net.Sockets;

namespace JFClient
{
    class JFClient
    {
        static void Main(string[] args)
        {
            Server svrInfo = GetServerInfo();
            Socket clntSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(svrInfo.ip);
            IPEndPoint server = new IPEndPoint(ip, Convert.ToInt32(svrInfo.port));
            clntSocket.Connect(server);

            MessageBox.Show(string.Format("服务器地址：{0}\n端口：{1}", svrInfo.ip, svrInfo.port), "提示", MessageBoxButtons.OK);
        }
        static Server GetServerInfo()
        {
            XmlDocument clntConfig = new XmlDocument();
            clntConfig.Load("client.config");
            return new Server(clntConfig.SelectSingleNode("/configuration/server/ip").InnerText, clntConfig.SelectSingleNode("/configuration/server/port").InnerText);
        }
    }

    class Server
    {
        public string ip;
        public string port;
        public Server(string ip, string port)
        {
            this.ip = ip;
            this.port = port;
        }
    }
}
