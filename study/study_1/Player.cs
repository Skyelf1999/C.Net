using System;
using System.Collections.Generic;
using System.Text;

namespace study_1
{
    class Player
    {
        // 类成员
        private string name = "未输入";
        private int age = 0;
        private string game_fav = "未输入";

        // 构造函数
        public Player()
        { }
        public Player(string x,int y)
        {
            name = x;
            age = y;
        }
        ~Player() { }

        // 类方法
        public string Name
        {
            get
            { return name; }
            set
            { name = value; }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public string Game_fav
        {
            get
            {
                return game_fav;
            }
            set
            {
                game_fav = value;
            }
        }

        public virtual void getInfo()
        {
            Console.WriteLine("name:{0}；age:{1}；game_fav:{2}", name, age, game_fav);
        }
    }


    class Player_DotA:Player
    {
        // 继承Player的成员：name, age, game_fav
        private int position;

        public Player_DotA()
        { }
        // 实现父类的带参构造
        public Player_DotA(string x, int y,int z): base(x,y)
        {
            position = z;
        }

        // 方法
        public int Position
        {
            get { return position; }
            set { position = value;  }
        }
        // 重写父类的同名方法
        public override void getInfo()
        {
            base.getInfo();     
            Console.WriteLine("position：{0}", position);
        }
        public void speak()
        {
            Console.WriteLine("我是" + Name);
        }

        public void speak_plus()
        {
            speak();
        }
    }
}
