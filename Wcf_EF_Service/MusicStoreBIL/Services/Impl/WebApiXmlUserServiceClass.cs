using MusicStoreBIL.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreBIL.Services.Impl
{
    /// <summary>
    /// XmlUserServiceClass在web应用当中的扩展
    /// 2017/05/07 fhr
    /// </summary>
    public class WebApiXmlUserServiceClass : XmlUserServiceClass
    {
        public WebApiXmlUserServiceClass()
        {
            this.userFileName = string.Format("{0}\\{1}", HttpRuntime.AppDomainAppPath, userFileName);
        }
    }
}