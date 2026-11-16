using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal class MergeSortWithInsertionSort
{
    static int M = 20; // The threshold for switching to insertion sort
    static int arraySize = 100000;
    public static int[] CreateArray()
    {
        int[] array = new int[arraySize];
        Random rng = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rng.Next(1, arraySize + 1);
        }
        return array;
    }

    public static int[] MergeWithInsert(int[] array)
    {

        if (array.Length <= 1)
        {
            return array;
        }
        int[] mid = new int[1];
        mid[0] = array.Length / 2; // The mid index is calculated by dividing the length of the array by 2
        int[] left = new int[array.Length/2 ];  // The left half of the array is created with the size of mid
        int[] right = new int[array.Length - mid[0]];  // The right half of the array is created with the size of array.Length - mid

        Array.Copy(array, 0, left, 0, mid[0]); // The left half of the array is copied to the left array, the size of the left array is mid, and the size of the right array is array.Length - mid
        Array.Copy(array, mid[0], right, 0, array.Length - mid[0]);

        //Console.Write("left array going into Insertion Sort: " + string.Join(", ", left)); // Print the left and right arrays after each iteration
        //Console.WriteLine("    |    " + "right array going into Insertion Sort: " + string.Join(", ", right));

        //left = InsertionSortMethod(left); // left array is sorted using insertion sort
        //right = InsertionSortMethod(right); // right array is sorted using insertion sort

        //Console.Write("left array after Insertion Sort: " + string.Join(", ", left)); // Print the left and right arrays after each iteration
        //Console.WriteLine("    |    " + "right array after Insertion Sort: " + string.Join(", ", right));
        //Console.WriteLine("    ");

        return Merge(array, left, mid, right); // merge the two sorted arrays and return the merged array sorted using insertion sort

    }
    private static int[] Merge(int[] array, int[] left, int[] mid, int[] right)
    {
        int[] merged = new int[left.Length + right.Length];
        int leftIndex = 0;
        int rightIndex = 0;
        int mergedIndex = 0;

        while (leftIndex < left.Length && rightIndex < right.Length) // While there are elements in both left and right arrays
        {
            if (left[leftIndex] <= right[rightIndex]) // If the current element in the left array is less than or equal to the current element in the right array
            {
                merged[mergedIndex] = left[leftIndex]; // Add the current element in the left array to the merged array
                leftIndex++; // Move to the next element in the left array
            }
            else
            {
                merged[mergedIndex] = right[rightIndex]; // Add the current element in the right array to the merged array
                rightIndex++; // Move to the next element in the right array
            }
            mergedIndex++; // Move to the next position in the merged array
        }

        return merged; // Return the merged array

        //    int[] merged = new int[left.Length + right.Length];
        //    int leftIndex = 0;
        //    int rightIndex = 0;
        //    int mergedIndex = 0;

        //    while (leftIndex < left.Length) // If there are any remaining elements in the left array, they are added to the merged array
        //    {
        //        merged[mergedIndex] = left[leftIndex];
        //        leftIndex++;
        //        mergedIndex++;
        //    }

        //    while (rightIndex < right.Length) // If there are any remaining elements in the right array, they are added to the merged array
        //    {
        //        merged[mergedIndex] = right[rightIndex];
        //        rightIndex++;
        //        mergedIndex++;
        //    }

        //Console.Write("left array:" + string.Join(", ", left)); // Print the merged array after each iteration
        //Console.Write("  |  " + "right array:" + string.Join(", ", right));
        //Console.WriteLine("  |  " + "merged left and right array:" + string.Join(", ", merged));

        // return merged;
    }

    public static void MergeSort(int[] array, int[] lo, int[] hi)
    {
        if (hi.Length <= lo.Length)
            return;
        if (hi.Length - lo.Length <= M) // If the size of the section is less than or equal to M, use insertion sort
        {
            for (int i =0; i <= hi.Length; i++) 
            {
               for (int j = i + 1; j <= lo.Length; j++)
                {
                    InsertionSortMethod(array, lo[i], hi[j]);
                }
            }
        }

        int[] mid = new int[1];
        mid[0] = lo.Length + (hi.Length - lo.Length) / 2; // Calculate the mid index of the array
        MergeSort(array, lo, mid); // Recursively sort the left half of the array
        MergeSort(array, mid, hi); // Recursively sort the right half of the array
        Merge(array, lo, mid, hi); // Merge the two sorted halves of the array
    }

    public static void InsertionSortMethod(int[] array, int lo, int hi)
    {
        for (int i = lo + 1; i <= hi; i++) // Start from the second element in the section
        {
            int key = array[i];
            int j = i - 1;

            while (j >= lo && array[j] > key) // Move elements that are greater than key to one position ahead of their current position
            {
                array[j + 1] = array[j]; // Shift the element to the right
                j--;
            }

            array[j + 1] = key;
        }
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
