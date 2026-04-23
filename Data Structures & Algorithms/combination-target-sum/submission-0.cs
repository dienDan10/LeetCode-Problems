public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        List<List<int>> result = new List<List<int>>();
        List<int> subset = new List<int>();
        Dfs(nums, 0, 0, target, result, subset);
        return result;
    }

    private void Dfs(int[] nums, int index, int sum, int target, List<List<int>> result, List<int> subset) {
        if (index >= nums.Length || sum > target) return;

        if (sum == target) {
            result.Add(new List<int> (subset));
            return;
        }

        subset.Add(nums[index]);
        Dfs(nums, index, sum + nums[index], target, result, subset);

        subset.Remove(nums[index]);
        Dfs(nums, index + 1, sum, target, result, subset);
    }
}
