public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int l = 0, r = numbers.Length - 1;

        while (l < r) {
            int sum = numbers[l] + numbers[r];

            if (sum == target) return [l + 1, r + 1];

            if (sum < target) {
                l++;
            } else {
                r--;
            }
        }

        return [-1, -1];
    }
}
