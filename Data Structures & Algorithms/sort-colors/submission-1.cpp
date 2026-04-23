class Solution {
public:
    void sortColors(vector<int>& nums) {
        std::array<int, 3> counts{};

        for (const int& num : nums) {
            counts[num]++;
        }

        int i = 0;
        for (int j = 0; j < 3; j++) {
            while (counts[j] > 0) {
                nums[i++] = j;
                counts[j]--; 
            }
        } 
    }
};