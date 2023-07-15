using LeetCodeSolutions;

namespace LeetCodeSolutionsTests;

public class LeetCodeSolutionsTests : Solution
{
    [Theory]
    [InlineData(null, null, false)]
    [InlineData("", null, false)]
    [InlineData(null, new string[] { }, false)]
    [InlineData("", new string[] { }, false)]
    [InlineData("leetcode", new string[] { "leet", "code" }, true)]
    [InlineData("applepenapple", new string[] { "apple", "pen" }, true)]
    [InlineData("catsandog", new string[] { "cats", "dog", "sand", "and", "cat" }, false)]
    [InlineData("bb", new string[] { "a", "b", "bbb", "bbbb" }, true)]
    [InlineData("cars", new string[] { "car", "ca", "rs" }, true)]
    [InlineData("aaaaaaa", new string[] { "aaaa", "aaa" }, true)]
    [InlineData("goalspecial", new string[] { "go", "goal", "goals", "special" }, true)]
    [InlineData("aebbbbs", new string[] { "a", "aeb", "ebbbb", "s", "eb" }, true)]
    public void WordBreakTests(string s, IList<string> wordDict, bool expected)
    {
        Assert.Equal(expected, WordBreak(s, wordDict));
    }

    [Theory]
    [InlineData(null, 0)]
    [InlineData(new int[] { }, 0)]
    [InlineData(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
    [InlineData(new int[] { 0, 1, 0, 3, 2, 3 }, 4)]
    [InlineData(new int[] { 7, 7, 7, 7, 7, 7, 7 }, 1)]
    public void LengthOfLISTests(int[] nums, int expected)
    {
        Assert.Equal(expected, LengthOfLIS(nums));
    }
}
