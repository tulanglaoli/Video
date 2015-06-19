using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using AsyncClient;
using AsyncServer;
using System.Threading;

namespace MyUDPClient
{
    class Program
    {
        static void Main(string[] args)
        {

            //AsyncUdpSever.Servermain("192.168.1.103");
            AsyncUdpClient.Init();

            while(true)
            {
                string Rmsg = Console.ReadLine();
                AsyncUdpClient.auc.SendMsg(Rmsg);
                //SendMessage1("127.0.0.1",Rmsg,2009);
            }
            
        }
        static UdpClient u = new UdpClient();
         static bool messageSent = false;

         static void SendCallback(IAsyncResult ar)
        {
            UdpClient u = (UdpClient)ar.AsyncState;

            Console.WriteLine("number of bytes sent: {0}", u.EndSend(ar));
            
        }

        static void SendMessage1(string server, string message,int listenPort)
        {
            // create the udp socket
           

            u.Connect(server, listenPort);
            Byte[] sendBytes = Encoding.ASCII.GetBytes(message);

            // send the message
            // the destination is defined by the call to .Connect()
            u.BeginSend(sendBytes, sendBytes.Length,
                        new AsyncCallback(SendCallback), u);

          
        }

    }
}
