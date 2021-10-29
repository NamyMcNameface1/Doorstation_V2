using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace Test
{
    class UDPSender
    {
        public Socket Sock { get; set; }
        public IPAddress ServerAddr { get; set; }
        public IPEndPoint EndPoint { get; set; }
        public UDPSender(string IPAddresse, int portNumber)
        {
            Sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            ServerAddr = IPAddress.Parse(IPAddresse);
            EndPoint = new IPEndPoint(ServerAddr, portNumber);
        }
        public void SendMessage(string message) 
        {
            byte[] send_buffer = Encoding.ASCII.GetBytes(message);
            Sock.SendTo(send_buffer, EndPoint);
        }

        //Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        //IPAddress serverAddr = IPAddress.Parse("192.168.1.222");
        //IPEndPoint endPoint = new IPEndPoint(serverAddr, 49420);
        //string text = "test1";
        //byte[] send_buffer = Encoding.ASCII.GetBytes(text);
        //sock.SendTo(send_buffer, endPoint);
    }
}
