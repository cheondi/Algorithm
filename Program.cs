using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

public class Solution 
{
    public static int solution(int numbers, int[,] computers) 
    {
        int answer = 0;
        bool[] visited = new bool[numbers];
        for(int i =0;i<numbers;i++)
        {
            if(!visited[i])
                answer +=SetFamily(i,computers,visited,numbers);
        }
        return answer ;
    }
    public static int SetFamily(int index, int[,] computers, bool[] visited,int num)
    {
        if(visited[index])
            return 0;
        visited[index] = true;
        for(int i =0; i<num;i++)
        {
            if(computers[index,i]==1)
                SetFamily(i,computers,visited,num);
        }
        return 1;
    }
    public static void Main(string[] args) 
    {
        int n =3;
        int[,] computers = new int[,]{{1, 1, 0}, {1, 1, 0}, {0, 0, 1}};
        
        
        Console.WriteLine(solution(n,computers));

    }
}