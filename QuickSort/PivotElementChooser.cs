using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public class PivotElementChooser
    {
        private int PivotChoice { get; set; }
        public PivotElementChooser(int pivotChoice = 0)
        {
            PivotChoice = pivotChoice;
        }

        public int ChoosePivot(int[] inputArray, int left, int right)
        {
            if (PivotChoice == 1)
                return choosePivotFirstElement(inputArray, left);
            if (PivotChoice == 2)
                return choosePivotLastElement(inputArray, left, right);

            return choosePivotMedianElement(inputArray, left, right);
        }

        private static int choosePivotLastElement(int[] inputArray, int left, int right)
        {
            var pivot = inputArray[right];
            swap(inputArray, left, right);
            return pivot;
        }

        private static int choosePivotFirstElement(int[] inputArray, int left)
        {
            return inputArray[left];
        }

        private static int choosePivotMedianElement(int[] inputArray, int left, int right)
        {
            var first = inputArray[left];
            var last = inputArray[right];

            var mid = (right + left) / 2;

            var middle = inputArray[mid];
            var median = getMedian(first, middle, last);

            var position = Array.IndexOf(inputArray, median);

            swap(inputArray, left, position);

            return median;
        }

        private static int getMedian(int first, int middle, int last)
        {
            int[] array = new int[3] { first, middle, last };
            Array.Sort(array);
            return array[1];
        }

        private static void swap(int[] inputArray, int i, int j)
        {
            var swap = inputArray[j];
            inputArray[j] = inputArray[i];
            inputArray[i] = swap;
        }

    }
}
