~~~ cs
using System.Collections;
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
    public class Reversecomparer : IComparer
    {
        edges[] edge = new edges[m+1];
        int IComparer.Compare(Object _x , Object _y)
        {
            edges x = (edges)_x;
            edges y = (edges)_y;
            return x.dist.CompareTo(y.dist);
        }
    }
    public class Global
    {
        public static int n , m;
        public static int a , b;
        public static int k ,x;

        public static int[] parent;

        public struct edges
        {   
            public int src;
            public int dest;
            public int dist;

            public edges(int _src,int _dest,int _dist){src=_src;dest=_dest;dist=_dist;}
            
        }

        
        //public static int[,] graph = new int[n,n];
    }
   
    class Program
    {       
        public static void Main()
        {
            
             
            string read = ReadLine();
            string[] read1 = read.Split('\x020');
            n=int.Parse(read1[0]);
            m=int.Parse(read1[1]);

            edges[] edge = new edges[m+1];
            parent =new int[n+1];
            IComparer mycomparer = new Reversecomparer();

            for(int i=1; i <n+1;i++)
            {
                parent[i]= i;
            }

            for(int i=1;i<m+1;i++)
            {
                read =ReadLine();
                read1 = read.Split('\x020');
                edge[i].src = int.Parse(read1[0]);
                edge[i].dest = int.Parse(read1[1]);
                edge[i].dist = int.Parse(read1[2]);
            }
            Array.Sort(edge,mycomparer);
            int result = 0;
            for(int i=1;i<edge.Length;i++)
            {
                if(find_parent(edge[i].src)!=find_parent(edge[i].dest))
                {
                    union_parent(edge[i].src,edge[i].dest);
                    result+=edge[i].dist;
                } 
            }
            WriteLine(result);
        }
        public static int find_parent(int x)
        {
            if(parent[x]!= x)
            {
                parent[x] = find_parent(parent[x]);
            }
            return parent[x];
        }
        public static void union_parent(int a, int b)
        {
            a=find_parent(a);
            b=find_parent(b);
            if(a<b)
            {
                parent[b]=a;
            }
            else
            {
                parent[a] =b;
            }

        }
    }
}
~~~
    
