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

        public void test(HashSet<int> set)
        {
            set.Add(1);
        }

        public void test_Params(params int[] arr)
        {
            string func = "传递参数Params";
            utils.funcStart(func);

            utils.printArrayInt(arr);

            utils.funcEnd(func);
        }

        // 测试输出参数
        public void test_Out(int a,out int x,out int y)
        {
            string func = "输出参数out";
            utils.funcStart(func);

            x = a/10;
            y = a%10;

            utils.funcEnd(func);
        }


        public void test_Action()
        {
            Action<string> act;
        }
        public void dshGet(string s)
        {
            Console.WriteLine("dsh get "+s);
        }
        public void htmGet(string s)
        {
            Console.WriteLine("htm get "+s);
        }
        


        public void test_Struct()
        {
            string func = "结构体";
            utils.funcStart(func);



            utils.funcEnd(func);
        }


        public void test_Char()
        {
            string func = "char";
            utils.funcStart(func);

            char x= '1';
            Console.WriteLine("比较字符'0'和'1'：{0}\n",x<'1');

            for(int i=0;i<4;i++)
            {
                x = (char)((int)x+1);
                Console.WriteLine(x);
            }

            char[] arr_char = {'h','e','l','l','o'};

            utils.funcEnd(func);
        }


        public void test_String()
        {
            string func = "字符串";
            utils.funcStart(func);

            string str = "forever";
            char[] arr = str.ToCharArray();
            List<char> list = new List<char>(arr);
            Console.WriteLine(list.Contains('f'));
            
            Console.WriteLine("\n测试分割功能：");
            string sentence = " something  for   nothing ";
            string[] res = sentence.Split(" ");
            utils.printArrayString(res);

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
            Tuple<string,int> x = new Tuple<string,int>("dsh",23);
            Console.WriteLine("{0}  {1}",x.Item1,x.Item2);

            utils.funcEnd(func);
        }


        public void test_Array()
        {
            string func = "数组";
            utils.funcStart(func);

            string[] arr = new string[]{"dsh","zdd","htm"};
            foreach(string s in arr) Console.WriteLine(s);

            Console.WriteLine("\n以下测试二维数组\n");
            List<int[]> list = new List<int[]>();
            list.Add(new int[]{1,4});
            list.Add(new int[]{7,10});
            list.Add(new int[]{3,5});
            list.Add(new int[]{2,8});
            int[][] arr_2 = list.ToArray();
            Console.WriteLine(arr_2[1][0]);

            Console.WriteLine("\n数组自定义排序\n");
            Array.Sort(arr_2,(a,b) => a[0]-b[0]);
            foreach(int[] x in arr_2) utils.printArrayInt(x);


            utils.funcEnd(func);
        }


        public void test_HashSet()
        {
            string func = "哈希集合";
            utils.funcStart(func);

            HashSet<int> hs = new HashSet<int>(new int[]{2,11,32,99});
            Console.WriteLine("存入1、4、10");
            hs.Add(1);
            hs.Add(4);
            hs.Add(10);
            hs.Add(1);
            Console.WriteLine("10是否在集合中：{0}",hs.Contains(10));
            int[] arr = hs.ToArray();
            utils.printArrayInt(arr);

            Console.WriteLine("\n数组转换成集合");
            ISet<int> set = new HashSet<int>(arr);
            Console.WriteLine("集合包含4？\t{0}",set.Contains(4));
            // Console.WriteLine(hs[0]);


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
            Console.WriteLine("\n在指定位置插入一个元素：");
            list.Insert(1,"tm");
            utils.printArrayString(list.ToArray(),false);
            Console.WriteLine("\n删除一个中间元素：");
            list.RemoveAt(1);
            utils.printArrayString(list.ToArray(),false);

            Console.WriteLine("\n下面测试int列表");
            List<int> list_int = new List<int>(new int[]{2,4,3,1});
            list_int.Sort();
            utils.printArrayInt(list_int.ToArray());
            // list_int.Sort(false);
            // utils.printArrayString(list_int.ToArray(),false);

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
            al.Add(new Data<int>(22));
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
            LinkedListNode<string>? head = ll.First;
            if(head!=null) head.Value = "链表开头";
            ll.AddAfter(head,new LinkedListNode<string>("内容为"));
            LinkedListNode<string>? cur = head;
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
            string func = "字典";
            utils.funcStart(func);

            Dictionary<string,int> dict = new Dictionary<string,int>();
            dict.Add("dsh",3400);
            dict.Add("wjl",2300);
            dict.Add("zdd",5000);
            Console.WriteLine("dsh的分数：{0}，zdd的分数：{1}",dict["dsh"],dict["zdd"]);
            Console.WriteLine("是否存在key：dsh\t{0}",dict.ContainsKey("dsh"));
            Console.WriteLine("是否存在value：2300\t{0}",dict.ContainsValue(2300));
            Console.WriteLine("循环输出字典");
            foreach(KeyValuePair<string,int> kv in dict)
                Console.WriteLine("{0}\t{1}",kv.Key,kv.Value);

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

            Console.WriteLine("\n测试引用类型特性");
            List<TreeNode> nodes = new List<TreeNode>();
            TreeNode root = new TreeNode(0);
            TreeNode cur;
            nodes.Add(root);
            for(int i=0;i<5;i++)
            {
                TreeNode node = new TreeNode(i+1);
                nodes.Add(node);
                cur = nodes[i];
                cur.left = node;
            }
            Console.WriteLine(root.left);
            ISet<TreeNode> set = new HashSet<TreeNode>();
            set.Add(new TreeNode(11));
            set.Add(root);
            set.Add(new TreeNode(11));
            set.Add(root);
            foreach(TreeNode temp in set) Console.WriteLine(temp);
            

            utils.funcEnd(func);
        }


        public void test_Try()
        {
            string func = "异常捕获";
            utils.funcStart(func);

            int[] arr = {1,2,3,4,5};
            int i=0;
            while(true)
            {
                try
                {
                    Console.WriteLine(arr[i++]);
                }
                catch
                {
                    Console.WriteLine("下标越界");
                    break;
                }
            }

            utils.funcEnd(func);
        }
    }

    
}