using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignMethod
{
    //----------------------------- 简单工厂类 -----------------------------//
    // 增加新产品，需要添加枚举值
    enum ProductIndex
    {
        Computer,
        Phone
    };

    /// <summary>
    /// 工厂类
    /// </summary>
    public class Factory
    {
        /// <summary>
        /// 生产方法：
        /// </summary>
        /// <returns>Product的子类对象</returns>
        public static Product GetProduct(int index)
        {
            Product ret = null;
            // 增加新产品，需要添加新的case判断
            switch(index)
            {
                case (int)ProductIndex.Computer:
                    ret = new Computer();
                    break;
                case (int)ProductIndex.Phone:
                    ret = new Phone();
                    break;
                default:
                    Console.WriteLine("产品不存在");
                    break;
            }

            return ret;
        }
    }


    /// <summary>
    /// 工厂类接口
    /// </summary>
    public interface IFactory
    {
        /// <summary>
        /// 生产方法（工厂类必须）
        /// </summary>
        /// <returns></returns>
        public Product GetProduct();
    }



    //----------------------------- 专精工厂类 -----------------------------//

    // 生产：Phone
    public class PhoneFactory : IFactory
    {
        public Product GetProduct()
        {
            return new Phone();
        }
    }
    // 生产：Computer
    public class ComputerFactory : IFactory
    {
        public Product GetProduct()
        {
            return new Computer();
        }
    }
}