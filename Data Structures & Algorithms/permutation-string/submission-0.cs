public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length) return false;

        int[] count1 = new int[26];
        for (int i = 0; i < s1.Length; i++) {
            count1[s1[i] - 'a']++;
        }
        var key1 = string.Join(',', count1);

        int[] count2 = new int[26];
        for (int r = 0; r < s2.Length; r++) {
            count2[s2[r] - 'a']++;
            if (r >= s1.Length - 1) {
                var key2 = string.Join(',', count2);
                if (key1 == key2) return true;
                count2[s2[r + 1 - s1.Length] - 'a']--;
            }
        }

        return false;
    }
}
