﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace CodeWrithing.CodeSignal
{
    class CodeSignal
    {
        /*
             Given a year, return the century it is in. The first century spans from the year 1 up to and including the year 100,
             the second - from the year 101 up to and including the year 200, etc.
        */
        public int Solution(int year)
        {
            if (year % 100 == 0)
            {
                return year / 100;
            }
            else
            {
                return (year / 100) + 1;
            }
        }

        //Given the string, check if it is a palindrome.
        public bool Solution(string inputString)
        {
            int left = 0;
            int right = inputString.Length - 1;

            while (left < right)
            {
                if (inputString[left] != inputString[right])
                {
                    return false;
                }
                ++left;
                --right;
            }

            return true;


        }

        /*Given an array of integers, find the pair of adjacent elements that has the largest product and return that product.*/
        public int Solution(int[] inputArray)
        {
            int max = inputArray[0] * inputArray[1];
            for (int i = 1; i < inputArray.Length - 1; ++i)
            {

                if (inputArray[i] * inputArray[i + 1] > max)
                {
                    max = inputArray[i] * inputArray[i + 1];
                }

            }
            return max;
        }
        /*Below we will define an n-interesting polygon. Your task is to find the area of a polygon for a given n.
        A 1-interesting polygon is just a square with a side of length 1. An n-interesting polygon is obtained by 
        taking the n - 1-interesting polygon and appending 1-interesting polygons to its rim,
        side by side. You can see the 1-, 2-, 3- and 4-interesting polygons in the picture below.*/
        // n = 1      *

        // n = 2      *
        //           ***
        //            *
        public int Polygon(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            int a = n + n - 1;
            return a * a - (a * a / 2);
        }

        //Ratiorg got statues of different sizes as a present from CodeMaster for his birthday,
        //each statue having an non-negative integer size. Since he likes to make things perfect, he wants to arrange them from smallest to largest so that each statue will be bigger than the previous one exactly by 1. He may need some additional statues to be able to accomplish that.
        //Help him figure out the minimum number of additional statues needed.
        public int CodeMaster(int[] statues)
        {
            int max = statues.Max();
            int min = statues.Min();
            return max - min + 1 - statues.Length;
        }

        /*Given a sequence of integers as an array, determine whether it is possible to obtain a strictly increasing sequence 
         * by removing no more than one element from the array.
        Note: sequence a0, a1, ..., an is considered to be a strictly increasing if a0 < a1 < ... < an.
        Sequence containing only one element is also considered to be strictly increasing.*/
        public bool IsIncreasingSequence(int[] sequence)
        {
            int count = 0;

            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i] <= sequence[i - 1])
                {
                    count++;

                    if (count > 1)
                    {
                        return false;
                    }

                    if (i == 1 || sequence[i] > sequence[i - 2])
                    {
                        sequence[i - 1] = sequence[i];
                    }
                    else
                    {
                        sequence[i] = sequence[i - 1];
                    }
                }
            }

            return true;
        }

        /*After becoming famous, the CodeBots decided to move into a new building together.
         * Each of the rooms has a different cost, and some of them are free, but there's a rumour that all the free rooms
         * are haunted! Since the CodeBots are quite superstitious, 
         * they refuse to stay in any of the free rooms, or any of the rooms below any of the free rooms.
         Given matrix, a rectangular matrix of integers, 
        where each value represents the cost of the room, your task is to return the total sum of all 
        rooms that are suitable for the CodeBots (ie: add up all the values that don't appear below a 0)*/
        public int TotalSum(int[][] matrix)
        {
            int m = matrix[0].Length;
            int n = matrix.Length;
            int sum = 0;

            for (int i = 0; i < n - 1; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i + 1][j] = 0;
                    }
                }
            }
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    if (matrix[i][j] > 0)
                    {
                        sum += matrix[i][j];
                    }
                }
            }
            Console.WriteLine(sum);
            return sum;
        }


        public string[] GetLongestStrings(string[] inputArray)
        {
            int[] length = new int[inputArray.Length];


            for (int i = 0; i < inputArray.Length; ++i)
            {
                length[i] = inputArray[i].Length;
            }
            
            int max = length.Max();

            List<string> longestStrings = new List<string>();

            for (int i = 0; i < length.Length; ++i)
            {
                if (length[i] == max)
                {
                    longestStrings.Add(inputArray[i]);
                }
            }
            return longestStrings.ToArray();
        }

        //Given two strings, find the number of common characters between them.
        public int CountCommonCharacters(string s1, string s2)
        {

            int n1 = s1.Length;
            int n2 = s2.Length;

            int[] countS1 = new int[26];
            int[] countS2 = new int[26];

            int count = 0;

            for (int i = 0; i < n1; i++)
            {
                countS1[s1[i] - 'a']++;
            }

            for (int i = 0; i < n2; i++)
            {
                countS2[s2[i] - 'a']++;
            }

            for (int i = 0; i < 26; i++)
            {
                count += (Math.Min(countS1[i], countS2[i]));
            }
            return count;
        }

        //Ticket numbers usually consist of an even number of digits.
        //A ticket number is considered lucky if the sum of the first half of the digits
        //is equal to the sum of the second half.
        //Given a ticket number n, determine if it's lucky or not
        public static bool IsLuckyTicket(int n)
        {
            int ticketNumber = n;
            int length = 0;
            int temp = ticketNumber;

            while (temp != 0)
            {
                temp /= 10;
                length++;
            }

            int halfLength = length / 2;
            int firstHalfSum = 0;
            int secondHalfSum = 0;

            for (int i = 0; i < length; i++)
            {
                int digit = ticketNumber % 10;
                ticketNumber /= 10;

                if (i < halfLength)
                {
                    firstHalfSum += digit;
                }
                else
                {
                    secondHalfSum += digit;
                }
            }

            return firstHalfSum == secondHalfSum;
        }
    }

}



