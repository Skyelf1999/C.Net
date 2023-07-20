using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace DesignPattern
{
    /// <summary>
    /// 抽象建造者
    /// </summary>
    public abstract class Builder : SingleInstance
    {
        string xmlPath = "/Users/dsh/Documents/C.Net/C#_onMac/designPattern/Builder/Builder.xml";
        // 具体build配置节点的路径
        protected abstract string NodePath {get;}
        // 保存生产产品属性配置的xml元素
        protected XmlNodeList settingElements;
        
        /// <summary>
        /// 读取配置，获取保存属性值的Element
        /// </summary>
        protected void initSettingElement()
        {
            XmlDocument document = new XmlDocument();
            document.Load(xmlPath);
            settingElements = document.SelectSingleNode(NodePath).ChildNodes;
        }


    }
}