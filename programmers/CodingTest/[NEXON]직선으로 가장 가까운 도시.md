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

    /*
     * Complete the 'closestStraightCity' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. STRING_ARRAY c
     *  2. INTEGER_ARRAY x
     *  3. INTEGER_ARRAY y
     *  4. STRING_ARRAY q
     */

    public static List<string> closestStraightCity(List<string> c, List<int> x, List<int> y, List<string> q)
    {
        const int MAX = 1000000001;
        List<string> results = new List<string>();

        Dictionary<int, Dictionary<string,(int,int)>> xindex = new Dictionary<int, Dictionary<string, (int, int)>>();
        Dictionary<int, Dictionary<string,(int,int)>> yindex = new Dictionary<int, Dictionary<string, (int, int)>>();
        
        Dictionary<int,List<(string,int)>> hashx = new Dictionary<int, List<(string, int)>>();
        Dictionary<int,List<(string,int)>> hashy = new Dictionary<int, List<(string, int)>>();
        
        Dictionary<string,(int,int)> cities = new Dictionary<string, (int, int)>();

        for(int i =0;i<c.Count;i++)
            cities.Add(c[i],(x[i],y[i]));

        List<int> xx = x;
        List<int> yy = y;

        bool xflag = false, yflag = false;

        if (xx.Count() == xx.Distinct().Count())
            xflag = true;
        if (yy.Count() == yy.Distinct().Count())
            yflag = true;
        
        for (int i = 0; i < q.Count; i++)
        {
            var city = cities[q[i]];
            int qx = city.Item1;
            int qy = city.Item2;
            
            
            Dictionary<string,(int, int)> sxi = new Dictionary<string, (int, int)>();
            Dictionary<string,(int, int)> syi = new Dictionary<string, (int, int)>();

            List<(string,int)> sx = new List<(string, int)>();
            List<(string,int)> sy = new List<(string, int)>();
 
            if (!xflag)
            {
                if (hashx.ContainsKey(qx))
                {
                    sx = hashx[qx];
                    sxi = xindex[qx];
                }
                else
                {
                    for (int j = 0; j < x.Count; j++)
                    {
                        if (x[j] == qx)
                            sx.Add((c[j],y[j]));
                    }
                    sx.Sort((x,y) =>x.Item2.CompareTo(y.Item2));
                    for(int j =0;j<sx.Count;j++)
                    {
                        sxi.Add(sx[j].Item1,(j,sx[j].Item2));
                    }
                    hashx.Add(qx, sx);
                    xindex.Add(qx,sxi);
                }
            }
            
            if (!yflag)
            {
                if (hashy.ContainsKey(qy))
                {
                    sy = hashy[qy];
                    syi = yindex[qy];
                }
                else
                {
                    for (int j = 0; j < y.Count; j++)
                    {
                        if (y[j] == qy)
                            sy.Add((c[j],x[j]));
                    }
                    sy.Sort((x,y)=>x.Item2.CompareTo(y.Item2));
                    for(int j=0;j<sy.Count;j++)
                    {
                        syi.Add(sy[j].Item1,(j,sy[j].Item2));
                    }
                    hashy.Add(qy, sy);
                    yindex.Add(qy,syi);
                }
            }

            int min1 = MAX;
            string name1 = "";

            int min2 = MAX;
            string name2 = "";

            if (sx.Count() > 1)
            {

                int index = sxi[q[i]].Item1; //index
                
                if (sx.Count() != 1 && index == 0)
                {
                    min1 = Math.Abs(sx[1].Item2 - qy);
                    name1 = sx[1].Item1;
                }
                else if (sx.Count() != 1 && index == sx.Count - 1)
                {
                    min1 = Math.Abs(sx[index - 1].Item2 - qy);
                    name1 = sx[index - 1].Item1;
                }
                else
                {
                    if (Math.Abs(sx[index - 1].Item2 - qy) > Math.Abs(sx[index + 1].Item2 - qy))
                    {
                        min1 = Math.Abs(sx[index + 1].Item2 - qy);
                        name1 = sx[index + 1].Item1;
                    }
                    else
                    {
                        min1 = Math.Abs(sx[index - 1].Item2 - qy);
                        name1 = sx[index - 1].Item1;
                    }
                }
            }
            if (sy.Count() > 1)
            {
                int index = syi[q[i]].Item1;
                
                if (sy.Count() != 1 && index == 0)
                {
                    min2 = Math.Abs(sy[1].Item2 - qx);
                    name2 = sy[1].Item1;
                }
                else if (sy.Count() != 1 && index == sy.Count - 1)
                {
                    min2 = Math.Abs(sy[index - 1].Item2 - qx);
                    name2 = sy[index - 1].Item1;
                }
                else
                {
                    if (Math.Abs(sy[index - 1].Item2 - qx) > Math.Abs(sy[index + 1].Item2 - qx))
                    {
                        min2 = Math.Abs(sy[index + 1].Item2 - qx);
                        name2 = sy[index + 1].Item1;
                    }
                    else
                    {
                        min2 = Math.Abs(sy[index - 1].Item2 - qx);
                        name2 = sy[index - 1].Item1;
                    }
                }
            }
            
            if (min1 == MAX && min2 == MAX)
            {
                results.Add("NONE");
            }
            else if (min1 == MAX && min2 != MAX)
            {
                results.Add(name2);
            }
            else if (min1 != MAX && min2 == MAX)
            {
                results.Add(name1);
            }
            else
            {
                if (min1 < min2)
                {
                    results.Add(name1);
                }
                else
                {
                    results.Add(name2);
                }
            }
        }
        return results;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        List<string> c = new List<string>();
        c.Add("a");
        c.Add("b");
        c.Add("c");

        List<int> x = new List<int>();
        x.Add(1);
        x.Add(10);
        x.Add(20);

        List<int> y = new List<int>();
        y.Add(1);
        y.Add(10);
        y.Add(10);

        List<string> q = new List<string>();
        q.Add("a");
        q.Add("b");
        q.Add("c");

        List<string> results = Result.closestStraightCity(c, x, y, q);
        foreach (var row in results)
            Console.WriteLine(row);

    }
}