﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MusicStoreBIL.Services.Impl
{
    /// <summary>
    /// 客户端服务的xml存储实现
    /// 2017/05/07 fhr
    /// </summary>
    public class XmlClientServiceClass:IClientService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(XmlClientServiceClass));
        private object locker = new object();
        protected string xmlClientFileName = "musicstore-clients.xml";
        public string FindClientSecret(string clientId)
        {
            lock (locker)
            {
                try
                {
                    var document = createXmlDocument();
                    var clientNodeList = document.SelectNodes("clients/client");
                    foreach (XmlNode clientNode in clientNodeList)
                    {
                        var cId = clientNode.Attributes["clientId"].Value;
                        if (cId == clientId)
                        {
                            return clientNode.Attributes["clientsecret"].Value;
                        }
                    }
                }
                catch (Exception e)
                {
                    log.Error("FindClientSecret wrong", e);
                }
                return null;
            }
        }

        public bool SaveClient(string clientId, string clientSecret)
        {
            lock (locker)
            {
                if (FindClientSecret(clientId) != null)
                {
                    return false;
                }
                try
                {
                    var document = createXmlDocument();
                    var rootNode = document.SelectSingleNode("clients");
                    var userElement = createClientElement(clientId, clientSecret, document);
                    rootNode.AppendChild(userElement);
                    document.Save(xmlClientFileName);
                    return true;
                }
                catch (Exception e)
                {
                    log.Error("SaveClient wrong", e);
                    return false;
                }
            }
        }
        public Task<string> FindClientSecretAsync(string clientId)
        {
           return Task<String>.Run(() =>
            {
                return FindClientSecret(clientId);
            });
        }

        public Task<bool> SaveClientAsync(string clientId, string clientSecret)
        {
            return  Task<bool>.Run(() =>
            {
                return SaveClient(clientId, clientSecret);
            });
        }
        private XmlElement createClientElement(string clientId, string clientSecret,XmlDocument document)
        {
            var userElement = document.CreateElement("client");
            var cIdAttri = document.CreateAttribute("clientId");
            cIdAttri.Value = clientId;
            var cSeAttri = document.CreateAttribute("clientSecret");
            cSeAttri.Value = clientSecret;
            userElement.Attributes.Append(cIdAttri);
            userElement.Attributes.Append(cSeAttri);
            return userElement;
        }
        private XmlDocument createXmlDocument()
        {
            var docMent = new XmlDocument();
            docMent.Load(xmlClientFileName);
            return docMent;
        }

    }
}
