using System;
using System.Collections.Generic;
using System.Linq;

namespace Validparentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join('-', ValidParentheses("()()(")));
        }

        static List<string> ValidParentheses(string s)
        {
            var result = new List<string>();

            if (IsValidParentheses(s))
            {
                result.Add(s);
                return result;
            }

            for (var i = 1; i < s.Length; i++)
            {
                if (result.Count > 0) break;

                var subs = RemoveSubString(s, i);

                result.AddRange(subs.Where(IsValidParentheses));
            }

            return result.Distinct().ToList();
        }

        static List<string> RemoveSubString(string s, int count)
        {
            var subStrings = new List<string>();

           
            for (int i = 0; i < s.Length - count; i++)
            {
                int j = count;
            
                var newSub = s;
            
                while (j >= 0)
                {
                    newSub = newSub.Remove(i, 1);
                    j--;
                }
            
                subStrings.Add(newSub);
            }


            return subStrings;
        }

        static bool IsValidParentheses(string s)
        {
            var stack = new Stack<char>();

            var isValid = true;

            foreach (var c in s)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }

                else if (c == ')')
                {
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    stack.Pop();
                }
            }

            return isValid && stack.Count == 0;
        }
    }
}