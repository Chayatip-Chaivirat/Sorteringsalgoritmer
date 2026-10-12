using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteringsAlgoritmer
{
    internal class InsertionSort
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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] sortedArray = InsertionSortMethod(array);
            stopwatch.Stop();
            Console.WriteLine("Sorted array: " + string.Join(", ", sortedArray));
            Console.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds + " ms");
        }
    }
}
