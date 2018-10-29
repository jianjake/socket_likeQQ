using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        //客户端通信套接字
        private Socket clientSocket;
        //新线程
        private Thread thread;
        //当前登录的用户
        private string userName = "";
        private string friend;
        private string filePath;
        private string picPath="";
        public Client()
        {
            InitializeComponent();
            //防止新线程调用主线程卡死
            CheckForIllegalCrossThreadCalls = false;
        }

        //通过IP地址与端口号与服务端建立链接       
        private void btnToServer_Click(object sender, EventArgs e)
        {
            //连接服务器前先选择用户
            if (cmbUser.SelectedItem == null)
            {
                MessageBox.Show("请选择登录用户");
                return;
            }
            userName = cmbUser.SelectedItem.ToString();
            Text = "当前用户：" + userName;
            //登录后禁止切换用户
            cmbUser.Enabled = false;
            //加载好友列表
            foreach (object item in cmbUser.Items)
            {
                if (item != cmbUser.SelectedItem)
                {
                    lbFriends.Items.Add(item);
                }
            }
            //新建通信套接字
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //这里的ip地址，端口号都是服务端绑定的相关数据。
            IPAddress ip = IPAddress.Parse(txtIP.Text);
            var endpoint = new IPEndPoint(ip, Convert.ToInt32(txtPort.Text));
            try
            {
                clientSocket.Connect(endpoint); //链接有端口号与IP地址确定服务端.
                //登录时给服务器发送登录消息
                string str = userName + "|" + " ";
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                var list = new List<byte>();
                list.Add(0);
                list.AddRange(buffer);
                byte[] newbuffer = list.ToArray();
                clientSocket.Send(newbuffer);
            }
            catch
            {
                MessageBox.Show("与服务器连接失败");
                lbFriends.Items.Clear();
            }
            //客户端在接受服务端发送过来的数据是通过Socket 中的Receive方法，
            //该方法会阻断线程，所以我们自己为该方法创建了一个线程
            thread = new Thread(ReceMsg);
            thread.IsBackground = true; //设置后台线程
            thread.Start();
        }

        public void ReceMsg()
        {
            while (true)
            {
                try
                {
                    var buffer = new byte[1024*1024*5];

                    int dateLength = clientSocket.Receive(buffer); //接收服务端发送过来的数据
                   
                    //MessageBox.Show(dateLength.ToString());
                    //一般消息
                    if (buffer[0] == (byte) MsgTypeEnum.String)
                    {
                        
                        //不解析第一位标识符
                        HandleStr(buffer, dateLength);
                    }
                        //抖屏消息
                    else if (buffer[0] == (byte) MsgTypeEnum.Shake)
                    {
                        HandleShake(buffer, dateLength);
                    }
                        //文件消息
                    else if (buffer[0] == (byte) MsgTypeEnum.File)
                    {
                        HandleFile(buffer, dateLength);
                    }
                    //图片
                    else if (buffer[0] == (byte)MsgTypeEnum.Picture)
                    {

                        HandlePic(buffer, dateLength);
                    }
                    else
                    {
                        MessageBox.Show("接收文件解析失败");
                    }
                }
                catch
                {
                }
            }
        }

        //发送文字与图片
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!IsSelectFriend())
            {
                return;
            }

             friend = lbFriends.SelectedItem.ToString();
            try
            {

                //图片
                if (richText.Rtf.IndexOf(@"{\pict\") > -1)
                {
                    string newstr = "我" + ":" + friend + "\r\n";
                    ShowSmsg(newstr);
                    try
                    {
                        Image bmp = Image.FromFile(picPath);
                        Clipboard.SetDataObject(bmp);

                        DataFormats.Format dataFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                        if (richShow.CanPaste(dataFormat))
                        {
                            richShow.Paste(dataFormat);
                        }

                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("图片插入失败。" + exc.Message, "提示",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    newstr = "           ____[" + DateTime.Now +
                                "]" + "\r\n" + "\r\n";
                    ShowSmsg(newstr);
                    SendPic();
                }
                else
                {

                    //界面显示消息
                    string newstr = "我" + ":" + friend + "\r\n" + richText.Text.Trim() + "           ____[" + DateTime.Now +
                                    "]" + "\r\n" + "\r\n";
                    ShowSmsg(newstr);
                    newstr = friend + ":" + "我"  + "\r\n" + richText.Text.Trim() + "           ____[" + DateTime.Now +
                                    "]" + "\r\n" + "\r\n";
                    SendStr(newstr);
                }
                richText.Text = "";
            }
            catch
            {
                MessageBox.Show("与服务器连接失败");
            }
        }

        //展示消息
        private void ShowSmsg(string newStr)
        {
            //txtChat.AppendText(newStr);
            richShow.AppendText(newStr);
        }

        private void btnCloseSer_Click(object sender, EventArgs e)
        {
            clientSocket.Close();
        }

        private void btnShake_Click(object sender, EventArgs e)
        {
            if (!IsSelectFriend())
            {
                return;
            }
            friend = lbFriends.SelectedItem.ToString();
            try
            {
                //界面显示消息
                string newstr = "我" + ":" + friend + "\r\n" + "\"发送了一个抖屏\""+ "           ____[" + DateTime.Now +
                                "]" + "\r\n" + "\r\n";
                ShowSmsg(newstr);
                SendShake();
            }
            catch
            {
                MessageBox.Show("与服务器连接失败");
            }
        }
        private void btnSelFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = false;
                ofd.Title = "选择要发送的文件";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                    //  txtMsg.Text = filePath;
                    richText.Text = filePath;
                }
            }
        }
        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (!IsSelectFriend()||filePath=="")
            {
                MessageBox.Show("选择好友与文件");
                return;
            }
            friend = lbFriends.SelectedItem.ToString();
            try
            {
                //界面显示消息
                string newstr = "我" + ":" + friend + "\r\n" + "\"发送了一个文件\"" + "           ____[" + DateTime.Now +
                                "]" + "\r\n" + "\r\n";
                ShowSmsg(newstr);
                SendFile();
                filePath = "";
            }
            catch
            {
                MessageBox.Show("与服务器连接失败");
            } 
        }
        //显示聊天内容---文字
        public void HandleStr(byte[] buffer, int dateLength)
        {
            //不解析第一位标识符
            string ReceiveMsg = Encoding.UTF8.GetString(buffer, 1, dateLength - 1);
            string[] msgTxt = ReceiveMsg.Split('|');
            string newstr = "      " + msgTxt[2] ;
            //把接收到的字节数组转成字符串显示在文本框中。
             ShowSmsg(newstr);

        }
        //显示聊天内容---抖屏
        public void HandleShake(byte[] buffer, int dateLength)
        {
            //不解析第一位标识符
            string ReceiveMsg = Encoding.UTF8.GetString(buffer, 1, dateLength - 1);
            string[] msgTxt = ReceiveMsg.Split('|');
            string newstr = "      " + msgTxt[0] + "：我" + "\r\n" + "      " + "\"发送了一个抖屏\"" + "           ____[" +
                            DateTime.Now + "]" + "\r\n" + "\r\n";
            //把接收到消息显示在文本框中。
            ShowSmsg(newstr);
            //震动
            ShakeBody();
        }
        //接受文件
        public void HandleFile(byte[] buffer, int dateLength)
        {
            //不解析第一位标识符
            string ReceiveMsg = Encoding.UTF8.GetString(buffer, 1, dateLength - 1);
            string[] msgTxt = ReceiveMsg.Split('|');
            //获得收到的标识字节个数
            int count = msgTxt[0].Length*2 + msgTxt[1].Length * 2 + msgTxt[2].Length * 2+3;
            string newstr = "      " + msgTxt[0] + "：我" + "\r\n" + "      " +"\"发送了一个文件\""+ "           ____[" +
                            DateTime.Now + "]" + "\r\n" + "\r\n";
            ShowSmsg(newstr);
            if (MessageBox.Show("好友" + msgTxt[0] + "发来一个文件是否接收", "收到文件", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                var sfd = new SaveFileDialog();
                sfd.Title = "保存文件";
                string fileType = "默认文件格式|*" + msgTxt[2];
                sfd.Filter = fileType;
                sfd.ShowDialog(this);
                using (var fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fs.Write(buffer, count, dateLength );
                }
                MessageBox.Show(msgTxt[1]+"保存成功");
                //把接收到的消息显示在文本框中。
                string resultstr1 = "      " + msgTxt[0] + "：我" + "\r\n" + "      " + "\"文件接收成功\"" + "           ____[" +
                    DateTime.Now + "]" + "\r\n" + "\r\n";
                ShowSmsg(resultstr1);
            }
            else
            {
                //把接收到的消息显示在文本框中。
                string resultstr = "      " + msgTxt[0] + "：我" + "\r\n" + "      " + "\"文件接收取消\"" + "           ____[" +
                         DateTime.Now + "]" + "\r\n" + "\r\n";
                ShowSmsg(resultstr);
            }
          
        }
        //接受图片
        public void HandlePic(byte[] buffer, int dateLength)
        {
            //不解析第一位标识符
            string ReceiveMsg = Encoding.UTF8.GetString(buffer, 1, dateLength - 1);
            //from|to|.XXX|
            string[] msgTxt = ReceiveMsg.Split('|');
            //获得收到的标识字节个数
            int count = msgTxt[0].Length * 2 + msgTxt[1].Length * 2 + msgTxt[2].Length * 2 ;
            if (msgTxt[2].Equals(".jpeg"))
                count += 3;
            if (msgTxt[2].Equals(".jpg")|| msgTxt[2].Equals(".png")|| msgTxt[2].Equals(".gif"))
                count += 4;
            //png、gif

            //string newstr = "      " + msgTxt[0] + "：我" + "\r\n" + "      " + "\"发送了一个图片\"" + "           ____[" +
            //                DateTime.Now + "]" + "\r\n" + "\r\n";
           // string newstr = "  " + msgTxt[0] + msgTxt[0].Length+ "   " + msgTxt[1] + "   " + msgTxt[2] + count;
             string picName = "D:\\mysocket\\picture\\03.jpeg";
              using (var fs = new FileStream(picName, FileMode.OpenOrCreate, FileAccess.Write))
              {
                  fs.Write(buffer, count, dateLength);
              }
            string newstr = "      " + msgTxt[0] + ":" +  "我" + "\r\n";
            ShowSmsg(newstr);
            var list = new List<byte>();
            //这里直接读取的文件，只适应于小文件（读取到内存中），大文件要用到断点续传等技术
            list.AddRange(ReadImageFile("D:\\mysocket\\picture\\03.jpeg"));
            byte[] newbuffer = list.ToArray();
            MemoryStream ms = new MemoryStream(newbuffer);
            Image image = System.Drawing.Image.FromStream(ms);
            //Graphics g = richShow.CreateGraphics();
            // g.DrawImage(image, 0, 0);
            // richShow.Clear();
            Thread th = new Thread(new ThreadStart(delegate ()
            {
                try
                {
                    //Image bmp1 = Image.FromFile("C:\\Users\\jake\\Desktop\\03.jpeg");
                    // Clipboard.Clear();

                    Clipboard.SetDataObject(image);

                    DataFormats.Format dataFormat1 = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (richShow.CanPaste(dataFormat1))
                    {
                        richShow.Paste(dataFormat1);
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show("图片插入失败。" + exc.Message, "提示",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }));
            th.TrySetApartmentState(ApartmentState.STA);
            th.Start();
            th.Join();
            
            newstr = "           ____[" + DateTime.Now +
                        "]" + "\r\n" + "\r\n";
            ShowSmsg(newstr);
        }
        private bool IsSelectFriend()
        {
            if (lbFriends.SelectedItems.Count != 1)
            {
                MessageBox.Show("请选择好友");
                return false;
            }
            else
            {
                return true ;   
            }
        }
        //发往服务器的消息 --文字
        private void SendStr(string MsgStr)
        {
            //发往服务器的消息     格式为 （发送者|接收者|信息）
            MyMessage msg = new MyMessage(MsgStr);
                //消息转字节
                byte[] buffer = msg.ToByteData();
                //添加标识符+发送者|接收者|
               byte[] sendbuffer= msg.MakeNewArrWithFlag(buffer,userName,friend);
               clientSocket.Send(sendbuffer);
            //txtMsg.Text = "";
            richText.Text = "";
        }
        //发送图片
        private void SendPic()
        {
            //发往服务器的消息     格式为 （发送者|接收者|信息）
            MyMessage msg = new MyMessage(picPath, MsgTypeEnum.Picture);
            //消息转字节
            byte[] buffer = msg.ToByteData();
            //添加标识符+发送者|接收者|
            byte[] sendbuffer = msg.MakeNewArrWithFlag(buffer, userName, friend);
            clientSocket.Send(sendbuffer);
            ///txtMsg.Text = "";
            richText.Text = "";

        }
        //发往服务器的消息 --抖屏
        private void SendShake()
        {
            //发往服务器的消息     格式为 （发送者|接收者|信息）
            MyMessage msg = new MyMessage(MsgTypeEnum.Shake);
            //消息转字节
            byte[] buffer = msg.ToByteData();
            //添加标识符+发送者|接收者|
            byte[] sendbuffer = msg.MakeNewArrWithFlag(buffer, userName, friend);
            clientSocket.Send(sendbuffer);
            // txtMsg.Text = "";
            richText.Text = "";
        }
        //发往服务器的消息 --文件
        private void SendFile()
        {
            //发往服务器的消息     格式为 （发送者|接收者|信息）
            MyMessage msg = new MyMessage(filePath,MsgTypeEnum.File);
            //消息转字节
            byte[] buffer = msg.ToByteData();
            //添加标识符+发送者|接收者|
            byte[] sendbuffer = msg.MakeNewArrWithFlag(buffer, userName, friend);
            clientSocket.Send(sendbuffer);
            ///txtMsg.Text = "";
            richText.Text = "";
        }
        Random randObj = new Random();

        private void ShakeBody()
        {
            //1.获取窗体当前坐标
            Point oldPoint = this.Location;
            //2.循环改变 窗体 坐标
            for (int i = 0; i < 15; i++)
            {
                //3.设置新的随机坐标
                this.Location = new Point(oldPoint.X + randObj.Next(30), oldPoint.Y + randObj.Next(30));
                System.Threading.Thread.Sleep(50);
                //4.还原坐标
                this.Location = oldPoint;
                System.Threading.Thread.Sleep(50);
            }
        }

        private void txtMsg_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtChat_TextChanged(object sender, EventArgs e)
        {

        }
        //读取图片
        private static byte[] ReadImageFile(String img)
        {
            FileInfo fileinfo = new FileInfo(img);
            byte[] buf = new byte[fileinfo.Length];
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            fs.Read(buf, 0, buf.Length);
            fs.Close();
            //fileInfo.Delete ();
            GC.ReRegisterForFinalize(fileinfo);
            GC.ReRegisterForFinalize(fs);
            return buf;
        }

        private void btnPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            o.Title = "请选择图片";
            o.Filter = "jpeg|*.jpeg|jpg|*.jpg|png|*.png|gif|*.gif";
            if (o.ShowDialog() == DialogResult.OK)
            {
                picPath = o.FileName;
                try
                {
                    Image bmp = Image.FromFile(picPath);
                    Clipboard.SetDataObject(bmp);

                    DataFormats.Format dataFormat = DataFormats.GetFormat(DataFormats.Bitmap);
                    if (richText.CanPaste(dataFormat))
                    {
                        richText.Paste(dataFormat);
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show("图片插入失败。" + exc.Message, "提示",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            richText.Focus();
        }
    }
}
