using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{
    //var t = new int[] { 9, 2, 1, 4, 5, 6, 12, 323, 45, 6, 55, 3 };

    public class SortingAlgorithms
    {
        public int[] BableSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j < array.Length; j++)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(j, j - 1, array);
                    }
                }
            }
            return array;
        }
        public int[] InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
            return array;
        }
        public int[] SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minValue = i;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[minValue] < array[j])
                    {
                        Swap(minValue, j, array);
                    }
                }
            }
            return array;
        }
        public int[] CountingSort(int[] array)
        {
            int max = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }
            var counts = new int[max + 1];
            for (int i = 0; i < array.Length; i++)
            {
                counts[array[i]]++;
            }
            int k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (counts[k] != 0)
                {
                    for (int j = 0; j < counts.Length; j++)
                    {
                        if (counts[k] == 0) break;
                        array[i++] = counts[k]--;
                    }
                }
            }

            return array;
        }
        public int[] MergeSort(int[] array)
        {
            PartitionMergeSort(array, 0, array.Length - 1);
            return array;
        }
        public int[] QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int j = PartitionQuickSort(left, right, array);
                QuickSort(array, left, j);
                QuickSort(array, j + 1, right);
            }

            return array;
        }
        private int PartitionQuickSort(int left, int right, int[] array)
        {
            var pivot = array[left];
            int i = left;
            int j = right;
            while (i < j)
            {

                while (array[i] <= pivot)
                {
                    i++;
                }
                while (array[j] > pivot)
                {
                    j--;
                }
                if (i < j)
                {
                    Swap(i, j, array);
                }
            }
            Swap(left, j, array);
            return j;
        }
        private void PartitionMergeSort(int[] array, int start, int end)
        {
            int midPoint;
            if (start < end)
            {
                midPoint = (start + end) / 2;
                PartitionMergeSort(array, start, midPoint);
                PartitionMergeSort(array, midPoint + 1, end);
                Merge(array, start, midPoint + 1, end);
            }
        }
        private void Merge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, eol, num, pos;
            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[pos++] = numbers[left++];
                else
                    temp[pos++] = numbers[mid++];
            }
            while (left <= eol)
                temp[pos++] = numbers[left++];
            while (mid <= right)
                temp[pos++] = numbers[mid++];
            for (i = 0; i < num; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }
        private void Swap(int index1, int index2, int[] array)
        {
            var temp = array[index2];
            array[index2] = array[index1];
            array[index1] = temp;
        }
      
    }
}
