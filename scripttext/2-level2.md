~~~ cs
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public static int solution(int[] priorities, int location) 
    {
        int answer = 0;
        Queue<KeyValuePair<int,int>> que = new Queue<KeyValuePair<int, int>>();
        for(int i =0;i<priorities.Length;i++)
        {
            que.Enqueue(new KeyValuePair<int, int>(i,priorities[i]));
        }
        while(true)
        {
            int max = que.Max(i=>i.Value);
            var deque = que.Dequeue();
            if(deque.Value == max)
            {
                if(deque.Key == location)
                    return answer+1;
                else
                {
                    answer++;
                    continue;
                }   
            }
            else
            {
                que.Enqueue(deque);
            }
        }
    }
    public static void Main(string[] args)
    {
        int[] i = new int[] {8,1,1,1,2,2,2,8};
        int j = 3;	
        Console.WriteLine(solution(i,j));
    }
}
~~~