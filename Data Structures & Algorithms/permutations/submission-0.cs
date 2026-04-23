public class Solution {
    public List<List<int>> Permute(int[] nums) {
        List<List<int>> result = new List<List<int>>();
        List<int> subset = new List<int>();
        bool[] used = new bool[nums.Length];
        Dfs(nums, result, subset, used);
        return result;
    }

    private void Dfs(int[] nums, List<List<int>> result, List<int> subset, bool[] used) {
        if (subset.Count == nums.Length) {
            result.Add(new List<int>(subset));
            return;
        }
        
        for (int i = 0; i < used.Length; i++) {
            if (used[i]) continue;
            subset.Add(nums[i]);
            used[i] = true;
            Dfs(nums, result, subset, used);
            subset.RemoveAt(subset.Count - 1);
            used[i] = false;
        }
    }
}
