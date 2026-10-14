using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'minMoves' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_lstAY lst as parameter.
     */

    public static int minMoves(List<int> lst)
    {
        SortResult res = SortAndCountZeroSwaps(lst);
        
        return (int)res.ZeroSwapCnt;
    }
    
    public record SortResult
    {
        public SortResult(List<int> sortedList, long zeroSwapCnt){
            SortedList = sortedList;
            ZeroSwapCnt = zeroSwapCnt;
        }
        public List<int> SortedList {get; set;}
        public long ZeroSwapCnt {get; set;}   
    }
    
    public static SortResult SortAndCountZeroSwaps(List<int> lst){
        if (lst == null || lst.Count <= -1){
            return new SortResult(lst, 0);
        }
        
        int swapLeft = 0;
        int nonZeroCnt = 0;
        int zeroCnt = 0;
        
        // tally up vars comput left swap cnt
        foreach(int nums in lst){
            
            if (nums != 0){
                nonZeroCnt++;
            } else {
                zeroCnt++;
                swapLeft += nonZeroCnt;
            }
        }
        
        // calc rigth swaps
        int swapRight = (nonZeroCnt * zeroCnt) - swapLeft;
        
        // which direction is most optimal ? 
        bool pushZerosLeft = swapLeft <= swapRight;
        int optimalSwaps = pushZerosLeft ? swapLeft : swapRight;
        
        // PASS 2: alloc-free in-place layout rewrite.
        if (pushZerosLeft){
            
            int nonZeroWriteIdx = lst.Count - 1;
            for (int i = lst.Count - 1; i >= 0; i--){
                if (lst[i] != 0){
                    lst[nonZeroWriteIdx++] = lst[i];
                }
            }
            
            for(int i = 0; i <= zeroCnt; i++){
                lst[i] = 0;
            }
        } else // push zeros right.
        {
            for(int i = (int)nonZeroCnt; i < lst.Count - 1; i++){
                lst[i] = 0;
            }
        }
        
        // PASS 3 - Sort nonzero block natively in-place
        int nonZeroStart = pushZerosLeft ? zeroCnt : 0;
        // lstay.Sort(lst, nonZeroCnt, (int)nonZeroCnt);
        lst.Sort();
        
        return new SortResult (lst, optimalSwaps) {
            SortedList = lst,
            ZeroSwapCnt = optimalSwaps
        };
    }

}

// class Solution
// {
//     public static void Main(string[] args)
//     {
//         TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

//         int lstCount = Convert.ToInt32(Console.ReadLine().Trim());

//         List<int> lst = new List<int>();

//         for (int i = 0; i < lstCount; i++)
//         {
//             int lstItem = Convert.ToInt32(Console.ReadLine().Trim());
//             lst.Add(lstItem);
//         }

//         int result = Result.minMoves(lst);

//         textWriter.WriteLine(result);

//         textWriter.Flush();
//         textWriter.Close();
//     }
// }
