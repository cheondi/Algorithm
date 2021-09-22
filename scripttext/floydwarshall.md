~~~ cs
using System.Globalization;
using System;
using static System.Console;
using static consoleapp1.Global;
using static consoleapp1.Program;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace consoleapp1
{
    public class Global
    {
        public static int n , m;
        public static int a , b;
        public static int k ,x;

        //public static int[,] graph = new int[n,n];
    }
   
    class Program
    {       
        public static void Main()
        {
            string read = ReadLine();
            string[] read1 = read.Split('\x020');
            n = int.Parse(read1[0]);
            m = int.Parse(read1[1]);

            int[,] graph = new int[n,n];

            for(int i=0; i<n;i++)
            {
                for(int j=0;j<n;j++)
                {
                    if(i!=j)
                    {
                        graph[i,j]=987654321;
                    }
                }
            }

            for(int i=0;i<m;i++)
            {
                string read2 = ReadLine();
                string[] read3 = read2.Split('\x020');
                a = int.Parse(read3[0])-1;
                b = int.Parse(read3[1])-1;
                graph[a,b]=1;
                graph[b,a]=1;
            }

            string read4 = ReadLine();
            string[] read5 = read4.Split('\x020');
            x = int.Parse(read5[0])-1;
            k = int.Parse(read5[1])-1;

            for(int i=0;i<n;i++)
            {
                for(int j=0;j<n;j++)
                {
                    for(int o=0;o<n;o++)
                    {
                        graph[j,o]= min(graph[j,o],graph[j,i]+graph[i,o]);
                    }
                }
            }

            int distance = graph[0,k]+graph[k,x];

            if(distance>=987654321)
            {
                Write(-1);
            }
            else
            {
                Write(distance);
            }

            
            
        }
        public static int dp(int x)
        {
            return 0;
        }
        public static int min(int a, int b)
        {
            if(a>b)
            {
                return b;
            }
            else
            {
                return a;
            }
        }
        
    }
    
}
~~~