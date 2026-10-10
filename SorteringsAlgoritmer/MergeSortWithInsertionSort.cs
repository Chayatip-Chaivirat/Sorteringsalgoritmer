using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteringsAlgoritmer
{
    internal class MergeSortWithInsertionSort
    {
        public static int[] MergeWithInsert(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }
            int mid = array.Length / 2; // The mid index is calculated by dividing the length of the array by 2
            int[] left = new int[mid];  // The left half of the array is created with the size of mid
            int[] right = new int[array.Length - mid];  // The right half of the array is created with the size of array.Length - mid

            Array.Copy(array, 0, left, 0, mid); // The left half of the array is copied to the left array, the size of the left array is mid, and the size of the right array is array.Length - mid
            Array.Copy(array, mid, right, 0, array.Length - mid);

            Console.Write("left array going into Insertion Sort: " + string.Join(", ", left)); // Print the left and right arrays after each iteration
            Console.WriteLine("    |    " + "right array going into Insertion Sort: " + string.Join(", ", right));

            left = InsertionSort.InsertionSortMethod(left); // left array is sorted using insertion sort
            right = InsertionSort.InsertionSortMethod(right); // right array is sorted using insertion sort

            Console.Write("left array after Insertion Sort: " + string.Join(", ", left)); // Print the left and right arrays after each iteration
            Console.WriteLine("    |    " + "right array after Insertion Sort: " + string.Join(", ", right));
            Console.WriteLine("    ");

            //Merge(left, right); // merge the two sorted arrays and return the merged array
            return InsertionSort.InsertionSortMethod(Merge(left, right)); // merge the two sorted arrays and return the merged array sorted using insertion sort

        }
        private static int[] Merge(int[] left, int[] right)
        {
            int[] merged = new int[left.Length + right.Length];
            int leftIndex = 0;
            int rightIndex = 0;
            int mergedIndex = 0;

            while (leftIndex < left.Length) // If there are any remaining elements in the left array, they are added to the merged array
            {
                merged[mergedIndex] = left[leftIndex];
                leftIndex++;
                mergedIndex++;
            }

            while (rightIndex < right.Length) // If there are any remaining elements in the right array, they are added to the merged array
            {
                merged[mergedIndex] = right[rightIndex];
                rightIndex++;
                mergedIndex++;
            }

            Console.Write("left array:" + string.Join(", ", left)); // Print the merged array after each iteration
            Console.Write("  |  " + "right array:" + string.Join(", ", right));
            Console.WriteLine("  |  " + "merged left and right array:" + string.Join(", ", merged));

            return merged;
        }
    }
}
