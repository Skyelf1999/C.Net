using System;
using System.Collections;

// 创建：dotnet new console
// 在控制台中输入 dotnet run 运行程序


namespace vsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 工具对象
            Utils utils = new Utils();
            // Leetcode题目
            Leetcode leetcode = new Leetcode();
            // 测试用对象
            Test testPrograms = new Test();
            // 插入排序
            InsertSort insertSort = new InsertSort();
            SwapSort swapSort = new SwapSort();
            SelectSort selectSort = new SelectSort();

            // testPrograms.test_Tuple();
            
            // int[][] arr = {new int[]{3,0,8,4}, new int[]{2,4,5,7}, new int[]{9,2,6,3}, new int[]{0,3,1,0}};

            leetcode.Test();
            
            // selectSort.Direct(new Data<int>(2),
            //                     new Data<int>(5),
            //                     new Data<int>(1),
            //                     new Data<int>(0),
            //                     new Data<int>(4),
            //                     new Data<int>(1));
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

}

