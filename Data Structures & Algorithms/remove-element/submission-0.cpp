class Solution {
public:
    int removeElement(vector<int>& nums, int val) {
        nums.erase(std::remove_if(nums.begin(), nums.end(), [&val](const int& num) {
            return num == val;
        }), nums.end());

        return nums.size();
    }
};