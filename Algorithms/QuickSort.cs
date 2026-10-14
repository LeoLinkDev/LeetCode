using System;

public class SortingAlgorithms
{
    // Main method to call for sorting
    public static void QuickSort(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
            return;
            
        QuickSort(arr, 0, arr.Length - 1);
    }

    // Recursive sorting method
    private static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            // Partition the array and get the pivot index
            int pivotIndex = Partition(arr, left, right);

            // Recursively sort the elements before and after partition
            QuickSort(arr, left, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, right);
        }
    }

    // The two-pointer partitioning logic
    private static int Partition(int[] arr, int left, int right)
    {
        // Choose the rightmost element as the pivot
        int pivot = arr[right];
        
        // i will keep track of the boundary of numbers smaller than the pivot
        int i = left - 1;

        // j iterates through the array to compare elements against the pivot
        for (int j = left; j < right; j++)
        {
            // If the current element is smaller than the pivot, swap it into the left side
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        // Finally, swap the pivot into its correct, sorted position
        Swap(arr, i + 1, right);
        
        // Return the index where the pivot ended up
        return i + 1;
    }

    // Helper method to swap two elements in an array
    private static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}