namespace LeetCodeSolutions;

public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var r = s;
        foreach (var w in wordDict)
        {
            var pos = r.IndexOf(w);
            while (pos >= 0)
            {
                if (pos >= 0)
                {
                    r = r.Remove(pos, w.Length);
                }
                else
                {
                    break;
                }

                pos = r.IndexOf(w);
            }
            if (r.Length == 0)
            {
                return true;
            }
        }
        return r.Length == 0;
    }
}
