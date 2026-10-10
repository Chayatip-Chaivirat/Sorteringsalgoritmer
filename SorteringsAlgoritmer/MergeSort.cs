using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SorteringsAlgoritmer
{
    internal class MergeSort
    {
        public static int[] MergeSortMethod(int[] array)
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

            left = MergeSortMethod(left); // left array is sorted recursively
            right = MergeSortMethod(right); // right array is sorted recursively


            return Merge(left, right); // merge the two sorted arrays and return the merged array
        }

        private static int[] Merge(int[] left, int[] right)
        {
            int[] merged = new int[left.Length + right.Length];
            int leftIndex = 0;
            int rightIndex = 0;
            int mergedIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] < right[rightIndex]) // Compare the elements of the left and right arrays, if the element in the left array is smaller than the element in the right array,
                                                         // then the element in the left array is added to the merged array.
                {
                    merged[mergedIndex] = left[leftIndex];
                    leftIndex++;
                }
                else //Otherwise the element in the right array is added to the merged array
                {
                    merged[mergedIndex] = right[rightIndex];
                    rightIndex++;
                }
                mergedIndex++;
            }

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
            Console.WriteLine("  |  " + "merged array:" + string.Join(", ", merged));

            return merged;
        }
    }
}
