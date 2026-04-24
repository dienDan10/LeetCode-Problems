class Solution {
public:
    vector<vector<int>> subsetsWithDup(vector<int>& nums) {
        std::sort(nums.begin(), nums.end());
        std::vector<std::vector<int>> result{};
        std::vector<int> subset{};
        backtrack(nums, 0, result, subset);
        return result;
    }

    void backtrack(std::vector<int>& nums, int index, std::vector<std::vector<int>>& result,
        std::vector<int>& subset) {
            if (index == nums.size()) {
                result.push_back(subset);
                return;
            }

            int current = nums[index];
            subset.push_back(current);
            backtrack(nums, index + 1, result, subset);
            subset.pop_back();

            while (current == nums[index]) index++;
            backtrack(nums, index, result, subset);
    }
};
