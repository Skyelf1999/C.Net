using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StructPattern
{
    /// <summary>
    /// 抽象装饰类：超级元素（强化元素爆发效果）
    /// </summary>
    public abstract class SuperMagicElement : IMagicElement
    {
        // 被强化的元素
        IMagicElement element;
        // 强化效果名称
        public abstract string EffectName {get;}
        /// <summary>
        /// 强化效果
        /// </summary>
        protected abstract void SuperEffect();

        public void ElementBoost(int n=1)
        {
            element.ElementBoost(n);
            SuperEffect();
        }
        public string GetElementName()
        {
            return element.GetElementName();
        }


        public SuperMagicElement(IMagicElement element)
        {
            this.element = element;
        }
    }


    /// <summary>
    /// Debuff效果强化元素
    /// </summary>
    public class DebuffElement : SuperMagicElement
    {
        public DebuffElement(IMagicElement element) : base(element)
        {
        }

        public override string EffectName => "使元素爆发增加Debuff效果";

        protected override void SuperEffect()
        {
            Console.WriteLine("对 敌人 施加：Debuff");
        }
    }


    /// <summary>
    /// Buff效果强化元素
    /// </summary>
    public class BuffElement : SuperMagicElement
    {
        public BuffElement(IMagicElement element) : base(element)
        {
        }

        public override string EffectName => "使元素爆发增加Buff效果";

        protected override void SuperEffect()
        {
            Console.WriteLine("对 友军 施加：Buff");
        }
    }
}