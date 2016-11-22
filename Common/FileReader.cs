using System;
using System.Collections.Generic;
using System.IO;

namespace Common
{
    public static class FileReader
    {
        public static List<int> ReadFileAsListOfInts(string fileName)
        {
            var inputArray = new List<int>();

            var fileLocation = String.Format(@"C:\Users\lisaa\Documents\GitHub\Algorithm-Analysis-and-Design\Common\InputFiles\{0}.txt", fileName);
            var lines = File.ReadLines(fileLocation);

            foreach (var line in lines)
            {
                int item = int.Parse(line);
                inputArray.Add(item);
            }

            return inputArray;
        }
    }
}
