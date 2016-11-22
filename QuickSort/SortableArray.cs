using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public class SortableArray
    {
        private int[] Sortable { get; set; }
        private int Comparisons { get; set; }

        private readonly PivotElementChooser pivotElementChooser;

        public SortableArray(int[] sortable, int pivotChoice)
        {
            Sortable = sortable;
            Comparisons = 0;
            pivotElementChooser = new PivotElementChooser(pivotChoice);
        }

        public int[] Sort()
        {
            return quickSort(Sortable, 0, Sortable.Length - 1);
        }

        public int CountComparisons()
        {
            quickSort(Sortable, 0, Sortable.Length - 1);
            return Comparisons;
        }
        
        private int[] quickSort(int[] inputArray, int left, int right)
        {
            var length = right - left + 1;
            if (length <= 1)
            {
                return inputArray;
            }

            int p = pivotElementChooser.ChoosePivot(inputArray, left, right);

            partition(inputArray, p, left, right);

            Comparisons += length - 1;

            var leftPart = quickSort(inputArray, left, p - 2);
            var rightPart = quickSort(inputArray, p, right);

            return inputArray;
        }

        private void partition(int[] inputArray, int pivot, int left, int right)
        {
            int i = left + 1;
            for (int j = left + 1; j <= right; j++)
            {
                if (inputArray[j] < pivot)
                {
                    swap(inputArray, i, j);
                    i++;
                }
            }

            inputArray[left] = inputArray[i - 1];
            inputArray[i - 1] = pivot;
        }

        private void swap(int[] inputArray, int i, int j)
        {
            var swap = inputArray[j];
            inputArray[j] = inputArray[i];
            inputArray[i] = swap;
        }
    }
}
