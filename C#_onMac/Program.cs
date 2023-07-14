using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using DesignMethod;
using XmlTest;

namespace OnMac
{
    class Program
    {
        static void Main(string[] args)
        {
            // testFactory();
            // testXml();
            testType();
        }


        /// <summary>
        /// 设计模式：简单工厂
        /// </summary>
        public static void testSimpleFactory()
        {
            Product product = Factory.GetProduct(1);
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
            var computer = Activator.CreateInstance(typeof(Computer),8000,"拯救者");
        }
    }

}
