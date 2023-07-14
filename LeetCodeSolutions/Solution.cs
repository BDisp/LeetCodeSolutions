namespace LeetCodeSolutions;

public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        var r = s;
        for (int i = 0; i < wordDict.Count; i++)
        {
            string? w = wordDict[i];
            while (true)
            {
                var pos = r.IndexOf(w);
                if (pos >= 0)
                {
                    r = r.Remove(pos, w.Length);
                }
                else
                {
                    break;
                }
            }
            if (r.Length == 0)
            {
                return true;
            }
        }
        return r.Length == 0;
    }
}
