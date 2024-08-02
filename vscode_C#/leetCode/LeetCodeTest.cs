using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leetcode
{

    public class LeetCodeTest
    {
        public int MaxmiumScore(int[] cards, int cnt) 
        {
            /*
                选cnt个数，且和为偶数：2n个奇数(n>=0)
                因此，每次可挑选：1个偶数，或2个奇数
            */
            // 两种数分组（降序，方便优先挑大的）
            List<int> oddArr = new List<int>();     // 奇数
            List<int> evenArr = new List<int>();    // 偶数
            Array.Sort(cards);
            for(int i=cards.Length-1;i>=0;i--)
                if(cards[i]%2==1) oddArr.Add(cards[i]);
                else evenArr.Add(cards[i]);

            // 如果必须选奇数个奇数，那么必然无法选出和为偶数的情况
            if(evenArr.Count<cnt && (cnt-evenArr.Count)%2==1) return 0;

            // 挑选cnt个数
            int ret = 0;
            int oddNum=0, evenNum=0;
            while((oddNum+evenNum)<cnt)
            {
                // 选偶数
                if((oddArr.Count-oddNum)<2 || (oddArr[oddNum]+oddArr[oddNum+1])<evenArr[evenNum])
                {
                    Console.WriteLine("选偶数：{0}\tret={1}", evenArr[evenNum], ret);
                    ret += evenArr[evenNum++];
                }
                // 选奇数
                else
                {
                    Console.WriteLine("选奇数：{0}、(1)\tret={2}", oddArr[oddNum], oddArr[oddNum+1], ret);
                    ret += oddArr[oddNum] + oddArr[oddNum+1];
                    oddNum += 2;
                }
            }

            return ret;
        }
    }
    



}