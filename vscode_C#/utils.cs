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
        }

        public void printArrayString(string[] arr,bool choice=true)
        {
            for(int i=0;i<arr.Length;i++)
                if(choice) Console.WriteLine(arr[i]);
                else Console.Write(arr[i]+"  ");
        }

        public void printArrayChar(char[] arr,bool choice=true)
        {
            for(int i=0;i<arr.Length;i++)
                if(choice) Console.WriteLine(arr[i]);
                else Console.Write(arr[i]+"  ");
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
    }
}