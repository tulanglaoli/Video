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
    public class AsyncUdpClient
    {
        class UdpState
        {
            public UdpClient udpClient = null;
            public IPEndPoint ipEndPoint = null;
            public const int BufferSize = 1024;
            public byte[] buffer = new byte[BufferSize];
            public int counter = 0;
            public string laststring;
        }
        public static AsyncUdpClient auc;
        public static bool messageSent = false;
        // Receive a message and write it to the console.
        // 定义端口
        private int listenPort = 11001;
        private int remotePort = 11000;
        // 定义节点
        private IPEndPoint localEP = null;
        private IPEndPoint remoteEP = null;
        // 定义UDP发送和接收
        private UdpClient udpReceive = null;
        private UdpClient udpSend = null;
        private UdpState udpSendState = null;
        private UdpState udpReceiveState = null;
        private int counter = 0;
        // 异步状态同步
        private ManualResetEvent sendDone = new ManualResetEvent(false);
        private ManualResetEvent receiveDone = new ManualResetEvent(false);
        public  string receiveString = "end";
        public  string sendmessage="start";
        // 定义套接字
        //private Socket receiveSocket;
        //private Socket sendSocket;
        
        
        public AsyncUdpClient()
        {
            // 本机节点
            localEP = new IPEndPoint(IPAddress.Any, listenPort);
            // 远程节点
            remoteEP = new IPEndPoint(IPAddress.Parse("192.168.1.255"), remotePort);
            // 实例化
            udpReceive = new UdpClient(localEP);
            udpSend = new UdpClient();

            // 分别实例化udpSendState、udpReceiveState
            udpSendState = new UdpState();
            udpSendState.ipEndPoint = remoteEP;
            udpSendState.udpClient = udpSend;

            udpReceiveState = new UdpState();
            udpReceiveState.ipEndPoint = remoteEP;
            udpReceiveState.udpClient = udpReceive;

            //receiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //receiveSocket.Bind(localEP);

            //sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //sendSocket.Bind(remoteEP);
        }

        public AsyncUdpClient(string ServerIP)
        {
            // 本机节点
            localEP = new IPEndPoint(IPAddress.Any, listenPort);
            // 远程节点
            remoteEP = new IPEndPoint(IPAddress.Parse(ServerIP), remotePort);
            // 实例化
            udpReceive = new UdpClient(localEP);
            udpSend = new UdpClient();

            // 分别实例化udpSendState、udpReceiveState
            udpSendState = new UdpState();
            udpSendState.ipEndPoint = remoteEP;
            udpSendState.udpClient = udpSend;

            udpReceiveState = new UdpState();
            udpReceiveState.ipEndPoint = remoteEP;
            udpReceiveState.udpClient = udpReceive;

            //receiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //receiveSocket.Bind(localEP);

            //sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //sendSocket.Bind(remoteEP);
        }

        public AsyncUdpClient(string ServerIP, int listenp, int remotep)
        {
            listenPort = listenp;
            remotePort = remotep;
            // 本机节点
            localEP = new IPEndPoint(IPAddress.Any, listenPort);
            // 远程节点
            remoteEP = new IPEndPoint(IPAddress.Parse(ServerIP), remotePort);
            // 实例化
            udpReceive = new UdpClient(localEP);
            udpSend = new UdpClient();

            // 分别实例化udpSendState、udpReceiveState
            udpSendState = new UdpState();
            udpSendState.ipEndPoint = remoteEP;
            udpSendState.udpClient = udpSend;

            udpReceiveState = new UdpState();
            udpReceiveState.ipEndPoint = remoteEP;
            udpReceiveState.udpClient = udpReceive;

            //receiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //receiveSocket.Bind(localEP);

            //sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //sendSocket.Bind(remoteEP);
        }
        

        /// <summary>
        /// 发送等待回执
        /// </summary>
        public void SendMsg()
        {
            udpSend.Connect(remoteEP);

            //Thread t = new Thread(new ThreadStart(ReceiveMessages));
            //t.Start();
            Byte[] sendBytes;
            
            while (true)
            {
                lock (this)
                {
                    sendBytes = Encoding.ASCII.GetBytes(sendmessage);
                    udpSendState.counter = counter;
                    // 调用发送回调函数
                    udpSend.BeginSend(sendBytes, sendBytes.Length, new AsyncCallback(SendCallback), udpSendState);
                    sendDone.WaitOne();
                    Thread.Sleep(200);
                    ReceiveMessages();
                }
            }
        }
        

        /// <summary>
        /// 发送是否等待回执
        /// </summary>
        /// <param name="IsWait"></param>
        public void SendMsg(bool IsWait)
        {
            udpSend.Connect(remoteEP);

            //Thread t = new Thread(new ThreadStart(ReceiveMessages));
            //t.Start();
            Byte[] sendBytes;

            while (true)
            {
                lock (this)
                {
                    sendBytes = Encoding.ASCII.GetBytes(sendmessage);
                    udpSendState.counter = counter;
                    // 调用发送回调函数
                    udpSend.BeginSend(sendBytes, sendBytes.Length, new AsyncCallback(SendCallback), udpSendState);
                    sendDone.WaitOne();
                    Thread.Sleep(200);
                    ReceiveMessages(IsWait);
                }
            }
        }

        /// <summary>
        /// 发送指定信息
        /// </summary>
        /// <param name="msg"></param>
        public void SendMsg(string msg)
        {
            sendmessage = msg;
            udpSend.Connect(remoteEP);

            //Thread t = new Thread(new ThreadStart(ReceiveMessages));
            //t.Start();
            Byte[] sendBytes;
            bool IsGetMessage=false;
            while (!IsGetMessage)
            {
                lock (this)
                {
                    counter++;
                    sendBytes = Encoding.ASCII.GetBytes(sendmessage);
                    udpSendState.counter = counter;
                    // 调用发送回调函数
                    Console.WriteLine("发送信息：" + sendmessage);
                    udpSend.BeginSend(sendBytes, sendBytes.Length, new AsyncCallback(SendCallback), udpSendState);
                    sendDone.WaitOne();
                    Thread.Sleep(200);
                    IsGetMessage = true;
                    //ReceiveMessages(false, sendmessage);
                }
            }
        }

        // 发送回调函数
        public void SendCallback(IAsyncResult iar)
        {
            UdpState udpState = iar.AsyncState as UdpState;
            if (iar.IsCompleted)
            {
                Console.WriteLine("第{0}个发送完毕！", udpState.counter);
                Console.WriteLine("number of bytes sent: {0}",  udpState.udpClient.EndSend(iar));
                
                //if (udpState.counter == 10)
                //{
                //    udpState.udpClient.Close();
                //}
                sendDone.Set();
            }
        }

        /// <summary>
        /// 不等待接收
        /// </summary>
        public void ReceiveMessages()
        {
            ReceiveMessages(true);
        }


        /// <summary>
        /// 是否等待接收
        /// </summary>
        /// <param name="IsWait"></param>
        public void ReceiveMessages(bool IsWait)
        {
            lock (this)
            {
                udpReceive.BeginReceive(new AsyncCallback(ReceiveCallback), udpReceiveState);
                if (IsWait)
                { 
                    receiveDone.WaitOne();
                }
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 暂时没有用
        /// </summary>
        /// <param name="IsWait"></param>
        /// <param name="sendstring"></param>
        public void ReceiveMessages(bool IsWait, string sendstring)
        {
            lock (this)
            {
                udpReceiveState.laststring = sendstring;
                udpReceive.BeginReceive(new AsyncCallback(ReceiveCallback), udpReceiveState);
                if (IsWait)
                {
                    receiveDone.WaitOne();
                }
                Thread.Sleep(100);
            }
        }

        // 接收回调函数
        public void ReceiveCallback(IAsyncResult iar)
        {
            UdpState udpState = iar.AsyncState as UdpState;
            if (iar.IsCompleted)
            {
                Byte[] receiveBytes = udpState.udpClient.EndReceive(iar, ref udpReceiveState.ipEndPoint);
                receiveString = Encoding.ASCII.GetString(receiveBytes);
                Console.WriteLine("Received: {0}", receiveString);
                receiveDone.Set();
            }
        }



        /// <summary>
        /// 定点发送
        /// </summary>
        /// <param name="IP">定点IP</param>
        public static void Clientmain(string IP)
        {
            auc = new AsyncUdpClient(IP);
            auc.SendMsg(false);
            Console.Read();
        }

        /// <summary>
        /// 广播
        /// </summary>
        public static void Clientmain()
        {
            auc = new AsyncUdpClient();
            auc.SendMsg(false);
            Console.Read();
        }

        public static void Init()
        {
            auc = new AsyncUdpClient();
           
        } 
    }
}