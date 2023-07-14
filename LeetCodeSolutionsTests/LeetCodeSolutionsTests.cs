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
}
