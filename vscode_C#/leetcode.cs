using System.Reflection.Metadata.Ecma335;
using System.Globalization;
using System;
using System.Collections;


namespace vsTest
{
    // 保存Leetcode题目答案
    class Leetcode
    {
        // 题目：
        /*
            
        */


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


        // 题目：字符串尾单词长度
        /*
            给你一个字符串 s，由若干单词组成，单词前后用一些空格字符隔开。返回字符串中 最后一个 单词的长度。
            单词 是指仅由字母组成、不包含任何空格字符的最大子字符串
        */
        public void LengthOfLastWord(string s) 
        {
            int start = -1;
            int end = -2;
            int i = 0;

            // 找到最后一个单词的首尾字母序号
            for(i=0;i<s.Length;i++)
            {
                if(s[i]!=' ')
                    if(i==0 || s[i-1]==' ')
                    {
                        start = i;
                        Console.WriteLine("start = {0}",start);
                    }
                if(i>0 && s[i-1]!=' ' && s[i]==' ')
                {
                    end = i;
                    Console.WriteLine("end = {0}",end);
                }
            }
            Console.WriteLine("----");
            if(start>end)
            {
                end = i;
                Console.WriteLine("end = {0}",end);
            }
            string ret = s.Substring(start,end-start);
            Console.WriteLine("{0}, {1}, {2}, {3}\n\n",start,end,ret,s.Length);
        }


        // 题目：模拟加法器
        /*
            给定一个由 整数 组成的 非空 数组所表示的非负整数，在该数的基础上加一
            输入：digits = [1,2,3]
            输出：[1,2,4]
            解释：输入数组表示数字 12
        */
        public int[] PlusOne(int[] digits)
        {
            int carry = 0;
            for(int i=digits.Length-1;i>=0;i--)
            {
                if(i==digits.Length-1) digits[i] = digits[i] + 1 + carry;
                else digits[i] += carry;
                carry = 0;
                // 进位
                if(digits[i]>=10)
                {
                    digits[i] -= 10;
                    carry = 1;
                }
            }
            if(carry>0) // 最高位有进位
            {
                int[] ret = new int[digits.Length+1];
                ret[0] = carry;
                for(int i=0;i<digits.Length;i++) ret[i+1] = digits[i];
                return ret;
            }
            return digits;
        }


        // 题目：找到错误数字
        /*
            集合 s 包含从 1 到 n 的整数。
            集合里面某一个数字复制了成了集合里面的另外一个数字的值，
            导致集合 丢失了一个数字 并且 有一个数字重复 。
        */
        public int[] FindErrorNums(int[] nums)
        {
            int[] ret = new int[2];
            int i,j=0;
            Array.Sort(nums);

            for(i=1;i<nums.Length;i++)
            {
                if(nums[i]==nums[i-1]) break;
                if(nums[i-1]==i && nums[i]!=i+1) j=i;
            }
            ret[0] = nums[i];       // 重复出现的数

            if(ret[0]==i+1)         // 丢失的数字在前
            {
                Console.WriteLine("在前");
                ret[1] = j+1;
                return ret;
            }
            else if(ret[0]==i)      // 丢失的数字在后
            {
                Console.WriteLine("在后");
                while(++i<nums.Length)
                {
                    if(nums[i]!=nums[i-1]+1)
                    {
                        ret[1] = i;
                        return ret;
                    }
                }
            }
            ret[1] = i;

            return ret;
        }


        // 题目：判断出栈顺序是否可行
        public bool ValidateStackSequences(int[] pushed, int[] popped) 
        {
            Stack<int> stack = new Stack<int>();
            int i=0,j=0;
            stack.Push(pushed[0]);
            while(i<pushed.Length)
            {
                while(stack.Count>0 && stack.Peek()==popped[j])
                {
                    stack.Pop();
                    j++;
                }
                stack.Push(pushed[i]);
                i++;
            }
            if(stack.Count==0) return true;
            return false;
        }


        // 题目：计算优惠价格
        // 类型：数组
        /*
            商店里正在进行促销活动，如果你要买第 i 件商品，那么你可以得到与 prices[j] 相等的折扣
            其中 j 是满足 j > i 且 prices[j] <= prices[i] 的 最小下标 ，如果没有满足条件的 j ，你将没有任何折扣。
            请你返回一个数组，数组中第 i 个元素是折扣后你购买商品 i 最终需要支付的价格。
        */
        public int[] FinalPrices(int[] prices) 
        {
            int[] ret = new int[prices.Length];
            int discount;

            for(int i=0;i<ret.Length-1;i++)
            {
                discount = 0;
                for(int j=i+1;j<prices.Length;j++)
                {
                    if(prices[j]<=prices[i])
                    {
                        discount = prices[j];
                        break;
                    }
                }
                ret[i] = prices[i]-discount;
            }
            ret[ret.Length-1] = prices[prices.Length-1];

            return ret;
        }



