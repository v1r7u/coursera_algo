using System;
using System.IO;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main()
        {
            int[] array = ParseFile();

            long inversions = 0;
            Sort(array, ref inversions);

            Console.WriteLine(inversions);
            Console.ReadKey();
        }

        private static int[] ParseFile()
        {
            var file = File.Open(@"E:\projects\coursera\1. MergeSort\IntegerArray.txt",FileMode.Open);
            TextReader tr = new StreamReader(file);
            var readToEnd = tr.ReadToEnd();
            tr.Dispose();
            file.Close();
            var strings = readToEnd.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            return strings.Select(int.Parse).ToArray();
        }

        private static int[] Sort(int[] array, ref long inversions)
        {
            var length = array.Length;
            if (length == 1)
                return array;

            int[] first = GetArrayPart(array, 0, length / 2);
            int[] second = GetArrayPart(array, length / 2, length);

            var sortedFirst = Sort(first, ref inversions);
            var sortedSecond = Sort(second, ref inversions);
            return MergeArrays(sortedFirst, sortedSecond, ref inversions);
        }

        private static int[] GetArrayPart(int[] array, int start, int end)
        {
            var length = end - start;
            int[] newArray = new int[length];
            Array.Copy(array, start, newArray, 0, length);

            return newArray;
        }

        private static int[] MergeArrays(int[] first, int[] second, ref long inversions)
        {
            var firstLength = first.Length;
            var secondLength = second.Length;
            
            int length = firstLength + secondLength;
            int firstCounter = 0;
            int secondCounter = 0;
            int[] merged = new int[length];

            for (int i = 0; i < length; i++)
            {
                if (firstCounter >= firstLength)
                {
                    merged[i] = second[secondCounter];
                    secondCounter++;
                }
                else if (secondCounter >= secondLength)
                {
                    merged[i] = first[firstCounter];
                    firstCounter++;
                }
                else if (first[firstCounter] <= second[secondCounter])
                {
                    merged[i] = first[firstCounter];
                    firstCounter++;
                }
                else
                {
                    merged[i] = second[secondCounter];
                    secondCounter++;
                    inversions += firstLength - firstCounter;
                }
            }

            return merged;
        }
    }
}
