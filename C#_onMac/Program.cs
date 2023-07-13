using System;
using System.Collections;
using System.Collections.Generic;
using DesignMethod;
using XmlTest;

namespace OnMac
{
    class Program
    {
        static void Main(string[] args)
        {
            // testFactory();
            testXml();
        }


        /// <summary>
        /// 设计模式：工厂
        /// </summary>
        public static void testFactory()
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
    }

}
