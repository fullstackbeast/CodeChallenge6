using System;

namespace LongestDuplicateSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = LongestDuplicateSubstring("aa");
            
            Console.WriteLine(s);
        }

        static string LongestDuplicateSubstring(string s)
        {
            if (s.Length < 3) return "";
            
            string result = "";

            for (int i = 0; i < s.Length; i++)
            {
                for(int j = 2; j <= s.Length - i; j++)
                {
                    string sub = s.Substring(i, j);
                    if (!CheckDuplicate(s, sub)) continue;
                    if (sub.Length > result.Length) result = sub;
                }
                
            }
            
            
            return result;
        }
        
        static bool CheckDuplicate(string s, string subString)
        {
            int count = 0;
            for (int i = 0; i <= s.Length-subString.Length; i++)
            {
                if (s.Substring(i, subString.Length) == subString)
                {
                    count++;
                    if(count > 1) return true;
                }
            }
            return false;
        }
    
    }
}