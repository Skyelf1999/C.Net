using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace DesignPattern
{
    /// <summary>
    /// 数据类
    /// </summary>
    [Serializable]
    public class DataClass
    {
        public dynamic data;

        public DataClass(dynamic x)
        {
            data = x;
        }

        public override string ToString()
        {
            return data!=null ? data.ToString() : "数据未初始化";
        }
    }


    // [Serializable]
    // public class Prototype : ICloneable
    // {
    //     public int id;
    //     string text;
    //     public string Text { get => text; set => text = value; }
    //     public DataClass data;

    //     public Prototype(int id,string text)
    //     {
    //         this.id = id;
    //         Text = text;
    //         data = new DataClass(null);
    //     }

    //     public object Clone()
    //     {
    //         // return this.MemberwiseClone();
            
    //         // 写入字节流
    //         BinaryFormatter formatter = new BinaryFormatter();
    //         MemoryStream stream = new MemoryStream();
    //         formatter.Serialize(stream,this);

    //         // 读取并存储为新对象
    //         byte[] bt = stream.ToArray();
    //         stream = new MemoryStream(bt);
    //         return formatter.Deserialize(stream) as Prototype;
    //     }

    //     public override string ToString()
    //     {
    //         return id.ToString() + "\t" + text + "\t" + data.ToString();
    //     }
    // }


}