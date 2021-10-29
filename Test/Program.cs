using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Collections.Specialized;
using System.Drawing;
using System.Threading;
using System.Configuration;


namespace Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //endet eine Message an den eibport(IPAddress, PortNummer) um das Licht einzuschalten
            //var UDPPacket = new UDPSender("192.168.1.222", 49420);
            //UDPPacket.SendMessage("test1");

            string IPaddressListener = ConfigurationManager.AppSettings.Get("IPAddressListener");
            Console.WriteLine("IP Addresse: " + IPaddressListener);
            int PortNumberListener = int.Parse(ConfigurationManager.AppSettings.Get("PortNumberListener"));
            Console.WriteLine("Port Nummer: " + PortNumberListener);

            //öffnet den listener um später Klingel auzuwerten
            //var ReadDoorbellUDP = new UDPListener(IPaddressListener, PortNumberListener);
            var ReadDoorbellUDP = new UDPListener("192.168.1.109", 49422);
            var ReadCams = new ReadCamera();
            var PushMessage = new Pushover();
            string readMessage;
           

            // Open a Stream and decode a PNG image
            //Stream image = new FileStream(Constants.InputFilename, FileMode.Open, FileAccess.Read, FileShare.Read);

            while (true)
            {
                try
                {
                    readMessage = ReadDoorbellUDP.ReadMessage();
                    if (readMessage == "DingDong")
                    {
                        Stream imageEG = ReadCams.GetImage(Constants.CamBaseUrl_EG);
                        Stream imageUG = ReadCams.GetImage(Constants.CamBaseUrl_UG);
                        
                        await PushMessage.PushImage("Kamerabild UG:", imageUG);
                        await PushMessage.PushImage("An der Haustür hats geklingelt!\n" +
                            "Kamerabild EG:", imageEG);
                        
                    }
                    Console.WriteLine("This is the message you received " +
                                                          readMessage);
                    Console.WriteLine("This message was sent from " +
                                                ReadDoorbellUDP.EndPoint.Address.ToString() +
                                                " on their port number " +
                                                ReadDoorbellUDP.EndPoint.Port.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
