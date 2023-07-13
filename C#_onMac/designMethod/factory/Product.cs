using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignMethod
{
    /// <summary>
    /// 此文件保存产品类的定义
    /// </summary>


    /// <summary>
    /// 产品类抽象
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        /// <value>string</value>
        public abstract string Name{get;}


        /// <summary>
        /// 展示产品信息（）可重写
        /// </summary>
        public virtual void ShowInfo()
        {
            Console.WriteLine("被生产的产品名称：{0}",this.Name);
        }
    }


    /// <summary>
    /// 产品：电脑
    /// </summary>
    public class Computer : Product
    {
        public override string Name {get {return "Computer";}}

        public Computer()
        {
            ShowInfo();
        }
    }


    /// <summary>
    /// 产品：手机
    /// </summary>
    public class Phone : Product
    {
        public override string Name {get {return "Phone";}}

        public Phone()
        {
            ShowInfo();
        }
    }
}