class Solution {
public:
    int lastStoneWeight(vector<int>& stones) {
        std::priority_queue<int> max_heap{};
        for (const int& stone : stones) {
            max_heap.push(stone);
        }

        while (max_heap.size() > 1) {
            int a = max_heap.top();
            max_heap.pop();
            int b = max_heap.top();
            max_heap.pop();

            int result = std::abs(a - b);
            if (result == 0) continue;
            max_heap.push(result);
        }

        if (max_heap.empty()) return 0;
        return max_heap.top();
    }
};
