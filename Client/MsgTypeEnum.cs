using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// 消息类型
    /// </summary>
   public enum MsgTypeEnum
    {
       //  登录消息
       Login =0,
       //一般消息
       String =1,
       //抖动屏幕
       Shake=2,
       //文件
       File=3,
       //图片
       Picture=4
    }
}
