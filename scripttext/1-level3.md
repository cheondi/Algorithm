~~~ cs
using System.Security.Principal;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public static int[] solution(string[] genres, int[] plays) 
    {
        Dictionary<string,int> dic = new Dictionary<string, int>();
        List<int> answer = new List<int>();
        for(int i =0;i<genres.Length;i++)
        {
            if(dic.ContainsKey(genres[i]))
                dic[genres[i]] = dic[genres[i]] +plays[i];
            else
                dic.Add(genres[i],plays[i]);
        }
        var desc = dic.OrderByDescending(i=>i.Value);
        int index =0;
        foreach(var row in desc)
        {
            int max1= -1;
            int max2= -1;
            int swap = 0;
            for(int j=0;j<genres.Length;j++)
            {
                if(row.Key == genres[j])
                {
                    if(max1 ==-1 && max2 ==-1)
                    {
                        max1 = j;
                    }
                    else if(max1 != -1 && max2 ==-1)
                    {
                        if(plays[j]>plays[max1])
                        {
                            swap = max1;
                            max1 = j;
                            max2 = swap;
                        }
                        else
                        {
                            max2 = j;
                        }
                    }
                    else if(max1 != -1 && max2 !=-1)
                    {
                        if(plays[j]> plays[max1])
                        {
                            swap = max1;
                            max1 = j;
                            max2 = swap;
                        }
                        else if(plays[j]>plays[max2] &&plays[j]<=plays[max1])
                        {
                            max2 = j;
                        }
                    }
                }
            }
            answer.Add(max1);
            index+=1;
            if(max2 !=-1)
            {
                answer.Add(max2);
                index+=1;
            }
        }
        return answer.ToArray();
    }
    public static void Main(string[] args)
    {
        string[] i = new string[] {"classic", "pop", "classic", "classic", "pop"};
        int[] j = new int[] {500, 600, 150, 800, 2500};	
        for(int k=0; k<i.Length;k++)
            Console.WriteLine(solution(i,j)[k]);
    }
}
~~~