using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SorteringsAlgoritmer
{
    internal class MergeSortWithInsertionSort
    {//if you wanna use the Program to run, comment out(mark and press ctrl + K + C in that order) the Main and CreateArray methods in all classes, and uncomment everything in the Program class (mark and press ctrl + K + U in that order). 

        public static int[] CreateArray() 
        {
            int[] array = new int[100];
            Random rng = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rng.Next(1, 101);
            }
            return array;
        }

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

            left = InsertionSortMethod(left); // left array is sorted using insertion sort
            right = InsertionSortMethod(right); // right array is sorted using insertion sort

            Console.Write("left array after Insertion Sort: " + string.Join(", ", left)); // Print the left and right arrays after each iteration
            Console.WriteLine("    |    " + "right array after Insertion Sort: " + string.Join(", ", right));
            Console.WriteLine("    ");

            return Merge(left, right); // merge the two sorted arrays and return the merged array sorted using insertion sort

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

        public static int[] InsertionSortMethod(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i]; // The key is the element that is being compared to the elements in the sorted part of the array
                int j = i - 1; // j is the index of the last element in the sorted part of the array

                while (j >= 0 && array[j] > key) // while j is grater than the key, the elements in the sorted part of the array are shifted to the right to make room for the key
                {
                    array[j + 1] = array[j]; // The element in the sorted part of the array is shifted to the right
                    j--; // j is decremented to compare the key to the next element in the sorted part of the array
                }
                array[j + 1] = key; // The key is inserted into the sorted part of the array
            }
            return array;
        }

        static void Main(string[] args)
        {
            int[] array = CreateArray();
            Console.WriteLine("Unsorted array: " + string.Join(", ", array));
            Console.WriteLine("    ");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] sortedArray = MergeWithInsert(array);
            stopwatch.Stop();
            Console.WriteLine("Sorted array: " + string.Join(", ", sortedArray));
            Console.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds + " ms");
        }
    }
}
