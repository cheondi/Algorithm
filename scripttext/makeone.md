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
        public static int[] d =new int[30001];
    }
    class Program
    {       
        public static void Main()
        {
            
            m = int.Parse(ReadLine());
            Write(makeone(m));
            
        }
        public static int makeone(int x)
        {
            int[] number =new int[2];
            for(int i=2;i<x+1;i++)
            {
                d[i]=d[i-1]+1;
                if(i%2 == 0)
                {
                    number[0]=d[i];
                    number[1]=d[i/2]+1;
                    d[i]=number.Min();
                }
                if(i%3==0)
                {
                    number[0]=d[i];
                    number[1]=d[i/3]+1;
                    d[i]=number.Min();
                }
                if(i%5==0)
                {
                    number[0]=d[i];
                    number[1]=d[i/5]+1;
                    d[i]=number.Min();
                }
            }
            return d[x];
            
        }
    }
    
}
~~~