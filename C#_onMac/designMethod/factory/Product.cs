using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignMethod
{
    /// <summary>
    /// 此文件保存产品类的定义
    /// </summary>



    public interface IProduct
    {
        public string Name {get;}
        public void ShowInfo();
    }

    /// <summary>
    /// 产品类抽象
    /// </summary>
    public abstract class Product : IProduct
    {
        public abstract string Name{get;}       // 名称
        public abstract string Company {get;}   // 所属公司
        public virtual float DefaultPrice {get {return 100;}}
        public float price;                     // 价格
        public float? Price
        {
            get {return price;}
            set { price = (value==null || value<0.1f) ? DefaultPrice : (float)value; }
        }
        protected int quality;                  // 品质
        public int Quality{get{return (int)price/1000;}}


        /// <summary>
        /// 展示产品信息
        /// </summary>
        public virtual void ShowInfo()
        {
            Console.WriteLine("生产产品：{0} - {1} {2}元",this.Name,Company,price);
        }
    }



    //----------------------------- 电脑 -----------------------------//

    /// <summary>
    /// 产品：电脑
    /// </summary>
    public class Computer : Product,IProduct
    {
        public override string Name {get {return "Computer";}}
        public override string Company {get {return "测试";}}

        public override float DefaultPrice {get {return 4000;}}

        public Computer(float price)
        {
            Price = price;
            ShowInfo();
        }
    }


    public class Mac : Computer
    {
        public override string Name {get {return "Mac";}}

        public override string Company {get {return "Apple";}}

        public override float DefaultPrice {get {return 8000;}}

        public Mac(float price) : base(price)
        {

        }
    }

    public class ThinkPad : Computer
    {
        public override string Name {get {return "TinkPad";}}

        public override string Company {get {return "联想";}}

        public override float DefaultPrice {get {return 4000;}}

        public ThinkPad(float price) : base(price)
        {
        }
    }



    //----------------------------- 手机 -----------------------------//

    /// <summary>
    /// 产品：手机
    /// </summary>
    public class Phone : Product
    {
        public override string Name {get {return "Phone";}}
        public override string Company {get {return "测试";}}
        public override float DefaultPrice {get {return 2000;}}

        public Phone(float price)
        {
            Price = price;
            ShowInfo();
        }
    }


    public class IPhone : Phone
    {
        public override string Name {get {return "iPhone";}}
        public override string Company {get {return "Apple";}}
        public override float DefaultPrice {get {return 5000;}}

        public IPhone(float price) : base(price)
        {
            
        }
    }
}