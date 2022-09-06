public IList<IList<int>> LevelOrder(TreeNode root) 
{
    List<List<int>> ret = new List<List<int>>();
    List<int> floor = new List<int>();
    Queue<TreeNode> que = new Queue<TreeNode>();
    int count = 1;      // 记录下一层的节点数
    TreeNode cur;       // 当前操作节点

    if(root==null) return ret;
    que.Enqueue(root);
    while(count>0)
    {
        for(int i=count;i>0;i--)
        {
            cur = que.Dequeue();
            floor.Add(cur.val);
            if(cur.left!=null) que.Enqueue(cur.left);
            if(cur.right!=null) que.Enqueue(cur.right);
        }
        count = que.Count;
        ret.Add(floor);
        floor.Clear();
    }

    return ret;

}