using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace DotNet.Utilities
{
    // 定义 UdpState类
    
    // 异步UDP类
    public class AsyncUdpSever
    {
        class UdpState
        {
            public UdpClient udpClient;
            public IPEndPoint ipEndPoint;
            public const int BufferSize = 1024;
            public byte[] buffer = new byte[BufferSize];
            public int counter = 0;
        }
        // 定义节点
        public static AsyncUdpSever aus;
        private IPEndPoint ipEndPoint = null;
        private IPEndPoint remoteEP = null;
        // 定义UDP发送和接收
        private UdpClient udpReceive = null;
        private UdpClient udpSend = null;
        // 定义端口
        private  int listenPort = 11000;
        private  int remotePort = 11001;
        UdpState udpReceiveState = null;
        UdpState udpSendState = null;
        // 异步状态同步
        private ManualResetEvent sendDone = new ManualResetEvent(false);
        private ManualResetEvent receiveDone = new ManualResetEvent(false);
        public static string receiveString = "end";
        public static string sendmessage="start";
        public AsyncUdpSever()
        {
            // 本机节点
            ipEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
            // 远程节点
            remoteEP = new IPEndPoint(IPAddress.Parse("192.168.1.255"), remotePort);
            // 实例化
            udpReceive = new UdpClient(ipEndPoint);
            udpSend = new UdpClient();

            // 分别实例化udpSendState、udpReceiveState
            udpReceiveState = new UdpState();
            udpReceiveState.udpClient = udpReceive;
            udpReceiveState.ipEndPoint = ipEndPoint;

            udpSendState = new UdpState();
            udpSendState.udpClient = udpSend;
            udpSendState.ipEndPoint = remoteEP;
        }

        public AsyncUdpSever(string ServerIP)
        {
            // 本机节点
            ipEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
            // 远程节点
            remoteEP = new IPEndPoint(IPAddress.Parse(ServerIP), remotePort);
            // 实例化
            udpReceive = new UdpClient(ipEndPoint);
            udpSend = new UdpClient();

            // 分别实例化udpSendState、udpReceiveState
            udpReceiveState = new UdpState();
            udpReceiveState.udpClient = udpReceive;
            udpReceiveState.ipEndPoint = ipEndPoint;

            udpSendState = new UdpState();
            udpSendState.udpClient = udpSend;
            udpSendState.ipEndPoint = remoteEP;
        }

        public AsyncUdpSever(string ServerIP,int listenp,int remotep)
        {
            listenPort = listenp;
            remotePort = remotep;
            // 本机节点
            ipEndPoint = new IPEndPoint(IPAddress.Any, listenPort);
            // 远程节点
            remoteEP = new IPEndPoint(IPAddress.Parse(ServerIP), remotePort);
            // 实例化
            udpReceive = new UdpClient(ipEndPoint);
            udpSend = new UdpClient();

            // 分别实例化udpSendState、udpReceiveState
            udpReceiveState = new UdpState();
            udpReceiveState.udpClient = udpReceive;
            udpReceiveState.ipEndPoint = ipEndPoint;

            udpSendState = new UdpState();
            udpSendState.udpClient = udpSend;
            udpSendState.ipEndPoint = remoteEP;
        }

        public void ReceiveMsg()
        {
            Console.WriteLine("listening for messages");
            while (true)
            {
                lock (this)
                {
                    // 调用接收回调函数
                    IAsyncResult iar = udpReceive.BeginReceive(new AsyncCallback(ReceiveCallback), udpReceiveState);
                    receiveDone.WaitOne();
                    Thread.Sleep(100);
                }
            }
        }
        // 接收回调函数
        private void ReceiveCallback(IAsyncResult iar)
        {
            UdpState udpReceiveState = iar.AsyncState as UdpState;
            if (iar.IsCompleted)
            {
                Byte[] receiveBytes = udpReceiveState.udpClient.EndReceive(iar, ref udpReceiveState.ipEndPoint);
                receiveString = Encoding.ASCII.GetString(receiveBytes);
                Console.WriteLine("Received: {0}", receiveString);
                //Thread.Sleep(100);
                receiveDone.Set();
                SendMsg();
            }
        }
        // 发送函数
        private void SendMsg()
        {
            udpSend.Connect(udpSendState.ipEndPoint);
            udpSendState.udpClient = udpSend;
            udpSendState.counter++;

            
            Byte[] sendBytes = Encoding.Unicode.GetBytes(sendmessage);
            udpSend.BeginSend(sendBytes, sendBytes.Length, new AsyncCallback(SendCallback), udpSendState);
            sendDone.WaitOne();
        }
        // 发送回调函数
        private void SendCallback(IAsyncResult iar)
        {
            UdpState udpState = iar.AsyncState as UdpState;
            Console.WriteLine("第{0}个请求处理完毕！", udpState.counter);
            Console.WriteLine("number of bytes sent: {0}", udpState.udpClient.EndSend(iar));
            sendDone.Set();
        }

        /// <summary>
        /// 广播
        /// </summary>
        public static void Servermain()
        {
             aus = new AsyncUdpSever();
            Thread t = new Thread(new ThreadStart(aus.ReceiveMsg));
            t.Start();
            Console.Read();
        }

        /// <summary>
        /// 定点发送
        /// </summary>
        /// <param name="IP"></param>
        public static void Servermain(string IP)
        {
             aus = new AsyncUdpSever(IP);
            Thread t = new Thread(new ThreadStart(aus.ReceiveMsg));
            t.Start();
            Console.Read();
        }
    }
}