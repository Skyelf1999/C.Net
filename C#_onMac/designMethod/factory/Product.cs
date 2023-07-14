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
        public abstract string Name{get;}       // 名称
        public float price;                     // 价格
        protected int quality;
        public int Quality{get{return (int)price/1000;}}


        /// <summary>
        /// 展示产品信息（）可重写
        /// </summary>
        public virtual void ShowInfo()
        {
            Console.WriteLine("被生产的产品：{0} {1}元",this.Name,price);
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
            price = 2000;
            ShowInfo();
        }
        public Computer(float price)
        {
            if(price>0) this.price = price;
            else price = 2000;
            // Console.WriteLine(tag);
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
            price = 1000;
            ShowInfo();
        }
        public Phone(float price)
        {
            if(price>0) this.price = price;
            else price = 1000;
            ShowInfo();
        }
    }
}