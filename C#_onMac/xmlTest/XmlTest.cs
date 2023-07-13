using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;


namespace XmlTest
{
    class XmlTest
    {
        public static void DocumentTest()
        {
            XmlDocument document = new XmlDocument();
            document.Load("/Users/dsh/Documents/C.Net/C#_onMac/xmlTest/test.xml");

            // 取得目标节点
            XmlNode fruitShopNode = document.SelectSingleNode("FruitShop");
            foreach(XmlElement fruit in fruitShopNode.ChildNodes)
            {
                string name = fruit.GetAttribute("name");
                int price = int.Parse(fruit.ChildNodes[0].InnerText);
                string color = fruit.ChildNodes[1].InnerText;
                Console.WriteLine("{0} {1} {2}\n",name,price,color);
            }
            Console.WriteLine(fruitShopNode.Attributes);
        }


        public static void ReaderTest()
        {

        }
    }
}