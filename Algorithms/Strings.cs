using System.Collections.Generic;

namespace Algorithms;

public static class Strings
{
    // 3. Longest Substring Without Repeating Characters
    // Difficulty: Medium
    /// <summary>
    /// Given a string s, find the length of the longest substring without duplicate characters.
    /// 
    /// Best optimal solution: O(1) and O(n) time space complexity
    /// Pattern: Sliding-Window
    /// 
    /// </summary>
    /// <remarks>
    /// O(1) Space Complexity: cMap lookups
    /// The problem constraints state the string consists of English letters, digits, symbols, and spaces. 
    /// A fixed 128-element array covers the entire standard ASCII table, 
    /// requiring practically zero memory overhead compared to dynamically resizing a HashSet or Dictionary.
    /// 
    ///  O(n) Time Complexity: s lookup
    /// 
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/description/
    /// 
    /// <param name="s"></param>
    /// <returns></returns>
    public static int LengthOfLongestSubstring_Hash(string s) {
        // Array to store the last seen index of each ASCII character
        int[] cmap = new int[128];
        Array.Fill(cmap, -1); 
        
        int left = 0;
        int maxlen = 0;
        
         // loop current window
        for (int right = 0; right < s.Length; right++) {
            char c = s[right];
            
            //  slide window right when char was last seen in the current window
            if (cmap[c] >= left) {
                left = cmap[c] + 1;
            }
            
            // Update the last seen index for the current character
            cmap[c] = right;
            
            // Calculate max length continuously
            maxlen = Math.Max(maxlen, right - left + 1);
        }
        
        return maxlen;
    }

    /// <summary>
    /// Find the length of the longest substring without duplicate characters from a string
    /// Less performant than sliding-window approach.
    /// </summary>
    /// <param name="s">input string to search</param>
    /// <returns>longest substring without duplicate characters</returns>
    public static int LengthOfLongestSubstring(string s) {
        Dictionary<string, int> charCnt = [];
        HashSet<char> chars = []; // to build key

        //count chars
        string key = "";
        foreach(char c in s) {
            if (!chars.Contains(c)){
                chars.Add(c);
            }
            else{
                key = string.Join("", chars.ToArray());
                charCnt[key] = key.Length;
                chars.Clear();
            }
        }
        key = string.Join("", chars.ToArray());
        charCnt[key] = key.Length;

       return charCnt.Values.Max();
    }


    // Project only single, non-repeating chars from a string
    /// <summary>
    /// Counts characters in string, project only single (non-repeating chars)
    /// </summary>
    /// <param name="input">String to search | e.g. "aabccddde" should return "be"</param>
    /// <remarks>
    /// Time Complexity: $O(n)$
    /// Dictionary lookups and insertions are an average of $O(1)$.
    /// String Join: Constructing the final string using 
    /// string.Join iterates through the HashSet and allocates a new string, taking up to $O(n)$ time.
    /// 
    /// Overall Time: $O(n) + O(n) + O(n)$ simplifies to $O(n)$.
    /// 
    /// Space Complexity: $O(n)$
    /// Overall Space: $O(n)$ to store the data structures and the returned string.
    /// 
    /// </marks>
    /// <returns>a string of single (non-repeating chars) from a string</returns>
    public static string GetNonRepeatedCharsHash(string input)
    {
        // setup data structures
        Dictionary<char, int> charCnt = [];

        // setup data structure that accepts only unique values for O(1) lookups
        HashSet<char> singleChars = [];

        // count input
        foreach(char c in input)
        {
            charCnt[c] = charCnt.GetValueOrDefault(c) + 1;
        }

        // collect non-repeating input
        foreach(char c in input)
        {
            if (charCnt[c] == 1){
                singleChars.Add(c);
            }
        }
        return string.Join("",singleChars);
    }

    /// <summary>
    /// Counts characters in string, project only single (non-repeating chars). 
    /// Less performant due to high overhead of LINQ enumerators, delegates, and the public data structures used by GroupBy
    /// </summary>
    /// <param name="input">String to search | e.g. "aabccddde" should return "be"</param>
    /// <remarks>
    /// Time Complexity: $O(n)$
    /// 
    /// Space Complexity: $O(n)$
    /// Overall Space: $O(n)$ to store the data structures and the returned string.
    /// 
    /// </marks>
    /// <returns>a string of single (non-repeating chars) from a string</returns>
    public static string GetNonRepeatedCharsLinq(string input)
    {
        string result = new([.. input.GroupBy(e => e)
                                     .Where(g => g.Count() == 1)
                                     .Select(g => g.Key)]);
        return result;
    }

}