        // 题目：二进制求和
        public string AddBinary(string a, string b) 
        {
            Stack<bool> st = new Stack<bool>();
            bool carry = false;
            int i=a.Length-1,j=b.Length-1;

            while(i>-1 || j>-1)
            {
                if(i<0)                 // b有剩余
                {
                    if(b[j]=='0')
                    {
                        st.Push(carry);
                        carry = false;
                    }
                    else
                    {
                        if(carry) st.Push(false);
                        else st.Push(true);
                    }
                }
                else if(j<0)            // a有剩余
                {
                    if(a[i]=='0')
                    {
                        st.Push(carry);
                        carry = false;
                    }
                    else
                    {
                        if(carry) st.Push(false);
                        else st.Push(true);
                    }
                }
                else
                {
                    if(a[i]==b[j])      // 0&0 或 1&1，结果末尾为0
                    {
                        st.Push(carry);
                        if(a[i]=='0') carry = false;
                        else carry = true;
                    }
                    else                // 0&1，结果末尾为1
                    {
                        if(carry) st.Push(false);
                        else st.Push(true);
                    }
                }
                Console.WriteLine("i={0}, j={1}, 本次结果={2}, 进位={3}",i,j,st.Peek(),carry);
                i--;
                j--;
                
            }
            if(carry) st.Push(carry);
            
            string ret = "";
            // 根据栈构造结果
            while(st.Count>0)
            {
                if(st.Pop()) ret = ret+"1";
                else ret = ret+"0";
            }
            
            return ret;
        }


        // 城市天际线
        /*
            在不改变四个方向视图形状的基础上
            尽可能增大高度
            返回增加的高度和
        */
        public int MaxIncreaseKeepingSkyline(int[][] grid) 
        {
            // 每个楼可增高高度为 min{所在行高度最大值, 所在列高度最大值}
            int ret = 0;
            int[] rowMax = new int[grid.Length];
            int[] colMax = new int[grid[0].Length];
            int i,j;

            // 初始化列最大值
            for(j=0;j<grid[0].Length;j++)
            {
                colMax[j] = 0;
                for(i=0;i<grid.Length;i++)
                    if(grid[i][j]>colMax[j]) colMax[j] = grid[i][j];
                Console.WriteLine("第{0}列最大值：{1}",j,colMax[j]);
            }

            // 初始化行最大值
            for(i=0;i<grid.Length;i++)
            {
                rowMax[i] = 0;
                for(j=0;j<grid[i].Length;j++)
                    if(grid[i][j]>rowMax[i]) rowMax[i] = grid[i][j];
                Console.WriteLine("第{0}行最大值：{1}",i,rowMax[i]);
            }

            // 增高
            for(i=0;i<grid.Length;i++)
            {
                for(j=0;j<grid[i].Length;j++)
                {
                    int n = rowMax[i]>=colMax[j]?colMax[j]:rowMax[i];
                    if(grid[i][j]<n) ret += n-grid[i][j];
                }
            }

            return ret;
        }

        
        // 题目：找到最长回文子串
        public string LongestPalindrome(string s) 
        {
            string ret = "";
            int n = s.Length;
            int end = 2*n-1;

            for(int i=0;i<end;i++)
            {
                double mid = i/2.0;
                int p = (int)(Math.Floor(mid));
                int q = (int)(Math.Ceiling(mid));
                // 向两侧扩散
                while(p>-1 && q<n)
                {
                    if(s[p]!=s[q]) break;
                    p--;
                    q++;
                }

                int len = q-p-1;
                if(len>ret.Length) ret = s.Substring(p+1,len);
            }
            return ret;
        }


        // 题目：寻找重复子树
        // 存储访问过的子树字符串和对应的节点
        Dictionary<string,TreeNode> history = new Dictionary<string,TreeNode>();
        // 存储重复子树的根节点
        HashSet<TreeNode> repeatNodes = new HashSet<TreeNode>();
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) 
        {
            dfs(root);
            return new List<TreeNode>(repeatNodes);
        }
        public string dfs(TreeNode cur)
        {
            if(cur==null) return "";
            // 子树字符串
            string str = cur.data.ToString() + "(";
            str = str + dfs(cur.left) + ")(";
            str = str + dfs(cur.right) + ")";
            // 历史记录中有此子串 --> 有重复子树
            if(history.ContainsKey(str)) repeatNodes.Add(history[str]);
            else history.Add(str,cur);
            return str;
        }


        // 题目：交换数字，使原数最大
        public int MaximumSwap(int num) 
        {
            char[] res = num.ToString().ToCharArray();
            int maxIndex;
            char temp;

            for(int i=0;i<res.Length-1;i++)
            {
                Console.WriteLine("当前位数字：{0}",res[i]);
                maxIndex = i;
                for(int j=i+1;j<res.Length;j++)
                    if(Convert.ToInt32(res[j])>Convert.ToInt32(res[i]))
                        if(Convert.ToInt32(res[j])>=Convert.ToInt32(res[maxIndex]))
                            maxIndex = j;
                if(maxIndex>i)
                {
                    Console.WriteLine("交换目标：{0}",res[maxIndex]);
                    temp = res[maxIndex];
                    res[maxIndex] = res[i];
                    res[i] = temp;
                    return Convert.ToInt32(new string(res));
                }
            }
            Console.WriteLine("无可交换数字");
            return Convert.ToInt32(new string(res));
        }

    }
}