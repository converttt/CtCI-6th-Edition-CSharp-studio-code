using System;
using System.Collections.Generic;

namespace Common_Topics
{
    public static class Medians
    {
        private static int _median;

        /*
            There are 2 sorted arrays A and B of size n each. 
            Write an algorithm to find the median of the array obtained after merging the above 2 arrays(i.e. array of length 2n). 
            The complexity should be O(log(n))
         */
        public static int MedianOfEqual(int[] a, int[] b)
        {
            if (a.Length == 1)
            {
                _median = (a[0] + b[0]) / 2;
            }

            _MedianOfEqual(a, 0, a.Length - 1, b, 0, b.Length - 1);

            return _median;
        }

        /*
            Find the median of two arrays with the unequal sizes.
            The complexity should be O(log(n))
         */
        public static int MedianOfUnequal(int[] a, int[] b)
        {
            return _MedianOfUnequal(a, b);
        }

        private static void _MedianOfEqual(int[] a, int aStart, int aFinish, int[] b, int bStart, int bFinish)
        {
            if ((aFinish - aStart + 1) == 2)
            {
                _median = (Math.Max(a[aStart], b[bStart]) + Math.Min(a[aFinish], b[bFinish])) / 2;
                return;
            }

            int aMedian = _Median(a, aStart, aFinish);
            int bMedian = _Median(b, bStart, bFinish);

            if (aMedian == bMedian)
            {
                _median = aMedian;
            }
            else if (aMedian < bMedian)
            {
                _MedianOfEqual(a, (aFinish + aStart) / 2 + 1, aFinish, b, bStart, (bFinish + bStart) / 2);
            }
            else
            {
                _MedianOfEqual(a, aStart, (aFinish + aStart) / 2, b, (bFinish + bStart) / 2 + 1, bFinish);   
            }
        }

        private static int _MedianOfUnequal(int[] a, int[] b)
        {
            if (a.Length == 1 && b.Length == 1)
            {
                return (a[0] + b[0]) / 2;
            }

            int[] smallArr;
            int[] largeArr;
            if (a.Length > b.Length)
            {
                smallArr = b;
                largeArr = a;
            }
            else
            {
                smallArr = a;
                largeArr = b;
            }
            int largeMedianI = (largeArr.Length - 1) / 2;

            if (a.Length == 1 || b.Length == 1)
            {
                if (largeArr.Length % 2 == 0)
                {
                    if (smallArr[0] < largeArr[largeMedianI])
                    {
                        return largeArr[largeMedianI];
                    }
                    else if (smallArr[0] > largeArr[largeMedianI + 1])
                    {
                        return largeArr[largeMedianI + 1];
                    }
                    else
                    {
                        return smallArr[0];
                    }
                }
                else
                {
                    if (smallArr[0] < largeArr[largeMedianI - 1])
                    {
                        return (largeArr[largeMedianI - 1] + largeArr[largeMedianI]) / 2;
                    }
                    else if (smallArr[0] > largeArr[largeMedianI + 1])
                    {
                        return (largeArr[largeMedianI + 1] + largeArr[largeMedianI]) / 2;
                    }
                    else
                    {
                        return (smallArr[0] + largeArr[largeMedianI]) / 2;
                    }
                }
            }
            else if (a.Length == 2 || b.Length == 2)
            {
                if (largeArr.Length % 2 == 0)
                {
                    if (Math.Max(smallArr[0], smallArr[1]) < largeArr[largeMedianI - 1])
                    {
                        return (largeArr[largeMedianI] + largeArr[largeMedianI - 1]) / 2;
                    }
                    else if (Math.Min(smallArr[0], smallArr[1]) > largeArr[largeMedianI + 2])
                    {
                        return (largeArr[largeMedianI + 1] + largeArr[largeMedianI + 2]) / 2;
                    }
                    else
                    {
                        return _MedianOf4(smallArr[0], smallArr[1], largeArr[largeMedianI], largeArr[largeMedianI + 1]);
                    }
                }
                else
                {
                    if (Math.Max(smallArr[0], smallArr[1]) < largeArr[largeMedianI - 1])
                    {
                        return largeArr[largeMedianI - 1];
                    }
                    else if (Math.Min(smallArr[0], smallArr[1]) > largeArr[largeMedianI + 1])
                    {
                        return largeArr[largeMedianI + 1];
                    }
                    else
                    {
                        return _MedianOf3(smallArr[0], smallArr[1], largeArr[largeMedianI]);
                    }
                }
            }

            int aMedianI = a.Length / 2;
            int bMedianI = b.Length / 2;

            int[] newA;
            int[] newB;
            if (a[aMedianI] < b[bMedianI])
            {
                newA = new int[a.Length - aMedianI];
                Array.Copy(a, aMedianI, newA, 0, a.Length - aMedianI);

                newB = new int[bMedianI + 1];
                Array.Copy(b, 0, newB, 0, bMedianI + 1);
            }
            else
            {
                newA = new int[aMedianI + 1];
                Array.Copy(a, 0, newA, 0, aMedianI + 1);

                newB = new int[b.Length - bMedianI];
                Array.Copy(b, bMedianI, newB, 0, b.Length - bMedianI);
            }

            return _MedianOfUnequal(newA, newB);
        }

