public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) return false;

        int[] count = new int[30];

        foreach (var c in s.ToCharArray()) {
            count[c - 'a']++;
        }

        foreach (var c in t.ToCharArray()) {
            count[c - 'a']--;
        }

        foreach (var c in count) {
            if (c != 0) return false;
        }

        return true;
    }
}
