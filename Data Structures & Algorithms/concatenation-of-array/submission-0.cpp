class Solution {
public:
    vector<int> getConcatenation(vector<int>& nums) {
        int size_nums = nums.size();
        std::vector<int> result (size_nums * 2);
        for (int i = 0; i < size_nums; i++) {
            result[i] = nums[i];
            result[i + size_nums] = nums[i];
        }

        return result;
    }
};