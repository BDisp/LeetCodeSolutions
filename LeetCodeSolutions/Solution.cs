using System.Linq;

namespace LeetCodeSolutions;

public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
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
                var sb = s.Substring(idx, length);
                var found = wordDict.Contains(sb);
                if (found)
                {
                    idx += length;
                    length = 1;
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
}
