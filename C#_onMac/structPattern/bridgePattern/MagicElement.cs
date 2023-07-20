using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StructPattern
{
    /// <summary>
    /// 魔法元素接口
    /// 各元素都有各自的元素爆发效果
    /// </summary>
    public interface IMagicElement
    {
        string GetElementName();        // 获取元素名称
        void ElementBoost(int n);       // 元素爆发
    }


    // 具体魔法元素：火、风、土……
    public class Fire : IMagicElement
    {
        public void ElementBoost(int n)
        {
            Console.WriteLine("\t混沌陨石\t伤害倍率：{0}",n);
        }

        public string GetElementName() => "火";
    }

    public class Wind : IMagicElement
    {
        public void ElementBoost(int n)
        {
            Console.WriteLine("\t强袭飓风\t伤害倍率：{0}",n);
        }

        public string GetElementName() => "风";
    }

    public class Earth : IMagicElement
    {
        public void ElementBoost(int n)
        {
            Console.WriteLine("\t撕裂大地\t伤害倍率：{0}",n);
        }

        public string GetElementName() => "土";
    }
}