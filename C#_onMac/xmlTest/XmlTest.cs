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
            document.Load("/Users/dsh/Documents/MyGit/C.Net/C#_onMac/xmlTest/test.xml");

            // 取得目标节点
            XmlNode fruitShopNode = document.SelectSingleNode("FruitShop");

            // 遍历目标节点的子元素集合
            foreach(XmlElement fruit in fruitShopNode.ChildNodes)
            {
                string name = fruit.GetAttribute("name");
                int price = int.Parse(fruit.ChildNodes[0].InnerText);
                string color = fruit.ChildNodes[1].InnerText;
                Console.WriteLine("{0} {1} {2}\n",name,price,color);
            }
            Console.WriteLine(fruitShopNode.Attributes+"\n\n");

            Console.WriteLine("选取所有FruitShop/Fruit标签");
            XmlNodeList xmlNodeList = document.SelectNodes("FruitShop/Fruit");
            foreach(XmlElement element in xmlNodeList)
                Console.WriteLine(element.Name);
            Console.WriteLine();

            Console.WriteLine("选取蔬菜的颜色");
            XmlNode node = document.SelectSingleNode("FruitShop/Vegetable/color");
            Console.WriteLine(node.InnerText);
        }


        public static void ReaderTest()
        {

        }
    }
}