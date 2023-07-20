using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StructPattern
{
    /// <summary>
    /// 抽象类：法师
    /// 法师分为普通、大师、传奇3个级别，每个法师都有自己的元素属性
    /// 法师可释放终极技能，根据自身级别和元素产生不同效果
    /// </summary>
    public abstract class Magician
    {
        // 法师名称
        public string name;
        // 法师级别
        public abstract int Level {get;}
        protected IMagicElement magicElement=null;
        // 设定该法师的元素
        public IMagicElement MagicElement {set {magicElement = value;} }

        public virtual void UltimateSkill()
        {
            if(magicElement==null)
            {
                Console.WriteLine("尚未获得元素");
                return;
            }
            Console.Write("释放元素爆发：");
            magicElement.ElementBoost(Level);
        }

        public Magician(string name)
        {
            this.name = name;
        }
    }


    public class MagicianNormal : Magician
    {
        public override int Level => 1;
        public override void UltimateSkill()
        {
            Console.Write("普通法师 ");
            base.UltimateSkill();
        }
        public MagicianNormal(string name) : base(name)
        {
        }
    }

    public class MagicianMaster : Magician
    {
        public override int Level => 2;
        public override void UltimateSkill()
        {
            Console.Write("大师法师 ");
            base.UltimateSkill();
        }
        public MagicianMaster(string name) : base(name)
        {
        }
    }

    public class MagicianLegend : Magician
    {
        public override int Level => 3;
        public override void UltimateSkill()
        {
            Console.Write("传奇法师 ");
            base.UltimateSkill();
        }
        public MagicianLegend(string name) : base(name)
        {
        }
    }
}