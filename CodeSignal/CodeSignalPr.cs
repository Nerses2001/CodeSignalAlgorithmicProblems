using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodeWrithing.CodeSignal
{
    class CodeSignalPr
    {
        // Given an array of integers, replace all the occurrences of elemToReplace with substitutionElem.
        public int[] ReplaceElements(int[] inputArray, int elemToReplace, int substitutionElem)
        {
            for (int i = 0; i < inputArray.Length; ++i)
            {
                if (inputArray[i] == elemToReplace)
                {
                    inputArray[i] = substitutionElem;
                }
            }
            return inputArray;
        }
        //Check if all digits of the given integer are even.

        public bool AreAllDigitsEven(int n)
        {
            while (n != 0)
            {
                int digit = n % 10;
                if (digit % 2 != 0)
                {
                    return false;
                }
                n /= 10;
            }
            return true;
            /*string digits = number.ToString();
            foreach (char digit in digits)
            {
                if (int.Parse(digit.ToString()) % 2 != 0)
                {
                    return false;
                }
            }
            return true;*/
        }

        //Correct variable names consist only of English letters, digits and underscores and they can't start with a digit.
        //Check if the given string is a correct variable name.

        public bool IsCorrectVariableName(string name)
        {

            string pattern = @"^[a-zA-Z_][a-zA-Z0-9_]*$";

            bool isMatch = Regex.IsMatch(name, pattern);

            return isMatch;
        }

        //Given a string, your task is to replace each of
        //its characters by the next one in the English alphabet; i.e. replace a with b, replace b with c,
        //etc (z would be replaced by a).
        public string ReplaceWithNextAlphabetCharacter(string inputString)
        {
            char[] result = new char[inputString.Length];
            for (int i = 0; i < inputString.Length; i++)
            {
                char currentChar = inputString[i];
                char nextChar;

                if (currentChar == 'z')
                {
                    nextChar = 'a';
                }  
                else if (char.IsLetter(currentChar))
                {
                    nextChar = (char)(currentChar + 1);
                }
                else
                {
                    nextChar = currentChar;
                }

                result[i] = nextChar;
            }
            return new string(result);
        }

        //Given two cells on the standard chess board, determine whether they have the same color or not.
        public bool AreCellsSameColor(string cell1, string cell2)
        {
            if ((int)cell1[0] % 2 == (int)cell1[1] % 2 && (int)cell2[0] % 2 == (int)cell2[1] % 2)
            {
                return true;
            }
            else if ((int)cell1[0] % 2 != (int)cell1[1] % 2 && (int)cell2[0] % 2 != (int)cell2[1] % 2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        // FindOppositeNumber
        // Consider integer numbers from 0 to n - 1 written down along the circle in such a way
        // that the distance between any two neighboring numbers is equal (note that 0 and n - 1 are neighboring, too).
        // Given n and firstNumber, find the number which is written in the radially opposite position to firstNumber.
        public int FindOppositeNumber(int n, int firstNumber)
        {
            return (firstNumber + n / 2) % n;
        }

        // You have deposited a specific amount of money into your bank account.
        // Each year your balance increases at the same growth rate.
        // With the assumption that you don't make any additional deposits,
        // find out how long it would take for your balance to pass a specific threshold.
        public int CalculateTimeToReachThreshold(int deposit, int rate, int threshold)
        {
            double dep = deposit;
            int k = 0;
            while (dep < threshold)
            {
                dep = dep + dep * rate / 100;
                ++k;
            }
            return k;
        }

        // Given a sorted array of integers a, your task is to determine which element of a is closest to all other values of a.
        // In other words, find the element x in a, which minimizes the following sum
        // abs(a[0] - x) + abs(a[1] - x) + ... + abs(a[a.length - 1] - x)
        //(where abs denotes the absolute value) If there are several possible answers, output the smallest one.

        public int FindMinimumSum(int[] a)
        {
            int n = a.Length;
            int minSum = int.MaxValue;
            int minElement = -1;

            for (int i = 0; i < n; i++)
            {
                int sum = 0;

                for (int j = 0; j < n; j++)
                {
                    sum += Math.Abs(a[i] - a[j]);
                }

                if (sum < minSum)
                {
                    minSum = sum;
                    minElement = a[i];
                }
            }

            return minElement;
        }

    }
}
