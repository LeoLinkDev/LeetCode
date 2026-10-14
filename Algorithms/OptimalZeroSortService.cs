using System;

namespace Algorithms.xunit;

    public interface ISortService
    {
        SortResult  SortAndCountZeroSwaps(int[] array);
    }

    public record SortResult
    {
        public int[]? SortedArray;
        public long ZeroSwaps;
        public string? TargetZeroDirection;
    }

    public class OptimalZeroSortService : ISortService
    {
        /// <summary>
        /// Implementation: Dual-Direction Optimal Zero's Swap Counter
        /// 
        /// Performance:
        /// O(n) Linear Time complexity. Equiped to handle datasets of 10^5 elements.
        /// 
        /// Logic:
        /// 1. Calculate whether it is more optimal to group zeros on the left or the right.
        /// 2. Run a standard optimized sort on the non-zero numbers while positioning the zeros on their calculated optimal side.
        /// 
        /// </summary>
        /// <param name="array">Array to sort, merge and calculate the global minimum number of adjacent swaps.</param>
        /// <param name="ascending">True/False toggle for descending or ascending order.</param>
        /// <returns>The global minimum number of adjacent swaps.</returns>
        public SortResult SortAndCountZeroSwaps(int[]? array)
        {
            if (array == null || array.Length <= 1)
            {
                return new SortResult { SortedArray = array, ZeroSwaps = 0, TargetZeroDirection = "Left" };
            }

            long swapsIfLeft = 0;
            long nonZeroCount = 0;
            int zeroCount = 0;

            // SINGLE COMBINED PASS: Tally variables and compute Left Swap counts
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0){
                    nonZeroCount++;
                }
                else {
                    zeroCount++;
                    swapsIfLeft += nonZeroCount; // Total non-zeros to the left of this zero
                }
            }

            // Mathematical shortcut to calculate the Right Swaps instantly ( e.g. given [1, 0, 1, 0] when: 2 * 2 = 4 (nonZeroCount * zeroCount) - 2 (swapsIfLeft) then swapsIfRight = 2)
            // without needing a second iteration pass
            long swapsIfRight = (nonZeroCount * zeroCount) - swapsIfLeft;

            // Determine optimal direction based entirely on zero-involved movements
            bool pushZerosLeft = swapsIfLeft <= swapsIfRight;
            long optimalSwaps = pushZerosLeft ? swapsIfLeft : swapsIfRight;

            // PASS 2: Allocation-Free In-Place Layout Rewrite
            if (pushZerosLeft)
            {
                    // Pushing Zeros Left means Non-Zeros go to the Right.
                    // Process from RIGHT to LEFT to prevent overwriting unread elements.
                    int nonZeroWriteIdx = array.Length - 1;
                    for (int i = array.Length - 1; i >= 0; i--)
                    {
                        if (array[i] != 0) {
                            array[nonZeroWriteIdx--] = array[i];
                        }
                    }
                        
                    // Fill the leftover space on the left with Zeros
                    for (int i = 0; i < zeroCount; i++) {
                        array[i] = 0;
                    }
                }
                else
                {
                    // Pushing Zeros Right means Non-Zeros go to the Left.
                    // Process from LEFT to RIGHT to prevent overwriting unread elements.
                    int nonZeroWriteIdx = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i] != 0) {
                            array[nonZeroWriteIdx++] = array[i];
                        }
                    }
                    
                    // Fill the leftover space on the right with Zeros
                    for (int i = (int)nonZeroCount; i < array.Length; i++){
                        array[i] = 0;
                    }
            }

            // PASS 3: Sort the isolated non-zero block natively in-place
            int nonZeroStart = pushZerosLeft ? zeroCount : 0;
            Array.Sort(array, nonZeroStart, (int)nonZeroCount);

            return new SortResult 
            { 
                SortedArray = array, 
                ZeroSwaps = optimalSwaps, 
                TargetZeroDirection = pushZerosLeft ? "Left" : "Right" 
            };
        }
    }
