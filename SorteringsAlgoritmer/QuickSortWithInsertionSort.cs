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
    static int M = 20; // The threshold for switching to insertion sort
    static int arraySize = 1000000; // The size of the array to be sorted
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
        if (array == null)
            throw new ArgumentNullException(nameof(array));

        if (array.Length <= 1)
            return array;

        // Shuffle the array to avoid bad pivot choices.
        Random rng = new Random();

        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1); // Random index from 0 to i

            int temp = array[i]; // Swap array[i] with the element at random index to shuffle the array
            array[i] = array[j];
            array[j] = temp; // Swap the elements
        }

        QuickSort(array, 0, array.Length - 1); // Call the QuickSort method to sort the array

        return array;
    }

    public static void QuickSort(int[] array, int lo, int hi)
    {
        // Nothing to sort if the section has 0 or 1 elements.
        if (hi <= lo)
            return;

        // Switch to Insertion Sort for small sections.
        if (hi - lo + 1 <= M) // If the size of the section is less than or equal to M, use Insertion Sort
        {
            InsertionSortMethod(array, lo, hi);
            return;
        }

        // Partition the array.
        int pivot = Partition(array, lo, hi); 

        // Sort the left and right sections recursively.
        QuickSort(array, lo, pivot - 1); // pivot - 1 is the index of the last element in the left section
        QuickSort(array, pivot + 1, hi); // pivot + 1 is the index of the first element in the right section
    }

    public static int Partition(int[] array, int lo, int hi)
    {
        int pivot = array[lo];

        int i = lo; // Start i at the left end of the section.
        int j = hi + 1; // Start j at the right end of the section.

        while (true)
        {
            // Move i to the right.
            do
            {
                i++;
            }
            while (i < hi && array[i] < pivot); // Stop when we find an element greater than or equal to the pivot.

            // Move j to the left.
            do
            {
                j--;
            }
            while (array[j] > pivot); // Stop when we find an element less than or equal to the pivot.

            // Stop when the indexes meet.
            if (i >= j)
                break;

            // Swap elements.
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        // Put pivot in its correct position.
        int temp2 = array[lo]; // pivot is at array[lo], we need to swap it with array[j] because j is the last index of the left section.
        array[lo] = array[j]; // pivot is now at array[j]
        array[j] = temp2; // array[j] is now the pivot

        return j;
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
        int[] sortedArray = QuickSortWihtInsertionSort(array);
        stopwatch.Stop();
        Console.WriteLine("Sorted array: " + string.Join(", ", sortedArray));
        Console.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}
