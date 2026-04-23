class Solution {
public:
    vector<int> sortArray(vector<int>& nums) {
        quick_sort(nums, 0, nums.size() - 1);
        return nums;
    }

    void quick_sort(std::vector<int>& nums, int l, int r) {
        if (l >= r) return;

        int pivot_index = move(nums, l, r);
        quick_sort(nums, l, pivot_index - 1);
        quick_sort(nums, pivot_index + 1, r);
    }

    int move(std::vector<int>& nums, int l, int r) {
        int pivot = nums[l];

        while (l < r) {
            while (l < r && nums[r] > pivot) r--;
            if (l < r) nums[l++] = nums[r];

            while (l < r && nums[l] < pivot) l++;
            if (l < r) nums[r--] = nums[l];
        }

        nums[l] = pivot;
        return l;
    }
};