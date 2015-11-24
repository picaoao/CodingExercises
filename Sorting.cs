namespace Sorting
{
    using System;
    using System.Collections.Generic;

    public class Sorting
    {
        // sort numbers between multitle input sorted arrays, without merging arrays together
        public static int[] SortNumbers(int[][] input)
        {
            // indexes keep the current element in each array of input                 
            var indexes = new int[input.Length];

            // init to 0 for each array index
            for (int i = 0; i < input.Length; i++)
            {
                indexes[i] = 0;
            }

            var output = new List<int>();

            while (true)
            {
                // try to find the array that contains the smallest value ( init to -1 , which means not available (termination case))
                int smallest_input_index = -1;

                // find the array nr that has the smallest value compare i with i-1 between the current element of each input array
                for (int i = 1; i < indexes.Length; ++i)
                {       
                    // if both -1, then means that there are no more elements in input array for i and i-1             
                    if (indexes[i] == -1 && indexes[i - 1] == -1)
                    {
                        continue;
                    }
                    else if (indexes[i] == -1)
                    {
                        smallest_input_index = i - 1;
                    }
                    else if (indexes[i - 1] == -1)
                    {
                        smallest_input_index = i;
                    }
                    else
                    {
                        // we compare both values and select smallest input array
                        if (input[i][indexes[i]] < input[i - 1][indexes[i - 1]])
                            smallest_input_index = i;
                        else
                            smallest_input_index = i - 1;
                    }
                }

                // if there is an input array
                if (smallest_input_index != -1)
                {
                    // get value
                    var val = input[smallest_input_index][indexes[smallest_input_index]];

                    // update current element, if we reach end of input array, we set current element to -1
                    if (input[smallest_input_index].Length == indexes[smallest_input_index] + 1)
                    {
                        // end of input for array
                        indexes[smallest_input_index] = -1;
                    }
                    else
                    {
                        indexes[smallest_input_index] += 1;
                    }

                    // add value to final sorted output list
                    output.Add(val);
                }
                else
                {
                    // means we reach all elements in input arrays
                    break;
                }

            }

            return output.ToArray();
        }

        // get 2 sorted arrays and find the nth greatest number in the 2 arrays, without merging them together
        // ([1, 6, 9, 20], [2, 5, 8, 11, 12], 5) = 8
        public static int FindNGreatestElement(int[] input1, int[] input2, int n)
        {
            int i1 = 0;
            int i2 = 0;

            // nth number
            int j = 0;
            int j_value = 0;

            while (true)
            {
                if (i1 < input1.Length && i2 < input2.Length)
                {
                    if (input1[i1] < input2[i2])
                    {
                        j++;
                        j_value = input1[i1];
                        i1++;
                    }
                    else if (input1[i1] == input2[i2])
                    {
                        j++;
                        j_value = input1[i1];
                        i1++;
                        i2++;
                    }
                    else
                    {
                        j++;
                        j_value = input2[i2];
                        i2++;
                    }
                }
                else if (i1 < input1.Length)
                {
                    j++;
                    j_value = input1[i1];
                    i1++;
                }
                else if (i2 < input2.Length)
                {
                    j++;
                    j_value = input2[i2];
                    i2++;
                }
                else
                {
                    j_value = -1;
                    break;
                }

                if (j == n)
                    break;
            }

            return j_value;
        }
        
        public static int[] SelectionSort(int[] input)
        {           
            for(int i=0; i < input.Length; ++i)
            {                
                for(int j = i+1; j < input.Length; ++j)
                {
                    if(input[j] < input[i])
                    {
                        var tmp = input[i];
                        input[i] = input[j];
                        input[j] = tmp;
                    }
                }
            }
            
            return input;
        }

        public static int[] BubbleSort(int[] input)
        {
            bool sorted = false;
            int k = 0;
            while (!sorted)
            {
                var swap = false;

                for (int i = 0; i < input.Length - 1 - k; ++i)
                {
                    if (input[i] > input[i + 1])
                    {
                        var tmp = input[i + 1];
                        input[i + 1] = input[i];
                        input[i] = tmp;

                        swap = true;
                    }
                }

                if (!swap)
                {
                    sorted = true;
                }

                ++k;
            }

            return input;
        }

        public static int[] QuickSort(int[] input)
        {
            QuickSortHelper(input, 0, input.Length - 1);
            return input;
        }

        public static void QuickSortHelper(int[] input, int start, int end)
        {
            if (start < end)
            {
                var splitPoint = QuickSortPartition(input, start, end);
                QuickSortHelper(input, start, splitPoint - 1);
                QuickSortHelper(input, splitPoint + 1, end);
            }
        }

        public static int QuickSortPartition(int[] input, int start, int end)
        {
            var pivot = input[start];

            int leftMark = start + 1;
            int rightMark = end;

            for (; leftMark <= rightMark;)
            {
                // move left mark
                if (input[leftMark] <= pivot)
                {
                    ++leftMark;
                }
                else
                {
                    if (input[leftMark] > input[rightMark])
                    {
                        //switch
                        var tmp = input[rightMark];
                        input[rightMark] = input[leftMark];
                        input[leftMark] = tmp;
                    }

                    --rightMark;
                }
            }

            input[start] = input[rightMark];
            input[rightMark] = pivot;

            return rightMark;
        }

        public static int[] MergeSort(int[] input)
        {
            if (input.Length == 1)
            {
                return input;
            }

            var mid = 0;
            var size1 = 0;
            var size2 = 0;

            if (input.Length == 2)
            {
                mid = 0;
                size1 = 1;
                size2 = 1;
            }
            else
            {
                mid = input.Length / 2;
                size1 = mid;
                size2 = input.Length - mid;
            }
            var input1 = new int[size1];
            var input2 = new int[size2];

            Array.Copy(input, input1, size1);
            Array.Copy(input, size1, input2, 0, size2);

            int[] leftMergeSort = MergeSort(input1);
            int[] rightMergeSort = MergeSort(input2);
            int[] mergeSort = Merge(leftMergeSort, rightMergeSort);

            return mergeSort;
        }

        public static int[] Merge(int[] input1, int[] input2)
        {
            var sortArray = new int[input1.Length + input2.Length];

            var sortArrayI = 0;

            for (int i = 0, j = 0; i < input1.Length || j < input2.Length; ++sortArrayI)
            {
                if (i == input1.Length)
                {
                    sortArray[sortArrayI] = input2[j];
                    ++j;
                }
                else if (j == input2.Length)
                {
                    sortArray[sortArrayI] = input1[i];
                    ++i;
                }

                else if (input1[i] <= input2[j])
                {
                    sortArray[sortArrayI] = input1[i];
                    ++i;
                }
                else
                {
                    sortArray[sortArrayI] = input2[j];
                    ++j;
                }
            }

            return sortArray;
        }
    }
}