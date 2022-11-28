~~~ cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Solution
{
    public static long[] solution(int x, int n) {
        long[] answer = new long[n];
        for(long i =1;i<=n;i++)
            answer[i-1] = x*i;
        return answer;
    }


    public static void Main(string[] args)
    {
        int x=10000000 ,n=1000;
        long[] results = solution(x,n);
        foreach(var row in results)
            Console.WriteLine(row);
    }
}