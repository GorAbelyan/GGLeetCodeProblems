using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    public class ArrayProblems
    {
        public int[] GetConcatenation(int[] nums)
        {
            var result = new int[2 * nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = nums[i];
                result[i + nums.Length] = nums[i];
            }
            return result;
        }
        public int FinalValueAfterOperations(string[] operations)
        {
            int result = 0;
            for (int i = 0; i < operations.Length; i++)
            {
                if (operations[i].Contains('+'))
                {
                    result++;
                }
                else
                {
                    result--;
                }
            }
            return result;
        }
        public int[] RunningSum(int[] nums)
        {
            var result = new int[nums.Length];
            int previusValue = nums[0];
            result[0] = previusValue;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                result[i + 1] = result[i] + nums[i + 1];
            }
            return result;
        }
        public int[] Shuffle(int[] nums, int n)
        {
            var result = new int[nums.Length];
            bool odd = false;
            int j = 0;
            int k = n;

            for (int i = 0; i < nums.Length; i++)
            {
                if (odd)
                {
                    result[i] = nums[k++];
                }
                else
                {
                    result[i] = nums[j++];
                }
                odd = !odd;
            }

            return result;

        }
    }
}
