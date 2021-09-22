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

    public class heap
    {
        public static int[,] tree =new int[1000,3];
        public static int heap_size = 0;

        public static void add(int a, int b,int x)
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
                    if(tree[i,0]<tree[i/2,0])
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
                for(int j=1;j<10;j++)
                {
                    Write(tree[j,0]+" ");
                }
                WriteLine();
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
                if(tree[i,0]>tree[2*i,0] && tree[2*i,0]!=0)
                {
                    swap(ref tree[2*i,0],ref tree[i,0]);
                    swap(ref tree[2*i,1],ref tree[i,1]);
                    swap(ref tree[2*i,2],ref tree[i,2]);
                    i*=2;
                }
                else if(tree[i,0]>tree[2*i+1,0] && tree[2*i+1,0]!=0)
                {
                    swap(ref tree[2*i+1,0],ref tree[i,0]);
                    swap(ref tree[2*i+1,1],ref tree[i,1]);
                    swap(ref tree[2*i+1,2],ref tree[i,2]);
                    i=2*i+1;
                }
                else
                {
                    i=1;
                    if(tree[i,0]<tree[2*i,0] && tree[i,0]<tree[2*i+1,0])
                    {
                        break;
                    }
                    else if(tree[2*i,0]==0 ||tree[2*i+1,0]==0)
                    {
                        break;
                    }
                }

            }
            for(int j =1;j<10;j++)
            {
                Write(tree[j,0]+ " ");
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
   
    class Program
    {       
        public static void Main()
        {
             
            for(int i=0;i<9;i++)
            {
                m = int.Parse(ReadLine());
                heap.add(1,1,-m);
            }
            WriteLine("------------------------");
            for(int i=0;i<11;i++)
            {
                var result = heap.pop();
                WriteLine(-result.Item1);
            }

        }
    }
}
~~~
    
