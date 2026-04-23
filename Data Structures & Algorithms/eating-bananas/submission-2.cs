public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        // find the max number in the array
        int max = 0;
        foreach (var num in piles) {
            if (num > max) max = num;
        }

        // binary search from 1 to max until we find the correct number
        int left = 1, right = max;
        int k = 0;
        while (left <= right) {
            int middle = left + (right - left) / 2;
            int totalHour = 0;
            foreach (var num in piles) {
                totalHour += (num + middle - 1) / middle; // hours to eat curren pile
            }
            
            if (totalHour <= h) { // continue to search to find a smaller number
                k = middle;
                right = middle - 1;
            } else {
                left = middle + 1;
            }
        }

        return k;
    }
}
