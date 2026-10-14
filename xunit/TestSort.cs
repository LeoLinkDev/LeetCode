using Algorithms;
using Xunit.Internal;

namespace Algorithms.xunit;

public class SortTests : IClassFixture<OptimalZeroSortService>
{
    private readonly ISortService _sortService;
    private readonly ITestOutputHelper _output;

    public SortTests(OptimalZeroSortService sortService, ITestOutputHelper output)
    {
        _sortService = sortService;
        _output = output;
    }

    [Fact]
    public void Test_Mixed_Optimal_Swaps_Right()
    {
        // Arrange
        int[] input = [2, -1, 3, 8, 0, 4, 0, 7];

        // Act
        SortResult result = _sortService.SortAndCountZeroSwaps(input);

        // Assert
        Assert.Equal(3, result.ZeroSwaps);
        Assert.Equal("Right", result.TargetZeroDirection);
    }

    [Fact]
    public void Test_Mixed_Optimal_Swaps_Left()
    {
        // Arrange
        int[] input = [2, 0, 3, -2, 0, 4, 5, 7];

        // Act
        SortResult result = _sortService.SortAndCountZeroSwaps(input);

        // Assert
        Assert.Equal(4, result.ZeroSwaps);
        Assert.Equal("Left", result.TargetZeroDirection);
    }

    [Fact]
    public void Should_Pick_Optimal_Array_To_Move_Zeros_Left_Or_Right()
    {
        // Given: array | expected minimum zero-only adjacent swaps (Zeros Left vs Zeros Right). 
        // NOTE: Logic determins optimal direction. Non-zeros swaps are not counted.
        var testCases = new (int[]? Input, long Expected)[]
        {     
              (null, 0)
            , (Array.Empty<int>(), 0)
            , (new int[]{ 0 }, 0)
            , (new int[]{ 5 }, 0)
            , (new int[]{ 2, 3, 4, 5, 0, 0, 0, 0 }, 0)  // Zeros Right costs 0 swaps
            , (new int[]{ 2, -1, 3, 8, 0, 4, 0, 7 }, 3)  // Zeros Right costs 3 swaps (Cheaper than Left which costs 9)
            , (new int[]{ 0, 0, 0, 0, 2, -5, 9, 1 }, 0)  // Zeros Left costs 0 swaps
            , (new int[]{ 0, 9 }, 0)                    // Zeros Left costs 0 swaps
            , (new int[]{ 42, 0 }, 0)                   // Zeros Right costs 0 swaps
            , (new int[]{ 0, 2, 0, 4, 0, 6, 0, 8 }, 6)   // Zeros Right costs 6 swaps (Cheaper than Left which costs 10)
            , (new int[]{ 9, 0, 8, 0, 7, 0, 6, 0 }, 6)   // Zeros Left costs 6 swaps (Cheaper than Right which costs 10)
            , (new int[]{ 0, 0, 0, 0, 8 }, 0)          // (0, 0, 0, 0, 0) costs 0 swaps
            , (new int[]{ 3, 4, -1, 99, 2 }, 0)         // No zeros to move
            , (new int[]{ 0, 0, 42 }, 0)                // Zeros Left costs 0 swaps
            , (new int[]{ -5, 0, 0 }, 0)                // Zeros Right costs 0 swaps
            , (new int[]{ 0, 7, -3 }, 0)                // Zeros Left costs 0 swaps
            , (new int[]{ 8, 0, 5 }, 1)                 // Left costs 1, Right costs 1 -> Min is 1
            , (new int[]{ 2, 0, 0, -1, 4, 0, 9 }, 5)     // Zeros Right costs 5 swaps (Cheaper than Left which costs 7)
            , (new int[]{ 0, 3, 4, 0, 5, -2, 0, 1 }, 6)   // Zeros Left costs 6 swaps (Cheaper than Right which costs 9)
            , (new int[]{ 9, 8, 0, 0, 0, 7, 0, 0, 6, 0 }, 8) // Zeros Left costs 8 swaps (Cheaper than Right which costs 12)
            , (new int[]{ 0, 0, 0, 99, 0, 0, 0 }, 3)    // Left costs 3, Right costs 3 -> Min is 3
            , (new int[]{ int.MinValue, 0, int.MaxValue, 0 }, 1) // Left costs 2, Right costs 1 -> Min is 1
        };

        OptimalZeroSortService optimalZeroSortService = new();
        
        foreach (var kvp in testCases)
        {
            // When
            int[]? workingArray = (int[]?)kvp.Input?.Clone();

            // Sort and calculate zero swaps with most optimal directions
            SortResult result = optimalZeroSortService.SortAndCountZeroSwaps(workingArray);

            // Then 
            long actual = result.ZeroSwaps;
            long expected = kvp.Expected;
            bool pass = actual == expected;
            bool sortedArrayHasVaue = result?.SortedArray is not null;

            _output.WriteLine($"Passed: {pass.ToString().PadRight(5)}" +
                            $"| Expected: {expected.ToString().PadRight(2)} " + 
                            $"| Actual: {actual.ToString().PadRight(2)} " + 
                            $"| Dir: {result?.TargetZeroDirection?.PadRight(5)} " + 
                            $"| Result: {(result?.SortedArray is not null ? string.Join(", ", result.SortedArray) : "null")}");
            Assert.Equal(expected, actual);
        }
    }    
}