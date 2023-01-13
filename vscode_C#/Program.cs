using System;
using System.Collections;

// 创建：dotnet new console
// 在控制台中输入 dotnet run 运行程序


namespace vsTest
{
    class Program
    {
        // 工具对象
        Utils utils = new Utils();
        // Leetcode题目
        Leetcode leetcode = new Leetcode();
        // 测试用对象
        static Test testPrograms = new Test();
        // 排序
        InsertSort insertSort = new InsertSort();
        SwapSort swapSort = new SwapSort();
        SelectSort selectSort = new SelectSort();

        static void Main(string[] args)
        {
            
            // testPrograms.test_Tuple();
            
            // int[][] arr = {new int[]{3,0,8,4}, new int[]{2,4,5,7}, new int[]{9,2,6,3}, new int[]{0,3,1,0}};

            testPrograms.test_HashSet();
            
            
            // selectSort.Direct(new Data<int>(2),
            //                     new Data<int>(5),
            //                     new Data<int>(1),
            //                     new Data<int>(0),
            //                     new Data<int>(4),
            //                     new Data<int>(1));
            
            // Console.WriteLine(2 | 1<<2);
        }
        
    }
    

    // 测试用数据类
    class Data<T>
    {
        int index;
        public T? data;
        ArrayList dataList = new ArrayList();

        private int p = 10;

        public int Index
        {
            get => index;
            set => index = value;
        }
        public int P{
            get { return p; }
            set { p = value; }
        }

        // 构造方法
        public Data(int index)
        {
            this.index = index;
            dataList.Add("index = "+index.ToString());
        }
        public Data(int index,T data)
        {
            this.index = index;
            this.data = data;
            dataList.Add("index = "+index.ToString());
            dataList.Add("data = "+data.ToString());
        }

        public override string ToString()
        {
            string info = string.Join("；",(string[])dataList.ToArray(typeof(string)));
            return info;
        }
    }



    // public class ExamRoom 
    // {
    //     int N;
    //     List<int> unavailable;
    //     Utils utils = new Utils();

    //     public ExamRoom(int n) {
    //         N = n;
    //         unavailable = new List<int>();
    //         unavailable.Add(9);
    //     }
        
    //     public int Seat() {
    //         foreach(int i in unavailable) Console.Write(i+" ");
    //         Console.Write("\n");
    //         if(unavailable.Count==0)
    //         {
    //             unavailable.Add(0);
    //             unavailable.Sort();
    //             return 0;
    //         }
    //         else if(unavailable.Count==1)
    //         {
    //             int ret = 0;
    //             if(unavailable[0]<5) ret = N-1;
    //             unavailable.Add(ret);
    //             unavailable.Sort();
    //             return ret;
    //         }

    //         int p = -1, q = unavailable[0];
    //         for(int i=0;i<unavailable.Count-1;i++)
    //         {
    //             int len = unavailable[i+1]-unavailable[i];
    //             if(len==1) continue;
    //             else if(len/2 > (q-p)/2)
    //             {
    //                 p = unavailable[i];
    //                 q = unavailable[i+1];
    //             }
    //         }
    //         unavailable.Add((q+p)/2);
    //         unavailable.Sort();
    //         Console.WriteLine("新的区间：[{0}, {1}]",p,q);
    //         return (q+p)/2;
    //     }
        
    //     public void Leave(int p) {
    //         unavailable.Remove(p);
    //     }
    // }

}

