using System;
using System.Collections.Generic;
using System.IO;
using Common;

namespace QuickSort
{
    public class QuickSorter
    {
        public static void Main(string[] args)
        {
            var input = FileReader.ReadFileAsListOfInts("QuickSortInput");

            var sortablewithFirstAsPivot = new SortableArray(input.ToArray(), 1);
            var sortablewithLastAsPivot = new SortableArray(input.ToArray(), 2);
            var sortablewithMedianAsPivot = new SortableArray(input.ToArray(), 0);
            var sortablewithDefaultAsPivot = new SortableArray(input.ToArray(), 0);

            Console.WriteLine(sortablewithFirstAsPivot.CountComparisons());
            Console.WriteLine(sortablewithLastAsPivot.CountComparisons());
            Console.WriteLine(sortablewithMedianAsPivot.CountComparisons());
            Console.WriteLine(sortablewithDefaultAsPivot.CountComparisons());

            Console.ReadLine();
        }

        
    }
}