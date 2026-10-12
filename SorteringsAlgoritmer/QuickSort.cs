using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteringsAlgoritmer
{
    internal class QuickSort
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

        public static int[] QuickSortMethod(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int pivot = array[array.Length / 2]; // The pivot is chosen as the middle element of the array

            int[] left = array.Where(x => x < pivot).ToArray(); // If the element is less than the pivot, it is added to the left array
            int[] middle = array.Where(x => x == pivot).ToArray(); // If the element is equal to the pivot, it is added to the middle array
            int[] right = array.Where(x => x > pivot).ToArray(); // If the element is greater than the pivot, it is added to the right array

            Console.Write("Pivot: " + pivot);
            Console.WriteLine(" | Left: " + string.Join(", ", left) + " | Middle: " + string.Join(", ", middle) + " | Right: " + string.Join(", ", right));

            return QuickSortMethod(left).Concat(middle).Concat(QuickSortMethod(right)).ToArray(); // Return a sorted array by connecting the left, middle, and right arrays recursively
        }

        static void Main(string[] args)
        {
            int[] array = CreateArray();
            Console.WriteLine("Unsorted array: " + string.Join(", ", array));
            Console.WriteLine("    ");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] sortedArray = QuickSortMethod(array);
            stopwatch.Stop();
            Console.WriteLine("Sorted array: " + string.Join(", ", sortedArray));
            Console.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds + " ms");
        }
    }
}
