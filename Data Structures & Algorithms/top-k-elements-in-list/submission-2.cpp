class Solution {
public:
    vector<int> topKFrequent(vector<int>& nums, int k) {
        unordered_map<int, int> umap{};

        for (const int& num : nums) {
            umap[num]++;
        }

        auto comp = [](const pair<int, int>& a, const pair<int, int>& b) {
            return a.second < b.second;
        };
        priority_queue<pair<int, int>, vector<pair<int, int>>, decltype(comp)> heap {comp};
        for (const auto& item : umap) {
            heap.push(item);
        }

        vector<int> result{};
        while (k > 0) {
            result.push_back(heap.top().first);
            heap.pop();
            k--;
        }

        return result;
    }
};
