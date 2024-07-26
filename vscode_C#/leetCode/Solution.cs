using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leetcode
{
    public class Solution
    {
        int[] dirX = new int[]{0,0,-1,1};
        int[] dirY = new int[]{-1,1,0,0};
        // dp[i,j]：从i出发，可用步数为j时，到终点的路径数量
        int[,] dp;


        /// <summary>
        /// 获取坐标对应的位置Index
        /// </summary>
        /// <param name="n">列数</param>
        /// <param name="x">当前x</param>
        /// <param name="y">当前y</param>
        /// <returns>位置Index</returns>
        int GetIndex(int n, int x, int y)
        {
            return x*n+y;
        }


        public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn) {
            dp = new int[m*n,maxMove+1];
            
            // 初始化边缘格子的出界路径
            for(int i=0;i<m;i++)
                for(int j=0;j<n;j++)
                {
                    if (i == 0) AddEdgePath(n,i,j,maxMove);
                    if (i == m - 1) AddEdgePath(n,i,j,maxMove);
                    if (j == 0) AddEdgePath(n,i,j,maxMove);
                    if (j == n - 1) AddEdgePath(n,i,j,maxMove);
                }
            Console.WriteLine("边缘位置初始出界路径数初始化完毕");

            /*
                状态转移
                dp[(x,y) , j] = 
                    dp[(x,y-1) , j-1] + dp[(x,y+1) , j-1] + dp[(x-1,y) , j-1] + dp[(x+1,y) , j-1]
            */
            for(int curMaxMove=1;curMaxMove<=maxMove;curMaxMove++)
                for(int i=0;i<m;i++)
                    for(int j=0;j<n;j++)
                    {
                        int curIndex = GetIndex(n, i, j);
                        Console.WriteLine("\ncurIndex={0}",curIndex);
                        // 计算
                        for(int k=0;k<4;k++)
                        {
                            int x = i+dirX[k];
                            int y = j+dirY[k];
                            if(x>=0 && x<m && y>=0 && y<n)
                            {
                                int nextIndex = GetIndex(n, x, y);
                                Console.WriteLine("nextIndex={0}",nextIndex);
                                dp[curIndex, curMaxMove] += dp[nextIndex, curMaxMove-1];
                            } 
                        }
                    }

            return dp[GetIndex(n,startRow,startColumn),maxMove];
        }


        /// <summary>
        /// 为边缘位置添加不同剩余步数情况下的基础出界路径数
        /// </summary>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="maxMove"></param>
        void AddEdgePath(int n, int x, int y, int maxMove)
        {
            int index = GetIndex(n,x,y);
            for(int i=1;i<=maxMove;i++) dp[index,i]++;
        }


        


        /// <summary>
        /// 路径访问dfs
        /// </summary>
        /// <param name="m">行数</param>
        /// <param name="n">列数</param>
        /// <param name="x">当前x</param>
        /// <param name="y">当前y</param>
        /// <param name="maxMove">最大移动次数</param>
        /// <returns>路径数</returns>
        // int Dfs(int m, int n, int x, int y, int maxMove);
    }
}