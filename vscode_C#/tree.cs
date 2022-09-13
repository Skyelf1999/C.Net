using System;
using System.Collections;


namespace vsTest
{
    // 树叶节点
    class TreeNode
    {
        public int? data;                // 数据
        public TreeNode? left  = null;      // 左子
        public TreeNode? right = null;      // 右子
        public bool flag = true;

        public TreeNode(int? data=null)
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
        private int deep;                          // 深度
        private int count = 1;                     // 节点总数
        private int leaf;                          // 叶子总数


        // 队列建树
        public void createByIntArray(int[] arr)
        {
            // 保存数据
            dataList = new List<int>(arr);

            // 借助队列进行创建
            Queue<TreeNode> help = new Queue<TreeNode>();
            this.root = new TreeNode(arr[0]);
            TreeNode? cur = root;
            TreeNode? node = null;
            for(int i=1;i<arr.Length;i++)
            {
                // 若这次即将加入新节点的是下一个操作节点的子，则更换当前操作节点
                if(i>1 && i%2==1 && help.Count>0) 
                {
                    Console.WriteLine("上一操作节点添加完毕，节点：{0}；左子：{1}；右子：{2}",
                        cur,cur.left,cur.right);
                    cur = help.Dequeue();
                    Console.WriteLine("更换操作节点，当前节点为：{0}",cur);
                }
                // 根据数据创建新节点
                if(arr[i]!=-999) node = new TreeNode(arr[i]);
                else node = null;
                // 若新节点不为空，则添加为当前操作节点的子节点
                if(node!=null)
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
                if(node!=null) help.Enqueue(node);
                Console.WriteLine();
            }
            Console.WriteLine("上一操作节点添加完毕，节点：{0}；左子：{1}；右子：{2}",
                        cur,cur.left,cur.right);

            deep = (int)Math.Floor(Math.Log(dataList.Count,2)) + 1;
            for(int i=Convert.ToInt32(Math.Pow(2,deep-1))-1;i<dataList.Count;i++)
                if(dataList[i]!=-999) leaf++;
            Console.WriteLine("创建完毕！");
            Console.WriteLine("有效节点数：{0}；深度：{1}；叶子数：{2}\n",count,deep,leaf);
            this.Deep = deep;
            this.Count = count;
            this.Leaf = leaf;
        }


        // 根据DLR和LDR结果创建树
        public void createByDLRandLDR(int[] preorder,int[] inorder)
        {
            if(preorder==null || inorder==null) return;

            Stack<TreeNode> st = new Stack<TreeNode>();
            int index = 0;      // 指向当前节点的最后左后代
            this.root = new TreeNode(preorder[0]);
            st.Push(this.root);

            for(int i=1;i<preorder.Length;i++)
            {
                TreeNode cur = st.Peek();
                if(cur.data!=inorder[index])
                {
                    cur.left = new TreeNode(preorder[i]);
                    st.Push(cur.left);
                }
                else
                {
                    // 此时中序index指向的节点正是栈顶节点
                    while(st.Count>0 && st.Peek().data==inorder[index])
                    {
                        cur = st.Pop();
                        index++;
                    }
                    cur.right = new TreeNode(preorder[i]);
                    st.Push(cur.right);
                }
            }


        }


        // 根据LDR和LRD结果创建树
        public void createByLDRandLRD(int[] inorder,int[] postorder)
        {

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


        // 广度优先
        public void BFS(TreeNode? cur,bool choice)
        {
            Console.WriteLine("进行BFS，起点：{0}",cur);
            Queue<TreeNode> que = new Queue<TreeNode>();
            if(!choice)
            {
                // 不分组
                while(cur!=null)
                {
                    if(cur!=null) Console.WriteLine(cur);
                    if(cur.left!=null) que.Enqueue(cur.left);
                    if(cur.right!=null) que.Enqueue(cur.right);
                    if(que.Count==0) break;
                    cur = que.Dequeue();
                }
            }
            else
            {
                // 分组
                // List<List<TreeNode>> ret = new List<List<TreeNode>>();
                List<TreeNode> floor = new List<TreeNode>();
                que.Enqueue(cur);
                while(que.Count!=0)
                {
                    while(que.Count!=0)
                    {
                        Console.WriteLine(que.Peek());
                        floor.Add(que.Dequeue());
                    }
                    for(int i=0;i<floor.Count;i++)
                    {
                        if(floor[i].left!=null) que.Enqueue(floor[i].left);
                        if(floor[i].right!=null) que.Enqueue(floor[i].right);
                    }
                    floor.Clear();
                    Console.WriteLine();
                }
            }
        }


        public int[] toArrayInt(TreeNode cur)
        {
            List<int> list = new List<int>();
            Queue<TreeNode> que = new Queue<TreeNode>();
            while(cur!=null)
            {
                if(cur!=null) list.Add((int)cur.data);
                if(cur.left!=null) que.Enqueue(cur.left);
                if(cur.right!=null) que.Enqueue(cur.right);
                if(que.Count==0) break;
                cur = que.Dequeue();
            }
            return (int[])list.ToArray();
        }



    }
}