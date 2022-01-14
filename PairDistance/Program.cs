using System;
using System.Collections.Generic;

namespace PairDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PairDistance(new int[]{1,1,1}, 2));
        }
        
        static int PairDistance(int[] arr, int k)
        {
            if(arr.Length == 0) return 0;
            var differences = new List<int>();
            for (var i = 0; i < arr.Length -1; i++)
            {
                for (var j = i + 1; j < arr.Length; j++) 
                    differences.Add(Math.Abs(arr[i] - arr[j]));
            }
            
            differences.Sort();

            return differences[k -1];
        }
    }
}