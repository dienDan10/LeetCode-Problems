class Solution {
public:
    vector<vector<int>> combinationSum2(vector<int>& candidates, int target) {
        std::vector<std::vector<int>> result{};
        std::vector<int> subset{};
        std::sort(candidates.begin(), candidates.end());
        backtrack(candidates, 0, target, result, subset);

        return result;
    }

    void backtrack(std::vector<int>& candidates, int index, int target, 
        std::vector<std::vector<int>>& result, std::vector<int>& subset) {
            if (target == 0) {
                result.push_back(subset);
                return;
            }

            if (target < 0 || index >= candidates.size()) return;

            int current = candidates[index];
            subset.push_back(current);
            backtrack(candidates, index + 1, target - current, result, subset);
            subset.pop_back();

            while (current == candidates[index]) index++;
            backtrack(candidates, index, target, result, subset);
    }
};
