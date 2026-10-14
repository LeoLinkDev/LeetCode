
namespace Algorithms;

public static partial class Sort
{
    /// <summary>
    /// Optimized Two-Pointer (In-Place Merge Simulation)
    /// The 1ms runtime code uses an optimized two-pointer approach. 
    /// Instead of creating a new array and physically merging all elements (which takes $O(m+n)$ space), 
    /// it simulates the merging process to find the median.
    /// 
    /// How it works: 
    ///
    /// It uses two pointers (i and j) to iterate through nums1 and nums2. 
    /// Since it only needs to reach the middle of the combined arrays to find the median, 
    /// the loop runs exactly (total / 2) + 1 times.
    /// 
    /// Tracking state: 
    /// 
    /// It maintains two variables, prev and curr, to store the two most recent values seen. 
    /// This is necessary because if the total number of elements is even, the median requires the average of the two middle elements.
    /// 
    /// Complexity: 
    /// 
    /// This approach improves space complexity to $O(1)$ (constant space) while keeping the time complexity at $O(m+n)$ (linear time).
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns></returns>
    public static double FindMedianSortedArrays_TwoPointers(int[] nums1, int[] nums2) {
        int m = nums1.Length;
        int n = nums2.Length;
        int total = m + n;
        int half = total / 2;
        int i = 0; int j = 0; // two pointers
        int cur = 0;
        int prev = 0;

        // Move pointers until half of the total number of elements are processed.
        for (int k = 0; k <= half; k++){
            prev = cur; // track last seen elements

            // Check array boundries and update current element
            if (i < m && (j >= n || nums1[i] <= nums2[j])){
                cur = nums1[i++];
            } else {
                cur = nums2[j++];
            }
        }

        // return median average of combined last seen elements, if total length is even, or cur elemnt, if odd
        return total % 2 == 0 ? (cur + prev) / 2.0D : cur;
    }

    public static double FindMedianSortedArrays_Into_Third_Array(int[] nums1, int[] nums2) {
        int m = nums1.Length;
        int n = nums2.Length;
        int totalLen = m + n;
        int[] merged = new int[totalLen];
        int i = 0, j = 0, k = 0;
        
        // Merge the two arrays in sorted order
        while (i < m && j < n) {
            if (nums1[i] < nums2[j]) {
                merged[k++] = nums1[i++];
            } else {
                merged[k++] = nums2[j++];
            }
        }
        
        // Add any remaining elements from nums1
        while (i < m) {
            merged[k++] = nums1[i++];
        }
        
        // Add any remaining elements from nums2
        while (j < n) {
            merged[k++] = nums2[j++];
        }
        
        // Find the median
        if (totalLen % 2 == 0) {
            return (merged[totalLen / 2 - 1] + merged[totalLen / 2]) / 2.0;
        } else {
            return merged[totalLen / 2];
        }
    }

    /// <summary>
    /// Sorts the array: zeros grouped on the left, non-zeros sorted ascending on the right
    /// </summary>
    /// <param name="array"></param>
    /// <returns>zero</returns>
    public static void SortArrayWithZerosLeft(int[] array)
    {
        if (array == null || array.Length <= 1) return;

        List<int> nonZeros = [];
        long zeroCount = 0;

        foreach (int num in array)
        {
            if (num == 0) zeroCount++;
            else nonZeros.Add(num);
        }

        // Sort the non-zero elements natively
        nonZeros.Sort();

        // Rewrite back into the original array: Zeros first, then non-zeros
        int index = 0;
        while (zeroCount > 0)
        {
            array[index++] = 0;
            zeroCount--;
        }
        foreach (int num in nonZeros)
        {
            array[index++] = num;
        }
    }
}
