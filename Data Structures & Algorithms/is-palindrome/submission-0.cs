public class Solution {
    public bool IsPalindrome(string s) {
        int l = 0, r = s.Length - 1;

        while (l < r) {
            while (l < r && !char.IsLetterOrDigit(s[l])) l++;
            while (l < r && !char.IsLetterOrDigit(s[r])) r--;

            if (char.ToLower(s[r]) != char.ToLower(s[l])) return false;

            l++;
            r--;
        }

        return true;
    }
}
