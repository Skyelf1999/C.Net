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

        public TreeNode(Object? data=null)
        {
            if(Convert.ToInt32(data)!=-999) this.data = data;
            else this.data = null;
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
                if(i>1 && i%2==1) cur = help.Dequeue();
                // 根据数据创建新节点
                node = new TreeNode(arr[i]);
                // 若新节点不为空，则添加为当前操作节点的子节点
                if(node.data!=null)
                {
                    count++;
                    if(i%2==1) cur.left = node;
                    else cur.right = node;
                }
                // 进队，准备作为之后的操作节点
                help.Enqueue(new TreeNode(arr[i]));
            }
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

        // 前序遍历
        public void dlr()
        {

        }

        // 中序遍历
        public void ldr()
        {

        }

        // 后序遍历
        public void lrd()
        {

        }

    }
}