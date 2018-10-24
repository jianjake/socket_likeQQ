using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket sendsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //实例化socket         
            IPEndPoint ipendpiont = new IPEndPoint(IPAddress.Parse("192.168.123.10"), 10001);
            sendsocket.Connect(ipendpiont);
            //建立终结点 
            System.IO.FileStream fs = new System.IO.FileStream(@"F:/Temp/Client/flash01.jpg", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);
            byte[] fssize = new byte[fs.Length];
            System.IO.BinaryReader strread = new System.IO.BinaryReader(fs);
            strread.Read(fssize, 0, fssize.Length - 1);
            sendsocket.Send(fssize);
            fs.Close();
            sendsocket.Shutdown(System.Net.Sockets.SocketShutdown.Send);
            sendsocket.Close();
        }
    }
}