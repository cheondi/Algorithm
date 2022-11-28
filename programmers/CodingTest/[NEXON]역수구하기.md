~~~ cs
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{
    public static void reciprocal(int N)
    {
        List<int> m = new List<int>();
        List<int> n = new List<int>();
        int now = 10;
        string zero = "0.";
        int index=0;
        
        while (true)
        {
            if (n.Contains((now%N) *10))
            {
                if(now/N==0)
                {
                    index = n.FindIndex(x=>x==(now%N) *10);
                }
                else
                {
                    m.Add(now / N);
                    index = n.FindIndex(x => x == (now % N) * 10)+1;
                }
                break;
            }
            else
            {
                m.Add(now / N);
                n.Add((now%N) *10);
                now = (now%N) *10;
            }
            if(now==0)
            {
                m.Add(0);
                index = n.FindIndex(x=>x==0)+1;
                break;
            }
        }
        
        List<string> strings = m.ConvertAll<string>(x => x.ToString());
        if(m.Count()-index==1 && m[index]!=0)
            Console.Write(zero + m[index] + " ");
        else
            Console.Write(zero + String.Join(null, strings) + " ");
        
        for (int i = index; i < m.Count(); i++)
        {
            Console.Write(m[i]);
        }

    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int N = 9; 
        //53 0188679245283
        //67 014925373134328358208955223880597
        //92 0869565217391304347826
        //56 857142
        Result.reciprocal(N);
    }
}
~~~