using System;

namespace Common_Topics
{
    public class Heapsort<T> where T : IComparable
    {
        protected int heapSize;

        public void BuildHeap(T[] arr)
        {
            heapSize = arr.Length - 1;
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(i, arr);
            }
        }

        public void PerformHeapSort(T[] arr)
        {
            BuildHeap(arr);

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Swap(0, i, arr);
                heapSize--;
                Heapify(0, arr);
            }
        }

        protected void Heapify(int index, T[] arr)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int largest = index;

            if (left <= heapSize && arr[left].CompareTo(arr[largest]) > 0)
            {
                largest = left;
            }

            if (right <= heapSize && arr[right].CompareTo(arr[largest]) > 0)
            {
                largest = right;
            }

            if (largest != index)
            {
                Swap(largest, index, arr);
                Heapify(largest, arr);
            }
        }

        protected void Swap(int a, int b, T[] arr)
        {
            T tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;
        }
    }
}