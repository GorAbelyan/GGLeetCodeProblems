using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_Course
{
    public class ArraySection
    {
        public int BinarySearch(int[] array, int searchedNumber)
        {

            var left = 0;
            var right = array.Length - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;
                if (array[mid] == searchedNumber)
                    return mid;
                else if (array[mid] > searchedNumber)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return -1;
        }
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            string w1 = "";
            string w2 = "";
            foreach (var item in word1)
            {
                string.Concat(w1, item);
            }
            foreach (var item in word2)
            {
                string.Concat(w2, item);

            }


            return w1 == w2;
        }
        public int CountBalls(int lowLimit, int highLimit)
        {
            var result = new int[46];
            for (int i = lowLimit; i <= highLimit; i++)
            {
                var sum = GetDigitSum(i);
                result[sum]++;
            }
            var res = int.MinValue;
            foreach (var val in result)
                if (val > res)
                    res = val;
            return res;
        }
        public int GetDigitSum(int lowLimit)
        {
            int sum = 0;
            while (lowLimit > 0)
            {
                var lastDigit = lowLimit % 10;
                lowLimit /= 10;
                sum += lastDigit;
            }
            return sum;
        }
        public int RepeatedNTimes(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], 0);
                //  else
                //dict[nums[i]]++;
            }
            int highKey = 0;
            int highValue = 0;

            foreach (var item in dict.Keys)
            {
                if (highValue < dict[item])
                {
                    highValue = dict[item];
                    highKey = item;
                }
            }
            return highKey;

        }
        public int[] SortArrayByParity(int[] nums)
        {
            int rigthInd = nums.Length - 1;
            int leftInd = 0;
            while (rigthInd > leftInd)
            {
                while (leftInd < nums.Length && nums[leftInd] % 2 == 0)
                    leftInd++;
                while (rigthInd >= 0 && nums[rigthInd] % 2 == 1)
                    rigthInd--;
                if (leftInd < nums.Length && rigthInd >= 0)
                {
                    if (nums[leftInd] == 0)
                    {
                        leftInd++;
                        continue;
                    }
                    if (nums[rigthInd] == 0)
                    {
                        rigthInd--;
                        continue;
                    }
                    Swap(nums, leftInd, rigthInd);
                }
                rigthInd--;
                leftInd++;
            }
            return nums;
        }
        public void Swap(int[] nums, int l, int r)
        {
            var temp = nums[l];
            nums[l] = nums[r];
            nums[r] = temp;
        }
        public int[] SortArrayByParityII(int[] nums)
        {
            var index = 0;
            var zeroIndex = -1;

            for (int i = index; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    zeroIndex = i;
                    continue;
                }

                if (i % 2 == 1)
                {
                    var newnumberindex = GetOddNumber(nums, i);
                    if (newnumberindex == -1)
                        Swap(nums, i, zeroIndex);
                    else
                        Swap(nums, i, newnumberindex);
                }
                else if (i % 2 == 0)
                {
                    var newnumberindex = GetEvenNumber(nums, i);
                    if (newnumberindex == -1)
                        Swap(nums, i, zeroIndex);
                    else
                        Swap(nums, i, newnumberindex);
                }
            }
            return nums;
        }
        public int GetOddNumber(int[] nums, int index)
        {
            for (int i = index; i < nums.Length; i++)
                if (nums[i] % 2 == 1)
                    return i;
            return -1;
        }
        public int GetEvenNumber(int[] nums, int index)
        {
            for (int i = index; i < nums.Length; i++)
                if (nums[i] % 2 == 0)
                    return i;
            return -1;
        }

        public int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            //[[5,10],[2,5],[4,7],[3,9]]
            Array.Sort(boxTypes, (a, b) =>
            {
                return b[1] - a[1];

            }
            );
            return 0;
        }
        public string RemoveDuplicates(string s)
        {
            //a,1
            var strResult = new StringBuilder();
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    dict[s[i]]++;
                    if (dict[s[i]] == 2)
                    {
                        dict[s[i]] = 0;
                    }
                    strResult = new StringBuilder();
                    for (int j = 0; j < dict.Count; j++)
                    {
                        if (dict[s[j]] != 0)
                        {
                            strResult.Append(s[j]);
                        }
                    }

                }
                else
                {
                    dict.Add(s[i], 1);
                    strResult.Append(s[i]);
                }
            }
            var array = new List<int>();
            int max = 0;
            for (int i = 0; i < array.Count; i++)
            {
                max = Math.Max(max, array[i]);
            }

            return strResult.ToString();
        }

    }

}
