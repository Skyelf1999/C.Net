using System;
using System.Collections;


namespace vsTest
{
    // 树叶节点
    class TreeNode
    {
        public int? data;
        public TreeNode? left  = null;
        public TreeNode? right = null;

        public TreeNode(int? data=null)
        {
            this.data = data;
        }
    }

    // 树结构管理类
    class Tree
    {
        TreeNode root = new TreeNode();         // 根节点
        // 树数据列表
        List<int>? dataList = null;
        int deep;                               // 深度
        int Count;                              // 节点总数
        int leaf;                               // 叶子总数

        // 根据数组数据创建树
        public void createByArray(int[] arr)
        {
            /* 
                数组的序号为0~Length-1时
                    左子：i*2+1；右子：i*2+2
                数组的序号为1~Length时
                    左子：i*2；右子：i*2+1
            */
            // 保存数据
            dataList = new List<int>(arr);
            // 借助队列进行创建
            Queue<TreeNode> help = new Queue<TreeNode>();
            TreeNode cur = root;
            for(int i=0;i*2+1<arr.Length;i++)
            {
                // 当前节点
                if(arr[i]!=-999) cur.data = arr[i];
                else continue;
                // 左子
                if(arr[i*2+1]!=-999 ) cur.left = new TreeNode(arr[i*2+1]);
                else cur.left = null;
                // 右子
                if((i+1)*2<arr.Length) cur.right = new TreeNode(arr[(i+1)*2]);
                else cur.right = null;
            }
        }
    }
}