using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteringsAlgoritmer
{
    internal class QuickSortWithInsertionSort
    {
        public static int[] QuickSortWihtInsertionSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }
            int pivot = array[array.Length / 2]; // The pivot is the middle element in the array

            int[] left = array.Where(x => x < pivot).ToArray(); // If the element is less than the pivot, it is added to the left array
            int[] middle = array.Where(x => x == pivot).ToArray(); // If the element is equal to the pivot, it is added to the middle array
            int[] right = array.Where(x => x > pivot).ToArray(); // If the element is greater than the pivot, it is added to the right array

            Console.Write("Pivot: " + pivot);
            Console.WriteLine(" | Left: " + string.Join(", ", left) + " | Middle: " + string.Join(", ", middle) + " | Right: " + string.Join(", ", right));

            return InsertionSort.InsertionSortMethod(left).Concat(middle).Concat(InsertionSort.InsertionSortMethod(right)).ToArray(); // Return a sorted array by connecting the left, middle, and right arrays recursively

        }
    }
}
