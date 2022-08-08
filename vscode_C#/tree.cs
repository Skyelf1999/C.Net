using System;
using System.Collections;


namespace vsTest
{
    // 树叶节点
    class TreeNode
    {
        public Object? data;                // 数据
        public TreeNode? left  = null;      // 左子
        public TreeNode? right = null;      // 右子
        public bool flag = true;

        public TreeNode(Object? data=null)
        {
            if(Convert.ToInt32(data)!=-999) this.data = data;
            else this.data = null;
        }

        public bool isChild(TreeNode node)
        {
            if(left==node || right==node) return true;
            else return false;
        }

        public override string ToString()
        {
            return "data = " + data;
        }
    }


    // 树结构管理类
    class Tree
    {
        public TreeNode? root = null;              // 根节点
        // 树数据列表
        /* 
            数组的序号为0~Length-1时
                左子：i*2+1；右子：i*2+2
            数组的序号为1~Length时
                左子：i*2；右子：i*2+1
        */
        List<int>? dataList = null;
        private int deep;                   // 深度
        private int count = 1;              // 节点总数
        private int leaf;                   // 叶子总数


        // 根据数组数据创建二叉树
        public void createByIntArray(int[] arr)
        {
            // 保存数据
            dataList = new List<int>(arr);

            // 借助队列进行创建
            Queue<TreeNode> help = new Queue<TreeNode>();
            root = new TreeNode(arr[0]);
            TreeNode? cur = root;
            TreeNode? node = null;
            for(int i=1;i<arr.Length;i++)
            {
                // 若这次即将加入新节点的是下一个操作节点的子，则更换当前操作节点
                if(i>1 && i%2==1) 
                {
                    Console.WriteLine("上一操作节点添加完毕，节点：{0}；左子：{1}；右子：{2}",
                        cur,cur.left,cur.right);
                    cur = help.Dequeue();
                    Console.WriteLine("更换操作节点，当前节点为：{0}",cur);
                }
                // 根据数据创建新节点
                node = new TreeNode(arr[i]);
                // 若新节点不为空，则添加为当前操作节点的子节点
                if(node.data!=null)
                {
                    count++;
                    if(i%2==1)
                    {
                        cur.left = node;
                        Console.WriteLine("添加左子：{0}",node);
                    }
                    else
                    {
                        cur.right = node;
                        Console.WriteLine("添加右子：{0}",node);
                    }
                }
                else Console.WriteLine("该节点为空，不添加");
                // 进队，准备作为之后的操作节点
                help.Enqueue(node);
                Console.WriteLine();
            }
            Console.WriteLine("上一操作节点添加完毕，节点：{0}；左子：{1}；右子：{2}",
                        cur,cur.left,cur.right);

            deep = (int)Math.Floor(Math.Log(dataList.Count,2)) + 1;
            for(int i=Convert.ToInt32(Math.Pow(2,deep-1))-1;i<dataList.Count;i++)
                if(dataList[i]!=-999) leaf++;
            Console.WriteLine("创建完毕！");
            Console.WriteLine("有效节点数：{0}；深度：{1}；叶子数：{2}\n",count,deep,leaf);
        }
        

        public int Deep{
            get { return deep; }
            set { deep = value; }
        }
        public int Count{
            get { return count; }
            set { count = value; }
        }
        public int Leaf{
            get { return leaf; }
            set { leaf = value; }
        }

    }


    // 树访问类
    class TreeVisit
    {
        // 前序遍历
        public void dlr(TreeNode? cur,bool choice = true)
        {
            if(cur==null) return;
            if(choice)
            {
                Console.WriteLine(cur);
                dlr(cur.left);
                dlr(cur.right);
            }
            else
            {
                Console.WriteLine("进行非递归DLR");
                Stack<TreeNode> stack = new Stack<TreeNode>();
                while(stack.Count>0 || cur!=null)
                {       
                    Console.WriteLine(cur);
                    if(cur.left!=null)
                    {
                        if(cur.right!=null) stack.Push(cur.right);
                        cur = cur.left;
                    }
                    else if(cur.right!=null) cur = cur.right;
                    else 
                    {
                        if(stack.Count==0) cur = null;
                        else cur = stack.Pop();
                    }
                }
                Console.WriteLine();
            }
        }

        // 中序遍历
        public void ldr(TreeNode? cur,bool choice = true)
        {
            if(cur==null) return;
            if(choice)
            {
                dlr(cur.left);
                Console.WriteLine(cur);
                dlr(cur.right);
            }
            else
            {
                Console.WriteLine("进行非递归LDR，起点：{0}",cur);
                Stack<TreeNode> stack = new Stack<TreeNode>();
                while(stack.Count>0 || cur!=null)
                {
                    // 全部左后代进栈
                    while(cur!=null)
                    {
                        stack.Push(cur);
                        cur = cur.left;
                    }
                    if(stack.Count>0)
                    {
                        cur = stack.Pop();
                        Console.WriteLine(cur);
                        cur = cur.right;
                    }
                }
                Console.WriteLine();
            }
        }

        // 后序遍历
        public void lrd(TreeNode? cur,bool choice = true)
        {
            if(cur==null) return;
            if(choice)
            {
                dlr(cur.left);
                dlr(cur.right);
                Console.WriteLine(cur);
            }
            else
            {
                Console.WriteLine("进行非递归LRD，起点：{0}",cur);
                Stack<TreeNode> stack = new Stack<TreeNode>();
                while(stack.Count>0 || cur!=null)
                {
                    // 全部左后代进栈
                    while(cur!=null)
                    {
                        stack.Push(cur);
                        cur = cur.left;
                    }
                    if(stack.Count>0)
                    {
                        cur = stack.Peek();
                        // 初次
                        if(cur.flag && cur.right!=null) 
                        {
                            cur.flag = false;
                            cur = cur.right;
                        }
                        else    // 再次
                        {
                            cur = stack.Pop();
                            Console.WriteLine(cur);
                            cur = null;
                        }
                    }
                }
                Console.WriteLine();
            }
        }

    }
}