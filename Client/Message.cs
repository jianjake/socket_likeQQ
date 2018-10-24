using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// 消息类
    /// </summary>
  public  class MyMessage
    {
         MsgTypeEnum msgType;
        string filePath;
         string strMsg;
        string picPath;
         /// <summary>
         /// 普通文本消息
         /// </summary>
         /// <param name="msgString">消息</param>
        public MyMessage(string msgString)
        {
            this.msgType = MsgTypeEnum.String;
             this.strMsg = msgString;
        }
      /// <summary>
      /// 消息类型
      /// </summary>
      /// <param name="msgType"></param>
        public MyMessage(MsgTypeEnum msgType)
        {
            this.msgType = msgType;
        }
         /// <summary>
         /// 文件类型
         /// </summary>
         /// <param name="filePath"></param>
         /// <param name="msgType"></param>
        public MyMessage(string filePath, MsgTypeEnum msgType)
        {
            this.msgType = msgType;
            if (msgType== MsgTypeEnum.File)
                       this.filePath = filePath;
            else this.picPath = filePath;
        }
            /// <summary>
           /// 根据消息类型返回消息byte数组 
            /// </summary>
            /// <returns></returns>
        public byte[] ToByteData()
        {
            //消息数组
            byte[] arrMsg = null;
            switch (msgType)
            {
                case MsgTypeEnum.String:
                    {
                        //1.将消息字符串转成 字节数组
                        arrMsg = System.Text.Encoding.UTF8.GetBytes(strMsg);
                        break;
                    }
                case MsgTypeEnum.File:
                {
                    string fileType = Path.GetExtension(filePath) + "|"; //提示对方接收文件的类型
                        byte[] buffer0 = Encoding.UTF8.GetBytes(fileType);
                        var list = new List<byte>();
                        list.AddRange(buffer0);
                        //这里直接读取的文件，只适应于小文件（读取到内存中），大文件要用到断点续传等技术
                       list.AddRange(File.ReadAllBytes(filePath));  
                        byte[] newbuffer = list.ToArray();
                        arrMsg= newbuffer;
                        break;
                    }
                case MsgTypeEnum.Shake:
                    {
                        arrMsg = new byte[0];
                        break;
                    }
                case MsgTypeEnum.Picture:
                    {
                        string fileType = Path.GetExtension(picPath) + "|"; //提示对方接收文件的类型
                        byte[] buffer0 = Encoding.UTF8.GetBytes(fileType);
                       
                        var list = new List<byte>();
                        list.AddRange(buffer0);
                        //这里直接读取的文件，只适应于小文件（读取到内存中），大文件要用到断点续传等技术
                        list.AddRange(ReadImageFile(picPath));
                        byte[] newbuffer = list.ToArray();
                        arrMsg = newbuffer;
                        break;
                    }
            }
            return arrMsg;
        }

      /// <summary>
      /// 标记消息类型+发信人+收信人（最终消息）
      /// </summary>
      /// <param name="oldArr"></param>
      /// <param name="fromClient"></param>
      /// <param name="toClient"></param>
      /// <returns></returns>
        public byte[] MakeNewArrWithFlag(byte[] oldArr,string fromClient,string toClient)
        {
            //消息格式：   （类型标识符） 发信人| 收信人 +具体信息
          string str = fromClient + "|" + toClient + "|";
          byte[] buffer0 = Encoding.UTF8.GetBytes(str);
          var list = new List<byte>();
          list.AddRange(buffer0);
          list.AddRange(oldArr);
          byte[] newbuffer = list.ToArray();
          byte[] newArr = new byte[newbuffer.Length + 1];
            //1.将当前对象的类型转成标识数值存入新数组的第一个元素
            newArr[0] = (byte)msgType;
            //2.将 老数组的 数据 复制到 新数组中（从新数组第二个位置开始存放）
            newbuffer.CopyTo(newArr, 1);
            //3.返回 带标识位的 新消息数组
            return newArr;
        }
        public byte[] ReadImageFile(String img)
        {
            /*FileInfo fileinfo = new FileInfo(img);
            byte[] buf = new byte[fileinfo.Length];
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            fs.Read(buf, 0, buf.Length);
            fs.Close();
            //fileInfo.Delete ();
            GC.ReRegisterForFinalize(fileinfo);
            GC.ReRegisterForFinalize(fs);
            return buf;*/
            FileStream fileStream = new FileStream(img, FileMode.Open, System.IO.FileAccess.Read);

            fileStream.Seek(0, SeekOrigin.Begin);

            byte[] binary = new byte[fileStream.Length]; //创建文件长度的buffer 
            fileStream.Read(binary, 0, (int)fileStream.Length);

            fileStream.Close();

            fileStream.Dispose();

            fileStream = null;

            //MemoryStream stream = new MemoryStream(binary);
           //System.Drawing.Image img1 = System.Drawing.Image.FromStream(stream);
           //img1.Save("03.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);//xxx.jpeg为文件名

            return binary;
        }
    }
}
