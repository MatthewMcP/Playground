using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class SolutionThree {
    public int solutionTaskThree(int[] A) {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

        int? minDistance = null;
        for(int i =0 ; i < A.Length-1; i++)
        {
            var firstValue = A[i];
            //Console.WriteLine("firstValue: " + firstValue);

            var secondValue = A[i+1];    
            //Console.WriteLine("secondValue: " + secondValue);

            if(firstValue == secondValue)
            {
                //Lowest possible distance so I return
                return 0;
            }
            
            var adjacentFlag = true;
            int? newMinDistance = null;
            for(int j = 0 ; j <A.Length; j ++)
            {
                //Ensuring I don't check the first two numbers
                if(j==i || j == i+1)
                {
                    continue;   
                }
                
                var thirdValue = A[j];    
                //Console.WriteLine("third: " + thirdValue);

                if(firstValue < thirdValue && secondValue > thirdValue)
                {
                    //Console.WriteLine("Not Adjacent");
                    adjacentFlag = false;
                    break;
                }
                
                if(secondValue < thirdValue && firstValue > thirdValue)
                {
                    //Console.WriteLine("Not Adjacent");
                    adjacentFlag = false;
                    break;
                }

                var newDistace = Math.Abs(firstValue - secondValue);
                //Console.WriteLine("newDistace " + newDistace);

                if(!newMinDistance.HasValue || newMinDistance < newMinDistance.Value)
                {
                    newMinDistance = newDistace;
                }
            }

            if(adjacentFlag == false)
            {
                //first and second value are not adjacent0
                continue;
            }   
            else{
                if(!minDistance.HasValue || newMinDistance < minDistance.Value)
                {
                    minDistance = newMinDistance;
                }
            }
        }


        if(!minDistance.HasValue )
        {
            return -2;
        }
        
        if (minDistance > 100000000)
        {
            return -1;
        }

        return minDistance.Value;
    }
}