using System;
namespace Algorithms;

/// <summary>
/// Binary search with O(log n) time complexity.
/// </summary>
public static class BinarySearch
{

    /// <summary>
    /// Halving the work: The left = mid + 1 and right = mid - 1 lines are where the magic happens. 
    /// Instead of checking every index one by one (which would be linear time, or O(n), 
    /// this code actively narrows down the searchable elements by 50% during every iteration of the while loop.
    /// 
    /// Requirement: Array must be sorted.
    /// </summary>
    /// <remarks>
    /// This code is O(log n) time complexity, which is much faster than linear time for large datasets.
    /// </remarks>
    /// <param name="arr">The sorted arr to search in.</param>
    /// <param name="target">The value to search for.</param>
    /// <returns>The index of the target value if found, otherwise -1.</returns>
    public static int GetIntFromArray_BinarySearch(int[]? arr, int target)
    {
        if (arr == null || arr.Length <= 0) return -1;
        Array.Sort(arr);
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            // Avoid potential integer overflow compared to (left + right) / 2
            int mid = left + (right - left) / 2;
            
            // Check if target is present at mid
            if (arr[mid] == target)
                return mid;

            // If target is greater, ignore the left half
            if (arr[mid] < target)
                left = mid + 1;
            // If target is smaller, ignore the right half
            else
                right = mid - 1;
        }

        // Target was not present in the arr
        return -1;
    }


    public static int GetIntFromArray_GetIntFromArray_BinarySearchRecursive(int[] arr, int target, int left, int right)
    {
        // Target not found
        if (left > right) return -1;
        
        // Calculate mid-point (safe from integer overflow)
        int mid = left + (right - left) / 2;
        
        // target found!
        if (arr[mid] == target)
        {
            return mid;
        }

        // target is larger, check right half
        if (arr[mid] < target)
        {
          return GetIntFromArray_GetIntFromArray_BinarySearchRecursive(arr, target, mid + 1, right);
        }

        // target is smaller, check left half
          return GetIntFromArray_GetIntFromArray_BinarySearchRecursive(arr, target, left, mid -1);
    }
}