        private static int _MedianOf4(int a, int b, int c, int d)
        {
            int[] arr = new int[] {a, b, c, d};
            Array.Sort(arr);

            return (arr[1] + arr[2]) / 2;
        }

        private static int _MedianOf3(int a, int b, int c)
        {
            int[] arr = new int[] {a, b, c};
            Array.Sort(arr);

            return arr[1];
        }
        
        private static int _Median(int[] arr, int start, int finish)
        {
            int i = finish - start + 1;

            int median;
            if (i % 2 == 0)
            {
                median = (arr[(start + finish) / 2] + arr[(start + finish) / 2 + 1]) / 2;
            }
            else
            {
                median = arr[(start + finish) / 2];
            }

            return median;
        }

        /*
            Median in a stream of integers (running integers).
            Given that integers are read from a data stream. 

            After each new integer is added to the list, print the list's updated median on a new line 
            as a single double-precision number scaled to 1 decimal place (i.e., 12.3 format).
         */
        private static List<int> _minHeap = new List<int>();
        private static List<int> _maxHeap = new List<int>();
        private static List<int> _stream = new List<int>();

        public static decimal MedianFromStream(int i)
        {
            _stream.Add(i);

            if (_maxHeap.Count == 0 || _maxHeap[0] > i)
            {
                _maxHeap.Add(i);
                _BalanceMax(_maxHeap.Count / 2);
            } else
            {
                _minHeap.Add(i);
                _BalanceMin(_minHeap.Count / 2);
            }

            while (_maxHeap.Count - _minHeap.Count > 1)
            {
                _minHeap.Add(_maxHeap[0]);
                _maxHeap.RemoveAt(0);
                _BalanceMin(_minHeap.Count / 2);
            }

            while (_minHeap.Count - _maxHeap.Count > 1)
            {
                _maxHeap.Add(_minHeap[0]);
                _minHeap.Remove(0);
                _BalanceMax(_maxHeap.Count / 2);
            }

            if (_stream.Count % 2 == 0)
            {
                decimal result = Decimal.Divide(_maxHeap[0] +_minHeap[0], 2);
                return Math.Round(result, 1);
            }
            else if (_maxHeap.Count - _minHeap.Count > 0)
            {
                return _maxHeap[0];
            }
            else
            {
                return _minHeap[0];
            }
        }

        private static void _BalanceMax(int indx)
        {
            if (indx < 0)
            {
                return;
            }

            if ((indx * 2 + 1) <= _maxHeap.Count - 1)
            {
                if (_maxHeap[indx * 2 + 1] > _maxHeap[indx])
                {
                    _Swap(_maxHeap, indx, indx * 2 + 1);
                    _BalanceMax(indx * 2 + 1);
                }
            }
            
            if ((indx * 2 + 2) <= _maxHeap.Count - 1)
            {
                if (_maxHeap[indx * 2 + 2] > _maxHeap[indx])
                {
                    _Swap(_maxHeap, indx, indx * 2 + 2);
                    _BalanceMax(indx * 2 + 1);
                }
            }

            _BalanceMax(indx - 1);
        }

        private static void _BalanceMin(int indx)
        {
            if (indx < 0)
            {
                return;
            }

            if ((indx * 2 + 1) <= _minHeap.Count - 1)
            {
                if (_minHeap[indx * 2 + 1] < _minHeap[indx])
                {
                    _Swap(_minHeap, indx, indx * 2 + 1);
                    _BalanceMin(indx * 2 + 1);
                }
            }
            
            if ((indx * 2 + 2) <= _minHeap.Count - 1)
            {
                if (_minHeap[indx * 2 + 2] < _minHeap[indx])
                {
                    _Swap(_minHeap, indx, indx * 2 + 2);
                    _BalanceMin(indx * 2 + 1);
                }
            }

            _BalanceMin(indx - 1);
        }

        private static void _Swap(List<int> heap, int indx1, int indx2)
        {
            int tmp = heap[indx1];
            heap[indx1] = heap[indx2];
            heap[indx2] = tmp;
        }
    }
}