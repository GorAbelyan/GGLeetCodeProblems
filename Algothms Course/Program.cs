using System;
using System.Collections.Generic;

namespace Algothms_Course
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
            var swapTwoPairs = recursionSection.SwapPairs(new ListNode { next = new ListNode { next = new ListNode {next =new ListNode(),val=1 },val=2 },val=3 });
            var res = recursionSection.LadderLength("hit","cog",new List<string> {"hot","dot","tog","cog" });
        }

    }
}
