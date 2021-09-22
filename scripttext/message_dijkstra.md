~~~ cs
using System.Globalization;
using System;
using static System.Console;
using static consoleapp1.Global;
using static consoleapp1.max_heap;
using static consoleapp1.Program;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace consoleapp1
{
    public class Global
    {
        public static int n , m, c;
        public static int x , y, z;
        //public static int k ,x;
        public static int[,] graph = new int[n,n];
        public const int INF = 987654321;
        public static int[,] position =new int[30001,30001];
        public static int[] distance = Enumerable.Repeat<int>(INF,30001).ToArray<int>();
    }

    class Program
    {       
        public static void Main()
        {
            
            string read = ReadLine();
            string[] read1 = read.Split('\x020');
            n = int.Parse(read1[0]);
            m = int.Parse(read1[1]);
            c = int.Parse(read1[2]);
            for(int i=0;i<m;i++)
            {
                string read3 = ReadLine();
                string[] read2 = read3.Split('\x020');
                x = int.Parse(read2[0]);
                y = int.Parse(read2[1]);
                z = int.Parse(read2[2]);

                position[x,y]=z;
            }
            dijkstra(c);
            int cnt =0;
            int max_distance =0;
            for(int i=1;i<n+1;i++)
            {
                WriteLine(distance[i]);
                if(distance[i]<INF)
                {
                    cnt+=1;
                    int max = distance[i];
                    if(max > max_distance)
                    {
                        max_distance= max; 
                    } 
                }
            
            }
            WriteLine(cnt-1 +" "+  max_distance);

        }

        public static void dijkstra(int start)
        {
            push(0,start,-position[0,start]);
            distance[start] = 0;
            while(heap_size!=0)
            {
                var temp = pop();
                int dist = temp.Item1;
                int now = temp.Item3;

                if(distance[now]<dist)
                {
                    continue;
                }
                for(int i =1; i<n+1;i++)
                {
                    if(position[now,i]>0)
                    {
                        int cost = dist + position[now,i];
                        if(cost<distance[i])
                        {
                            distance[i]=cost;
                            push(now,i,-distance[i]);
                        }
                    }
                }
            }
            
        }
    }

    
    public class max_heap
    {
        public static int[,] tree =new int[1000,3];
        public static int heap_size = 0;

        public static void push(int a, int b,int x)
        {
            heap_size+=1;
            
                tree[heap_size,0]=x;
                tree[heap_size,1]=a;
                tree[heap_size,2]=b;

                int i = heap_size;

                while(true)
                {
                    if(i==1)
                    {
                        break;
                    }
                    if(tree[i,0]>tree[i/2,0])
                    {
                        swap(ref tree[i,0],ref tree[i/2,0]);
                        swap(ref tree[i,1],ref tree[i/2,1]);
                        swap(ref tree[i,2],ref tree[i/2,2]);
                        i/=2;
                    }
                    else
                    {
                        break;
                    }
                    
                
                }
        }
        public static Tuple<int,int,int> pop()
        {
            if(heap_size == 0)
            {
                return new Tuple<int, int, int>(-1,-1,-1);
            }
            int item0 = tree[1,0];
            int item1 = tree[1,1];
            int item2 = tree[1,2];
            
            tree[1,0] = tree[heap_size,0];
            tree[1,1] = tree[heap_size,1];
            tree[1,2] = tree[heap_size,2];
            
            tree[heap_size,0]=0;
            tree[heap_size,1]=0;
            tree[heap_size,2]=0;

            heap_size-=1;
            int i=1;
            while(true)
            {
                if(tree[i,0]<tree[2*i,0])
                {
                    swap(ref tree[i,0],ref tree[i*2,0]);
                    swap(ref tree[i,1],ref tree[i*2,1]);
                    swap(ref tree[i,2],ref tree[i*2,2]);
                    i*=2;
                }
                else if(tree[i,0]<tree[2*i+1,0])
                {
                    swap(ref tree[i,0],ref tree[i*2+1,0]);
                    swap(ref tree[i,1],ref tree[i*2+1,1]);
                    swap(ref tree[i,2],ref tree[i*2+1,2]);
                    i*=2;
                }
                else
                {
                    i=1;
                    if(tree[i,0]>tree[2*i,0] && tree[i,0]>tree[2*i+1,0])
                    {
                        break;
                    }
                    else if(tree[2*i,0]==0 &&tree[2*i+1,0]==0)
                    {
                        break;
                    }
                }

            }
            
            return new Tuple<int, int, int> (item0,item1,item2);
        }
        public static void swap(ref int a,ref int b)
        {
            int temp = a; 
            a=b;
            b=temp;
        }
    }
}
~~~
    
