class Solution {
public:
    vector<vector<int>> permute(vector<int>& nums) {
        std::vector<std::vector<int>> result{};
        std::vector<int> subset{};
        std::vector<bool> selected(nums.size(), false);
        backtrack(nums, result, subset, selected);
        return result;
    }

    void backtrack(std::vector<int>& nums, std::vector<std::vector<int>>& result, 
        std::vector<int>& subset, std::vector<bool>& selected) {
            if (subset.size() == nums.size()) {
                result.push_back(subset);
                return;
            }

            for (int i = 0; i < nums.size(); i++) {
                if (selected[i] == true) continue;
                subset.push_back(nums[i]);
                selected[i] = true;
                backtrack(nums, result, subset, selected);
                subset.pop_back();
                selected[i] = false;
            }
    }
};
