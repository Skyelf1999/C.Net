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

            testPrograms.test_Class();
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

