using System;
using System.Collections;
using System.Collections.Generic;

namespace OnMac
{
    class Program
    {
        /// <summary>
        /// 使用yield实现可迭代访问对象
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> enumFunc()
        {
            yield return 1;
            yield return 2;
            yield return 9;
            yield break;
            yield return 100;
        }


        static void Main(string[] args)
        {
            TestEnumerable test = new TestEnumerable();
            foreach(int number in test) Console.WriteLine(number);

        }
    }

}
