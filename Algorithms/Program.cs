using System;
using System.Runtime.Serialization;
namespace Algorithms;

class Program
{
    static void Main(string[] args)
    {
        int[] arr  =  [3, 2, 2, 5, 4];
        int res = LongestBalanced(arr);
        Console.WriteLine($"Length Of Longest Balanced Subarray: {res} ");
        Console.WriteLine($"Output: {res} ");
        Console.WriteLine("------------------------");

        // string input  = "pwwkew";
        // int i = Strings.LengthOfLongestSubstring_Hash(input);
        // Console.WriteLine($"Length Of Longest Substring: {input} ");
        // Console.WriteLine($"Output: {i} ");
        // Console.WriteLine("------------------------");

        // // The arr MUST be sorted for Binary Search to work
        // int[] sortedInts = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };

        // int target = 23;

        // Console.WriteLine($"Array: {string.Join(",", sortedInts)}" );
        // Console.WriteLine($"Indic: {string.Join(",", sortedInts.Select((item, index) => index))}" );
        // Console.WriteLine($"Target: {target} ");

        // int resultIdx = 0;
        // resultIdx = BinarySearch.GetIntFromArray_BinarySearch(sortedInts, target);

        // if (resultIdx != -1)
        //     Console.WriteLine($"Binary Search: Element found at index: {resultIdx}");
        // else
        //     Console.WriteLine("Binary Search: Element not found in the arr.");

        // resultIdx = BinarySearch.GetIntFromArray_GetIntFromArray_BinarySearchRecursive(sortedInts, target, 0, sortedInts.Length-1);

        // if (resultIdx != -1)
        //     Console.WriteLine($"Binary Search Recur: Element found at index: {resultIdx}");
        // else
        //     Console.WriteLine("Binary Search Recurs: Element not found in the arr.");

        // input = "aabccddde";
        // string retStr = "";

        // retStr = Strings.GetNonRepeatedCharsHash(input);
        // Console.WriteLine("------------------------");
        // Console.WriteLine($"Project non-repeating characters for: '{input}'");
        // Console.WriteLine($"Dictionary/HashSet: '{retStr}'");
        // Console.WriteLine("------------------------");

        // retStr = Strings.GetNonRepeatedCharsLinq(input);
        // Console.WriteLine($"Project non-repeating characters for: '{input}'");
        // Console.WriteLine($"Linq: {retStr}");
    }

    public static int LongestBalanced(int[] nums) { 
        HashSet<int> even = [];
        HashSet<int> odd = [];
        int maxlen = 0;

        for (int i = 0; i <= nums.Length-1; i++){

                for (int j = i+1; j < nums.Length-1; j++)
                {
                    
                    if (nums[i] != nums[j]){
                        if (nums[i] % 2 == 0){
                            even.Add(nums[i]);
                        }
                        else {
                            odd.Add(nums[i]);
                            }
                    } 
                    else { break; }

                if (even.Count() == odd.Count()){
                    maxlen = Math.Max(maxlen, even.Count());
                }
            }
        }
        return maxlen;
    }
}
