using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StructPattern
{
    /// <summary>
    /// 假设的对外接口，声明了可供外部使用的方法
    /// </summary>
    public interface IAdapter
    {
        // 提供两个对外方法
        void Method1();
        void Method2();
    }

    /// <summary>
    /// 适配器：使对外方法能够调用目标功能方法
    /// </summary>
    public class Adapter : IAdapter
    {
        Adaptee adaptee;

        public Adapter()
        {
            adaptee = new Adaptee();
        }


        public void Method1()
        {
            Console.WriteLine("适配器对外接口：Method1");
            adaptee.Test1();
        }
        public void Method2()
        {
            Console.WriteLine("适配器对外接口：Method2");
            adaptee.TestA();
        }
    }


    public class Adaptee
    {
        public void Test1()
        {
            Console.WriteLine("实际调用的方法名：Test1");
        }

        public void Test2()
        {
            Console.WriteLine("实际调用的方法名：Test2");
        }

        public void TestA()
        {
            Console.WriteLine("实际调用的方法名：TestA");
        }
    }
}