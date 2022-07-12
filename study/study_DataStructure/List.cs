using System;
using System.Collections;

namespace study_DataStructure
{
    /*
        列表测试类
                测试内容包括：数组、动态数组、堆栈、队列
     */
    class List:test_program_struct
    {
        public List()
        {
            introduction = "\t1. 数组\n" +
               "\t2. 动态数组\n" +
               "\t3. 堆栈\n" +
               "\t4. 队列\n";
            Console.WriteLine(introduction + "请选择您需要测试的线性表：");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    test_array();
                    break;
                case 2:
                    test_array_list();
                    break;
                case 3:
                    test_stack();
                    break;
                case 4:
                    test_queue();
                    break;
            }
        }
        ~List() { }


        //------------------------------------ Array测试 ------------------------------------//
        public void test_array()
        {
            func_type("Array测试", true);

            Console.WriteLine("请输入数组长度：");
            int length = Convert.ToInt32(Console.ReadLine());
            string[] array_string = new string[length];
            Console.WriteLine("数组长度：" + array_string.Length);

            Console.WriteLine("\n对字符串数组进行循环赋值");
            for (int i = 0; i < length; i++) array_string[i] = Console.ReadLine();
            Console.WriteLine("\n循环输出数组：");
            foreach (string i in array_string) Console.Write(" " + i);
            Console.WriteLine("\n直接输出排序后的数组：");
            Array.Sort(array_string);
            foreach (string i in array_string) Console.Write(" " + i);
            Console.WriteLine("\n直接输出翻转后的数组：");
            Array.Reverse(array_string);
            foreach (string i in array_string) Console.Write(" " + i);

            func_type("Array测试", false);
        }


        //------------------------------------ ArrayList测试 ------------------------------------//
        public void test_array_list()
        {
            func_type("动态数组测试", true);

            ArrayList arrayList = create_arraylist("string");

            printf("\n请输入范围删除的开始序号和个数：");
            int index = Convert.ToInt32(Console.ReadLine());
            int count = Convert.ToInt32(Console.ReadLine());
            arrayList.RemoveRange(index, count);
            printf("\n删除后动态数组内容为：");
            foreach (string x in arrayList) printf(x);

            func_type("动态数组测试", false);
        }


        //------------------------------------ Stack测试 ------------------------------------//
        public void test_stack()
        {
            func_type("堆栈测试", true);

            Stack stack = new Stack();
            Console.WriteLine("请输入入栈元素个数：");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入入栈元素：");
            // 入栈
            for (int i = 0; i < n; i++)
            {
                stack.Push(Console.ReadLine());
                printf("当前元素已入栈");
            }
            printf("\n堆栈内容（顶-->底）：");
            foreach (string x in stack) printf(x);

            func_type("堆栈测试", false);
        }


        //------------------------------------ Queue测试 ------------------------------------//
        public void test_queue()
        {
            func_type("队列测试", true);

            Queue q = new Queue();
            string input;
            Console.WriteLine("请输入入队元素，以gg结束：");
            while (true)
            {
                input = Console.ReadLine();
                if (input.Equals("gg")) break;
                q.Enqueue(input);
            }
            Console.WriteLine("队列中元素个数：" + q.Count);
            Console.WriteLine("队列内容：");
            foreach(object i in q) Console.Write(i + "  ");

            func_type("队列测试", false);
        }

    }


}
