public class Solution {
    public string MinWindow(string s, string t) {
        var mapt = new Dictionary<char, int>();
        foreach (char c in t) {
            if (!mapt.ContainsKey(c)) mapt.Add(c, 1);
            else mapt[c]++;
        }

        int required = mapt.Count;
        int formed = 0;

        var window = new Dictionary<char, int>();

        int l = 0, r = 0;
        int minLength = int.MaxValue;
        int startIndex = 0;

        while (r < s.Length) {
            char c = s[r];
            if (!window.ContainsKey(c)) window.Add(c, 1);
            else window[c]++;

            if (mapt.ContainsKey(c) && window[c] == mapt[c]) formed++;

            // if matched, shrink window from left untill not match
            while (l <= r && formed == required) {
                if (r - l + 1 < minLength) {    // check for minLength every shrink
                    minLength = r - l + 1;
                    startIndex = l;
                }

                char leftChar = s[l];
                if (mapt.ContainsKey(leftChar)) {
                    window[leftChar]--;
                    if (window[leftChar] < mapt[leftChar]) formed--;
                }
                l++;
            }
            r++;
        }

        return minLength == int.MaxValue ? "" : s.Substring(startIndex, minLength);
    }
}
