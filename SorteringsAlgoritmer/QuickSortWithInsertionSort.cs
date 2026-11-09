using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class QuickSortWithInsertionSort
{
    public static int[] CreateArray()
    {
        int[] array = new int[100000];
        Random rng = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rng.Next(1, 100001);
        }
        return array;
    }

    public static int[] QuickSortWihtInsertionSort(int[] array)
    {
        if (array.Length <= 1)
        {
            return array;
        }
        int pivot = array[array.Length / 2]; // The pivot is the middle element in the array

        int[] left = InsertionSortMethod(array.Where(x => x < pivot).ToArray()); // If the element is less than the pivot, it is added to the left array
        int[] middle = InsertionSortMethod(array.Where(x => x == pivot).ToArray()); // If the element is equal to the pivot, it is added to the middle array
        int[] right = InsertionSortMethod(array.Where(x => x > pivot).ToArray()); // If the element is greater than the pivot, it is added to the right array
        // If the element is greater than the pivot, it is added to the right array and sorted using insertion sort

        int[] mergedArray = left.Concat(middle).Concat(right).ToArray(); // The left, middle, and right arrays are concatenated into a single array

        //Console.Write("Pivot: " + pivot);
        //Console.WriteLine(" | Left: " + string.Join(", ", left) + " | Middle: " + string.Join(", ", middle) + " | Right: " + string.Join(", ", right));

        return InsertionSortMethod(mergedArray); // Return a sorted array by connecting the left, middle, and right arrays recursively

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
