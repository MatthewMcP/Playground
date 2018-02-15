using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class SolutionFour {
    public int solutionTaskFour(string S) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

        var properPrefixArray = new string[S.Length];
        var properSuffixArray = new string[S.Length];

        for(int i =0; i < S.Length; i ++)
        {
            properPrefixArray[i] = S.Substring(0, i); 

            properSuffixArray[i] = S.Substring(S.Length-i, i); 
        }

        int longestSufPrefLength = 0;

        for(int i =0; i < S.Length; i ++)
        {
            for(int j =0; j < S.Length; j ++)
            {
                if (properPrefixArray[i].Equals(properSuffixArray[j]))
                {
                    if(properPrefixArray[i].Length > longestSufPrefLength)
                    {
                        longestSufPrefLength = properPrefixArray[i].Length;
                    }
                }
            }
        }

        return longestSufPrefLength;
    }
}