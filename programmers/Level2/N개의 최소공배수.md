~~~ cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Solution
{
    public static int solution(int[] arr) {
        int n = arr[0];
        for(int i =1;i<arr.Length;i++)
            n = lcm(n,arr[i]);
        return n;
    }
    public static int lcm(int n, int m)
    {
        return (n*m) / gdc(n,m); 
    }
    public static int gdc(int n,int m)
    {
        while (m != 0)
        {
            int r = n % m;
            n = m;
            m = r;
        }
        return n;
    }


    public static void Main(string[] args)
    {
        int[] arr = new int[] {2,6,8,14};
        Console.WriteLine(solution(arr));
    }
}