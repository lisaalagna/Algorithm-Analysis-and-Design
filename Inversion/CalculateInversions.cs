using System;
using Common;

namespace Inversion
{
    public class CalculateInversions
    {
        public static void Main(string[] args)
        {
            var input = FileReader.ReadFileAsListOfInts("InversionInput");
           
            var list = new CountableList(input);

            var inversions = list.CountInversions();
            var sorted = list.Sort();

            Console.WriteLine(inversions);
            Console.WriteLine(String.Join(",", sorted));
            Console.ReadLine();
        }
    }
}
