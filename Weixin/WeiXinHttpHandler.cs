using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiXin.Common;

namespace Weixin
{
    public class WeiXinHttpHandler : IHttpHandler
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsReusable
        {
            get { return true; }
        }
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            //由微信服务接收请求，具体处理请求
            WeiXinService wxService = new WeiXinService(context.Request);
            string responseMsg = wxService.Response();
            context.Response.Clear();
            context.Response.Charset = "UTF-8";
            context.Response.Write(responseMsg);
            context.Response.End();
        }
    }
}