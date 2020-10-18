using System;
using System.Collections.Generic;

namespace Test.Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 5 };
            //int[] arr = new int[] { 3,1,2};
            var res = solveEfficient(arr, 5);
            Console.ReadKey();
        }

        public static List<Tuple<int, int>> solveEfficient(int[] arr, int targetSum)
        {
            List<Tuple<int, int>> lst = new List<Tuple<int, int>>();
            List<List<int>> lst2 = new List<Tuple<int, int>>();
            Dictionary<int, int> tempList = new Dictionary<int, int>();
            int start = 0, end = 0;

            int currentSum = 0;

            while (start < arr.Length && end <= arr.Length)
            {
                if (currentSum == targetSum)
                {

                    /* as the currSum is equal to target sum, print the 
					 * result with end as end-1.
					 *  because when we added the element at end we
					 *  increased the pointer there only,
					 *  so now we need to subtract 1 because the 
					 *  subarray constituting that sum has
					 *   its last pointer one index where end is currently at.
					 */

                    lst.Add(new Tuple<int, int>(start, end - 1));

                    Console.WriteLine("starting index : " + start + ", " +
                            "Ending index : " + (end - 1));
                    if (end <= arr.Length - 1)
                    {
                        currentSum += arr[end];
                    }
                    end++;

                }

                else
                {
                    /* if the currSum becomes more than required, 
					 * we keep on subtracting the start element
					 * until it is less than or equal to 
					 required target sum. */
                    if (currentSum > targetSum)
                    {
                        tempList.Add(start, arr[start]);
                        currentSum -= tempList[start];
                        start++;
                    }
                    else
                    {
                        /* we add the last element to our
						 * currSum until our 
						 * sum becomes greater than or
						 * equal to target sum.
						 */
                        if (end <= arr.Length - 1)
                        {
                            tempList.Add(end, arr[end]);
                            currentSum += tempList[end];
                        }
                        end++;
                    }
                }
            }

            return lst;
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
