public class Solution {
    public int CharacterReplacement(string s, int k) {
        // window size - mostFrequence <= k
        int[] count = new int[26];
        int mostFrequence = 0;
        int l = 0;
        int length = 0;

        for (int r = 0; r < s.Length; r++) {
            count[s[r] - 'A']++;
            mostFrequence = Math.Max(mostFrequence, count[s[r] - 'A']);

            while ((r - l + 1) - mostFrequence > k) {
                count[s[l] - 'A']--;
                l++;
            }

            length = Math.Max(length, r - l + 1);
        }

        return length;
    }
}
