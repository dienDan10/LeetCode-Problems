public class Solution {
    public int Search(int[] nums, int target) {
        int l = 0, r = nums.Length - 1;
        while (l <= r) {
            int middle = l + (r - l) / 2;
            if (nums[middle] == target) return middle;

            if (nums[middle] > target) r = middle - 1;
            else l = middle + 1;
        }

        return -1;
    }
}
