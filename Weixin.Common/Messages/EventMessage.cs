﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WeiXin.Common.Messages
{
    /// <summary>
    /// 事件消息类
    /// </summary>
    class EventMessage : Message
    {
        private const string EVENT = "Event";
        private const string EVENT_KEY = "EventKey";
        /// <summary>
        /// 
        /// </summary>
        private static string template;
        /// <summary>
        /// 模板
        /// </summary>
        public override string Template
        {
            get 
            {
                if (string.IsNullOrEmpty(template))
                {
                    LoadTemplate();
                }

                return template;
            }
        }
        /// <summary>
        /// 事件类型
        /// </summary>
        public string Event { get; set; }
        /// <summary>
        /// 事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        public EventMessage()
        {
            this.MsgType = "event";
        }
        /// <summary>
        /// 加载模板
        /// </summary>
        private static void LoadTemplate()
        {
            template = @"<xml>
                                <ToUserName><![CDATA[{0}]]></ToUserName>
                                <FromUserName><![CDATA[{1}]]></FromUserName>
                                <CreateTime>{2}</CreateTime>
                                <MsgType><![CDATA[event]]></MsgType>
                                <Event><![CDATA[{3}]]></Event>
                                <EventKey>{4}</EventKey>
                            </xml>";
        }
        /// <summary>
        /// 从xml数据加载文本消息
        /// </summary>
        /// <param name="xml"></param>
        public static EventMessage LoadFromXml(string xml)
        {
            EventMessage em = null;
            if (!string.IsNullOrEmpty(xml))
            {
                XElement element = XElement.Parse(xml);
                if (element != null)
                {
                    em = new EventMessage();
                    em.FromUserName = element.Element(Common.FROM_USERNAME).Value;
                    em.ToUserName = element.Element(Common.TO_USERNAME).Value;
                    em.CreateTime = element.Element(Common.CREATE_TIME).Value;
                    em.Event =element.Element(EVENT).Value;
                    em.EventKey = element.Element(EVENT_KEY).Value;
                }
            }

            return em;
        }
    }
}
