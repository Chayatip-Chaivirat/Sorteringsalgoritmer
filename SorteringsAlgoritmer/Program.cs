using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SorteringsAlgoritmer
{
    internal class Program
    {
        public static int[] CreateArray()
        {
            int[] array = new int[10000];
            Random rng = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rng.Next(1, 10001);  
            }
            return array;
        }

        static void Main(string[] args)
        {
            Console.Clear();
            bool wantToQuit = false;
            int[] unsortedArray = CreateArray();
            //int[] unsortedArray = {6,4,10,9,5,8,2,1,7,3,3,3};
            Console.WriteLine("What method of sorting would you like to use? (1: Merge Sort, 2: Quick Sort, 3: Merge Sort with Insertion Sort, 4: Quick Sort with Insertion Sort, 5: Use Library)");
            Console.WriteLine("");
            Console.WriteLine("Unsorted Array: " + string.Join(", ", unsortedArray));

            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("    ");
            int[] sortedArray = null;
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

            if (choice == 1)
            {
                watch.Start();
                sortedArray = MergeSort.MergeSortMethod(unsortedArray);
                watch.Stop();
            }
            else if (choice == 2)
            {
                watch.Start();
                sortedArray = QuickSort.QuickSortMethod(unsortedArray);
                watch.Stop();
            }
            else if (choice == 3)
            {
                watch.Start();
                sortedArray = MergeSortWithInsertionSort.MergeWithInsert(unsortedArray);
                watch.Stop();
            }
            else if (choice == 4)
            {
                watch.Start();
                sortedArray = QuickSortWithInsertionSort.QuickSortWihtInsertionSort(unsortedArray);
                watch.Stop();
            }
            else if (choice == 5)
            {
                watch.Start();
                sortedArray = UseLibrary.AddAlgorithm(unsortedArray);
                watch.Stop();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 4.");
                choice = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("\n");
            Console.WriteLine("Sorted Array: " + string.Join(", ", sortedArray));
            Console.WriteLine("Time taken to sort: " + watch.ElapsedMilliseconds + " milliseconds");

            Console.WriteLine("Do you wish to close the program? (y/n)");
            if (Console.ReadLine().ToLower() == "y")
            {
                wantToQuit = true;
            }
            else
            {
                Console.Clear();
                Main(args);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
