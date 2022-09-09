using System;
using System.Collections;
using System.Collections.Generic;


namespace vsTest
{
    // 用于测试一些自定义方法
    class Test
    {
        Utils utils = new Utils();
        enum Game  {
                DotA, MHR, SC
                };

        // 测试方法示例
        public void test_Example()
        {
            string func = "";
            utils.funcStart(func);



            utils.funcEnd(func);
        }


        public void test_Enum()
        {
            string func = "枚举";
            utils.funcStart(func);

            Game x = Game.DotA;
            Game y = Game.MHR;
            Game z = Game.SC;
            Console.WriteLine("{0}, {1}, {2}",x,y,z+1);

            utils.funcEnd(func);
        }


        public void test_Tuple()
        {
            string func = "元组";
            utils.funcStart(func);

            var tuple = Tuple.Create("dsh",23,true);
            Console.WriteLine("姓名：{0}，年龄：{1}，性别：{2}",tuple.Item1,tuple.Item2,tuple.Item3?"男":"女");

            utils.funcEnd(func);
        }


        public void test_List()
        {
            string func = "List";
            utils.funcStart(func);

            List<string> list = new List<string>();
            list.Add("你说");
            list.Add("什么");
            list.Add("呢");
            string info = string.Join(",", (string[])list.ToArray());
            Console.WriteLine(info);
            Console.WriteLine("最后一个元素：{0}",list[list.Count-1]);

            utils.funcEnd(func);
        }


        public void test_ArrayList()
        {
            string func = "ArrayList";
            utils.funcStart(func);

            ArrayList al = new ArrayList();
            al.Add("你好");
            al.Add(100);
            // al.Add(true);
            al.Add(new Data(22));
            Console.WriteLine(al);

            utils.funcEnd(func);
        }


        public void test_LinkedList()
        {
            string func = "链表";
            utils.funcStart(func);

            LinkedList<string> ll = new LinkedList<string>();
            ll.AddLast("dsh");
            ll.AddLast("起名难");
            ll.AddFirst("开头");
            LinkedListNode<string> head = ll.First;
            head.Value = "链表开头";
            ll.AddAfter(head,new LinkedListNode<string>("内容为"));
            LinkedListNode<string> cur = head;
            while(cur!=null)
            {
                Console.WriteLine(cur.Value);
                cur = cur.Next;
            }

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


        public void test_Dic()
        {
            string func = "Hashtable";
            utils.funcStart(func);

            

            utils.funcEnd(func);
        }


        public void test_Stack()
        {
            string func = "Stack";
            utils.funcStart(func);

            Console.WriteLine("创建string类型的栈");
            Stack<string> st = new Stack<string>();
            Console.WriteLine("空栈长度：{0}",st.Count);
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

        public void test_Tree()
        {
            string func = "树";
            utils.funcStart(func);

            // 创建
            int nul = -999;
            int[] arr = {3,7,1,nul,2,4,nul,nul,nul,nul,nul,5,6};
            Tree tree = new Tree();
            tree.createByIntArray(arr);
            // 访问
            TreeVisit treeVisit = new TreeVisit();
            treeVisit.dlr(tree.root,false);
            // treeVisit.ldr(tree.root,false);
            // treeVisit.lrd(tree.root,false);
            // treeVisit.BFS(tree.root,true);
            int[] res = treeVisit.toArrayInt(tree.root);
            utils.printArrayInt(res);

            utils.funcEnd(func);
        }


        // 测试方法示例
        public void test_Class()
        {
            string func = "面向对象";
            utils.funcStart(func);

            Player x = new Player("dsh",23,"起名难的神话");
            string[] games = {"DotA2","MHR","HOS"};
            x.games = new List<string>(games);
            Console.WriteLine(x);

            utils.funcEnd(func);
        }
    }

    
}