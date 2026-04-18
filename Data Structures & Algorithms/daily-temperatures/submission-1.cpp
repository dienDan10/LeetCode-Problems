class Solution {
public:
    vector<int> dailyTemperatures(vector<int>& temperatures) {
        std::vector<int> result (temperatures.size());
        std::stack<std::pair<int, int>> st{};

        for (int i = 0; i < temperatures.size(); i++) {
            if (st.empty() || st.top().first >= temperatures[i]) {
                st.push(std::make_pair(temperatures[i], i));
                continue;
            }

            while (!st.empty() && st.top().first < temperatures[i]) {
                int days = i - st.top().second;
                result.at(st.top().second) = days;
                st.pop();
            }

            st.push(std::make_pair(temperatures[i], i));
        }

        return result;
    }
};
