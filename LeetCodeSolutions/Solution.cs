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
        var pred = new int[nums.Length];
        var mids = new int[nums.Length + 1];
        mids[0] = -1;

        var longest = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            var lo = 1;
            var hi = longest + 1;
            while (lo < hi)
            {
                var mid = lo + (int)Math.Floor((double)(hi - lo) / 2);
                if (nums[mids[mid]] >= nums[i])
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            var newlongest = lo;

            pred[i] = mids[newlongest - 1];
            mids[newlongest] = i;

            if (newlongest > longest)
            {
                longest = newlongest;
            }
        }

        var subSeq = new int[longest];
        var longestMid = mids[longest];

        for (int j = longest - 1; j >= 0; j--)
        {
            subSeq[j] = nums[longestMid];
            longestMid = pred[longestMid];
        }

        return subSeq.Distinct().Count();
    }
}
