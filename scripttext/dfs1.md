~~~ cs
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace consoleapp1
{
    class Program
    {
        public int n;
        public int m;
        public int[,] array;
        static void Main(string[] args)
        {
            
            string str=Console.ReadLine();
            string[] hello = str.Split('\x020');
            int n = int.Parse(hello[0]);
            int m = int.Parse(hello[1]);

            int[,] array = new int[n,m]; 
            for(int i=0;i<n;i++)
            {
                string num =Console.ReadLine();
                for(int j=0;j<m;j++)
                {
                    array[i,j]=int.Parse(num.Substring(j,1));
                }
            }

            int result =0;

            for(int i=0;i<n;i++)
            {
                for(int j=0;j<m;j++)
                {
                    if(dfs(i,j)==true)
                    {
                        result+=1;
                    }
                }
            }
            Console.WriteLine(result);
        
        
            bool dfs(int x,int y)
            {
                if(x<=-1||x>n||y<=-1||y>=m)
                {
                    return false;
                }
                if(array[x,y]==0)
                {
                    array[x,y]=1;
                    dfs(x-1,y);
                    dfs(x,y-1);
                    dfs(x+1,y);
                    dfs(x,y+1);
                    return true;
                }
                return false;
            }
        }
        
    }
}
~~~