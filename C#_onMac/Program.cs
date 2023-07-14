using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using DesignMethod;
using XmlTest;

namespace OnMac
{
    class Program
    {
        static void Main(string[] args)
        {
            testFactory();
            // testXml();
            // testType();
        }


        /// <summary>
        /// 设计模式：工厂
        /// </summary>
        public static void testFactory()
        {
            Console.WriteLine("简单工厂：传参生产");
            Product product = Factory.GetProduct(1);

            // 读取xml，根据配置生产对应产品
            Console.WriteLine("\n工厂方法：读配置生产");
            XmlDocument document = new XmlDocument();
            document.Load("/Users/dsh/Documents/C.Net/C#_onMac/designMethod/factory/Product.xml");
            XmlNode productListNode = document.SelectSingleNode("ProductList");
            // 读取子元素，创建对象
            Product[] products = new Product[productListNode.ChildNodes.Count];
            for(int i=0;i<products.Length;i++)
            {
                // 获取创建对象所需参数
                XmlElement productInfo = (XmlElement)productListNode.ChildNodes[i];
                string typeName = productInfo.GetAttribute("type");     // 产品类型名称
                string price = productInfo.InnerText;                   // 产品价格
                if(price.Length<1) price = "1";
                //反射
                Type type = Type.GetType("DesignMethod."+typeName);
                ConstructorInfo ctor = type.GetConstructor(new Type[]{typeof(float)});
                products[i] = (Product)ctor?.Invoke(new object[]{int.Parse(price)});
            }
            
        }


        /// <summary>
        /// XML测试
        /// </summary>
        public static void testXml()
        {
            XmlTest.XmlTest.DocumentTest();
        }


        /// <summary>
        /// Type反射测试
        /// </summary>
        public static void testType()
        {
            Computer cp = new Computer();
            Type type = cp.GetType();
            // Console.WriteLine("{0} {1} {2}\n",
            //     type.Name , type.FullName , type.BaseType);

            // Console.WriteLine("\n字段");
            // foreach(var temp in type.GetFields())
            // {
            //     Console.WriteLine(temp.Name);
            // }
            // Console.WriteLine("\n属性");
            // foreach(var temp in type.GetProperties())
            // {
            //     Console.WriteLine(temp.Name);
            // }
            // Console.WriteLine("\n方法");
            // foreach(var temp in type.GetMethods())
            // {
            //     Console.WriteLine(temp.Name);
            // }
            // Console.WriteLine("\n成员");
            // foreach(var temp in type.GetMembers())
            // {
            //     Console.WriteLine(temp.Name);
            // }
            // Console.WriteLine("\n构造函数");
            // foreach(var temp in type.GetConstructors())
            // {
            //     Console.WriteLine(temp.Name);
            // }
            // Console.WriteLine(typeof(int).Name);

            // 通过反射创建对象
            Type phoneType = Type.GetType("DesignMethod.Phone");
            ConstructorInfo ctor = phoneType.GetConstructor(new Type[]{typeof(float)});
            var phone = ctor?.Invoke(new object[]{4000});
            var computer = Activator.CreateInstance(typeof(Computer));
        }
    }

}
