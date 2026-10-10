using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorteringsAlgoritmer
{
    internal class UseLibrary
    {
        static SortedDictionary<int, int> useSortedDictionary = new SortedDictionary<int, int>();

        public static int[] AddAlgorithm(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (useSortedDictionary.ContainsKey(array[i]))
                {
                    useSortedDictionary[array[i]]++;
                }
                else
                {
                    useSortedDictionary.Add(array[i], 1);
                }
            }
            int[] sortedArray = new int[useSortedDictionary.Count];
            int index = 0;
            foreach (var item in useSortedDictionary)
            {
                sortedArray[index] = item.Key;
                index++;
            }
            return sortedArray;
        }
    }
}
