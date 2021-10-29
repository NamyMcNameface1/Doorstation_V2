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
    class UDPListener
    {

        public UdpClient ReceivingUdpClient { get; set; }
        public IPAddress ServerAddr { get; set; }
        public IPEndPoint EndPoint;

        public UDPListener(string IPAddresse, int portNumber)
        {
            // Verbindung init
            ReceivingUdpClient = new UdpClient(portNumber);
            ServerAddr = IPAddress.Parse(IPAddresse);
            EndPoint = new IPEndPoint(ServerAddr, portNumber); 
        }

        public string ReadMessage()
        {
            //Bytes einlesen und als String returnen
            Byte[] receiveBytes = ReceivingUdpClient.Receive(ref EndPoint);
            return Encoding.ASCII.GetString(receiveBytes);
        }
        

        ////Creates a UdpClient for reading incoming data.
        //UdpClient receivingUdpClient = new UdpClient(49422);

        ////Creates an IPEndPoint to record the IP Address and port number of the sender.
        //// The IPEndPoint will allow you to read datagrams sent from any source.

        //IPAddress serverAddr = IPAddress.Parse("192.168.1.109");
        //IPEndPoint RemoteIpEndPoint = new IPEndPoint(serverAddr, 49422);

        //    while(true)
        //    { 
        //        try
        //        {
        //            // Blocks until a message returns on this socket from a remote host.
        //            Byte[] receiveBytes = receivingUdpClient.Receive(ref RemoteIpEndPoint);

        //string returnData = Encoding.ASCII.GetString(receiveBytes);

        //Console.WriteLine("This is the message you received " +
        //                                      returnData.ToString());
        //            Console.WriteLine("This message was sent from " +
        //                                        RemoteIpEndPoint.Address.ToString() +
        //                                        " on their port number " +
        //                                        RemoteIpEndPoint.Port.ToString());
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.ToString());
        //        }

        //    }

    }
}
