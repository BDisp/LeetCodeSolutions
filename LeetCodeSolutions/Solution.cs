namespace LeetCodeSolutions;

public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        if (string.IsNullOrEmpty(s) || wordDict == null || wordDict.Count == 0)
        {
            return false;
        }
        var isSameChars = s.Distinct().Count() == 1 && wordDict.All(x => x[0] == s[0] && x.Distinct().Count() == 1);
        var maxItemLength = wordDict.Aggregate((max, cur) => max.Length > cur.Length ? max : cur).Length;
        var idx = isSameChars ? s.Length : 0;
        var length = isSameChars ? maxItemLength : 1;
        while (true)
        {
            if (isSameChars)
            {
                var sb = s.Substring(idx - length, length);
                var found = wordDict.Contains(sb);
                if (found)
                {
                    idx -= length;
                    length = 1;
                }
                else
                {
                    length++;
                }
                if (idx == 0 || idx - length < 0)
                {
                    return found;
                }
            }
            else
            {
                var found = GetWordBreakResult(s, wordDict, idx, length, out int newIdx, out int newLength);
                if (found)
                {
                    idx = newIdx;
                    length = newLength;
                }
                else
                {
                    length++;
                }
                if (idx == s.Length || idx + length > s.Length)
                {
                    return found;
                }
            }
        }
    }

    private bool GetWordBreakResult(string s, IList<string> wordDict, int idx, int length, out int newIdx, out int newLength)
    {
        newIdx = idx;
        newLength = length;

        while (true)
        {
            var sb = s.Substring(newIdx, newLength);
            var found = wordDict.Contains(sb);
            if (found)
            {
                newIdx += newLength;
                newLength = 1;
            }
            else
            {
                newLength++;
            }
            if (newIdx == s.Length || newIdx + newLength > s.Length)
            {
                return found;
            }
        }
    }
}
