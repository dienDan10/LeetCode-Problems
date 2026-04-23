public class Solution {
    public int FindMin(int[] nums) {
        int left = 0, right = nums.Length - 1;
        int res = nums[0];
        while (left <= right) {
            if (nums[left] < nums[right]) {
                res = Math.Min(res, nums[left]);
                break;
            }

            int middle = left + (right - left) / 2;
            res = Math.Min(nums[middle], res);

            if (nums[middle] >= nums[left]) {
                left = middle + 1;
            } else {
                right = middle - 1;
            }
        }

        return res;
    }
}
