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
        public static int m;
        public static int[] d =new int[1001];
    }
   
    class Program
    {       
        public static void Main()
        {
            
            m = int.Parse(ReadLine());
            
            Write(dp(m));
        }
        public static int dp(int x)
        {
            d[0]=0;
            d[1]=1;
            d[2]=3;
            for(int i=3;i<x+1;i++)
            {
                d[i]=d[i-1]+2*d[i-2];
            }
            return d[x];
        }
        /*public static int max(int a, int b)
        {
            
        }*/
    }
    
}
~~~