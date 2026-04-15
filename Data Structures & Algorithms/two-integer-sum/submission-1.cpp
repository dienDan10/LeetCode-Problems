class Solution {
public:
    vector<int> twoSum(vector<int>& nums, int target) {
        unordered_map<int, int> umap{};
        for (int i = 0; i < nums.size(); i++) {
            auto it = umap.find(target - nums.at(i));
            if (it != umap.end())
                return vector<int> {it->second, i};
            
            umap[nums.at(i)] = i;
        }

        return vector<int>{};
    }
};
