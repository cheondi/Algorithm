~~~ cs
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public static int[] solution(int[] prices) 
    {
        int[] answer = new int[prices.Length];
        for(int i =0;i<prices.Length;i++)
        {
            for(int j=i+1;j<prices.Length;j++)
            {
                answer[i]++;
                if(prices[i]>prices[j])
                    break;
            }
        }
        return answer;
    }
    public static void Main(string[] args)
    {
        int[] k =new int[] {1, 2, 3, 2, 3};	
        for(int i =0;i<5;i++)
            Console.WriteLine(solution(k)[i]);
    }
}
~~~