public class Solution {
    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        List<List<int>> result = new List<List<int>>();
        List<int> subset = new List<int>();
        Array.Sort(candidates);
        Dfs(candidates, 0, 0, target, result, subset);
        return result;
    }

    private void Dfs(int[] nums, int index, int sum, int target, List<List<int>> result, List<int> subset) {
        if (sum == target) {
            result.Add(new List<int> (subset));
            return;
        }

        if (index >= nums.Length || sum > target) return;
        
        subset.Add(nums[index]);
        Dfs(nums, index + 1, sum + nums[index], target, result, subset);

        subset.Remove(nums[index]);
        int next = index + 1;
        while (next < nums.Length && nums[index] == nums[next]) next++;
        Dfs(nums, next, sum, target, result, subset);
    }
}
