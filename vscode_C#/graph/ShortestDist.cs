using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graph
{
    public class ShortestDist
    {
        /// <summary>
        /// 最短路径 - Dijkstra算法
        /// </summary>
        /// <param name="n">顶点个数</param>
        /// <param name="edgeArr">邻接矩阵</param>
        /// <param name="start">起点</param>
        /// <param name="end">终点</param>
        public int Dijkstra(int n, int[,] edgeArr, int start, int end)
        {
            // 辅助数组
            bool[] s = new bool[n];                 // s[i]==true：已找到起点到顶点i的最短路径
            int[] dist = new int[n];                // dist[i]：start到顶点i的最短路径长度
            int[] path = new int[n];                // path[i]：从start到i的路径上，顶点i的直接前驱点
            
            // 初始化：将起点加入s
            s[start] = true;
            for(int i=0;i<n;i++)
            {
                dist[i] = edgeArr[start,i];
                if(dist[i]<int.MaxValue) path[i] = start;
                else path[i] = -1;
            }

            int midNode = start;            // 当前距离start最近且未找到最短路径的点
            int minDist = int.MaxValue;
            
            // 根据每一轮的中间点，更新dist
            for(int i=0;i<n;i++)
            {
                // 找到当前距离start最近，且尚未找到最短路径的顶点
                for(int j=0;j<n;j++)
                    if(!s[j] && dist[j]<minDist)
                    {
                        minDist = dist[j];
                        midNode = j;
                    }
                // midNode为本轮最近点，视为找到了从start到midNode最短路径
                if(minDist<int.MaxValue) s[midNode] = true;
                else break;

                // 以midNode为路径中间点，更新dist中到尚未找到最短路径的端点的路径长度
                for(int j=0;j<n;j++)
                    if(!s[j] && edgeArr[midNode,j]<int.MaxValue)
                    {
                        // 将之前start到j的最短距离和经过midNode到j的距离最对比
                        int newDist = dist[midNode] + edgeArr[midNode,j];
                        if(newDist<dist[j])
                        {
                            // 如果从start到j经过 midNode时 更近
                            // 更新start到j的最短路径长度dist[j]，和从start到j最短路径上j的直接前驱节点path[j]
                            dist[j] = newDist;
                            path[j] = midNode;
                        }
                    }

                // 充值暂存变量，开始下一轮
                minDist = int.MaxValue;
            }

            // 如果需要具体的路径过程，则可以从path中获取
            Stack<int> pathStack = new Stack<int>();
            int curNode = end;
            while(curNode!=start && curNode>-1)
            {
                pathStack.Push(curNode);
                curNode = path[curNode];
            }
            pathStack.Push(start);
            Console.WriteLine(string.Join(" --> ", pathStack));

            return dist[end];
        }



        /// <summary>
        /// 最短路径 - Floyd算法
        /// </summary>
        /// <param name="n">顶点个数</param>
        /// <param name="edgeArr">邻接矩阵</param>
        /// <param name="start">起点</param>
        /// <param name="end">终点</param>
        public int Floyd(int n, int[,] edgeArr, int start, int end)
        {
            int[,] dist = new int[n,n];     // dist[i,j]：i到j的最短路径距离
            int[,] path = new int[n,n];     // paht[i,j]：i到j的最短路径上，终点j的直接前驱顶点

            // 初始化
            for(int i=0;i<n;i++)
                for(int j=0;j<n;j++)
                {
                    dist[i,j] = edgeArr[i,j];
                    path[i,j] = dist[i,j]==int.MaxValue?-1:i;
                }

            // 分别以各个点为中间顶点，更新最短路径
            for(int mid=0;mid<n;mid++)
                for(int i=0;i<n;i++)
                {
                    if(i==mid) continue;
                    for(int j=0;j<n;j++) 
                    {
                        if(j==mid || i==j) continue;
                        if(dist[i,mid]+dist[mid,j] < dist[i,j])
                        {
                            dist[i,j] = dist[i,mid]+dist[mid,j];
                            path[i,j] = mid;
                        }
                    }  
                }     

            return dist[start,end];
        }
    }
}