using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;
using DesignPattern;
using StructPattern;

namespace OnMac
{
    public class TestDesignPattern
    {
        private static class Holder
        {
            public static readonly TestDesignPattern instance = new TestDesignPattern();
        }

        public static TestDesignPattern GetInstance()
        {
            return Holder.instance;
        }



        // -------------------------------- 相关测试 -------------------------------- //

        /// <summary>
        /// 设计模式：工厂
        /// </summary>
        public void testFactory()
        {
            Console.WriteLine("简单工厂：传参生产");
            Product product = Factory.GetProduct(1);

            // 读取xml，根据配置生产对应产品
            Console.WriteLine("\n工厂方法：读配置生产");
            XmlDocument document = new XmlDocument();
            document.Load("/Users/dsh/Documents/C.Net/C#_onMac/creationPattern/factory/Product.xml");
            XmlNode productListNode = document.SelectSingleNode("ProductList");
            // 读取子元素，创建对象
            // Console.WriteLine("节点名称：{0}",productListNode.Name);
            Product[] products = new Product[productListNode.ChildNodes.Count];
            for(int i=0;i<products.Length;i++)
            {
                // 获取创建对象所需参数
                XmlElement productInfo = (XmlElement)productListNode.ChildNodes[i];
                string typeName = productInfo.GetAttribute("type");     // 产品类型名称
                string price = productInfo.InnerText;                   // 产品价格
                if(price.Length<1) price = "0";

                //反射
                Type type = Type.GetType("DesignPattern."+typeName);
                ConstructorInfo ctor = type.GetConstructor(new Type[]{typeof(int)});
                products[i] = (Product)ctor?.Invoke(new object[]{int.Parse(price)});
            }
            
            // 抽象工厂
            Console.WriteLine();
            document.Load("/Users/dsh/Documents/C.Net/C#_onMac/creationPattern/factory/AbstractFactory.xml");
            string abstractFactoryName = document.SelectSingleNode("AbstractFactory").InnerText;
            Type absFacType = Type.GetType("DesignPattern."+abstractFactoryName);
            ConstructorInfo absFacCtor = absFacType.GetConstructor(new Type[]{});
            IAbstractFactory abstractFactory = (IAbstractFactory)absFacCtor?.Invoke(new object[]{});
            abstractFactory.CreateComputer();
        }


        


        /// <summary>
        /// 设计模式：单例
        /// </summary>
        public void testSingleInstance()
        {
            Console.WriteLine("单例测试");
            SingleInstance instance_1 = SingleInstance.GetInstance();
            SingleInstance instance_2 = SingleInstance.GetInstance();
            // instance_2.count += 10;
            Console.WriteLine("当前获取实例次数：{0}",instance_1.count);
            Console.WriteLine("是否是同一个实例：{0}",instance_1==instance_2);
        }


        /// <summary>
        /// 设计模式：原型
        /// </summary>
        public void testPrototype()
        {
            Console.WriteLine("原型测试");
            Prototype a = new Prototype(1002,"dsh");
             a.data.data = "DotA2";
            Prototype b = a.Clone() as Prototype;
            a.Text = "htm";
            Console.WriteLine("{0} {1}",a.Equals(b),a.data.Equals(b.data));
            a.data.data = "MHW";
            Console.WriteLine(a);
            Console.WriteLine(b);
        }


        /// <summary>
        /// 设计模式：结构型模式-适配器
        /// </summary>
        public void testAdapter()
        {
            Console.WriteLine("适配器");
            Adapter adapter = new Adapter();
            adapter.Method2();
        }


        /// <summary>
        /// 设计模式：结构型模式-桥接
        /// </summary>
        public void testBridge()
        {
            // Console.WriteLine(Type.GetType("StructPattern.Fire").FullName);
            Console.WriteLine("法师的名称、等级等基本属性由法师类实现，而元素相关的功能由外部桥接的接口对象实现\n\n");
            // 读取xml
            XmlDocument document = new XmlDocument();
            document.Load("/Users/dsh/Documents/C.Net/C#_onMac/structPattern/bridgePattern/Magician.xml");
            XmlNode parent = document.SelectSingleNode("config");

            Magician[] team = new Magician[parent.ChildNodes.Count];
            // 遍历子标签，通过反射创建对象
            for(int i=0;i<team.Length;i++)
            {
                XmlElement element = parent.ChildNodes[i] as XmlElement;
                Console.WriteLine("当前信息：{0} {1} {2}\n",element.Name,element.GetAttribute("name"),element.InnerText);
                // 创建法师对象
                Type type = Type.GetType("StructPattern.Magician"+element.Name);
                ConstructorInfo ctor = type.GetConstructor(new Type[]{typeof(string)});
                team[i] = (Magician)ctor?.Invoke(new object[]{element.GetAttribute("name")});
                // 设定元素
                type = Type.GetType(element.InnerText);
                if(type==null) 
                {
                    Console.WriteLine("元素不存在");
                    string name = "StructPattern."+"Wind";
                    type = Type.GetType(name);
                }
                Console.WriteLine("元素：{0}",type.Name);
                ctor = type.GetConstructor(new Type[0]);
                team[i].MagicElement = (IMagicElement)ctor?.Invoke(null);
            }

            // 施法
            foreach(Magician magician in team) magician.UltimateSkill();
            // 普通法师 释放元素爆发： 强袭飓风        伤害倍率：1
            // 传奇法师 释放元素爆发： 混沌陨石        伤害倍率：3
            // 大师法师 释放元素爆发： 撕裂大地        伤害倍率：2
            // 普通法师 释放元素爆发： 强袭飓风        伤害倍率：1
        }


        /// <summary>
        /// 设计模式：结构型模式-组合模式
        /// </summary>
        public void testComposition()
        {
            Console.WriteLine("组合模式");
            Folder a = new Folder("小说");
            a.add(new File("目录"));
            a.add(new Folder("第一卷"));
            a.add(new Folder("第二卷"));
            a.add(new Folder("第三卷"));
            a.GetChild(1).add(new File("2-1"));
            a.GetChild(1).add(new File("2-2"));
            a.ShowInfo();
        }


        /// <summary>
        /// 设计模式：结构型模式-装饰模式
        /// </summary>
        public void testExpand()
        {
            Console.WriteLine("装饰模式");
            IMagicElement wind,buffWind,debuffWind;     // 透明模式，可将装饰前后的对象统一处理
            wind = new Wind();
            Console.WriteLine("强化前的风元素：");
            wind.ElementBoost();
            Console.WriteLine("强化后的风元素：");
            buffWind = new BuffElement(wind);
            buffWind.ElementBoost();
            debuffWind = new DebuffElement(wind);
            debuffWind.ElementBoost();
        }


        public void testMainSystem()
        {
            Console.WriteLine("外观模式（主系统模式）");
            MainSystem mainSystem = MainSystem.GetInstance();
            mainSystem.Bounce();
            mainSystem.DoubleAttack();
            mainSystem.QuickAttack();
        }
    }
}