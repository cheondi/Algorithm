~~~ cs
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public static int solution(int[] citations) 
    {
        List<int> answer = new List<int>();
        for(int i =0;i<=citations.Length;i++)
        {
            if(citations.Count(x=>x>=i)>=i)
            {
                answer.Add(i);
                Console.WriteLine(i);
            }
        }
        return answer.Max();
    }
    public static void Main(string[] args)
    {
        int[] citations = new int[] {3,0,6,1,5};
        Console.WriteLine(solution(citations));
    }
}