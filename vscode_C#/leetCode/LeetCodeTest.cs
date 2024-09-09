using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leetcode
{

    public class LeetCodeTest
    {
        public int LongestArithSeqLength(int[] nums) 
        {
            int n = nums.Length;

            int ret = 0;
            // dp[i]：以nums[i]结尾的各个等差子序列，不同等差与对应的子序列长度
            Dictionary<int,int>[] dp = new Dictionary<int,int>[n];
            for(int cur=0;cur<n;cur++)
            {
                Console.WriteLine("nums[{0}] = {1}", cur, nums[cur]);
                dp[cur] = new Dictionary<int, int>();
                for(int pre=0;pre<cur;pre++)
                {
                    // 枚举当前元素之前的元素，作为等差序列中的上一个元素
                    int diff = nums[cur] - nums[pre];
                    int lastLength = dp[pre].ContainsKey(diff) ? dp[pre][diff] : 0;
                    if(!dp[cur].ContainsKey(diff)) dp[cur][diff] = 2;
                    dp[cur][diff] = Math.Max(dp[cur][diff], lastLength+1);
                    if(dp[cur][diff]>ret) ret = dp[cur][diff];
                }
                foreach(int diff in dp[cur].Keys) Console.WriteLine("diff：{0}，最长等差子序列长度：{1}",diff,dp[cur][diff]);
            }

            return ret;
        }
    }
    



}