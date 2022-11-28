~~~ cs
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'minMoves' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. 2D_INTEGER_ARRAY maze
     *  2. INTEGER x
     *  3. INTEGER y
     */
    public static int n = 0;
    public static int m = 0;
    public static int[] dx = { -1, 1, 0, 0 };
    public static int[] dy = { 0, 0, -1, 1 };
    public static Queue<(int, int)> que = new Queue<(int, int)>();
    public static int minMoves(List<List<int>> maze, int x, int y)
    {
        n = maze.Count();

        m = maze[0].Count();

        List<(int, int)> golds = new List<(int, int)>();

        golds.Add((0, 0));
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (maze[i][j] == 2)
                {
                    golds.Add((i, j));
                }
            }
        }
        golds.Add((x, y));

        int cnt = golds.Count;
        int[,] dij = new int[cnt, cnt];
        dij[0, cnt - 1] = -2;
        dij[cnt - 1, 0] = -2;
        for (int i = 0; i < cnt; i++)
        {
            for (int j = i + 1; j < cnt; j++)
            {
                if (golds[i] != golds[j] && (i != 0 || j != cnt - 1))
                {
                    int[,] maz = new int[n, m];
                    for (int k = 0; k < n; k++)
                    {
                        for (int l = 0; l < m; l++)
                        {
                            if (maze[k][l] != 2)
                                maz[k, l] = maze[k][l];
                            else
                                maz[k, l] = 1;
                        }
                    }
                    if (maze[golds[i].Item1][golds[i].Item2] == 2)
                        maz[golds[i].Item1, golds[i].Item2] = 0;

                    maz[golds[j].Item1, golds[j].Item2] = 0;

                    int xx = bfs(golds[i].Item1, golds[i].Item2, golds[j].Item1, golds[j].Item2, maz);
                    dij[golds.IndexOf(golds[i]), golds.IndexOf(golds[j])] = xx;
                    dij[golds.IndexOf(golds[j]), golds.IndexOf(golds[i])] = xx;
                }
            }
        }

        bool[] visited = new bool[cnt - 1];
        visited[0] = true;

        for (int i = 0; i < visited.Count(); i++)
        {
            FindMin(0, i, dij, visited, 0);
        }

        if (answers.Count == 0) return -1;
        else return answers.Min();
    }
    public static List<int> answers = new List<int>();
    public static void FindMin(int start, int end, int[,] arr, bool[] visitied, int sum)
    {
        if (arr[start, end] <= 0)
            return;
        else
        {

            visitied[end] = true;
            sum = sum + arr[start, end];
            
            if (!visitied.Contains(false))
            {
                if (arr[end, visitied.Count()] > 0)
                {
                    sum = sum + arr[end, visitied.Count()];
                    answers.Add(sum);
                    visitied[end] = false;
                    return;
                }
                else
                {
                    visitied[end] = false;
                    return;
                }
            }
            else
            {
                if(RR(arr,end)!=0)
                {
                    visitied[RR(arr,end)] = false;
                }
                for (int i = 0; i < visitied.Count(); i++)
                {
                    if (!visitied[i] && arr[end, i] > 0)
                    {
                        FindMin(end, i, arr, visitied, sum);
                    }
                }
                visitied[end] = false;
                return;
            }
        }
    }
    public static int RR(int[,] arr , int num)
    {
        int cnt = 0;
        int result= 0;
        for(int i =0;i<arr.GetLength(0);i++)
        {
            if(arr[i,num]>0)
            {
                cnt++;
                if(cnt>1)
                    break;
                result = i;
            }
        }
        if(cnt==1) return result;
        else return 0;
    }
    public static int bfs(int sx, int sy, int ex, int ey, int[,] arr)
    {
        que.Enqueue((sx, sy));

        while (que.Count != 0)
        {
            (int a, int b) = que.Dequeue();
            for (int k = 0; k < 4; k++)
            {
                int x = a + dx[k];
                int y = b + dy[k];
                if ((0 <= x && x < n) && (0 <= y && y < m) && (arr[x, y] == 0) && (x != sx || y != sy))
                {
                    que.Enqueue((x, y));
                    arr[x, y] = arr[a, b] + 1;
                }
            }
        }
        if (arr[ex, ey] != 0) return arr[ex, ey];
        else return -1;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        List<List<int>> maze = new List<List<int>>();
        List<int> maze1 = (new int[] { 0, 1, 0, 2, 0, 0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 2, 2 }).ToList();
        List<int> maze2 = (new int[] { 2, 0, 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1 }).ToList();
        List<int> maze3 = (new int[] { 0, 0, 0, 2, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1 }).ToList();
        List<int> maze4 = (new int[] { 0, 1, 0, 0, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 }).ToList();
        List<int> maze5 = (new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 }).ToList();
        List<int> maze6 = (new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 }).ToList();
        List<int> maze7 = (new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }).ToList();
        List<int> maze8 = (new int[] { 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }).ToList();
        List<int> maze9 = (new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }).ToList();
        List<int> maze10 = (new int[] { 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 }).ToList();
        List<int> maze11 = (new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0 }).ToList();
        List<int> maze12 = (new int[] { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 }).ToList();
        List<int> maze13 = (new int[] { 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 }).ToList();
        List<int> maze14 = (new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0 }).ToList();
        List<int> maze15 = (new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 }).ToList();
        List<int> maze16 = (new int[] { 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 }).ToList();
        List<int> maze17 = (new int[] { 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }).ToList();
        List<int> maze18 = (new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 }).ToList();
        List<int> maze19 = (new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 }).ToList();

        maze.Add(maze1);
        maze.Add(maze2);
        maze.Add(maze3);
        maze.Add(maze4);
        maze.Add(maze5);
        maze.Add(maze6);
        maze.Add(maze7);
        maze.Add(maze8);
        maze.Add(maze9);
        maze.Add(maze10);
        maze.Add(maze11);
        maze.Add(maze12);
        maze.Add(maze13);
        maze.Add(maze14);
        maze.Add(maze15);
        maze.Add(maze16);
        maze.Add(maze17);
        maze.Add(maze18);
        maze.Add(maze19);

        int x = 8, y = 10;
        Console.WriteLine(Result.minMoves(maze, x, y));
    }
}
~~~