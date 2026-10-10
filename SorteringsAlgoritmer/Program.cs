using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteringsAlgoritmer
{
    internal class Program
    {
        public static int[] CreateArray()
        {
            int[] array = new int[10];
            Random rng = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rng.Next(1, 20);
            }
            return array;
        }
        static void Main(string[] args)
        {
            //int[] unsortedArray = CreateArray();
            int[] unsortedArray = {6,4,10,9,5,8,2,1,7,3};
            Console.WriteLine("Unsorted Array: " + string.Join(", ", unsortedArray));
            Console.WriteLine("What method of sorting would you like to use? (1: Merge Sort, 2: Quick Sort)");

            int choice = int.Parse(Console.ReadLine());
            int[] sortedArray = null;

            switch (choice)
            {
                case 1:
                    sortedArray = MergeSort.MergeSortMethod(unsortedArray);
                    break;

                case 2:
                    sortedArray = QuickSort.QuickSortMethod(unsortedArray);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            Console.WriteLine("\n");
            Console.WriteLine("Sorted Array: " + string.Join(", ", sortedArray));
            Console.ReadKey();
        }
    }
}
