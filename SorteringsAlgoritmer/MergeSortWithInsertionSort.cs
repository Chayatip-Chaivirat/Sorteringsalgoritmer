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
    static int arraySize = 10000;
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
        if (array == null)
            throw new ArgumentNullException(nameof(array));

        // Create one temporary array for merging.
        int[] temp = new int[array.Length];

        MergeSort(array, temp, 0, array.Length - 1);

        return array;
    }
    private static void Merge(int[] array, int[] temp, int lo, int mid, int hi)
    {
        // Copy the current section into the temporary array.
        Array.Copy(array, lo, temp, lo, hi - lo + 1);

        int i = lo;
        int j = mid + 1;

        // Go through the original section and insert
        // the smallest available value from the two halves.
        for (int k = lo; k <= hi; k++)
        {
            if (i > mid)
            {
                // Left half is finished.
                array[k] = temp[j];
                j++;
            }
            else if (j > hi)
            {
                // Right half is finished.
                array[k] = temp[i];
                i++;
            }
            else if (temp[i] <= temp[j])
            {
                // Take the smaller value from the left half.
                array[k] = temp[i];
                i++;
            }
            else
            {
                // Take the smaller value from the right half.
                array[k] = temp[j];
                j++;
            }
        }
    }

    private static void MergeSort(int[] array, int[] temp, int lo, int hi)
    {
        // If the section has 0 or 1 elements, it is already sorted.
        if (hi <= lo)
            return;

        // Switch to Insertion Sort for small sections.
        if (hi - lo + 1 <= M)
        {
            InsertionSortMethod(array, lo, hi);
            return;
        }

        // Calculate the middle index.
        int mid = lo + (hi - lo) / 2;

        // Recursively sort the left half.
        MergeSort(array, temp, lo, mid);

        // Recursively sort the right half.
        MergeSort(array, temp, mid + 1, hi);

        // Merge the two sorted halves.
        Merge(array, temp, lo, mid, hi);
    }


    private static void InsertionSortMethod(
       int[] array, int lo, int hi)
    {
        for (int i = lo + 1; i <= hi; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= lo && array[j] > key)
            {
                array[j + 1] = array[j];
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
