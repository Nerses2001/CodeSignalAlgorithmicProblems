using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
        //Given a divisor and a bound, find the largest integer N such that:

        //N is divisible by divisor.
        //N is less than or equal to bound.
        //N is greater than 0.
        //It is guaranteed that such a number exists
        public int FindLargestNumber(int divisor, int bound)
        {
            if (bound % divisor == 0)
            {
                return bound;
            }
            else
            {
                return bound - bound % divisor;
            }
        }


        // One night you go for a ride on your motorcycle. At 00:00 you start your engine,
        // and the built-in timer automatically begins counting the length of your ride,
        // in minutes. Off you go to explore the neighborhood.
        // When you finally decide to head back, you realize there's a
        // chance the bridges on your route home are up, leaving you stranded! Unfortunately,
        // you don't have your watch on you and don't know what time it is. All you know thanks to
        // the bike's timer is that n minutes have passed since 00:00.
        // Using the bike's timer, calculate the
        // current time. Return an answer as the sum of digits that
        // the digital timer in the format hh:mm would show.
        public int CalculateCurrentTime(int n)
        {
            int hours = n / 60;
            int minutes = n % 60;

            string hoursStr = hours.ToString();
            string minutesStr = minutes.ToString();

            int hoursDigitSum = hoursStr.Sum(digit => int.Parse(digit.ToString()));
            int minutesDigitSum = minutesStr.Sum(digit => int.Parse(digit.ToString()));

            return hoursDigitSum + minutesDigitSum;
        }


        // Some phone usage rate may be described as follows:
        // first minute of a call costs min1 cents,
        // each minute from the 2nd up to 10th(inclusive) costs min2_10 cents
        // each minute after 10th costs min11 cents.
        // You have s cents on your account before the call.What is the duration of the
        // longest call (in minutes rounded down to the nearest integer) you can have?

        public int CalculateLongestCallDuration(int min1, int min2_10, int min11, int s)
        {
            if (s == min1)
            {
                return 1;
            }
            else if (s < min1)
            {
                return 0;
            }
            else if (s <= min1 + (min2_10 * 9))
            {
                return (s - min1) / min2_10 + 1;
            }
            else
            {
                int remainingBalance = s - (min1 + (min2_10 * 9));
                int additionalMinutes = remainingBalance / min11;

                return 10 + additionalMinutes;
            }

        }

        //You found two items in a treasure chest! The first item weighs weight1 and is worth value1,
        //and the second item weighs weight2 and is worth value2.
        //What is the total maximum value of the items you can take with you,
        //assuming that your max weight capacity is maxW and you can't come
        //back for the items later?
        //Note that there are only two items and you can't
        //bring more than one item of each type, i.e. you can't take two first items or two second items.
        
        public int KnapsackLight(int value1, int weight1, int value2, int weight2, int maxW)
        {
            var ret = 0;
            if (value1 > value2)
            {
                if (weight1 <= maxW)
                {
                    ret += value1;
                    maxW -= weight1;
                }
                if (weight2 <= maxW)
                {
                    ret += value2;
                    maxW -= weight2;
                }
            }
            else
            {
                if (weight2 <= maxW)
                {
                    ret += value2;
                    maxW -= weight2;
                }
                if (weight1 <= maxW)
                {
                    ret += value1;
                    maxW -= weight1;
                }
            }
            return ret;

        }

        // You're given three integers, a, b and c.
        // It is guaranteed that two of these integers are equal to each other.
        // What is the value of the third integer?
        public int FindThirdInteger(int a, int b, int c)
        {
            return a ^ b ^ c;
        }

        //In order to stop the Mad Coder evil genius you need to decipher the encrypted message he sent to his minions.
        //The message contains several numbers that, when typed into a supercomputer,
        //will launch a missile into the sky blocking out the sun, and making all the people on Earth grumpy and sad. 
        //You figured out that some numbers have a modified single digit in their binary representation.More specifically, in the given number n the kth bit from the right was initially set to 0, but its current value might be different.It's now up to you to write a function that will change the kth bit of n back to 0.
        public int KillKthBit(int n, int k)
        {
            return n & ~(1 << (k - 1));
        }
        //You are given an array of up to four non-negative integers, each less than 256.
        //Your task is to pack these integers into one number M in the following way:
        //The first element of the array occupies the first 8 bits of M;
        //The second element occupies next 8 bits, and so on.
        //Return the obtained integer M.
        //Note: the phrase "first bits of M" refers to the least significant bits of M - the right-most bits of an integer.
        public int PackArray(int[] a)
        {
            int M = 0;
            for (int i = 0; i < a.Length; i++)
            {
                M |= a[i] << (i * 8);
            }
            return M;
        }


        // You are given two numbers a and b where 0 ≤ a ≤ b. Imagine you construct an array of all the integers from a to b inclusive.
        // You need to count the number of 1s in the binary representations of all the numbers in the array.
        public int RangeBitCount(int a, int b)
        {
            int ret = 0;
            for (int i = a; i <= b; i++)
            {
                ret += Enumerable.Range(0, 4).Sum(d => (i & (1 << d)) >> d);
            }
            return ret;
        }

        // Reverse the order of the bits in a given integer.
       public  int ReverseBits(int a)
        {
            if (a == 0)
            {
                return 0;
            }

            string binary = string.Empty;

            while (a > 0)
            {
                int remainder = a % 2;
                binary = remainder + binary;
                a /= 2;
            }

            return BinaryToInt(binary);
        }
        public int BinaryToInt(string binary)
        {
            int result = 0;
            int power = 0;

            for (int i = 0; i < binary.Length; ++i)
            {
                int bit = binary[i] - '0';
                result += bit * (int)Math.Pow(2, power);
                power++;
            }

            return result;
        }

        public int ReverseBits1(int a)
        {
            int rev = 0;

            while (a > 0)
            {
                rev <<= 1;

                if ((int)(a & 1) == 1)
                    rev ^= 1;

                a >>= 1;
            }
            return rev;
        }
    }


}
