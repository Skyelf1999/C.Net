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
            int[] list = {1,4,3,2};
            Console.WriteLine(MaximumProduct(list));
        }

        static int MaximumProduct(int[] nums) 
        {
            Array.Sort(nums);
            int result = 1;
            // 没有正数时
            if(nums[nums.Length-1]<=0) result = nums[nums.Length-1] * nums[nums.Length-2] *nums[nums.Length-3];
            // 有1个正数时 或 有2个正数时
            else if(nums[nums.Length-1]>0 && nums[nums.Length-3]<=0) result = nums[nums.Length-1] * nums[0] *nums[1];
            // 有3个正数时
            else result = 0;

            return result;
        }


        

        static string ReorderString(string text)
        {
            ArrayList result = new ArrayList();     // 所有单词
            int num_space = 0;                      // 空格数量
            int i;
            int count = 0;                          // 记录当前单词长度

            // 遍历，进行空格数量统计和单词存储
            for(i=0;i<text.Length;i++)
            {
                if(!text[i].Equals(' '))
                {
                    count++;
                    // Console.WriteLine("{0}, {1}",i,count);
                }
                else
                {
                    num_space++;
                    // 上一个单词结束，切割单词，加入result
                    if(i>0 && !text[i-1].Equals(' '))
                    {
                        // Console.WriteLine(text.Substring(i-count,count));
                        result.Add(text.Substring(i-count,count));
                    }
                    count = 0;
                }
            }
            if(count>0) result.Add(text.Substring(i-count,count));
            Console.WriteLine("遍历完成，单词数量：{0}，空格数量：{1}",result.Count,num_space);

            // 计算用于分割和结尾的空格数量，生成间隔空格和尾空格
            int n = 0;
            if(result.Count==1) n = 0;
            else n = num_space/(result.Count-1);
            string mid = "";
            for(i=0;i<n;i++) mid = mid+" ";
            if(result.Count==1) n = num_space;
            else n = num_space%(result.Count-1);
            string tail = "";
            for(i=0;i<n;i++) tail = tail+" ";

            Console.WriteLine(string.Join(mid, (string[])result.ToArray(typeof(string))) + tail + ";");
            return "\nover\n";
        }
    }

}

