class Solution {
public:
    int findDuplicate(vector<int>& nums) {
        for (int& num : nums) {
            if (nums[std::abs(num)] < 0) return std::abs(num);

            nums[std::abs(num)] *= -1;
        }

        return 0;
    }
};
