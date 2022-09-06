    public IList<IList<int>> LevelOrder(TreeNode root) 
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        IList<IList<int>> listoflist=new List<IList<int>>();
        queue.Enqueue(root);
        int LevelCount=0;

        while(queue.Count!=0)
        {
            LevelCount=queue.Count;
            IList<int> list=new List<int>();
            TreeNode node=(TreeNode)queue.Dequeue();
            if(node==null) break;

            for(int i=0;i<LevelCount;i++)
            {
                list.Add(node.val);

                if(node.left!=null)
                    queue.Enqueue(node.left);
                if(node.right!=null)
                    queue.Enqueue(node.right);
                
                if(i!=LevelCount-1)
                    node=(TreeNode)queue.Dequeue(); 
            }
            listoflist.Add(list);
        }
        return listoflist;
    }
