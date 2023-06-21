using System;

using CodeWrithing.CodeSignal;

namespace CodeWrithing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CodeSignal.CodeSignal problemSolver = new CodeSignal.CodeSignal();

            int century = problemSolver.Solution(2023);
            Console.WriteLine("Century: " + century);

            bool isPalindrome = problemSolver.Solution("racecar");
            Console.WriteLine("Is Palindrome: " + isPalindrome);

            int[] array = { 1, 2, 3, 4, 5 };
            int maxProduct = problemSolver.Solution(array);
            Console.WriteLine("Max Product: " + maxProduct);

            int polygonArea = problemSolver.Polygon(3);
            Console.WriteLine("Polygon Area: " + polygonArea);


            Console.ReadLine();
        }
    }
}
