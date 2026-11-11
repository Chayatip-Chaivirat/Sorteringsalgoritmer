using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

internal class QuickSortWithInsertionSort
{
    static int M = 10; // The threshold for switching to insertion sort
    static int arraySize = 100; // The size of the array to be sorted
    public static int[] CreateArray()
    {
        int[] array = new int[arraySize];
        Random rng = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rng.Next(1, arraySize+1);
        }
        return array;
    }

    public static int[] QuickSortWihtInsertionSort(int[] array)
    {
        int[] mergedArray = new int[arraySize];
        int[] insertionSortArray = new int[arraySize];
        int[] quickSortArray = new int[arraySize];
        //quickSortArray = QuickSort(array);
        //insertionSortArray = InsertionSortMethod(quickSortArray);
        //mergedArray = insertionSortArray;
        //return mergedArray;


        //    if (mergedArray.Length <= M)
        //    {
        //        return InsertionSortMethod(array);
        //    }
        //    else
        //    {
        //        int pivot = array[array.Length / 2]; // The pivot is the middle element in the array
        //        int[] left = array.Where(x => x < pivot).ToArray(); // If the element is less than the pivot, it is added to the left array
        //        int[] middle = array.Where(x => x == pivot).ToArray(); // If the element is equal to the pivot, it is added to the middle array
        //        int[] right = array.Where(x => x > pivot).ToArray(); // If the element is greater than the pivot, it is added to the right array
        //                                                             // If the element is greater than the pivot, it is added to the right array and sorted using insertion sort

        //        int[] mergedArray = new left.Concat(middle).Concat(right).ToArray(); // The left, middle, and right arrays are concatenated into a single array

        //        //Console.Write("Pivot: " + pivot);
        //        //Console.WriteLine(" | Left: " + string.Join(", ", left) + " | Middle: " + string.Join(", ", middle) + " | Right: " + string.Join(", ", right));
        //    }

        //for (int i = 0; i < array.Length; i++)
        //{
        //    int[] left = array.Where(x => x < pivot).ToArray(); // If the element is less than the pivot, it is added to the left array
        //    int[] middle = array.Where(x => x == pivot).ToArray(); // If the element is equal to the pivot, it is added to the middle array
        //    int[] right = array.Where(x => x > pivot).ToArray(); // If the element is greater than the pivot, it is added to the right array
        //    mergedArray = left.Concat(middle).Concat(right).ToArray(); // The left, middle, and right arrays are concatenated into a single array
        //    if (array.Length <= M)
        //    { // The merged array is concatenated with the original array 
        //        insertionSortArray = InsertionSortMethod(mergedArray);
        //        break;
        //    }
        //}
        //int[] mergedArray;


        //if (array.Length <= M)
        //{
        //    insertionSortArray = InsertionSortMethod(quickSortArray); // If the length of the array is less than or equal to M, the array is sorted using insertion sort
        //    mergedArray = insertionSortArray.Concat(quickSortArray).ToArray(); // The merged array is the concatenation of the insertion sort array and the quicksort array
        //}
        //else 
        //{
        //    quickSortArray = QuickSort(array);
        //}

        for (int i = 0; array[i] <= array[M]; i++) // The loop iterates through the array until the element at index M is reached
        {
            mergedArray = InsertionSortMethod(array); // If the length of the array is less than or equal to M, the array is sorted using insertion sort
        }
        for (int j = M; array[j] < array.Length; j++) // The loop iterates from index M through the array until the end of the array is reached
        {
            mergedArray = QuickSort(array); // The merged array is sorted using quicksort
        }
        mergedArray = QuickSort(array); // The merged array is sorted using quicksort
        return mergedArray;
    }

    public static int[] QuickSort(int[] array)
    {
        int[] doneArray = new int[array.Length];
        int loopedTimes = array.Length - 10;
        for (int i = 0; i < array.Length && i <= loopedTimes; i++)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int pivot = array[array.Length / 2]; // The pivot is chosen as the middle element of the array

            int[] left = array.Where(x => x < pivot).ToArray(); // If the element is less than the pivot, it is added to the left array
            int[] middle = array.Where(x => x == pivot).ToArray(); // If the element is equal to the pivot, it is added to the middle array
            int[] right = array.Where(x => x > pivot).ToArray(); // If the element is greater than the pivot, it is added to the right array

            //Console.Write("Pivot: " + pivot);
            //Console.WriteLine(" | Left: " + string.Join(", ", left) + " | Middle: " + string.Join(", ", middle) + " | Right: " + string.Join(", ", right));
            doneArray = QuickSort(left).Concat(middle).Concat(QuickSort(right)).ToArray();
        }
        return doneArray;
    }

    public static int[] InsertionSortMethod(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
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
        int[] sortedArray = QuickSortWihtInsertionSort(array);
        stopwatch.Stop();
        Console.WriteLine("Sorted array: " + string.Join(", ", sortedArray));
        Console.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}
