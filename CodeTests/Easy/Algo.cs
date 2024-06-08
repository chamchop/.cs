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
}