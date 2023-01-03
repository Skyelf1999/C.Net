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

        public Utils utils = new Utils();


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

        
        // 题目：找到最长回文子串
        public string LongestPalindrome(string s) 
        {
            string ret = "";
            int n = s.Length;
            int end = 2*n-1;

            // 以各字符为中心，寻找回文子串
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
        /*
            需要对数字进行位操作，可以先转换成字符数组
        */
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


        // 题目：字母异位词分组
        /*
            由相同字母构成的单词为异位词
            可先将每个单词字母排序后，存储到对应的组别
        */
        public void GroupAnagrams(string[] strs) 
        {
            Dictionary<string,IList<string>> dict = new Dictionary<string,IList<string>>();
            char[] arr;
            string str;

            // 将各字符串分组存放
            for(int i=0;i<strs.Length;i++)
            {
                // 得到排序后的字符串
                arr = strs[i].ToCharArray();
                Array.Sort(arr);
                str = new string(arr);
                Console.WriteLine("原单词：{0}，组别：{1}",strs[i],str);
                // 存放
                // if(!dict.ContainsKey(str)) dict.Add(str,new List<string>({strs[i]}));
                dict[str].Add(strs[i]);
            }

        }


        // 题目：求最长无重复字符子串的长度
        public void LengthOfLongestSubstring(string s) 
        {
            int ret = 1;
            Dictionary<char,int> history = new Dictionary<char,int>();
            int i=0,j=0;
            while(i<s.Length && j<s.Length)
            {
                while(j<s.Length)
                {
                    Console.WriteLine("当前位置：{0}，字符：{1}",j,s[j]);
                    if(history.ContainsKey(s[j]))
                        if(history[s[j]]>=i) break;
                        else history[s[j]] = j;
                    else history.Add(s[j],j);
                    j++;
                }
                if(j-i>ret) ret = j-i;
                Console.WriteLine("更新结果，起点：{0}，终点：{1}，长度：{2}\n",i,j-1,ret);
                if(j<s.Length) i = history[s[j]]+1;
            }
        }


        // 题目：字符串解码
        /*
            编码规则为: k[encoded_string]
            表示其中方括号内部的 encoded_string 正好重复 k 次。注意 k 保证为正整数。
        */
        public void DecodeString(string s) 
        {
            if(s.Length<4) Console.WriteLine(s);

            string ret = "";
            Stack<char> st = new Stack<char>();
            IList<char> buff = new List<char>();
            int k = 0;      // 嵌套深度

            for(int i=0;i<s.Length;i++)
            {
                Console.WriteLine("当前字符：{0}",s[i]);
                if(k==0 && isLetter(s[i])) ret+=s[i];
                else
                {
                    if(s[i]=='[') k++;
                    if(isNum(s[i]) || isLetter(s[i]) || s[i]=='[') st.Push(s[i]);
                    else
                    {
                        // 遇到']'，开始弹出
                        k--;
                        while(st.Peek()!='[') buff.Insert(0,st.Pop());
                        st.Pop();   // 弹出'['
                        Console.WriteLine("重复内容：{0}，重复次数：{1}",new string(buff.ToArray()),st.Peek()-48);
                        if(k==0)    // 嵌套层为0，加入结果
                            for(int j=st.Pop()-48;j>0;j--) ret += new string(buff.ToArray());
                        else        // 嵌套层不为0，重新入栈，等待遍历到该嵌套层结束
                            for(int j=st.Pop()-48;j>0;j--)
                                foreach(char c in buff) st.Push(c);
                        buff.Clear();
                    }
                }
                Console.WriteLine(ret);
                Console.WriteLine();
            }
        }
        public bool isLetter(char c)
        {
            if((int)c>57&&(int)c<123&&c!='['&&c!=']') return true;
            else return false;
        }
        public bool isNum(char c)
        {
            if((int)c<58) return true;
            else return false;
        }
        


        public void Test() 
        {

        }




        int N;
        int[][] zero = {new int[]{4,2}};
        public int OrderOfLargestPlusSign(int n) {
            int ret = 1;      
            N = n;
            if(n==1 && !isZero(0,0)) return 1;
            int[][] dir = {new int[]{0,1} , new int[]{0,-1} , new int[]{1,0} , new int[]{-1,0}};

            for(int x=0;x<n;x++)
                for(int y=0;y<n;y++)
                {
                    if(isZero(x,y) || (x==0||y==0||x==n-1||y==n-1&&!isZero(x,y))) continue;
                    // 进行扩展
                    int k = 1;
                    while(true)
                    {
                        if(isZero(x+(k-1)*dir[0][0],y+(k-1)*dir[0][1])||!inArea(x+(k-1)*dir[0][0],y+(k-1)*dir[0][1])) break;
                        if(isZero(x+(k-1)*dir[1][0],y+(k-1)*dir[1][1])||!inArea(x+(k-1)*dir[1][0],y+(k-1)*dir[1][1])) break;
                        if(isZero(x+(k-1)*dir[2][0],y+(k-1)*dir[2][1])||!inArea(x+(k-1)*dir[2][0],y+(k-1)*dir[2][1])) break;
                        if(isZero(x+(k-1)*dir[3][0],y+(k-1)*dir[3][1])||!inArea(x+(k-1)*dir[3][0],y+(k-1)*dir[3][1])) break;
                        k++;
                    }
                    // ret = Math.Max(ret,k);
                    if(k>ret)
                    {
                        ret = k;
                        Console.WriteLine("{0} {1}  更新ret={2}",x,y,k);
                    }
                }

            return ret-1;
        }


        // 判断当前格是否是0
        bool isZero(int x,int y)
        {
            foreach(int[] arr in zero)
                if(x==arr[0] && y==arr[1]) return true;
            return false;
        }

        bool inArea(int x,int y)
        {
            if(x>=0&&x<N && y>=0&&y<N) return true;
            return false;
        }


    

    }
}