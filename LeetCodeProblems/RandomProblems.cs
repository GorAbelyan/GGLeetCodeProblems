using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    public class RandomProblems
    {
        public int Rob(int[] nums)
        {

            //TODO Rob
            return 2;
        }
        public int RomanToInt(string s)
        {
            int answer = 0;
            answer = GetNumber(s[s.Length - 1]);
            if (s.Length == 1)
            {
                return answer;
            }
            int lastElementValue = GetNumber(s[s.Length - 1]);
            for (int i = s.Length - 2; i >= 0; i--)
            {
                int currentValue = GetNumber(s[i]);
                if (lastElementValue > currentValue)
                {
                    answer -= currentValue;
                }
                else
                {
                    answer += currentValue;
                }
                lastElementValue = currentValue;
            }
            return answer;
        }

        public int[] MinimumNumberofOperationstoMoveAllBallstoEachBox(string boxes)
        {
            var t = '2' - '0';
            var answer = new int[boxes.Length];
            for (int i = 0; i < boxes.Length; i++)
            {
                for (int j = 0; j < boxes.Length; j++)
                {
                    if (j == i) continue;
                    if (boxes[j] == '1')
                    {
                        answer[i] += Math.Abs(i - j);
                    }
                }
            }

            return answer;
        }

        public int GetNumber(char symbol)
        {
            switch (symbol)
            {
                case 'I':
                    return 1;
                    break;
                case 'V':
                    return 5;
                    break;
                case 'X':
                    return 10;
                    break;
                case 'L':
                    return 50;
                    break;
                case 'C':
                    return 100;
                    break;
                case 'D':
                    return 500;
                    break;
                case 'M':
                    return 1000;
                    break;
                default:
                    return 0;
                    break;
            }
        }


        //n = 3, edges = [[0,1],[1,2],[2,0]]
        public bool ValidPath(int n, int[][] edges, int start, int end)
        {
            var dict = new Dictionary<int, List<int>>();
            foreach (var edge in edges)
            {
                if (!dict.ContainsKey(edge[0]))
                    dict.Add(edge[0], new List<int>());
                if (!dict.ContainsKey(edge[1]))
                    dict.Add(edge[1], new List<int>());
                dict[edge[0]].Add(edge[1]);
                dict[edge[1]].Add(edge[0]);
            }
            var hs = new HashSet<int>();
            return dfs(start, end, dict, hs);
        }
        bool dfs(int start, int end, Dictionary<int, List<int>> dict, HashSet<int> hs)
        {
            if (start == end)
                return true;
            if (!hs.Add(start))
                return false;
            foreach (var next in dict[start])
            {
                if (dfs(next, end, dict, hs))
                    return true;
            }
            return false;
        }
        public int[] QueriesonNumberofPointsInsideaCircle(int[][] points, int[][] queries)
        {
            var answer = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    if (Math.Pow((queries[i][0] - points[j][0]), 2) + Math.Pow((queries[i][1] - points[j][1]), 2) <= Math.Pow(queries[i][2], 2))
                    {
                        answer[i]++;
                    }
                }
            }
            return answer;
        }
        public IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            var result = new List<IList<int>>();
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < groupSizes.Length; i++)
            {
                if (dict.ContainsKey(groupSizes[i]))
                    dict[groupSizes[i]].Add(i);
                else dict.Add(groupSizes[i], new List<int>() { i });
            }
            foreach (var d in dict)
            {
                var temp = d.Value.Count / d.Key;
                var j = 0;
                while (temp > 0)
                {
                    var arr = new int[d.Key];
                    var k = 0;
                    for (int i = j * d.Key; i < d.Key + j * d.Key; i++)
                    {
                        arr[k++] = d.Value[i];
                    }
                    result.Add(arr);
                    temp--;
                    j++;

                }
            }
            return result;

        }
        public int MaxWidthOfVerticalArea(int[][] points)
        {
            var answer = 0;
            var pointss = points.Select(x => x[0]).ToArray();
            Array.Sort(pointss);
            for (int i = 0; i < pointss.Length - 1; i++)
            {
                answer = Math.Max(pointss[i + 1] - pointss[i], answer);
            }
            return answer;
        }

        public int NumberOfBeams(string[] bank)
        {
            int answer = 0;
            for (int i = 0; i < bank.Length; i++)
            {
                for (int j = 0; j < bank[i].Length; j++)
                {
                    if (bank[i][j] == '1')
                    {
                        if (j - 1 >= 0 && bank[i][j - 1] == '0')
                        {
                            answer++;
                        }
                        if (j + 1 < bank[i].Length && j + 2 < bank[i].Length && bank[i][j + 2] != '1' && bank[i][j + 1] == '0')
                        {
                            answer++;
                            var t = "dsgdg";


                        }

                    }
                }

            }
            return answer;
        }
        public static List<int> KMP(string s, string pattern)
        {
            // get pattern's array 
            var patterns = new int[pattern.Length];
            for (int i = 1; i < pattern.Length; i++)
            {
                var j = 0;
                if (pattern[j] == pattern[i])
                {
                    patterns[i]++;
                    while (i + 1 < pattern.Length && pattern[++j] == pattern[++i])
                    {
                        patterns[i] = patterns[i - 1] + 1;
                    }
                }
            }

            // get substring in given string 
            int m = 0;
            int n = 0;
            var list = new List<int>();
            while (m < s.Length)
            {
                if (s[m] == pattern[n])
                {
                    m++;
                    n++;
                }

                // abacd   n 
                // abababacd  m 
                if (n == pattern.Length)
                {
                    list.Add(m - n);
                    n = 0;
                    if (m != 0)
                        m--;
                }
                else if (m < s.Length && s[m] != pattern[n])
                {
                    if (n == 0)
                        m++;
                    else
                        n = patterns[n - 1];
                }

            }

            return list;
        }

        //_test_this is a _testtest_ to see if _testestest_ it 
        public static string UnderscorifySubstring(string str, string substring)
        {
            var list = KMP(str, substring);
            var result = new StringBuilder();
            var k = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (k < list.Count && i == list[k])
                {
                    result.Append('_');

                    var left = list[k];
                    var right = 0;
                    while (i < str.Length && k + 1 < list.Count
                        && list[k + 1] - list[k] <= substring.Length)
                    {
                        k++;
                    }

                    if (left == list[k])
                    {
                        result.Append(substring);
                        i += substring.Length - 1;
                        k++;
                    }
                    else
                    {
                        right = list[k] + substring.Length;
                        result.Append(str.Substring(left, right - left));
                        i = right - 1;
                        k++;

                    }
                    result.Append('_');
                }
                else
                {
                    result.Append(str[i]);
                }
            }

            return result.ToString();
        }





        //apple apple, 
        //banan anything banan,

        //banan ,apple,apple,banan,orange,banan,
        public int AmazonSecondTask(List<string> codeList, List<string> ShoppingCart)
        {
            List<List<string>> codeGroups = new List<List<string>>();
            foreach (string code in codeList)
            {
                codeGroups.Add(code.Split(' ').ToList());
            }
            var codeGroupIndex = 0;
            var fruitIndex = 0;
            for (int i = 0; i < ShoppingCart.Count; i++)
            {
                if (ShoppingCart[i] == codeGroups[codeGroupIndex][fruitIndex] || codeGroups[codeGroupIndex][fruitIndex] == "anything")
                {
                    fruitIndex++;
                }

                if (fruitIndex == codeGroups[codeGroupIndex].Count)
                {
                    fruitIndex = 0;
                    codeGroupIndex++;
                    if (codeGroupIndex == codeGroups.Count)
                    {
                        break;
                    }
                }
            }
            return codeGroupIndex == codeGroups.Count ? 1 : 0;
        }

        //(()))(
        public int LongestBalancedSubstring(string str)
        {
            var maxCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i + 1; j < str.Length - i; j += 2)
                {
                    if (IsBalanced(str.Substring(i, j - i + 1)))
                    {
                        maxCount = Math.Max(maxCount, str.Substring(i, j - i + 1).Length);
                    }
                }
            }
            return maxCount;
        }
        public bool IsBalanced(string str)
        {
            var stack = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(')
                {
                    stack.Push(str[i]);
                }
                else
                {
                    if (stack.Count != 0)
                    {
                        if (stack.Peek() == '(')
                        {
                            stack.Pop();
                        }
                    }
                }
            }
            return stack.Count == 0;
        }
        public int[] CreateTargetArray(int[] nums, int[] index)
        {
            List<int> target = new List<int>();
            //Stack
            //Queue
            //Dictionary
            //HashSet
            //Array
            //String
            //SortedSet optional
            string Name = "aaaabbcc";
            Name.Replace('a', 'k');


            for (int i = 0; i < nums.Length; i++)
            {
                if (target.Count >= index[i])
                {
                    target.Insert(index[i], nums[i]);
                }
                else
                {
                    target.Add(nums[index[i]]);

                }
            }
            int[] array = target.ToArray();
            return array;

        }
        public string StrWithout3a3b(int a, int b)
        {
            var str = new StringBuilder();

            while (a > 0 || b > 0)
            {
                var st = str.ToString();
                if (st.EndsWith("aa"))
                {
                    str.Append("b");
                    b--;
                }
                else if (st.EndsWith("bb"))
                {
                    str.Append("a");
                    a--;
                }
                else if (a > b)
                {
                    str.Append("a");
                    a--;
                }
                else
                {
                    str.Append("b");
                    b--;
                }
            }

            var dict = new Dictionary<char, int>();

            return str.ToString();

        }
        public class CombinationIterator
        {
            string _characters;
            int _combinationLenght;
            Queue<string> stack = new Queue<string>();

            //abcd
            public CombinationIterator(string characters, int combinationLength)
            {
                _characters = characters;
                _combinationLenght = combinationLength;
                if (characters.Length >= combinationLength)
                {
                    for (int i = 0; i < characters.Length; i++)
                    {

                    }
                }

            }

            public string Next()
            {
                if (stack.Count != 0)
                {
                    return stack.Dequeue();
                }
                return "";
            }

            public bool HasNext()
            {
                if (stack.Count == 0) return false;
                return true;
            }
        }
        public class WordDictionary
        {
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();

            public WordDictionary()
            {
            }

            public void AddWord(string word)
            {
                if (!dict.ContainsKey(word.Length))
                    dict.Add(word.Length, new List<string>());
                dict[word.Length].Add(word);
            }

            public bool Search(string word)
            {
                if (!dict.ContainsKey(word.Length))
                    return false;
                var items = dict[word.Length];
                foreach (var item in items)
                {
                    var k = 0;
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == '.') { k++; continue; }
                        if (item[i] == word[i])
                        {
                            k++;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (k == word.Length)
                    {
                        return true;
                    }
                }
                return false;
            }


        }


    }
}

