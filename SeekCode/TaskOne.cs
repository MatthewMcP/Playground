using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class SolutionOne {
    public int solutionTaskOne(int N) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

        Random random = new Random();

        //Not Greater than 10^9 but can be 10^9
        int max = 1000000001;
        
        //Greater than N but less than max
        int randomNumber = random.Next(N+1, max);
        Console.WriteLine("Random Number within Range: " + randomNumber);

        //If result is 10 or less return 10 to fulfil requirements. "10" could be changed.
        if (randomNumber <= 10)
        {
            return 10;
        }

        //Ensuring it ends with 0 
        var lastDigit = randomNumber % 10;
        var zeroEndingNumber = randomNumber - lastDigit;
        Console.WriteLine("Random Number ending with 0: " + zeroEndingNumber);

        return zeroEndingNumber;


    }
}