using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StructPattern
{
    /// <summary>
    /// 抽象类：文件节点
    /// </summary>
    public abstract class FileNode
    {
        public string name;
        public abstract void add(FileNode node);
        public abstract void remove(int i);
        public abstract FileNode GetChild(int i);
        
        protected void NotSupport()
        {
            Console.WriteLine("不支持此功能！");
        }

        /// <summary>
        /// 显示节点信息(递归显示子节点)
        /// </summary>
        public abstract void ShowInfo(string tab="");

        public FileNode(string name)
        {
            this.name = name;
        }
    }


    /// <summary>
    /// 文件
    /// </summary>
    public class File : FileNode
    {
        public File(string name) : base(name)
        {
        }

        // 文件不支持增删子文件、获取子文件
        public override void add(FileNode node)
        {
            NotSupport();
        }
        public override void remove(int i)
        {
            NotSupport();
        }
        public override FileNode GetChild(int i)
        {
            NotSupport();
            return null;
        }
     
        public override void ShowInfo(string tab="")
        {
            Console.WriteLine("{0}文件 {1}",tab,name);
        }
    }


    /// <summary>
    /// 文件夹
    /// </summary>
    public class Folder : FileNode
    {
        protected List<FileNode> children;

        public Folder(string name) : base(name)
        {
            children = new List<FileNode>();
        }

        public override void add(FileNode node)
        {
            children.Add(node);
        }

        public override FileNode GetChild(int i)
        {
            if(i<children.Count) return children[i];
            else return null;
        }

        public override void remove(int i)
        {
            if(i<children.Count) children.RemoveAt(i);
        }

        public override void ShowInfo(string tab="")
        {
            Console.WriteLine("{0}<文件夹 {1}>",tab,name);
            for(int i=0;i<children.Count;i++)
                children[i].ShowInfo(tab+"\t");
        }
    }
}