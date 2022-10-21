using System;



namespace vsTest
{
    class SelectSort
    {
        Utils utils = new Utils();

        public SelectSort()
        {

        }


        // 直接选择排序
        public void Direct(params Data<int>[] arr)
        {
            string func = "冒泡排序";
            utils.funcStart(func);

            Data<int> temp;
            int min = 0;
            for(int i=0;i<arr.Length-1;i++)
            {
                temp = arr[i];
                min = i;
                // 找到后序的最小值
                for(int j=i+1;j<arr.Length;j++)
                    if(arr[j].Index<temp.Index)
                    {
                        temp = arr[j];
                        min = j;
                    }
                // 交换
                arr[min] = arr[i];
                arr[i] = temp;    
            }
            
            utils.printDataInt(arr);
            utils.funcEnd(func);
        }


    }   
}