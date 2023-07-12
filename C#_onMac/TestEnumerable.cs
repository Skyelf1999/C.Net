

using System.Collections;

namespace OnMac
{
    /// <summary>
    /// 用 yiled return 实现GetEnumerator的可迭代访问类
    /// </summary>
    public class TestEnumerable : IEnumerable
    {
        int[] testData;
        int index;

        public TestEnumerable()
        {
            testData = new int[]{1,2,3,4,5,99};
            index = 0;
        }

        public IEnumerator GetEnumerator()
        {
            while(index<9) yield return testData[index++%6];
            index = 0;
        }
    }
}