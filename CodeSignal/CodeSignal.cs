using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Policy;
//https://app.codesignal.com/profile/nerses_h_kdd

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

        //Some people are standing in a row in a park. There are trees between them which cannot be moved.
        //Your task is to rearrange the people by their heights in a non-descending order without moving the trees.
        //People can be very tall!
        public int[] RearrangePeopleByHeight(int[] a)
        {

            List<int> peopleHeights = new List<int>();
            List<int> positions = new List<int>();

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != -1)
                {
                    peopleHeights.Add(a[i]);
                    positions.Add(i);
                }
            }

            CountigSort(ref peopleHeights);

            int currentIndex = 0;

            for (int i = 0; i < positions.Count; ++i)
            {
                a[positions[i]] = peopleHeights[currentIndex++];
            }

            return a;
        }

        private void CountigSort(ref List<int> inputArray)
        {
            if (inputArray.Count <= 1)
            {
                return;
            }

            int max = inputArray.Max();
            int min = inputArray.Min();

            int[] counts = new int[max - min + 1];
            int[] res = new int[inputArray.Count];

            for (int i = 0; i < inputArray.Count; ++i)
            {
                ++counts[inputArray[i] - min];

            }

            int k = 0;
            for (int i = 0; i < counts.Length; ++i)
            {
                while (counts[i] != 0)
                {
                    res[k++] = i + min;
                    --counts[i];
                }
            }
            inputArray = res.ToList();
        }


        //Write a function that reverses characters in (possibly nested) parentheses in the input string.
        //Input strings will always be well-formed with matching()s.
        public string ReverseInParentheses(string inputString)
        {
            Stack<int> st = new Stack<int>();

            for (int i = 0; i < inputString.Length; ++i)
            {
                if (inputString[i] == '(')
                {
                    st.Push(i);
                }
                else if (inputString[i] == ')')
                {
                    char[] A = inputString.ToCharArray();
                    ReverseString(ref A, st.Peek() + 1, i);
                    inputString = new string(A);
                    st.Pop();
                }

            }
            string res = "";
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] != ')' && inputString[i] != '(')
                {
                    res += string.Format("{0}", inputString[i]);

                }
            }
            return res;
        }

        void ReverseString(ref char[] A, int l, int h)
        {
            if (l < h)
            {
                char ch = A[l];
                A[l] = A[h];
                A[h] = ch;
                ReverseString(ref A, l + 1, h - 1);
            }
        }

        //Several people are standing in a row and need to be divided into two teams. The first person goes into team 1,
        //the second goes into team 2, the third goes into team 1 again, the fourth into team 2, and so on.
        //You are given an array of positive integers - the weights of the people.Return an array of two integers, where the first element is the total weight of team 1,
        //and the second element is the total weight of team 2 after the division is complete.
        public int[] DivideIntoTeams(int[] a)
        {
            int res2 = 0;
            int res1 = 0;

            for (int i = 1; i < a.Length; i += 2)
            {
                res2 += a[i];
                res1 += a[i - 1];
            }
            if (a.Length % 2 != 0)
            {
                res1 += a.Last();
            }
            int[] res = { res1, res2 };
            Console.WriteLine(res1 + " " + res2);
            return res;
        }


        //Given a rectangular matrix of characters, add a border of asterisks(*) to it.
        public  string[] AddBorder(string[] picture)
        {
            int m = picture[0].Length;
            string addElement = "";

            for (int i = 0; i < m + 2; ++i)
            {
                addElement += "*";
            }
            string[] result = new string[picture.Length + 2];

            result[0] = addElement;

            for (int i = 0; i < picture.Length; ++i)
            {
                result[i + 1] = string.Format("*{0}*", picture[i]);
            }

            result[result.Length - 1] = addElement;


            return result;
        }

        // Two arrays are called similar if one can be obtained from another by
        // swapping at most one pair of elements in one of the arrays.
        // Given two arrays a and b, check whether they are similar.

        public bool AreArraysSimilar(int[] a, int[] b)
        {
            int count = 0;

            if (a.Length != b.Length)
            {
                return false;
            }

            int max = a[0];

            if (a.Max() != b.Max())
            {
                return false;

            }
            else
            {
                max = a.Max();
            }


            int[] countsA = new int[max + 1];
            int[] countsB = new int[max + 1];

            for (int i = 0; i < a.Length; ++i)
            {
                ++countsA[a[i]];
                ++countsB[b[i]];
                if (a[i] != b[i])
                {
                    ++count;
                }
            }
            for (int i = 0; i < countsA.Length; ++i)
            {
                if (countsA[i] != countsB[i])
                {
                    return false;
                }
            }

            if (count > 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // You are given an array of integers. On each move you are allowed to increase exactly one of its element by one.
        // Find the minimal number of moves required to obtain a strictly increasing sequence from the input.
        public int MinMovesForStrictlyIncreasing(int[] inputArray)
        {
            int count = 0;
            for (int i = 1; i < inputArray.Length; ++i)
            {

                if (inputArray[i - 1] >= inputArray[i])
                {
                    int diff = inputArray[i - 1] - inputArray[i] + 1;
                    count += diff;
                    inputArray[i] = inputArray[i - 1] + 1;
                }
            }

            return count;
        }
        // Given a string, find out if its characters can be rearranged to form a palindrome.
        // CanFormPalindrome
        public bool CanFormPalindrome(string inputString)
        {

            Dictionary<char, int> charFreq = new Dictionary<char, int>();

            for (int i = 0; i < inputString.Length; ++i)
            {

                if (charFreq.ContainsKey(inputString[i]))
                {
                    ++charFreq[inputString[i]];
                }
                else
                {
                    charFreq.Add(inputString[i], 1);
                }

            }

            int odd = 0;

            foreach (int value in charFreq.Values)
            {
                if ((value & 1) == 1)
                {
                    ++odd;
                }

                if (odd > 1)
                {
                    return false;
                }

            }
            return true;
        }
        // Call two arms equally strong if the heaviest weights they each are able to lift are equal.
        // Call two people equally strong if their strongest arms are equally strong
        // (the strongest arm can be both the right and the left), and so are their weakest arms.
        // Given your and your friend's arms' lifting capabilities find out if you two are equally strong.
        public bool AreEquallyStrong(int yourLeft, int yourRight, int friendsLeft, int friendsRight)
        {
            int yourStrongest = Max(yourLeft, yourRight);
            int yourWeakest = Min(yourLeft, yourRight);

            int friendStrongest = Max(friendsLeft, friendsRight);
            int friendWeakest = Min(friendsLeft, friendsRight);

            return yourStrongest == friendStrongest && yourWeakest == friendWeakest;

        }

        int Max(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;
        }

        int Min(int a, int b)
        {
            if (a < b)
                return a;
            else
                return b;
        }

        // Given an array of integers, find the maximal absolute difference between any two of its adjacent elements.
        public int MaxAdjacentDifference(int[] inputArray)
        {
            int min = inputArray[0] - inputArray[1];


            for (int i = 1; i < inputArray.Length; ++i)
            {

                if (Math.Abs(inputArray[i] - inputArray[i - 1]) > min)
                {
                    min = Math.Abs(inputArray[i] - inputArray[i - 1]);
                }
            }

            return min;

        }

        // An IP address is a numerical label assigned to each device (e.g., computer, printer)
        // participating in a computer network that uses the Internet Protocol for communication.
        // There are two versions of the Internet protocol, and thus two versions of addresses.
        // One of them is the IPv4 address.
        // Given a string, find out if it satisfies the IPv4 address naming rules.
        public bool IsValidIPv4Address(string inputString)
        {
            string[] segments = inputString.Split('.');

            if (segments.Length != 4)
                return false;

            foreach (string segment in segments)
            {
                if (!int.TryParse(segment, out int value) || value < 0 || value > 255 || segment != value.ToString())
                    return false;
            }

            return true;
        }

        // You are given an array of integers representing coordinates of obstacles situated on a straight line.
        // Assume that you are jumping from the point with coordinate 0 to the right.You are allowed only
        // to make jumps of the same length represented by some integer.
        // Find the minimal length of the jump enough to avoid all the obstacles.

        public int AvoidObstacles(int[] inputArray)
        {
            HashSet<int> myWay = new HashSet<int>();

            myWay.Add(inputArray[0]);

            int max = inputArray[0];

            for (int i = 1; i < inputArray.Length; ++i)
            {
                myWay.Add(Math.Abs(inputArray[i] - inputArray[i - 1]));
                max = Math.Max(max, inputArray[i]);

            }

            for (int i = 1; i < max; ++i)
            {
                bool divs = inputArray.Any(x => x % i == 0);
                if (!divs) return i;
            }

            return max + 1;


        }


        

        // Last night you partied a little too hard. Now there's a black and
        // white photo of you that's about to go viral! You can't let this ruin your reputation,
        // so you want to apply the box blur algorithm to the photo to hide its content.
        // The pixels in the input image are represented as integers.The algorithm distorts the input image in the following way: Every pixel x in the output image has a value equal to the average value of the pixel values from the 3 × 3 square that has its center at x, including x itself.All the pixels on the border of x are then removed.
        // Return the blurred image as an integer, with the fractions rounded down.

         public int[][] ApplyBoxBlur(int[][] image)
         { 
            int row = image.Length;
            int col = image[0].Length;

            int rowRes = row - 2;
            int colRes = col - 2;

            int[][] blurredImage = new int[rowRes][];

            for (int i = 0; i < rowRes; i++)
            {
                blurredImage[i] = new int[colRes];

                for (int j = 0; j < colRes; j++)
                {
                    int[][] subMatrix = GetSubMatrix(image, i, j);
                    blurredImage[i][j] = GetAverage(subMatrix);
                }
            }

            return blurredImage; ;
        }

        private int[][] GetSubMatrix(int[][] matrix, int rowIndex, int colIndex)
        {
            int[][] subMatrix = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                subMatrix[i] = new int[3];
                for (int j = 0; j < 3; j++)
                {
                    subMatrix[i][j] = matrix[rowIndex + i][colIndex + j];
                }
            }
            return subMatrix;
        }

        private int GetAverage(int[][] matrix)
        {
            int totalSum = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    totalSum += matrix[i][j];
                }
            }
            return totalSum / 9;
        }

        
        //In the popular Minesweeper game you have a board with some mines and those cells that
        //don't contain a mine have a number in it that indicates the total number of mines in the neighboring cells.
        //Starting off with some arrangement of mines we want to create a Minesweeper game setup.
        public int[][] Minesweeper(bool[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            int[][] hintsMatrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                hintsMatrix[i] = new int[cols];
            }

            int[] dr = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dc = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i][j])
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            int newRow = i + dr[k];
                            int newCol = j + dc[k];

                            if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                            {
                                ++hintsMatrix[newRow][newCol];
                            }
                        }
                    }
                }
            }

            return hintsMatrix;
        }
    }
}



