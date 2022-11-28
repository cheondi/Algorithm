~~~ cs
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public static int[] solution(int[] array, int[,] commands) 
    {
        List<int> answer = new List<int>();
        for(int i =0; i<commands.Length/3;i++)
        {
            int[] newarray = new int[commands[i,1]-commands[i,0]+1];
            for(int j =commands[i,0]-1;j<=commands[i,1]-1;j++)
            { 
                newarray[j-(commands[i,0]-1)] = array[j];
            }
            Array.Sort(newarray);
            answer.Add(newarray[commands[i,2]-1]);
        }
        return answer.ToArray();
    }
    public static void Main(string[] args)
    {
        int[] array = new int[] {1, 5, 2, 6, 3, 7, 4};
        int[,] commands = new int[,]{{2, 5, 3}, {4, 4, 1}, {1, 7, 3}};
        foreach(var row in solution(array,commands))
            Console.WriteLine(row);
    }
}