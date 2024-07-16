using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BehaviorPattern
{
    /// <summary>
    /// 抽象职责链元素
    /// </summary>
    public abstract class ChainElement
    {
        protected ChainElement superior;      // 上级
        protected string name;                // 本级名称
        
        public ChainElement(string name) => this.name=name;

        /// <summary>
        /// 设置职责链中的上级对象
        /// </summary>
        /// <param name="next"></param>
        public void SetSuperior(ChainElement next) => superior = next;

        /// <summary>
        /// 处理请求：请假
        /// </summary>
        public abstract void HandleHolidayRequest(int num);
    }


    public class TeamLeader : ChainElement
    {
        public TeamLeader(string name=""): base("组长·"+name)
        {
            
        }

        public override void HandleHolidayRequest(int num)
        {
            if(num<=5) Console.WriteLine("\t{0}  已批准假期：{1} 天",name,num);
            else
            {
                Console.WriteLine("{0}  无审批权限，交由上级处理",name);
                superior?.HandleHolidayRequest(num);
            }
        }
    }


    public class Administration : ChainElement
    {
        public Administration(string name=""): base("行政·"+name)
        {
            
        }

        public override void HandleHolidayRequest(int num)
        {
            if(num<=10) Console.WriteLine("\t{0}  已批准假期：{1} 天",name,num);
            else
            {
                Console.WriteLine("{0}  无审批权限，交由上级处理",name);
                superior?.HandleHolidayRequest(num);
            }
        }
    }


    public class Manager : ChainElement
    {
        public Manager(string name=""): base("经理"+name)
        {
            
        }

        public override void HandleHolidayRequest(int num)
        {
            Console.WriteLine("\t{0}  已批准假期：{1} 天",name,num);
        }
    }
}