~~~ cs
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public static List<string> list = new List<string>();
    public static List<int> allnum = new List<int>();
    public static int solution(string numbers) 
    {
        int answer = 0;
        StringBuilder sb = new StringBuilder();
        char[] latter = new char[numbers.Length];
        for(int i =0;i<numbers.Length;i++)
        {
            latter[i] = numbers[i];
        }
        Perm(latter,0);
        foreach(var row in list)
        {
            StringCombination(row,sb,0);
        }
        foreach(var row in allnum)
        {
            Console.WriteLine(row);
            if(CheckPrime(row))
                answer++;
        }
        return answer;
    }
    public static void StringCombination(string s, StringBuilder sb, int index)
    {
        for (int i = index; i < s.Length; i++)
        {
            sb.Append(s[i]);
            //Console.WriteLine(sb.ToString());
            if(allnum.Contains(int.Parse(sb.ToString()))==false)
                allnum.Add(int.Parse(sb.ToString()));
            StringCombination(s, sb, i + 1);
            sb.Remove(sb.Length - 1, 1);
        }
    }
    public static bool CheckPrime(int num)
    {
        int cnt =0;
        if(num == 1)
            return false;
        if(num == 0)
            return false;
        for(int i =1;i<=num;i++)
        {
            if(num%i == 0)
                cnt++;
        }
        if(cnt ==2)
            return true;
        else
            return false;
    }
    public static void Perm(char[] a, int k)
    {
        if (k == a.Length - 1)
        {
            string result = "";
            for (int i = 0; i < a.Length; i++)
            {
                result= result+a[i];
            }
            list.Add(result);
        }
        else
        {
            for (int i = k; i < a.Length; i++)
            {
                char temp = a[k];
                a[k] = a[i];
                a[i] = temp;

                Perm(a, k + 1);
                temp = a[k];
                a[k] = a[i];
                a[i] = temp;
            }
        }
    }

    public static void Main(string[] args)
    {
        string numbers = "011";
        Console.WriteLine(solution(numbers));
    }
}
~~~