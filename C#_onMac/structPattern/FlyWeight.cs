using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StructPattern
{
    /// <summary>
    /// 抽象享元类：棋子
    /// </summary>
    public abstract class Chess
    {
        // 内部状态：棋子颜色
        public abstract string Color {get;}

        // 外部状态：棋子位置
        protected int x;
        protected int y;
        public void SetPosition(int x,int y)
        {
            this.x = x;
            this.y = y;
            ShowInfo();
        }
        
        public Chess()
        {
            x = 0;
            y = 0;
        }

        public void ShowInfo()
        {
            Console.WriteLine("{0} 放置于 ({1},{2})",Color,x,y);
        }
    }


    public class WhiteChess : Chess
    {
        public WhiteChess()
        {
        }
        public override string Color => "白棋";
    }


    public class BlackChess : Chess
    {
        public BlackChess()
        {
        }
        public override string Color => "黑棋";
    }


    /// <summary>
    /// 棋子工厂
    /// </summary>
    public class ChessBox
    {
        static class Holder{
            public static readonly ChessBox instance = new ChessBox();
        }
        public static ChessBox GetInstance() => Holder.instance;
        Dictionary<int,Chess> box;      // 棋盒

        public ChessBox()
        {
            box = new Dictionary<int, Chess>();
        }

        /// <summary>
        /// 工厂方法：创建棋子
        /// </summary>
        /// <returns></returns>
        Chess CreateChess(int color)
        {
            Chess ret;
            if(color==0) ret = new WhiteChess();
            else ret = new BlackChess();
            return ret;
        }

        /// <summary>
        /// 设定享元对象外部状态：放置棋子
        /// </summary>
        public Chess PutChessAt(int color,int x,int y)
        {
            // 获取享元对象
            box.TryGetValue(color,out Chess ret);
            if(ret==null)
            {
                ret = CreateChess(color);
                box.Add(color,ret);
            }
            // 放置棋子
            ret.SetPosition(x,y);
            return ret;
        }
    }

}