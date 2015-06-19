
using System.Collections;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
//Server 
namespace DotNet.Utilities
{
    public class NewSocket
    {

        // Use this for initialization
        Socket severSocket;//服务端Socket
        Socket clientSocket;//客户端
        Thread thread;//连接线程
        IPEndPoint clientip;//被连接的IP地址
        string returnStr;//用于传递消息的字符串
        string receiveStr;//接收客户端发来的字符串
        string sendStr;//发送的字符串

        int recv;//用于表示客户端发送的信息长度
        int recvTow;
        byte[] receiveData = new byte[1024];//用于缓存客户端所发送的信息,通过socket传递的信息必须为字节数组
        byte[] sendData = new byte[1024];//用于缓存客户端所发送的信息,通过socket传递的信息必须为字节数组

        //程序初始化
        public void Init(string IP, int port)
        {
            //初始化命令字符串
            returnStr = "";
            receiveStr = "";




            //建立服务器端socket
            IPEndPoint ipep = new IPEndPoint(/*addr[0]*/IPAddress.Parse(IP), port);//本机预使用的IP和端口
            severSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            severSocket.Bind(ipep);//绑定
            severSocket.Listen(10);//监听
            //建立服务器端socket end


            //新建线程
            thread = new Thread(new ThreadStart(GoClient));
            //启动线程
            thread.Start();
        }

        void GoClient()
        {
            //客户端连接
            ConnetClient();
            //用死循环来不断的从客户端获取信息
            while (true)
            {

                //每次接收数据之前先清空字符数组
                receiveData = new byte[1024];
                try
                {
                    recv = clientSocket.Receive(receiveData);
                    if (recv == 0)
                    {
                        ConnetClient();
                        continue;
                    }
                }
                //当信息长度为0，说明客户端连接断开
                //if (recv == 0)
                catch
                {
                    //等待客户端重新连接
                    ConnetClient();
                    //进入下一次循环
                    continue;
                }
                //接收到的消息
                receiveStr = Encoding.ASCII.GetString(receiveData, 0, recv);

            }
        }


        //等待客户端连接
        void ConnetClient()
        {


            if (clientSocket != null)
            {
                clientSocket.Close();
            }
            //等待连接
            //当有可用的客户端连接尝试时执行，并返回一个新的socket,用于与客户端之间的通信
            try
            {
                clientSocket = severSocket.Accept();
            }
            catch
            { }

        }

        //向客户端发送信息
        public void SendClient(string str)
        {
            if (clientSocket != null)
            {
                sendData = new byte[1024];
                sendData = Encoding.ASCII.GetBytes(str);
                clientSocket.Send(sendData, sendData.Length, SocketFlags.None);
            }
        }

        //返回传送命令
        public string ReturnStr()
        {
            lock (this)
            {
                returnStr = receiveStr;
            }
            return returnStr;
        }

        //清空消息
        public void SetStrEmpty()
        {
            returnStr = "";
            receiveStr = "";
        }

        //退出整个socket
        public void SocketQuit()
        {
            //先关闭客户端
            if (clientSocket != null)
            {
                clientSocket.Close();
            }
            //再关闭线程
            if (thread != null)
            {
                thread.Interrupt();
                thread.Abort();
            }
            //最后关闭服务端socket
            severSocket.Close();
        }

    }
}
