using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

internal class QuickSortWithInsertionSort
{
    static int M = 100; // The threshold for switching to insertion sort
    static int arraySize = 10000; // The size of the array to be sorted
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
        //    int[] mergedArray = new int[0];
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
        int[] mergedArray;

        if (array.Length <= M)
        {
            mergedArray = InsertionSortMethod(array); // If the length of the array is less than or equal to M, the array is sorted using insertion sort
        //  return mergedArray;
        }
        else
        {
            int pivot = array[array.Length / 2]; // The pivot is the middle element in the array

            int[] left = array.Where(x => x < pivot).ToArray(); // If the element is less than the pivot, it is added to the left array
            int[] middle = array.Where(x => x == pivot).ToArray(); // If the element is equal to the pivot, it is added to the middle array
            int[] right = array.Where(x => x > pivot).ToArray(); // If the element is greater than the pivot, it is added to the right array
            mergedArray = QuickSortWihtInsertionSort(left.Concat(middle).Concat(right).ToArray()); // mergedArray is the concatenation of the left, middle, and right arrays, which are sorted using quicksort with insertion sort
                                                                                                   //  return mergedArray;
        }
        return mergedArray;
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
        int[] sortedArray = QuickSortWihtInsertionSort(array);
        stopwatch.Stop();
        Console.WriteLine("Sorted array: " + string.Join(", ", sortedArray));
        Console.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}
