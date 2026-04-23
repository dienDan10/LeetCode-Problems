public class Solution {
    public int Search(int[] nums, int target) {
        int l = 0, r = nums.Length;
        while (l < r) {
            int middle = (l + r) / 2;
            if (nums[middle] == target) return middle;

            if (nums[middle] > target) r = middle;
            else l = middle + 1;
        }

        return -1;
    }
}
