public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var set = new HashSet<char>();
        var l = 0;
        var result = 0;

        for (int r = 0; r < s.Length; r++) {
            while (set.Contains(s[r])) {
                set.Remove(s[l++]);
            }

            set.Add(s[r]);
            result = Math.Max(result, set.Count);
        }

        return result;
    }
}
