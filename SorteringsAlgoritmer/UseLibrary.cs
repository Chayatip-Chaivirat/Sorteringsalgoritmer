using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteringsAlgoritmer
{
    internal class UseLibrary
    {
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

        static SortedDictionary<int, int> useSortedDictionary = new SortedDictionary<int, int>(); // Key int, Value int, the key is the element in the array, and the value is the number of times the element appears in the array

        public static int[] AddAlgorithm(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (useSortedDictionary.ContainsKey(array[i])) // If the key already exists in the sorted dictionary, the value is incremented by 1
                {
                    useSortedDictionary[array[i]]++;
                }
                else
                {
                    useSortedDictionary.Add(array[i], 1); // If the key does not exist in the sorted dictionary, the key is added with a value of 1
                }
            }
            int[] sortedArray = new int[array.Length]; // The sorted array is created with the size of the sorted dictionary count + the sum of the values in the sorted dictionary
            int index = 0;

            foreach (var item in useSortedDictionary) // The foreach loop iterates through the sorted dictionary and adds the values to the sorted array
            {
                for (int i = 0; i < item.Value; i++) // The for loop iterates through the value of the key and adds the key to the sorted array
                {
                    sortedArray[index] = item.Key; // The key is added to the sorted array
                    index++;
                }
            }   
            return sortedArray;
        }

        static void Main(string[] args)
        {
            int[] array = CreateArray();
            Console.WriteLine("Unsorted array: " + string.Join(", ", array));
            Console.WriteLine("    ");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] sortedArray = AddAlgorithm(array);
            stopwatch.Stop();
            Console.WriteLine("Sorted array: " + string.Join(", ", sortedArray));
            Console.WriteLine("Time taken: " + stopwatch.ElapsedMilliseconds + " ms");
        }
    }
}
