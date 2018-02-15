using System;

namespace SeekCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ///TaskFour
            var A = "Hello World dkjshflkjdsafhdsjfhipwasufhpsidoaufhnpdsoauifhjpdsauhfpidsufhdpsiufvhbciupsvdfnpoiusadfyhiweuphrfisndfoiudsjfp[osdijfposdif] Hello World";
            var solution = new SolutionFour();
            var B = solution.solutionTaskFour(A);
            Console.WriteLine("Result:" + B);

            Console.WriteLine("Finished");
            

            ///TaskThree
            //var A = new int[] {9, 7, 12};
            //var solution = new SolutionThree();
            //var B = solution.solutionTaskThree(A);
            //Console.WriteLine("Result:" + B);

            ///TaskTwo
            //var solution = new SolutionTwo();
            //var B = solution.solutionTaskTwo("J", "J");
            //Console.WriteLine("Result:" + B);

            ///TaskOne
            //int A = 9;
            //var solution = new SolutionOne();
            //var B = solution.solutionTaskOne(A);
            //Console.WriteLine(B);
            
            ///Demo
            //var A = new int[] {1, 3, 6, 4, 1, 2};
            //var solution = new Solution();
            //var B = solution.Solution1(A);
            //Console.WriteLine(B);
        }
    }
}
