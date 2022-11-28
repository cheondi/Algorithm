~~~ cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Solution
{
    public static string solution(string s) {
        string answer = "";
        for(int i=0;i<s.Length;i++)
        {
            if(i==0)
            {
                if(s[i] >='a')
                    answer+=(char)(s[i]-32);
                else
                    answer+= s[i];
            }
            else
            {
                if (s[i - 1] == ' ')
                {
                    if (s[i] > '9' && s[i] >= 'a')
                        answer += (char)(s[i] - 32);
                    else
                        answer += s[i];
                }
                else
                {
                    if(s[i]<='Z' && s[i] >='A')
                        answer+=(char)(s[i]+32);
                    else
                        answer+=s[i];
                    
                }
            }
        }
        return answer;
    }

    public static void Main(string[] args)
    {
        string s = "for the last week";
        Console.WriteLine(solution(s));
    }
}
