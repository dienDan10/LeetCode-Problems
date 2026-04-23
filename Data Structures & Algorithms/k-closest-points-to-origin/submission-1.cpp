class Solution {
public:
    vector<vector<int>> kClosest(vector<vector<int>>& points, int k) {
        auto cmp = [](std::pair<int, double>& a, std::pair<int, double>& b) {
            return a.second < b.second;
        };
        std::priority_queue<std::pair<int, double>, std::vector<std::pair<int, double>>, decltype(cmp)> max_heap(cmp);

        for (int i = 0; i < points.size(); i++) {
            std::vector<int>& point = points[i];
            double distance = std::sqrt(point[0] * point[0] + point[1] * point[1]);
            max_heap.push(std::make_pair(i, distance));
            if (max_heap.size() > k) {
                max_heap.pop();
            }
        }

        std::vector<std::vector<int>> result{};
        while (!max_heap.empty()) {
            result.push_back(points[max_heap.top().first]);
            max_heap.pop();
        }

        return result;
    }
};
