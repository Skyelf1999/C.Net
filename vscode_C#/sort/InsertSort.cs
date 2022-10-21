using System;
using System.Collections;


namespace vsTest
{
    class InsertSort
    {
        Utils utils = new Utils();

        public InsertSort()
        {
            // this.datas = arr;
        }


        // 直接插入排序
        public void Direct(params Data<int>[] arr)
        {
            string func = "直接插入排序";
            utils.funcStart(func);

            int i,j;
            Data<int> cur;
            for(i=1;i<arr.Length;i++)
            {
                cur = arr[i];
                Console.WriteLine("当前元素：{0}  {1}",i,cur);
                // 将比当前排序元素大的元素向后移动
                for(j=i-1;j>=0;j--)
                {
                    if(arr[j].Index>cur.Index) arr[j+1]=arr[j];
                    else break;
                }
                // 将当前排序元素插入合适位置
                Console.WriteLine("合适位置：{0}\n",j+1);
                arr[j+1]=cur;
            }

            utils.printDataInt(arr);
            utils.funcEnd(func);
        }

        
        // 折半插入排序
        public void Half(params Data<int>[] arr)
        {
            string func = "折半插入排序";
            utils.funcStart(func);

            int low,high,mid;
            Data<int> cur;
            for(int i=1;i<arr.Length;i++)
                if(arr[i].Index<arr[i-1].Index)     // 该元素位置错误
                {
                    cur = arr[i];
                    low = 0;
                    high = i-1;
                    // 在前面的有序序列中寻找正确位置low
                    while(low<=high)
                    {
                        mid = (low+high)/2;
                        if(arr[mid].Index==cur.Index)
                        {
                            low = mid;
                            break;
                        }
                        else if(arr[mid].Index>cur.Index) high = mid-1;
                        else low = mid+1;
                    }
                    // 移动
                    for(int j=i-1;j>=low;j--) arr[j+1]=arr[j];
                    arr[low] = cur;
                    utils.printDataInt(arr);
                    Console.WriteLine("元素：{1},合适位置：{0}\n",low,cur);
                }

            
            utils.funcEnd(func);
        }


        // 希尔排序
        public void Shell(params Data<int>[] arr)
        {
            string func = "希尔排序";
            utils.funcStart(func);

            int gap = arr.Length/2;
            Data<int> cur;
            while(gap>0)
            {
                for(int i=gap;i<arr.Length;i++)
                    // 从i=gap开始（防止没有上一个比较元素），间隔gap进行冒泡排序
                    for(int j=i;j>=gap;j-=gap)
                    {
                        cur = arr[j];
                        if(arr[j-gap].Index>cur.Index)
                        {
                            arr[j] = arr[j-gap];
                            arr[j-gap] = cur;
                        }
                    }
                gap = gap/2;
            }

            utils.printDataInt(arr);
            utils.funcEnd(func);
        }

        

        



    }
}