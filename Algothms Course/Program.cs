using System;
using System.Collections.Generic;

namespace Algorithms_Course
{
    class Program
    {
        static void Main(string[] args)
        {
            RecursionSection recursionSection = new RecursionSection();
            //recursionSection.TaylorSeries(4, 15);
            //recursionSection.TaylorSeriesV2HornersRule(4, 15);
            //Console.WriteLine(recursionSection.FibonacciSeries(6));
            //var reversed = recursionSection.ReverseList(new ListNode { next = new ListNode { next = new ListNode {next =new ListNode(),val=1 },val=2 },val=3 });
            //var isPalindrom = recursionSection.IsPalindrome(new ListNode { next = new ListNode { next = new ListNode {next =new ListNode(),val=1 },val=2 },val=3 });
            //var res = recursionSection.LadderLength("hit","cog",new List<string> {"hot","dot","tog","cog" });
            ArraySection arraySection = new ArraySection();
            //arraySection.CountBalls(1, 10);
            //arraySection.RepeatedNTimes(new int[] {1,2,3,3 });
            // arraySection.SortArrayByParity(new int[] {1,0 });
            //var t=     arraySection.SortArrayByParityII(new int[] {2,0,3,4,1,3 });
            //var vv = arraySection.RemoveDuplicates("abbaca");
            var aa = new int[4][];
             aa[0] = new int[2] {5,10 };
             aa[1] = new int[2] {2,5 };
             aa[2] = new int[2] {4,7 };
             aa[3] = new int[2] {3,9 };

            var vv = arraySection.MaximumUnits(aa,10 );
        }

    }
}
//[[5,10],[2,5],[4,7],[3,9]]