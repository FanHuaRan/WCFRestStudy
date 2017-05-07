using MusicStoreBIL.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreBIL.Services.Impl
{
    /// <summary>
    /// XmlClientServiceClass在web应用中的扩展
    /// 2017/05/07 fhr
    /// </summary>
    public class WebApiXmlClientServiceClass : XmlClientServiceClass
    {
       public WebApiXmlClientServiceClass()
        {
            this.xmlClientFileName = string.Format("{0}\\{1}", HttpRuntime.AppDomainAppPath, xmlClientFileName);
        }
    }
}