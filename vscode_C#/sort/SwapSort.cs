using System;



namespace vsTest
{
    class SwapSort
    {
        Utils utils = new Utils();

        public SwapSort()
        {

        }


        // 冒泡排序
        public void Bubble(params Data<int>[] arr)
        {
            string func = "冒泡排序";
            utils.funcStart(func);

            Data<int> temp;
            for(int i=arr.Length-1;i>0;i--)         // 最大的沉底到arr[i]，因此每轮少访问一个
                for(int j=0;j<i;j++)
                    if(arr[j].Index>arr[j+1].Index) // 当前比下一个大，交换
                    {
                        temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;
                    }

            utils.printDataInt(arr);
            utils.funcEnd(func);
        }


        // 快速排序
        public void Quick(params Data<int>[] arr)
        {
            string func = "快速排序";
            utils.funcStart(func);

            quickSort(ref arr,0,arr.Length-1);

            utils.printDataInt(arr);
            utils.funcEnd(func);
        }
        private void quickSort(ref Data<int>[] arr,int start,int end)
        {
            Console.WriteLine("start = {0}, end = {1}",start,end);
            if(start>=end) return;
            Data<int> temp = arr[start];
            int left=start,right=end;

            while(left<right)
            {
                while(left<right && temp.Index<=arr[right].Index) right -= 1;
                arr[left] = arr[right];
                while(left<right && temp.Index>=arr[left].Index) left += 1;
                arr[right] = arr[left];
            }

            arr[left] = temp;
            utils.printDataInt(arr);
            Console.WriteLine();
            quickSort(ref arr,start,left-1);
            quickSort(ref arr,left+1,end);

        }
    }   
}