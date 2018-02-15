using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution {
    
     public int Solution1(int[] A) {
         // write your code in C# 6.0 with .NET 4.5 (Mono)
        
         for(int i =1; i<10; i++)
         {
             Console.WriteLine("Writing: " +i);
             if (Array.Exists(A, x => x == i))
             {
                continue;
             }
             return i;
         }
         return 11;
     }
}