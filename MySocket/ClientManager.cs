using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MySocket
{
    /// <summary>
    /// 客户端管理
    /// </summary>
    public class ClientManager
    {
        //好友列表控件
        private System.Windows.Forms.ListBox listClient;
        //在服务器上显示消息的委托（全局）
        DGSendMsg dgSendMsg;
        //通信套接字key ：客户端ip value ：对应的通信套接字
        private Dictionary<string, Socket> ClientSocket;
        // 通信套接字key ：客户端ip value ：用户名（由于没有添加数据库我们暂时这么模拟，下篇我会讲到）
        private Dictionary<string, string> UserSocket;
        public ClientManager()
        { }
        /// <summary>
        /// 客户端管理类
        /// </summary>
        /// <param name="lb">列表控件</param>
        /// <param name="dgSendMsg">显示消息</param>
        public ClientManager(System.Windows.Forms.ListBox lb, DGSendMsg dgSendMsg)
        {
            //用户列表
            this.listClient = lb;
            //消息委托
            this.dgSendMsg = dgSendMsg;
            //通信字典
            ClientSocket = new Dictionary<string, Socket>();
            //用户字典
            UserSocket = new Dictionary<string, string>();
        }
        #region  添加客户端通信套接字+ public void AddClient(Socket sokMsg)
        /// <summary>
        /// 添加通信套接字
        /// </summary>
        /// <param name="sokMag">负责通信的socket</param>
        public void AddClient(Socket sokMsg)
        {
            //获取客户端通信套接字
            string strEndPoint = sokMsg.RemoteEndPoint.ToString();
            //通信套接字加入字典
            ClientSocket.Add(strEndPoint, sokMsg);
            //sokServer.Accept()这个接收消息的方法会使线程卡死，所以要开启新线程
            Thread thrMag = new Thread(ReciveMsg);
            //设置为后台线程防止卡死
            thrMag.IsBackground = true;
            //开启线程 为新线程传入通信套接字参数
            thrMag.Start(sokMsg);
            dgSendMsg(strEndPoint + "成功连接上服务端~~~!" + DateTime.Now.ToString());
        }
        #endregion
        bool isReceing = true;
        #region void ReciveMsg(object sokMsgObj)    服务接收客户端消息
        /// <summary>
        /// 服务接收客户端消息
        /// </summary>
        /// <param name="sokMsgObj">客户端Scoket</param>
        void ReciveMsg(object sokMsgObj)
        {
            Socket sokMsg = null;
            try
            {
                //sokMsg接收消息的socket
                sokMsg = sokMsgObj as Socket;
                //创建接收消息的缓冲区   默认5M
           
                //循环接收
                while (isReceing)
                {
                    byte[] arrMsg = new byte[5 * 1024 * 1024];
                    //接收到的真实消息存入缓冲区     并保存消息的真实长度（因为5M缓冲区不会全部用掉）
                    int realLength = sokMsg.Receive(arrMsg);
                    //将缓冲区的真实数据转成字符串
                    string strMsg = Encoding.UTF8.GetString(arrMsg, 1, realLength-1);
                    //dgSendMsg(strMsg);
                    string[] msgTxt = strMsg.Split('|');
                    //  msgTxt.Length == 2说明用户第一次连入，我们必须记录他的IP并与用户对应起来，如果局域网聊天
                    //IP在同一网段两个客户端还可以互相找到， 如果广域网下只有通过服务器转接才能找到
                    if (msgTxt.Length == 2)
                    {
                        //如果用户名已登录则强制下线
                        if (UserSocket.Values.Contains(msgTxt[0]))
                        {
                            sokMsg.Close();
                            return;
                        }
                        UserSocket.Add(sokMsg.RemoteEndPoint.ToString(), msgTxt[0]);
                        //显示列表
                        listClient.Items.Add(sokMsg.RemoteEndPoint + "---" + msgTxt [0]+ @"---上线~\(≧▽≦)/~啦啦啦");
                        continue;
                    }
                    SendMsgToClient(arrMsg, realLength);
                }
            }
            catch
            {
                //连接出错说明客户端连接断开
                RemoveClient(sokMsg.RemoteEndPoint.ToString());
            }
        }
        #endregion
        /// <summary>
        /// 移除下线用户信息
        /// </summary>
        /// <param name="strClientID">IP：端口</param>
        public void RemoveClient(string strClientID)
        {
            //要移除的用户名
            string name = UserSocket[strClientID];
            //  要移除的在线管理的项
            string onlineStr = strClientID + "---" + UserSocket[strClientID] + @"---上线~\(≧▽≦)/~啦啦啦";
        
            //移除在线管理listClient 集合
            if (listClient.Items.Contains(onlineStr))
            {
                listClient.Items.Remove(onlineStr);
            }
            //断开socket连接
            if (ClientSocket.Keys.Contains(strClientID))
            {
                ClientSocket[strClientID].Close();
                ClientSocket.Remove(strClientID);
                UserSocket.Remove(strClientID);
            }
            dgSendMsg(strClientID + "---" + name + @"---下线_"+DateTime.Now);
        }
        /// <summary>
        /// 转发给客户端
        /// </summary>
        /// <param name="Msg">byte[]消息</param>
        /// <param name="realLength">消息有效长度</param>
        public void SendMsgToClient(byte[] Msg,int realLength)
        {
            //解析发来的数据
            string strMsg = Encoding.UTF8.GetString(Msg, 1, realLength - 1);
            string[] msgTxt = strMsg.Split('|');
            //不可解析数据
            if (msgTxt.Length < 2)
            {
                return;
            }
            //  解析收消息的用户名
            string strTo = msgTxt[1];
            //获得当前发送的用户
            var nowtouser = UserSocket.Where(w => w.Value == strTo).FirstOrDefault();
            if (nowtouser.Key != null)
            {
                Socket conn = ClientSocket[nowtouser.Key];
                byte[] MsgArr = Msg.Take(realLength).ToArray();
                conn.Send(MsgArr);
            }

        }
    }
}
