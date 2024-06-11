using Algorithms.Easy;

/*var ts = new TwoSum();
int[] inputts = { 1, 2, 3, 4, 5 };
var result = ts.method(inputts, 11);
Console.WriteLine(result[0]);
Console.WriteLine(result[1]);

var ri = new RomanToInteger();
Console.WriteLine(ri.RomanToInt("IV"));
Console.WriteLine(ri.RomanToInt("MCMXCIV"));
Console.WriteLine(ri.solution("IV"));*/

/*var lcp = new LongCommonPrefix();
string[] inputlcp = { "testing", "testament", "testing", "taste" };
Console.WriteLine(lcp.LongestCommonPrefix(inputlcp));
Console.WriteLine(lcp.LongestCommonPrefix(inputlcp));*/

/*var pally = new Palindrome();
Console.WriteLine(pally.isPalindrome(121));*/

var vp = new ValidParentheses();
string[] vpinput = { "{]" };
foreach(string test in vpinput)
{
    Console.WriteLine(vp.IsValid(test));
}
