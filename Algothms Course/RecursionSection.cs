using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algothms_Course
{
    public class RecursionSection
    {
        public void TaylorSeries(double x, int n)
        {
            Console.WriteLine(TaylorSeriesRec(x, n));
        }



        static double powerValue = 1;
        static double factorialValue = 1;
        static double TayleroHornersAnswer = 1;
        public double TaylorSeriesRec(double x, int n)
        {
            if (n != 0)
            {
                var depth = TaylorSeriesRec(x, n - 1);
                powerValue = x * powerValue;
                factorialValue = n * factorialValue;
                return depth + (powerValue / factorialValue);

            }
            return 1;
        }

        public void TaylorSeriesV2HornersRule(int v1, int v2)
        {
            Console.WriteLine(TaylorSeriesRecV2HornersRule(v1, v2));
        }
        public double TaylorSeriesRecV2HornersRule(double x, int n)
        {
            if (n == 0) return TayleroHornersAnswer;
            TayleroHornersAnswer = 1 + x / n * TayleroHornersAnswer;
            return TaylorSeriesRecV2HornersRule(x, n - 1);
        }

        public int FibonacciSeries(int n)
        {
            if (n == 0) return 1;
            if (n == 1) return 1;
            return FibonacciSeries(n - 2) + FibonacciSeries(n - 1);
        }
        public int Factorial(int n)
        {
            if (n == 0) return 1;
            return Factorial(n - 1) * n;
        }
        public int CnFromKelement_C(int n, int k)
        {
            int t1, t2, t3;
            t1 = Factorial(n);
            t2 = Factorial(k);
            t3 = Factorial(n - k);
            return t1 / (t2 * t3);
        }

        public ListNode ReverseList(ListNode head)
        {
            return ReverseList(null, head);
        }

        Stack<ListNode> stack = new Stack<ListNode>();
        public bool IsPalindrome(ListNode head)
        {

            ListNode dummy = head;
            while (dummy != null)
            {
                stack.Push(dummy);
                dummy = dummy.next;
            }

            while (stack.Count>1) 
            {
                if (stack.Pop().val!=head.val)
                {
                    return false;
                }
                head = head.next;
            }
            return true;


    }

        public ListNode ReverseList(ListNode prev, ListNode node)
        {
            if (node == null)
            {
                return prev;
            }

            ListNode aux = node.next;
            node.next = prev;

            return ReverseList(node, aux);
        }

        int result = 0;
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord)) return result;

            var listOfOneChange = new Dictionary<string, List<string>>();
            wordList.Insert(0, beginWord);
            foreach (var item in wordList)
            {
                if (listOfOneChange.ContainsKey(item)) continue;
                listOfOneChange.Add(item, new List<string>());

                foreach (var second in wordList)
                {
                    if (second==item) continue;
                    int count = 0;
                    for (int i = 0; i < second.Length; i++)
                    {
                        if (second[i] != item[i]) count++;
                        if (count > 1) break;
                    }
                    if (count <= 1) listOfOneChange[item].Add(second);
                }
            }
            BFS(listOfOneChange, beginWord, endWord);
            return result;
        }
        public void BFS(Dictionary<string, List<string>> dictOfList, string firstWord, string endWord)
        {
            var queue = new Queue<string>();
            var hashSet = new HashSet<string>();
            hashSet.Add(firstWord);
            queue.Enqueue(firstWord);

            while (queue.Count > 0)
            {
                var size = queue.Count;
                result++;
                for (int i = 0; i < size; i++)
                {
                    var q = queue.Dequeue();

                    if (q == endWord) { return; }

                    foreach (var item in dictOfList[q])
                    {
                        if (hashSet.Contains(item))
                        {
                            continue;
                        }
                        hashSet.Add(item);
                        queue.Enqueue(item);
                    }
                }
            }
            result = 0;
        }
    }
}
