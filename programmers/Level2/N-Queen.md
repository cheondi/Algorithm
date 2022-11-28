~~~ cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Solution
{
    public static int answer = 0,n = 0;
    public static bool[] col = new bool[16];
    public static bool[] inc = new bool[31];
    public static bool[] dec = new bool[31];
    public static int solution(int nn) {
        n = nn;
        queen(1);
        return answer;
    }
    public static void queen(int r)
    {
        if (r > n)
        {
            answer++;
            return;
        }

        for (int i = 1; i <= n; i++)
        {
            if (!col[i] && !inc[r + i] && !dec[n + (r - i) + 1])
            {
                col[i] = inc[r + i] = dec[n + (r - i) + 1] = true;
                queen(r + 1);
                col[i] = inc[r + i] = dec[n + (r - i) + 1] = false;
            }
        }
    }
    
    public static void Main(string[] args)
    {
        Console.Write(solution(4));
    }
}
