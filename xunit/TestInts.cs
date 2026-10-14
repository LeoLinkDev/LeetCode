using Algorithms;
using Xunit.Internal;
namespace Algorithms.xunit;

public class TestInts(ITestOutputHelper output)
{
    private readonly ITestOutputHelper _output = output;

    [Fact]
    public void Should_Get_Median_of_Two_Sorted_Arrays_TwoPointer()
    {
        // Given: nums1 | nums2 | expected
        var testCases = new Dictionary<int[], KeyValuePair<int[], double>>
        {
              {[1, 3 ], new KeyValuePair<int[], double>([2], 2.00000D)}
            , {[1, 2 ], new KeyValuePair<int[], double>([3, 4], 2.50000D)}
        };

        foreach (var kv in testCases)
        {
            // When 
            double actual = Sort.FindMedianSortedArrays_TwoPointers(kv.Key, kv.Value.Key);
            _output.WriteLine($"\nNums1: {String.Join(",", kv.Key)}");
            _output.WriteLine($"Nums2: {String.Join(",", kv.Value.Key)}");
            _output.WriteLine($"Expected: {kv.Value.Value} ");
            _output.WriteLine($"Actual: {actual} ");
            _output.WriteLine("------------------------");

            // Then
            Assert.Equal(kv.Value.Value, actual);
        }
    }

    [Fact]
    public void Should_Get_Index_From_Unsorted_Array_BinarySearch()
    {
        // Given: array | target find | expected
        var testCases = new (int[]? input, KeyValuePair<int,int> expected)[] 
        {
              (null, new KeyValuePair<int, int>(23, -1 ))
            , (Array.Empty<int>(), new KeyValuePair<int, int>(23, -1))
            , (new int[]{2, 5, 8, 12, 16, 23, 38, 56, 72, 91}, new KeyValuePair<int, int>(23, 5))
            , (new int[]{42, 17, 89, 5, 23, 71, 9, 56, 34, 11}, new KeyValuePair<int, int>(5, 0)) // unsorted but function will sort it
        };

        foreach (var kv in testCases)
        {
            // When 
            int actual = BinarySearch.GetIntFromArray_BinarySearch(kv.input, kv.expected.Key);
            _output.WriteLine($"\nArray: {(kv.input is not null ? String.Join(",", kv.input) : "null")}");
            _output.WriteLine($"Target Find: {kv.expected.Key} ");
            _output.WriteLine($"Expected: {kv.expected.Value} ");
            _output.WriteLine($"Actual: {actual} ");
            _output.WriteLine("------------------------");

            // Then
            Assert.Equal(kv.expected.Value, actual);
        }
    }

}
