public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var map = new Dictionary<char, int>();
        int result = 0;
        for (int i = 0; i < s.Length; i++) {
            if (!map.ContainsKey(s[i])) {
                map.Add(s[i], i);
                continue;
            } 

            if (map.Count > result) result = map.Count;
            i = map[s[i]];
            map.Clear();
        }

        if (map.Count > result) result = map.Count;
        return result;
    }
}
