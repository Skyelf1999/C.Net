using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StructPattern
{
    public class MainSystem
    {
        // 单例实现
        public static class Holder{
            public static readonly MainSystem instance = new MainSystem();
        }
        public static MainSystem GetInstance() => Holder.instance;

        // 子系统
        AttackSystem attackSystem;
        DefendSystem defendSystem;


        public MainSystem()
        {
            attackSystem = new AttackSystem();
            defendSystem = new DefendSystem();
        }

        void Start(string name) => Console.Write("{0}：",name);
        void End() => Console.WriteLine();

        /// <summary>
        /// 对外行为：每个对外行为会调用多个子系统方法
        /// </summary>
        public void DoubleAttack()
        {
            Start("二连击");
            attackSystem.NormalAttack();
            attackSystem.CriticalAttack();
            End();
        }
        public void Bounce()
        {
            Start("弹反");
            defendSystem.NormalDefend();
            attackSystem.CriticalAttack();
            End();
        }
        public void QuickAttack()
        {
            Start("快速一击");
            defendSystem.DodgeDefend();
            attackSystem.NormalAttack();
            End();
        }
    }


    public class AttackSystem
    {
        public void NormalAttack()
        {
            Console.Write(" 轻攻击");
        }

        public void CriticalAttack()
        {
            Console.Write(" 暴击");
        }
    }


    public class DefendSystem
    {
        public void NormalDefend()
        {
            Console.Write(" 防御");
        }

        public void DodgeDefend()
        {
            Console.Write(" 闪避");
        }
    }
}