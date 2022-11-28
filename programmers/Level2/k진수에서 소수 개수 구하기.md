~~~ cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Solution
{
    public static int solution(int n, int k) {
        int answer = 0;
        if(k==10 && k ==8 && k==2 && k==4)
            number = Convert.ToString(n,k);
        else
            Dec2k(n, k);
        string[] spl = number.Split('0');
        foreach (var row in spl)
        {
            if (row.Length != 0)
            {
                if (row != "1" && prime(row))
                {
                    answer++;
                }
            }
        }
        return answer;
    }
    public static bool prime(string num)
    {
        long n = long.Parse(num);
        int nr = (int)Math.Sqrt(n); 
		for (int i = 2; i <= nr; i++) 
		{
			if (n % i == 0)
				return false; 
		} 
		return true; 
    }
    public static string number="";
    public static void Dec2k(int n, int k)
    {
        int num = n / k; 
        number = (n % k).ToString() + number;
        if (num >= k) 
            Dec2k(num, k);
        else 
            number = num.ToString() + number;
    }


    public static void Main(string[] args) 
    {
        int n =110011;
        int k =10;
        Console.WriteLine(solution(n,k));
    }
}
