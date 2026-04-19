class Solution {
public:
    int largestRectangleArea(vector<int>& heights) {
        std::stack<std::pair<int, int>> st{};
        int result{};

        for (int i = 0; i < heights.size(); i++) {
            if (st.empty()) {
                st.push(std::make_pair(heights[i], i));
                continue;
            }

            int index = i;
            while (!st.empty() && st.top().first > heights[i]) {
                auto top = st.top();
                st.pop();
                result = std::max(result, top.first * (i - top.second));
                index = top.second;
            }

            st.push(std::make_pair(heights[i], index));
        }

        while (!st.empty()) {
            auto top = st.top();
            result = std::max(result, top.first * (int)(heights.size() - top.second));
            st.pop();
        }

        return result;
    }
};
