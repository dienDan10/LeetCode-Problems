class Solution {
public:
    vector<vector<int>> subsets(vector<int>& nums) {
        std::vector<std::vector<int>> result{};
        std::vector<int> subset{};
        backtrack(result, subset, nums, 0);
        return result;
    }

    void backtrack(std::vector<std::vector<int>>& result, std::vector<int>& subset, std::vector<int>& nums, int index) {
        if (index == nums.size()) {
            result.push_back(subset);
            return;
        }

        backtrack(result, subset, nums, index + 1);
        subset.push_back(nums[index]);
        backtrack(result, subset, nums, index + 1);
        subset.pop_back();
    }
};
