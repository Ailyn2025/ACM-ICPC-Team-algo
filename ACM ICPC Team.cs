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
     * Complete the 'acmTeam' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts STRING_ARRAY topic as parameter.
     */

    public static List<int> acmTeam(List<string> topic)
    {
        int n = topic.Count;
        int m = topic[0].Length;
        int[] numbers = new int[n];
        
        for (int i = 0; i < n; i++)
        {
        numbers[i] = Convert.ToInt32(topic[i], 2);
        }
        
        int maxTopics = 0;
        int teamCount = 0;
        
        for (int i = 0; i < n - 1; i++)
        {
        for (int j = i + 1; j < n; j++)
        {
            int combined = numbers[i] | numbers[j];
            int knownTopics = CountBits(combined);
            
            if (knownTopics > maxTopics)
            {
                maxTopics = knownTopics;
                teamCount = 1;
            }
            else if (knownTopics == maxTopics)
            {
                teamCount++;
            }
        }
    }
    
    return new List<int> { maxTopics, teamCount };
}

private static int CountBits(int n)
{
    int count = 0;
    while (n > 0)
    {
        count += n & 1;
        n >>= 1;
    }
    return count;
}

    }



class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<string> topic = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string topicItem = Console.ReadLine();
            topic.Add(topicItem);
        }

        List<int> result = Result.acmTeam(topic);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
