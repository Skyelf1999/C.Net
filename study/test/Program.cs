using System;
using System.Collections;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] array = new int[][];
            array = { { 25,45},  };
           
        }

        public int NearestValidPoint(int x, int y, int[][] points)
        {
            /*
                有效点：横坐标或纵坐标相等
                曼哈顿距离：两个坐标差值的绝对值之和
            */
            if (points.Length == 0) return -1;
            int dis_min = Math.Abs(points[0][0] - x) + Math.Abs(points[0][1] - y);
            ArrayList avail_points = new ArrayList();   // 保存各个点的曼哈顿距离

            // 遍历
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i][0] == x || points[i][1] == y)  // 是有效点
                {
                    if (Math.Abs(points[i][0] - x) + Math.Abs(points[i][1] - y) <= dis_min)
                    {
                        // 更新有效点最小值，保存曼哈顿距离
                        dis_min = Math.Abs(points[i][0] - x) + Math.Abs(points[i][1] - y);
                        avail_points.Add(dis_min);
                        Console.WriteLine("序号为 {0} 的点更新了最小曼哈顿距离（{1}）",i,dis_min);
                    }
                    else avail_points.Add(-1);
                }
                else avail_points.Add(-1);
            }
            return avail_points.IndexOf(dis_min);
        }


    }

    class DataStruct    // 数据单元
    {
        int key = -1;
        int data_int = -1;
        string data_string = null;

        public DataStruct(int key, object data)
        {
            this.key = key;
        }

    }
}
