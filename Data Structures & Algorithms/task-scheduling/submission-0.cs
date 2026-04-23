public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int[] count = new int[26];
        int maxFrequency = 0;
        foreach (char num in tasks) {
            count[num - 'A']++;
            maxFrequency = Math.Max(maxFrequency, count[num - 'A']);
        }

        int maxFrequencyCount = 0;
        foreach (int num in count) {
            if (num == maxFrequency) 
                maxFrequencyCount++; 
        }

        return Math.Max(tasks.Length, (maxFrequency - 1) * (n + 1) + maxFrequencyCount);
    }
}
