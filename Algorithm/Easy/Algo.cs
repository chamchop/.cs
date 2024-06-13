using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;
using System.Text;

namespace Algorithms.Easy
{
    internal class TwoSum
    {
        /*  Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
            You may assume that each input would have exactly one solution, and you may not use the same element twice.
            You can return the answer in any order.
            Example 1:
            Input: nums = [2,7,11,15], target = 9
            Output: [0,1]
            Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].*/

        public int[] method(int[] nums, int target)
        {
            int[] res = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                int j = 1;
                while (j < nums.Length)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        res[0] = nums[i];
                        res[1] = nums[j];
                        break;
                    }
                    j++;
                }
                if (res[0] + res[1] == target)
                    break;
            }
            return res;
        }

        public int[] solution(int[] nums, int target)
        {
            Dictionary<int, int> dict = new();
            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                int complement = target - nums[i];
                if (dict.ContainsKey(complement))
                    return new int[] { dict[complement], i };
                dict[nums[i]] = i;
            }

            return new int[] { };
        }
    }
    internal class RomanToInteger
    {
        /*  Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

            Symbol       Value
            I             1
            V             5
            X             10
            L             50
            C             100
            D             500
            M             1000

            There are six instances where subtraction is used:
                I can be placed before V (5) and X (10) to make 4 and 9.
                X can be placed before L (50) and C (100) to make 40 and 90.
                C can be placed before D (500) and M (1000) to make 400 and 900.

            Given a roman numeral, convert it to an integer.

            Example 1:
            Input: s = "III"
            Output: 3
            Explanation: III = 3. */

        public int RomanToInt(string s)
        {
            s = ConvertToRoman(s);
            int result = 0;
            var characters = s.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                result += ConvertToInt(characters[i]);
            }
            return result;
        }

        public string ConvertToRoman(string s)
        {
            s = s.Replace("IV", "IIII");
            s = s.Replace("IX", "VIIII");
            s = s.Replace("XL", "XXXX");
            s = s.Replace("XC", "LXXXX");
            s = s.Replace("CD", "CCCC");
            s = s.Replace("CM", "DCCCC");
            return s;
        }

        public int ConvertToInt(char s) =>
            s switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new ArgumentException()
            };

        public int solution(string s)
        {
            var m = new Dictionary<char, int> {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            int ans = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (i + 1 < s.Length && m[s[i]] < m[s[i + 1]]) ans -= m[s[i]];
                else ans += m[s[i]];
            }

            return ans;
        }
    }
    internal class LongCommonPrefix
    {
        /*  Write a function to find the longest common prefix string amongst an array of strings.
            If there is no common prefix, return an empty string "".

            Example 1:
            Input: strs = ["flower","flow","flight"]
            Output: "fl"
           
            Example 2:
            Input: strs = ["dog","racecar","car"]
            Output: ""
            Explanation: There is no common prefix among the input strings. */

        public string LongestCommonPrefix(string[] arr)
        {
            string prefix = "";
            string res = "";
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                while (i < arr.Length)
                {
                    for (int j = 0; j < arr[i + 1].Length; j++)
                    {
                        char a = arr[i][j];
                        char b = arr[i + 1][j];
                        if (a.Equals(b))
                        {
                            count++;
                            if (count > j)
                            {
                                prefix += arr[i][j];
                                if (prefix.Length > res.Length) res += arr[i][j];
                            }
                            else count = 0;
                        }
                        else break;
                    }
                }
            }
            return res;
        }

        public string solution(string[] strs)
        {
            if (strs == null || strs.Length == 0) return string.Empty;

            Array.Sort(strs);
            StringBuilder ans = new StringBuilder();
            string first = strs[0];
            string last = strs[strs.Length - 1];

            for (int i = 0; i < Math.Min(first.Length, last.Length); i++)
            {
                if (first[i] != last[i]) return ans.ToString();
                ans.Append(first[i]);
            }

            return ans.ToString();
        }
    }
    internal class Palindrome
    {
        public bool isPalindrome(int x)
        {
            if (x < 0)
                return false;

            int reversed = 0;
            int temp = x;

            while (temp != 0)
            {
                int digit = temp % 10;
                reversed = reversed * 10 + digit;
                temp /= 10;
            }

            return (reversed == x);
        }
    }
    internal class ValidParentheses
    {
        /*  Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
            An input string is valid if:
            Open brackets must be closed by the same type of brackets.
            Open brackets must be closed in the correct order.
            Every close bracket has a corresponding open bracket of the same type.

            Example 1:
            Input: s = "()"
            Output: true
            Example 2:
            Input: s = "()[]{}"
            Output: true
            Example 3:
            Input: s = "(]"
            Output: false   */

        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
                if (c == '(' || c == '{' || c == '[')
                    stack.Push(c);
                else
                {
                    if (stack.Count == 0 ||
                        (c == ')' && stack.Peek() != '(') ||
                        (c == '}' && stack.Peek() != '{') ||
                        (c == ']' && stack.Peek() != '['))
                        return false;
                    stack.Pop();
                }
            return stack.Count == 0;
        }
    }
    internal class MergeSortedLists
    {
        /*  You are given the heads of two sorted linked lists list1 and list2.
            Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.
            Return the head of the merged linked list.

            Example 1:
            Input: list1 = [1,2,4], list2 = [1,3,4]
            Output: [1,1,2,3,4,4]

            Example 2:
            Input: list1 = [], list2 = []
            Output: []  */

        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode dummy = new ListNode();
            ListNode cur = dummy;

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    cur.next = list1;
                    list1 = list1.next;
                }
                cur = cur.next;
            }

            if (list1 != null || list2 != null)
                cur.next = list1 ?? list2;

            return dummy.next;
        }
    }
    internal class RemoveDuplicate
    {
        /*  Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. 
            The relative order of the elements should be kept the same. Then return the number of unique elements in nums.
            Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

            Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. 
            The remaining elements of nums are not important as well as the size of nums.
            Return k.
            Input: nums = [1,1,2]
            Output: 2, nums = [1,2,_]
            Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
            It does not matter what you leave beyond the returned k (hence they are underscores).   */

        public int RemoveDuplicates(int[] nums)
        {
            int j = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[j] = nums[i];
                    j++;
                }
            }
            return j;
        }
    }
    internal class RemoveElement
    {
        /*  Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. 
            The order of the elements may be changed. Then return the number of elements in nums which are not equal to val.
            Consider the number of elements in nums which are not equal to val be k, to get accepted, you need to do the following things:

            Change the array nums such that the first k elements of nums contain the elements which are not equal to val. 
            The remaining elements of nums are not important as well as the size of nums.
            Return k.

            Example 1:
            Input: nums = [3,2,2,3], val = 3
            Output: 2, nums = [2,2,_,_]
            Explanation: Your function should return k = 2, with the first two elements of nums being 2.
            It does not matter what you leave beyond the returned k (hence they are underscores).   */

        public int solution(int[] nums, int val)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    count++;
                }
            }
            return count;
        }
    }
    internal class StringOccurrenceIndex
    {
        /*  Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
            Example 1:
            Input: haystack = "sadbutsad", needle = "sad"
            Output: 0
            Explanation: "sad" occurs at index 0 and 6.
            The first occurrence is at index 0, so we return 0. */

        public int StrStr(string haystack, string needle)
        {
            var str = haystack.IndexOf(needle);
            return str;
        }
    }
}