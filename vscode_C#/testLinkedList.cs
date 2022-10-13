using System;

namespace vsTest
{
    class Node
    {
        public int val;
        public Node next = null;
        public Node(int v)
        {
            val = v;
        }
    }

    public class MyLinkedList {
        int count;      // 节点总数
        Node head;      // 头结点，不存储数据

        public MyLinkedList() {
            count = 0;
            head = new Node(0);
        }

        public void printSelf()
        {
            Node cur = head.next;
            while(cur!=null)
            {
                Console.Write("{0} --> ",cur.val);
                cur = cur.next;
            }
            Console.WriteLine("\tcount = {0}",count);
        }
        
        public int Get(int index) {
            if(index<0 || index>=count) return -1;
            Node ret = head;
            while(index>=0)
            {
                ret = ret.next;
                index--;
            }
            return ret.val;
        }
        
        public void AddAtHead(int val) {
            Node cur = head.next;
            head.next = new Node(val);
            head.next.next = cur;
            count++;
        }
        
        public void AddAtTail(int val) {
            Node cur = head;
            while(cur.next!=null) cur = cur.next;
            cur.next = new Node(val);
            count++;
        }
        
        public void AddAtIndex(int index, int val) {
            if(index<0) return;
            else if(index>=count)
            {
                AddAtTail(val);
                return;
            }

            Node pre = head;
            Node cur = head.next;       // 插入位置当前的节点

            while(index>0)
            {
                pre = cur;
                cur = cur.next;
                index--;
            }
            pre.next = new Node(val);
            pre.next.next = cur;
            count++;
        }
        
        public void DeleteAtIndex(int index) 
        {
            if(index<0 || index>=count) return;

            Node pre = head;
            Node cur = head.next;

            while(index>0)
            {
                pre = cur;
                cur = cur.next;
                index--;
            }

            pre.next = cur.next;
            count--;
        }
    }

}