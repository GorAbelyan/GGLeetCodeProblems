namespace Algothms_Course
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
    }
}
