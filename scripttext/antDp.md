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
        public static int[] d =new int[101];
    }
   
    class Program
    {       
        public static void Main()
        {
            
            m = int.Parse(ReadLine());
            string k_ = ReadLine();
            string[] k__ = k_.Split('\x020');
            int[] k=new int[m];
            for(int i=0; i<m;i++)
            {
                k[i]=int.Parse(k__[i]);
            }
            
            Write(dp(k,m));

        }
        public static int dp(int[] a, int x)
        {

            d[0]=a[0];
            d[1]=max(d[0],a[1]);
            for(int i=2;i<x;i++)
            {
                d[i]=max(d[i-1],d[i-2]+a[i]);
            }
            return d[x-1];
            
        }
        public static int max(int a, int b)
        {
            if(a>b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
    
}
~~~