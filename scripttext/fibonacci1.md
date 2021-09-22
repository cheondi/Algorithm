~~~ cs
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace consoleapp1
{
    public class Program
    {
        static int fibonacci(int x)
        {
            if(x==1||x==2)
            {
                return 1;
            }
            else
            {
                return fibonacci(x-1)+fibonacci(x-2);
            }
        }
        public static void Main()
        {
            int m = int.Parse(Console.ReadLine());
            Console.Write(fibonacci(m));
        }
    }
    
}
~~~