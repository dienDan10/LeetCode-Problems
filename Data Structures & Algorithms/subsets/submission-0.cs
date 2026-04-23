public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> result = new List<List<int>>();
        List<int> subset = new List<int>();
        Dfs(nums, 0, result, subset);
        return result;
    }

    private void Dfs(int[] nums, int index, List<List<int>> result, List<int> subset) {
        if (index >= nums.Length) {
            result.Add(new List<int> (subset));
            return;
        }

        subset.Add(nums[index]);
        Dfs(nums, index + 1, result, subset);

        subset.Remove(nums[index]);
        Dfs(nums, index + 1, result, subset);
    }
}
