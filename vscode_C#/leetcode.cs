using System;
using System.Collections;


namespace vsTest
{
    // 保存Leetcode题目答案函数
    class Leetcode
    {
        // 数组特征值
        public int SpecialArray(int[] nums) 
        {
            int result = -1;
            Array.Sort(nums);

            // 对于nums[i]，有 nums.Length-i 个数 >= nums[i]
            if(nums[0]>nums.Length) result = nums.Length;
            else for(int i=0;i<nums.Length;i++)
            {
                if(i>0 && (nums[i-1]<(nums.Length-i-1) && nums[i]>=(nums.Length-i)))
                {
                    result = nums.Length-i;
                    Console.WriteLine("在i={0} 时实现了追赶",i);
                }
            }
            return result;
        }

        public int MaximumProduct(int[] nums) 
        {
            Array.Sort(nums);
            int result = 1;
            // 没有正数时
            if(nums[nums.Length-1]<=0) result = nums[nums.Length-1] * nums[nums.Length-2] *nums[nums.Length-3];
            // 有1个正数时 或 有2个正数时
            else if(nums[nums.Length-1]>0 && nums[nums.Length-3]<=0) result = nums[nums.Length-1] * nums[0] *nums[1];
            // 有3个正数时，考虑是使用3个正数还是1正2负
            else if(nums[nums.Length-3]>0)
            {
                int a = nums[nums.Length-1] * nums[nums.Length-2] *nums[nums.Length-3];
                int b = nums[nums.Length-1] * nums[0] *nums[1];
                result = (a>b)?a:b;
            }

            return result;
        }


        

        public string ReorderString(string text)
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