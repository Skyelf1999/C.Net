using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignMethod

{
    public class SingleInstance
    {
        private static class Holder
        {
            public static readonly SingleInstance instance = new SingleInstance();
        }
        public int count = 0;

        private SingleInstance()
        {
            Console.WriteLine("单例创建");
        }

        /// <summary>
        /// 实例获取方法
        /// </summary>
        /// <returns></returns>
        public static SingleInstance GetInstance()
        {
            // if(instance==null) instance = new SingleInstance();
            Holder.instance.count++;
            return Holder.instance;
        }
    }
}