using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace study_DataStructure
{
    class Run
    {
        /*  
         *  数据结构与算法测试用主函数，创建测试对象进行测试
         *          测试列表相关：List
         *          测试搜索算法：Search
         *          测试排序算法：Sort
         */         
        static void Main(string[] args)
        {
            int key = Convert.ToInt32(Console.ReadLine());
            string info = Console.ReadLine();
            DataStruct data = new DataStruct(key, info);
            Console.WriteLine(data);
            int x;
            x = 5 / 2;
            Console.WriteLine(x);
        }

    }


    // 类框架
    class test_program_struct
    {
        protected int choice;                   // 功能选择
        protected string introduction;  // 功能介绍

        // 函数功能
        public void func_type(String func, bool choice)
        {
            if (!choice) Console.WriteLine("\n//---------------- " + func + " ----------------//\n\n");
            else Console.WriteLine("\n\n//---------------- " + func + " ----------------//\n");
        }

        // 自定义print、input
        public void printf(string content) { Console.WriteLine(content); }
        public void print(string content) { Console.Write(content); }
        public string input_string() { return Console.ReadLine(); }
        public int input_int() { return Convert.ToInt32(Console.ReadLine()); }
        
        // 创建指定类型的动态数组
        public ArrayList create_arraylist(string type) 
        {
            // 输入：数据集创建
            ArrayList datas = new ArrayList();
            int key;
            int info_int;
            string info_string;
            if (type.Equals("key"))                 // 数据单元只含有key
            {
                printf("对动态数组进行循环赋值，key输入999结束……");
                while (true)
                {
                    key = Convert.ToInt32(Console.ReadLine());
                    if (key == 999) break;
                    DataStruct data = new DataStruct(key);
                    datas.Add(data);
                }
            }
            else if (type.Equals("string"))     // 数据单元为 key-string构造
            {
                printf("对动态数组进行循环赋值，字符输入gg结束……");
                while (true)
                {
                    key = Convert.ToInt32(Console.ReadLine());
                    info_string = Console.ReadLine();
                    if (info_string.Equals("gg")) break;
                    DataStruct data = new DataStruct(key, info_string);
                    datas.Add(data);
                }
            }
            else if (type.Equals("int"))        // 数据单元为 key-int构造
            {
                printf("对动态数组进行循环赋值，整型数输入999结束……");
                while (true)
                {
                    key = Convert.ToInt32(Console.ReadLine());
                    info_int = Convert.ToInt32(Console.ReadLine());
                    if (info_int == 999) break;
                    DataStruct data = new DataStruct(key, info_int);
                    datas.Add(data);
                }
            }
            
            printf("动态数组内容为：");
            foreach (string x in datas) printf(x);
            printf("长度为：" + datas.Count);
            return datas;
        }
    }


    // 数据单元类
    class DataStruct    
    {
        public int key = 0;
        public string type = "null";            // 存储单元的类型
        public int data_int = 0;
        public string data_string = "null";

        // 构造方法
        public DataStruct(int key)
        {
            this.key = key;
        }
        public DataStruct(int key, int data_int)
        {
            this.key = key;
            type = "int";
            this.data_int = data_int;
        }
        public DataStruct(int key, string data_string)
        {
            this.key = key;
            type = "string";
            this.data_string = data_string;
        }
        ~DataStruct() { }

        public override string ToString()
        {
            string info = "key：" + key + "    type：" + type + "    data：";
            if (type.Equals("int")) info = info + data_int;
            else if (type.Equals("string")) info = info + data_string;
            return info;
        }
    }
}
