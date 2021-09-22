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
     * Complete the 'countMoves' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts INTEGER_ARRAY numbers as parameter.
     */

    public static long countMoves(List<int> numbers)
    {
        long answer = 0;

        while(true)
        {
            if(numbers.Min() == numbers.Max())
                break;
            bool flag =false;
            for(int i =0;i<numbers.Count;i++)
            {
                if(numbers[i] == numbers.Max() && !flag)
                {
                    numbers[i]+=1;
                    flag =true;
                }
                else
                {
                    numbers[i]+=1;
                }
            }
            answer++;
        }

        return answer;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int numbersCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> numbers = new List<int>();

        for (int i = 0; i < numbersCount; i++)
        {
            int numbersItem = Convert.ToInt32(Console.ReadLine().Trim());
            numbers.Add(numbersItem);
        }

        long result = Result.countMoves(numbers);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
