using System;
using System.Collections.Generic;
using System.Linq;

namespace Inversion
{
    public class CountableList
    {
        public List<int> Countable { get; set; }

        public long Inversions { get; set; }

        public CountableList(List<int> countable)
        {
            Countable = countable ?? new List<int>();
        }

        public long CountInversions()
        {
            sort(Countable);
            return Inversions;
        }

        public List<int> Sort()
        {
            return sort(Countable);
        }

        private List<int> sort(List<int> subArray)
        {
            List<int> sorted = new List<int>();
            if (subArray.Count() == 1)
            {
                sorted.Add(subArray[0]);
            }
            else
            {
                double splitSize = (double)subArray.Count() / 2;
                var left = subArray.Skip(0).Take((int)Math.Ceiling(splitSize)).ToList();
                var right = subArray.Skip((int)Math.Ceiling(splitSize)).Take((int)(Math.Floor(splitSize))).ToList();

                var leftSorted = sort(left);
                var rightSorted = sort(right);
                sorted = merge(leftSorted, rightSorted, subArray.Count());
            }

            return sorted;
        }

        private List<int> merge(List<int> left, List<int> right, int length)
        {
            List<int> output = new List<int>();
            int currentLeftPosition = 0;
            int currentRightPosition = 0;
            for (int k = 0; k < length; k++)
            {
                if (currentRightPosition < right.Count() && currentLeftPosition < left.Count())
                {
                    if (left[currentLeftPosition] < right[currentRightPosition])
                    {
                        output.Add(left[currentLeftPosition]);
                        currentLeftPosition++;
                    }
                    else
                    {
                        output.Add(right[currentRightPosition]);
                        Inversions += left.Count() - currentLeftPosition;
                        currentRightPosition++;
                    }
                }
                else if (currentLeftPosition >= left.Count())
                {
                    output.Add(right[currentRightPosition]);
                    Inversions += left.Count() - currentLeftPosition;
                    currentRightPosition++;
                }
                else if (currentRightPosition >= right.Count())
                {
                    output.Add(left[currentLeftPosition]);
                    currentLeftPosition++;
                }
            }

            return output;
        }
    }
}
