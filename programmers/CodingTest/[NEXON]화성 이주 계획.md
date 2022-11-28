~~~ cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
    class Solution
    {
        static int[] maximum = new int[]{0,0,2,4,6,9,12,16,20,25,30};
        static int max = 0;
        static int solution(int h, int w, int n, List<List<int>> arr)
        {
            List<(int, int)>[] nu = new List<(int, int)>[10];
            for (int i = 0; i < 10; i++)
            {
                nu[i] = new List<(int, int)>();
            }
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    nu[arr[i][j]].Add((i, j));

            List<(int, int)> nums = new List<(int, int)>();
            List<(int, int)> nums1 = new List<(int, int)>();

            for (int i = 9; i >=0; i--)
                nums1.AddRange(nu[i]);

            for(int i =0;i<n;i++)
                max = max + arr[nums1[i].Item1][nums1[i].Item2];
            
            bool[] visited;
            if(n==10)
            {
                flag = true;
                for (int i = 9; i >= 0; i--)
                {
                    nums.AddRange(nu[i]);
                    visited = new bool[nums.Count];
                    Combination(nums, visited, 0, n, arr, n);
                }
            }
            else
            {
                flag =false;
                visited = new bool[nums1.Count];
                Combination(nums1, visited, 0, n, arr, n);
            }


            return answer;
        }
        static bool flag = false;
        static int answer = 0;
        static int sum(List<List<int>> arr, bool[] visited,List<(int,int)> nums)
        {
            int sum =0;
            for(int i =0;i<visited.Length;i++)
            {
                if(visited[i])
                {
                    sum= sum+arr[nums[i].Item1][nums[i].Item2];
                }
            }
            return sum;
        }
        static void Combination(List<(int, int)> nums, bool[] visited, int start, int r,List<List<int>> arr,int nn)
        {
            int n = visited.Length;
            if (r == 0)
            {
                if (answer >= sum(arr, visited,nums))
                {
                    return;
                }
                else
                {
                    CheckNearBy(visited, arr,nn,nums);
                    return;
                }
            }

            for (int i = start; i < n; i++)
            {
                visited[i] = true;
                Combination(nums, visited, i + 1, r - 1,arr,nn);
                if(answer!=0 && flag)
                    return;
                visited[i] = false;
            }
        }
        static void CheckNearBy(bool[] visited,List<List<int>> arr,int nn,List<(int,int)> nums)
        {
            List<(int,int)> family = new List<(int, int)>();

            int n = visited.Count(x=>x==true);

            for(int i =0;i<visited.Length;i++)
                if(visited[i])
                    family.Add(nums[i]);
            if((family.Max(x=>x.Item1)-family.Min(x=>x.Item1)+1)*(family.Max(x=>x.Item2)-family.Min(x=>x.Item2)+1)>maximum[nn])
                return;
            int[] line = new int[n];
            for(int i =0;i<n;i++)
                line[i] = i;

            for(int i =0;i<n;i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        if ((family[i].Item1 == family[j].Item1 && Math.Abs(family[i].Item2 - family[j].Item2) == 1&& line[i]!=line[j])
                        ||(family[i].Item2 == family[j].Item2 && Math.Abs(family[i].Item1 - family[j].Item1) == 1&& line[i]!=line[j]))
                        {
                            int min = line[i]<line[j] ? line[i] : line[j];
                            int max = line[i]>line[j] ? line[i] : line[j];
                            for(int k=0;k<n;k++)
                            {
                                if(line[k]==max)
                                    line[k] = min;
                            }
                            if(line.Sum()==0)
                            {
                                answer= sum(arr,visited,nums);
                            }
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            string[] line = Console.ReadLine().TrimEnd().Split(' ');
            
            int H = int.Parse(line[0]);
            int W = int.Parse(line[1]);
            int N = int.Parse(line[2]);
            
            List<List<int>> arr = new List<List<int>>();
            for (int i = 0; i < H; i++)
            {
                List<int> ar =new List<int>(); 
                string lin = Console.ReadLine().TrimEnd();
                for(int j=0;j<W;j++)
                {
                    ar.Add(lin[j]-'0');
                }
                arr.Add(ar);
            }
            for(int i =0;i<H;i++)
            {
                for(int j =0;j<W;j++)
                    Console.Write(arr[i][j]+" ");
                Console.WriteLine();
            }
            Console.WriteLine(N);
            Console.WriteLine(solution(H, W, N, arr));
        }
    }
}
~~~