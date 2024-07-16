using System;
using System.Collections;
using System.Collections.Generic;

namespace OnMac
{
    public class TestEnumerable : IEnumerable
    {
        int[] testData;
        int index;

        public TestEnumerable()
        {
            testData = new int[]{1,2,3,4,5,99};
            index = 0;
        }

        /// <summary>
        /// 用 yiled return 实现 GetEnumerator
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            // 返回一次后index自增，指向下一个对象
            while(index<9) yield return testData[index++%6];
            index = 0;
        }

    }


    public class EnumFunc
    {
        /// <summary>
        /// 使用yield实现可迭代方法
        /// </summary>
        /// <returns>int</returns>
        public IEnumerable<int> enumFunc()
        {
            yield return 1;
            yield return 2;
            yield return 9;
            yield break;        // 中断迭代
            yield return 100;
        }
    }


    
}