using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class SolutionTwo {
    public int solutionTaskTwo(string A, string B) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

        //Number of times A wins
        var noOfAlexWins = 0;
        for(int i =0; i <A.Length; i ++)
        {
            var alexCardIntValue = getCardIntValue(A[i]);
            Console.WriteLine(alexCardIntValue);

            var bobCardIntValue = getCardIntValue(B[i]);
            Console.WriteLine(bobCardIntValue);

            if(alexCardIntValue > bobCardIntValue)
            {
                noOfAlexWins++;
            }
        }

        return noOfAlexWins;
    }

    public int getCardIntValue(char cardCharValue)
    {
        switch(cardCharValue) {
            case 'A'  :
                return 14;
            case 'K'  :
                return 13;
            case 'Q'  :
                return 12;
            case 'J'  :
                return 11;
            case 'T'  :
                return 10;
            case '2': 
            case '3': 
            case '4': 
            case '5': 
            case '6': 
            case '7': 
            case '8': 
            case '9': 
                int intResult = (int)Char.GetNumericValue(cardCharValue);
                return intResult;
            default : 
                throw new ArgumentException("Does not match assumptions 2-9,T,J,Q,K and/or A");
        }
    }
}