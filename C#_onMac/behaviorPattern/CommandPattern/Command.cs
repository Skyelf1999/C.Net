using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BehaviorPattern
{
    /// <summary>
    /// 抽象命令：请假
    /// </summary>
    public abstract class AbstractHolidayCommand
    {
        protected ChainElement executor;        // 执行者（此处设定为职责链实例中的链元素类）
        protected int dayNum;

        public AbstractHolidayCommand(ChainElement element,int day=1)
        {
            executor = element;
            dayNum = day;
        }

        /// <summary>
        /// 执行者执行命令
        /// </summary>
        public virtual void execute()
        {
            executor.HandleHolidayRequest(dayNum);
        }
    }


    /// <summary>
    /// 命令：组长审批请假
    /// </summary>
    public class LeaderHolidayCommand : AbstractHolidayCommand
    {
        public LeaderHolidayCommand(int num) : base(new TeamLeader(),num)
        {

        }
    }


    /// <summary>
    /// 命令：行政审批请假
    /// </summary>
    public class AdminHolidyCommand : AbstractHolidayCommand
    {
        public AdminHolidyCommand(int num) : base(new Administration(), num)
        {
        }

    }


    /// <summary>
    /// 命令：经理审批请假
    /// </summary>
    public class ManagerHolidyCommand : AbstractHolidayCommand
    {
        public ManagerHolidyCommand(int num) : base(new Manager(), num)
        {
        }

    }
}