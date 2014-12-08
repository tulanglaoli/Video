using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Xml;
//Send Data
public class SendClientSocket : MonoBehaviour {
	
	

	byte[] recvbytes= new byte[1024];
	bool ISConfig=false;
	string IP;
	int Port;
	// Use this for initialization
	void Start () {
		IP = PlayerPrefs.GetString("IP", "192.168.1.103");   
		Port = PlayerPrefs.GetInt("Port", 2000);   

		//string IP = "127.0.0.1";
		
	}

	void Update()
	{

	}

	void OnGUI()
	{
		if(GUI.Button (new Rect (0, 0, 100, 100), "Client"))
		{
			Client(IP,Port);
		}
		if(GUI.Button (new Rect (100, 0, 100, 100), "Play"))
		{
			Send("FF");
		}
		if(GUI.Button (new Rect (200, 0, 100, 100), "Stop"))
		{
			Send("SS");
		}
		if(GUI.Button (new Rect (0, 100, 100, 100), "Pause"))
		{
			Send("PP");
		}
		if(GUI.Button (new Rect (100, 100, 100, 100), "Forward"))
		{
			Send("RR");
		}
		if(GUI.Button (new Rect (200, 100, 100, 100), "Back"))
		{
			Send("LL");
		}
		if(GUI.Button (new Rect (100, 200, 100, 100), "Config And Save"))
		{
			if (ISConfig==false)
			{
				ISConfig = true;
			}
			else
			{
				ISConfig = false;
				PlayerPrefs.SetString("IP",IP);
				PlayerPrefs.SetInt("Port",Port);
			}
		}
		if (ISConfig == true) 
		{
			GUI.Label(new Rect (100, 300, 100, 20), "IP");
			IP = GUI.TextArea(new Rect (200, 300, 100, 20), IP);
			GUI.Label(new Rect (100, 350, 100, 20), "Port");
			Port = int.Parse(GUI.TextArea(new Rect (200, 350, 100, 20), Port.ToString()));
		}


	}
	
	int bytes;
	void Client(string IP,int port)
	{
		string hostName = System.Net.Dns.GetHostName();
		System.Net.IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(hostName);
		System.Net.IPAddress[] addr = ipEntry.AddressList;
		System.Net.IPAddress readIP = IPAddress.Parse(IP);
		IPEndPoint ipep = new IPEndPoint(readIP, port);
		Sharedcode.c = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
		Sharedcode.c.Connect(ipep);

	}
	void Send(string SendStr)
	{

		bytes = Sharedcode.c.Send(Encoding.ASCII.GetBytes (SendStr));

		print(Sharedcode.recvStr);
	}

	
	void OnApplicationQuit()
	{
		Sharedcode.c.Close();
	}
	
	
}

