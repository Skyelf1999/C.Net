using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BehaviorPattern
{
    /// <summary>
    /// Button
    /// </summary>
    public class Button
    {
        ICommand onClick;
        ICommand onRotate;


        /// <summary>
        /// 设定按下事件
        /// </summary>
        /// <param name="command">按下回调</param>
        public virtual void SetOnClickCommand(ICommand command)
        {
            onClick = command;
        }
        public virtual void Click() => onClick?.Execute();

        /// <summary>
        /// 设定旋转事件
        /// </summary>
        /// <param name="command">旋转回调</param>
        public virtual void SetRotateCommand(ICommand command)
        {
            onRotate = command;
        }
        public virtual void Rotate() => onRotate?.Execute();
    }
}