public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        List<List<int>> result = new List<List<int>>();
        List<int> subset = new List<int> ();
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

        int next = index + 1;
        while (next < nums.Length && nums[index] == nums[next]) next++;
        subset.RemoveAt(subset.Count - 1);
        Dfs(nums, next, result, subset);
    }
}
