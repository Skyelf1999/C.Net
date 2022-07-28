using System;
using System.Collections;


namespace vsTest
{
    // 用于测试一些自定义方法
    class Test
    {
        Utils utils = new Utils();

        // 测试方法示例
        public void test_Example()
        {
            string func = "";
            utils.funcStart(func);

            // ……

            utils.funcEnd(func);
        }

        public void test_Hashtable()
        {
            string func = "Hashtable";
            utils.funcStart(func);

            Hashtable ht = new Hashtable();
            ht.Add("name","dsh");
            ht.Add("age",22);
            ht.Add(2,"name");
            Console.WriteLine(ht[2]);

            utils.funcEnd(func);
        }

        public void test_Stack()
        {
            string func = "Stack";
            utils.funcStart(func);

            Console.WriteLine("创建string类型的栈");
            Stack<string> st = new Stack<string>();
            string[] datas = {"。", "MHRSB", "玩的是", "昨天晚上", "我"};
            Console.WriteLine("入栈元素：");
            foreach(string s in datas)
            {
                st.Push(s);
                Console.Write(s+"；");
            }
            Console.WriteLine("\n栈大小：{0}；栈顶元素：{1}；是否包含MHRSB：{2}",st.Count,st.Peek(),st.Contains("MHRSB"));
            utils.funcEnd(func);
        }

        public void test_Queue()
        {
            string func = "队列";
            utils.funcStart(func);

            Queue<string> queue = new Queue<string>();
            string[] datas = {"。", "MHRSB", "玩的是", "昨天晚上", "我"};
            Console.WriteLine("入队元素：");
            for(int i=datas.Length-1;i>-1;i--)
            {
                Console.Write(datas[i]+"；");
                queue.Enqueue(datas[i]);
            }
            Console.WriteLine();
            Console.WriteLine("队长：{1}；队首元素：{0}；是否包含MHRSB：{2}",queue.Peek(),queue.Count,queue.Contains("MHRSB"));
            Console.WriteLine("连续出队：{0}，{1}",queue.Dequeue(),queue.Dequeue());
            Console.WriteLine("当前队长：{0}",queue.Count);

            utils.funcEnd(func);
        }
    }

    
}