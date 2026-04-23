public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++) {
            if (map.ContainsKey(target - nums[i])) {
                return [map[target - nums[i]], i];
            } else {
                map.Add(nums[i], i);
            }
        }

        return [-1, -1];
    }
}
