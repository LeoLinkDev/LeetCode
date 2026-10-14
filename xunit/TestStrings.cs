using Algorithms;
namespace Algorithms.xunit;

public class TestStrings(ITestOutputHelper output)
{
    private readonly ITestOutputHelper _output = output;

    [Fact]
    public void Should_get_Length_of_Longest_Substring_Hash()
    {
        // Given
        var testCasesExpectedResults = new Dictionary<string, int>
        {
            {"abcabcbb", 3},
            {"bbbbb", 1},
            {"pwwkew", 3},
            {"", 0},
            {"eeb", 2},
            {"1PK1E", 4}
        };

        foreach (var kv in testCasesExpectedResults)
        {
            // When 
            int actual = Strings.LengthOfLongestSubstring_Hash(kv.Key);
            _output.WriteLine( $"Length Of Longest Substring: {kv.Key} ");
            _output.WriteLine($"Output: {actual} ");
            _output.WriteLine("------------------------");

            // Then
            Assert.Equal(kv.Value, actual);
        }
    }

    [Fact]
    public void Should_Get_NonRepeated_Chars_From_String_Hash()
    {
        // Given
        var testCasesExpectedRes = new Dictionary<string, string>
        {
            {"aabccddde", "be"},
            {"bbbbb", ""},
            {"", ""},
            {"eeb", "b"},
            {"1PK1E", "PKE"}
        };

        foreach (var kv in testCasesExpectedRes)
        {
            // When 
            string actual = Strings.GetNonRepeatedCharsHash(kv.Key);
            _output.WriteLine($"Project non-repeating characters for: '{kv.Key}'");
            _output.WriteLine($"Dictionary/HashSet: '{kv.Value}'");
            _output.WriteLine("------------------------");

            // Then
            Assert.Equal(kv.Value, actual);
        }
    }
    
}
