class Solution {
public:
    bool isValid(string s) {
        std::unordered_map<char, char> dic {
            {')', '('}, {'}', '{'}, {']', '['}
        };
        std::stack<char> st{};

        for (const char& c : s) {
            if (dic.find(c) == dic.end()) {
                st.push(c);
                continue;
            }
                
            if (st.size() == 0 || dic[c] != st.top()) return false;
            st.pop();
        }

        if (st.size() != 0) return false;
        return true;
    }
};
