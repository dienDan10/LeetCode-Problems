class Solution {
public:
    bool hasDuplicate(vector<int>& nums) {
        unordered_set<int> oset {};
        for (const int& num : nums) {
            if (!oset.insert(num).second) return true;
        }
        return false;
    }
};