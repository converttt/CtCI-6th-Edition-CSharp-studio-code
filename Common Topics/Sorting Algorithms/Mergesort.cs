using System;

namespace Common_Topics
{
    public static class MergeSort<T> where T : IComparable
    {
        public static T[] Sort(T[] arr)
        {
            Partitioning(arr, 0, arr.Length - 1);
            return arr;
        }

        private static void Merge(T[] arr, int start, int medium, int finish)
        {
            T[] leftPart = new T[medium - start + 1];
            T[] rightPart = new T[finish - medium];

            for (int i = start; i <= medium; i++)
            {
                leftPart[i - start] = arr[i];
            }

            for (int i = medium + 1; i <= finish; i++)
            {
                rightPart[i - medium - 1] = arr[i];
            }

            int r = 0;
            int l = 0;
            int cursor = start;

            while (r < rightPart.Length && l < leftPart.Length)
            {
                if (rightPart[r].CompareTo(leftPart[l]) < 0)
                {
                    arr[cursor] = rightPart[r];
                    r++;
                }
                else
                {
                    arr[cursor] = leftPart[l];
                    l++;
                }

                cursor++;
            }

            while (r < rightPart.Length)
            {
                arr[cursor] = rightPart[r];
                r++;
                cursor++;
            }

            while (l < leftPart.Length)
            {
                arr[cursor] = leftPart[l];
                l++;
                cursor++;
            }
        }

        private static void Partitioning(T[] arr, int start, int finish)
        {
            if (start < finish)
            {
                int medium = (start + finish) / 2;

                Partitioning(arr, start, medium);
                Partitioning(arr, medium + 1, finish);

                Merge(arr, start, medium, finish);
            }
        }
    }
}