namespace LeetCodeSolutions;

public class Solution
{
    Dictionary<string, bool> valuePairs = new Dictionary<string, bool>();

    public bool WordBreak(string s, IList<string> wordDict)
    {
        if (string.IsNullOrEmpty(s) || wordDict == null || wordDict.Count == 0)
        {
            return false;
        }

        if (valuePairs.ContainsKey(s))
        {
            return valuePairs[s];
        }

        if (wordDict.Contains(s))
        {
            valuePairs[s] = true;
            return true;
        }

        List<string> startsWith = new List<string>();
        foreach (string w in wordDict)
        {
            if (s.StartsWith(w))
            {
                startsWith.Add(w.Substring(0, w.Length));
            }
        }

        foreach (string sw in startsWith)
        {
            if (WordBreak(s.Substring(sw.Length), wordDict))
            {
                valuePairs[s] = true;
                return true;
            }
        }

        valuePairs[s] = false;
        return false;
    }

    public int LengthOfLIS(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return 0;
        }

        var sortedNums = new List<int>();

        foreach (var n in nums)
        {
            var idx = sortedNums.BinarySearch(n);
            if (idx < 0) idx = -(idx + 1);

            if (idx == sortedNums.Count) sortedNums.Add(n);
            else sortedNums[idx] = n;
        }

        return sortedNums.Count;
    }
}
