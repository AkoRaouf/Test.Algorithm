using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 3, 2};
            var res = solveEfficient(arr, 4);
            Console.ReadKey();
        }

        public static List<List<int>> solveEfficient(int[] arr, int targetSum)
        {
            List<List<int>> finalList = new List<List<int>>();
            try
            {
                Dictionary<int, int> tempList = new Dictionary<int, int>();
                int startIndex = 0, endIndex = 0;
                int currentSum = 0;

                while (startIndex < arr.Length && endIndex <= arr.Length)
                {
                    if (currentSum == targetSum)
                    {
                        finalList.Add(tempList.Select(x => x.Value).ToList());
                        tempList = new Dictionary<int, int>();
                        Console.WriteLine("starting index : " + startIndex + ", " +
                                "Ending index : " + (endIndex - 1));
                        if (endIndex <= arr.Length - 1)
                        {
                            tempList.Add(endIndex, arr[endIndex]);
                            currentSum += arr[endIndex];
                        }
                        endIndex++;
                    }

                    else
                    {
                        if (currentSum > targetSum)
                        {
                            currentSum -= arr[startIndex];
                            tempList.Remove(startIndex);
                            startIndex++;
                        }
                        else
                        {
                            if (endIndex <= arr.Length - 1)
                            {
                                tempList.Add(endIndex, arr[endIndex]);
                                currentSum += tempList[endIndex];
                            }
                            endIndex++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return finalList;
        }

        private static int subarraySum(int[] arr)
        {
            List<List<int>> lst = new List<List<int>>();
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i] * (i + 1) * (arr.Length - i);
                //lst.Add(new List<int> { arr[i], })
            }
            return result;
        }

        private static int subarraySum2(int[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int sum = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    sum += arr[j];
                    result += sum;
                }
            }
            return result;
        }
    }
}
