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
        public static int n,m;
        public static int[] mn=new int[101];
        public static int[] d =Enumerable.Repeat<int>(10001,10000).ToArray<int>();
    }
   
    class Program
    {       
        public static void Main()
        {
            
            string read = ReadLine();
            string[] k = read.Split('\x020');
            n=int.Parse(k[0]);
            m=int.Parse(k[1]);
            for(int i=0;i<n;i++)
            {
                mn[i]=int.Parse(ReadLine());
            }
            Write(dp(m));
        }
        public static int dp(int x)
        {
            d[0]=0;
            
            for(int i=0;i<n;i++)
            {
                for(int j=mn[i];j<m+1;j++)
                {
                    if(d[j-mn[i]]!=10001)
                    {
                        d[j]=min(d[j],d[j-mn[i]]+1);
                    }
                }
            }
            if(d[x]==10001)
            {
                return -1;
            }
            else
            {
                return d[x];
            }    
            
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