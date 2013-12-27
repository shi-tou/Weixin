using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeiXin.Common.Messages;

namespace WeiXin.Common.Handlers
{
    /// <summary>
    /// 事件处理类
    /// </summary>
    class EventHandler : IHandler
    {
        /// <summary>
        /// 请求的xml
        /// </summary>
        private string RequestXml { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="requestXml"></param>
        public EventHandler(string requestXml)
        {
            this.RequestXml = requestXml;
        }
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <returns></returns>
        public string HandleRequest()
        {
            string response = string.Empty;
            EventMessage em = EventMessage.LoadFromXml(RequestXml);
            if (em.Event.Equals("subscribe", StringComparison.OrdinalIgnoreCase))
            {
                //回复欢迎消息
                TextMessage tm = new TextMessage();
                tm.ToUserName = em.FromUserName;
                tm.FromUserName = em.ToUserName;
                tm.CreateTime = Common.GetNowTime();
                StringBuilder sb = new StringBuilder();
                sb.Append("HI，欢迎您关注【木头】订阅号").Append("\n\n");
                sb.Append("1.想跟你聊天吗，输入‘你好’试试吧").Append("\n");
                sb.Append("2.想了解天气吗？输入如\'北京\'或者\'beijing\'或者\'bj\'查询吧").Append("\n");
                tm.Content = sb.ToString();
                response = tm.GenerateContent();
            }

            return response;
        }
    }
}
