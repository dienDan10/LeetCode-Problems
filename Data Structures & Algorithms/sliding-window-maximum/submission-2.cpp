class Solution {
public:
    vector<int> maxSlidingWindow(vector<int>& nums, int k) {
        std::priority_queue<std::pair<int, int>> max_heap{};
        std::vector<int> result{};
        int l = 0, r = 0;
        int size = nums.size();
        while (r < size) {
            if (r - l + 1 > k) l++;
            max_heap.push(std::pair{nums[r], r});

            while (max_heap.top().second < l) {
                max_heap.pop();
            }

            if (r + 1 >= k) {
                result.push_back(max_heap.top().first);
            }
            r++;
        }

        return result;
    }
};
