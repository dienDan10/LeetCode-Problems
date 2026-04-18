class Solution {
public:
    vector<int> dailyTemperatures(vector<int>& temperatures) {
        std::vector<int> result (temperatures.size());
        std::stack<int> st{};

        for (int i = 0; i < temperatures.size(); i++) {
            while (!st.empty() && temperatures[st.top()] < temperatures[i]) {
                int index = st.top();
                st.pop();
                result.at(index) = i - index;
            }

            st.push(i);
        }

        return result;
    }
};
