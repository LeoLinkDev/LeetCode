namespace Algorithms
{
    public static class MergeSort
    {
        public static int[] MergeSortArrayRecursive(int[] nums)
        {
            // Base case: arrays of length 0 or 1 are already sorted
            if (nums.Length <= 1) return nums;

            // 1. Divide the array into two halves
            int mid = nums.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[nums.Length - mid];
            Array.Copy(nums, 0, left, 0, mid);
            Array.Copy(nums, mid, right, 0, nums.Length - mid);

            // 2. Recursively sort both halves, then merge them
            return MergeSortArrays(MergeSortArrayRecursive(left), MergeSortArrayRecursive(right));
        }

        private static int[] MergeSortArrays(int[] left, int[] right)
        {
            int[] merged = new int[left.Length + right.Length];
            int i = 0; // Pointer for left array
            int j = 0; // Pointer for right array
            int k = 0; // Pointer for merged array

            // 3. Merge the two sorted arrays by comparing elements
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    merged[k++] = left[i++];
                }
                else
                {
                    merged[k++] = right[j++];
                }
            }

            // 4. Collect any remaining elements from the left array
            while (i < left.Length)
            {
                merged[k++] = left[i++];
            }

            // 5. Collect any remaining elements from the right array
            while (j < right.Length)
            {
                merged[k++] = right[j++];
            }

            return merged;
        }
        
        public static int[] SortMergeTwoArrays(int[] nums1, int[] nums2){
            int m = nums1.Length;
            int n = nums2.Length;
            int total = m + n;
            int[] merged = new int[total];
            int i = 0; int j = 0; int k = 0;

            while( i <= m && j <= n)
                if (i <= m){
                    merged[k++] = nums1[i++];
                } else {
                    merged[k++] = nums2[j++];
                }

            while (i <= m){
                merged[k++] = nums1[i++]; 
            }

            while (j <= n){
                merged[k++] = nums1[j++]; 
            }

            return merged;
        }        
    }    
}