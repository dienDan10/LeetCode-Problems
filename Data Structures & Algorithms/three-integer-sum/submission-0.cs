public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        Array.Sort(nums);
        var result = new List<List<int>>();

        for (int i = 0; i < nums.Length - 2; i++) {
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int l = i + 1;
            int r = nums.Length - 1;
            while (l < r) {
                int sum = nums[i] + nums[l] + nums[r];
                if (sum == 0) {
                    result.Add(new List<int>() {nums[i], nums[l], nums[r]});
                    l++;

                    while (l < r && nums[l] == nums[l - 1]) l++;
                } else if (sum < 0) {
                    l++;
                } else {
                    r--;
                }
            }
        }

        return result;
    }
}
