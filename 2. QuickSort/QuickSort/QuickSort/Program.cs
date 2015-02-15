using System;
using System.IO;
using System.Linq;
using QuickSort.Sorting;

namespace QuickSort
{
    class Program
    {
        static void Main()
        {
            const string path = @"E:\projects\coursera\2. QuickSort\QuickSort.txt";
            int[] array = ParseFile(path);

            var left = new QuickSortLeftPivot(array);
            long leftResult = left.Sort();
            Console.WriteLine("Left Pivot. Number of comparisons:{0}", leftResult);

            var right = new QuickSortRightPivot(array);
            long rightResult = right.Sort();
            Console.WriteLine("Right Pivot. Number of comparisons:{0}", rightResult);

            var median = new QuickSortMedianPivot(array);
            var medianResult = median.Sort();
            Console.WriteLine("Median Pivot. Number of comparisons:{0}", medianResult);

            Console.ReadKey();
        }

        private static int[] ParseFile(string path)
        {
            int[] result;
            using (var fileStream = File.OpenRead(path))
            using (StreamReader sr = new StreamReader(fileStream))
            {
                string readToEnd = sr.ReadToEnd();
                string[] strings = readToEnd.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                result = strings.Select(int.Parse).ToArray();
            }
            
            return result;
        }
    }
}
