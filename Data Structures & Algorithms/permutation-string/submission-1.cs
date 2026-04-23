public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if (s1.Length > s2.Length) return false;

        int[] count1 = new int[26];
        for (int i = 0; i < s1.Length; i++) {
            count1[s1[i] - 'a']++;
        }

        int[] count2 = new int[26];
        for (int r = 0; r < s2.Length; r++) {
            count2[s2[r] - 'a']++;
            if (r >= s1.Length - 1) {
                if (Matches(count1, count2)) return true; 
                count2[s2[r + 1 - s1.Length] - 'a']--;
            }
        }

        return false;
    }

    public bool Matches(int[] arr1, int[] arr2) {
        for (int i = 0; i < arr1.Length; i++) {
            if (arr1[i] != arr2[i]) return false;
        }

        return true;
    }
}
