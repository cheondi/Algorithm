~~~ cs
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
        public static int[] d =new int[10001];
    }
    class Program
    {       
        public static void Main()
        {
            m = int.Parse(ReadLine());
            Write(fibonacci(m));
            
        }
        public static int fibonacci(int x)
        {

            if(x==1||x==2)
            {
                return 1;
            }

            if(d[x]!=0)
            {
                return d[x];
            }
            
            d[x]= fibonacci(x-1)+fibonacci(x-2);
            return d[x];
            
        }
    }
    
}
~~~