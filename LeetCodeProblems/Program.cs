using System;
using System.Collections.Generic;

namespace LeetCodeProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            var ArrayProblems = new ArrayProblems();
            var RandomProblems = new RandomProblems();
            //
            //ArrayProblems.GetConcatenation(new int[2]);
            //ArrayProblems.FinalValueAfterOperations(null);
            //ArrayProblems.RunningSum(null);
            //ArrayProblems.Shuffle(null, 3);

            //RandomProblems.Rob(null);
            //RandomProblems.ValidPath(3, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 0 } }, 0, 2);
            //RandomProblems.QueriesonNumberofPointsInsideaCircle(new int[][] { new int[] { 1, 3 }, new int[] { 3, 3 }, new int[] { 5, 3 }, new int[] { 2, 2, } },new int[][] { new int[] { 2, 3,1 }, new int[] { 4, 3,1 }, new int[] { 1,1,2 } });
            //  RandomProblems.MinimumNumberofOperationstoMoveAllBallstoEachBox("001011");
            //var t=  RandomProblems.GroupThePeople(new int[] { 3, 3, 3, 3, 3, 1, 3 });
            // var t=  RandomProblems.NumberOfBeams(new string[] {"011001", "000000", "010100", "001000" });
            //  var t = RandomProblems.AmazonSecondTask(new List<string> { "apple apple", "banan anything banan" }, new List<string>{"banan", "apple", "apple", "banan", "orange", "banan"});
            //     var t = RandomProblems.LongestBalancedSubstring("(()))(");
            // var t = RandomProblems.UnderscorifySubstring("testthis is a testtest to see if testestest it ","test");
            // var t = RandomProblems.CreateTargetArray(new int[] {0,1,2,3,4 },new int[] { 0, 1, 2, 2, 1 });
            // var t = RandomProblems.StrWithout3a3b(1,2);
            //apple apple, 
            //banan anything banan,
            //  CombinationIterator combinationIterator = new CombinationIterator("gkosu", 3);
            //banan ,apple,apple,banan,orange,banan,
            //SortSentence("Myself2 Me1 I4 and3");

            //int[] arr = { 67, 12, 95, 56, 85, 1, 100, 23, 60, 9 };
            //int n = 10, i;
            //Console.WriteLine("Quick Sort");
            //Console.Write("Initial array is: ");
            //for (i = 0; i < n; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
            //quickSort(arr, 0, 9);
            //Console.Write("\nSorted Array is: ");
            //for (i = 0; i < n; i++)
            //{
            //    Console.Write(arr[i] + " ");
            //}
            //var t = new int[][]
            // {
            //    new int[]{ 0,0,0 }, new int[]{ 0,0, 0}
            // };
            //FloodFill(t,0,0,2);

            var SortingAlgo = new SortingAlgorithms();

            // var babl = SortingAlgo.BableSort(new int[] { 9, 2, 1, 4, 5, 6, 12, 323, 45, 6, 55, 3 });
            // var insertion = SortingAlgo.InsertionSort(new int[] { 9, 2, 1, 4, 5, 6, 12, 323, 45, 6, 55, 3 });
            // var selection = SortingAlgo.SelectionSort(new int[] { 9, 2, 1, 4, 5, 6, 12, 323, 45, 6, 55, 3 });
            // var countingsort = SortingAlgo.CountingSort(new int[] { 9, 2, 1, 4, 5, 6, 12, 323, 45, 6, 55, 3 });
             //var quickSort = SortingAlgo.QuickSort(new int[] { 9, 2, 1, 4, 5, 6, 12 },0,6);
             var mergesort = SortingAlgo.MergeSort(new int[] { 9, 2, 1, 4 });

           
        }
        static public int Partition(int[] arr, int left, int right)
        {
            int pivot;
            pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        static public void quickSort(int[] arr, int left, int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(arr, left, right);
                if (pivot > 1)
                {
                    quickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    quickSort(arr, pivot + 1, right);
                }
            }
        }
        public static string SortSentence(string s)
        {
            var splitedString = s.Split(' ');
            var res = new string[splitedString.Length];
            for (int i = 0; i < splitedString.Length; i++)
            {
                res[splitedString[i][splitedString[i].Length - 1] - '0' - 1] = splitedString[i].Substring(0, splitedString[i].Length - 1);
            }
            return string.Join(' ', res);
        }
        static bool isFirst;
        static int OldColor;
        public static int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if (!isFirst)
            {
                OldColor = image[sr][sc];
                isFirst = true;
            }

            if (sr < 0 || sr >= image.Length) return image;
            if (sc < 0 || sc >= image[0].Length) return image;
            if (newColor == image[sr][sc]) return image;
            if (OldColor != image[sr][sc]) return image;
            image[sr][sc] = newColor;
            FloodFill(image, sr + 1, sc, newColor);

            FloodFill(image, sr - 1, sc, newColor);
            FloodFill(image, sr, sc + 1, newColor);
            FloodFill(image, sr, sc - 1, newColor);
            return image;
        }

    }
}