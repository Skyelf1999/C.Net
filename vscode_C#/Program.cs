﻿using System;
using System.Collections;

// 创建：dotnet new console
// 在控制台中输入 dotnet run 运行程序


namespace vsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 工具对象
            Utils utils = new Utils();
            // Leetcode题目
            Leetcode leetcode = new Leetcode();
            // 测试用对象
            Test testPrograms = new Test();

            testPrograms.test_List();
            // Console.WriteLine((int)Math.Pow(3,0.5));
            
            // int[][] arr = {new int[]{3,0,8,4}, new int[]{2,4,5,7}, new int[]{9,2,6,3}, new int[]{0,3,1,0}};
            // Console.WriteLine("\n\n需要 {0} 个完全平方数",leetcode.NumSquares(12));

        }

    }


    // 测试用数据类
    class Data
    {
        public int dataInt = -999;
        private int p = 10;

        public Data(int dataInt)
        {
            this.dataInt = dataInt;
        }

        public int P{
            get { return p; }
            set { p = value; }
        }

        public override string ToString()
        {
            ArrayList list = new ArrayList();
            list.Add("dataInt："+dataInt.ToString());
            string info = string.Join("；",(string[])list.ToArray(typeof(string)));
            return info;
        }
    }

}

