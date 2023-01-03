using System.Runtime.ConstrainedExecution;
using System.Collections.Specialized;
using System.Text;
using System.Buffers;
using System.Collections;
using System.ComponentModel;
using System;


namespace vsTest
{
    class Utils
    {
        public void test()
        {
            Console.WriteLine("成功");
        }

        public void introduce(string func,bool choice=true)
        {
            string info = "---------------- " + func + " ----------------";
            if(choice) info = "\n\n" + info + "\n";
            else info = "\n" + info + "\n\n";
            Console.WriteLine(info);
        }

        public void funcStart(string func)
        {
            Console.WriteLine("\n\n---------------- " + func + " ----------------\n");
        }
        public void funcEnd(string func)
        {
            Console.WriteLine("\n---------------- " + func + " ----------------\n\n");
        }

        public void printArrayInt(int[] arr)
        {
            for(int i=0;i<arr.Length;i++)
                Console.Write(arr[i].ToString()+"  ");
            Console.Write("\n");
        }

        public void printArrayString(string[] arr,bool choice=true)
        {
            for(int i=0;i<arr.Length;i++)
                if(choice)
                {
                    Console.WriteLine(arr[i]);
                    Console.Write("\n");
                }
                else Console.Write(arr[i]+"  ");
        }

        public void printArrayChar(char[] arr,bool choice=true)
        {
            for(int i=0;i<arr.Length;i++)
                if(choice) Console.WriteLine(arr[i]);
                else Console.Write(arr[i]+"  ");
        }

        public void printQueueInt(Queue<int> que)
        {
            while(que.Count>0)
                Console.Write(que.Dequeue()+"  ");
        }

        public void printDic(Dictionary<int,int> dic)
        {
            foreach(int k in dic.Keys)
                Console.WriteLine("{0}--{1}",k,dic[k]);
        }

        public void printDataInt(params Data<int>[] arr)
        {
            printDataIntArr(arr);
        }
        public void printDataIntArr(Data<int>[] arr)
        {
            foreach(Data<int> x in arr) Console.WriteLine(x);
        }


        // 判断完全平方数
        public bool isSqr(int n)
        {
            int i=1;
            while(n>0)
            {
                n -= i;
                i += 2;
            }
            if(n==0) return true;
            return false;
        }

        public void searchIntArr(int[] data,int target)
        {
            Array.Sort(data);
            int low=0,high=data.Length;
            while (low<=high)
            {
                if(data[(low+high)/2]==target)
                {
                    Console.WriteLine("目标下标：{0}",(low+high)/2);
                    return;
                }
                if(data[(low+high)/2]>target) high = (low+high)/2-1;
                else low = (low+high)/2 + 1;
            }
            Console.WriteLine("目标不存在");
        }
    }
}