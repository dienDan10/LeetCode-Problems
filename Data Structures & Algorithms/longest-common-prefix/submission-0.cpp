class Solution {
public:
    string longestCommonPrefix(vector<string>& strs) {
        std::string result{};

        int min_length = 200;
        for(const auto& s : strs) {
            if (s.size() < min_length)
                min_length = s.size();
        }

        int i = 0;
        while (i < min_length) {
            char c = strs[0][i];
            bool is_match = true;
            for (int j = 1; j < strs.size(); j++) {
                if (strs[j][i] != c) {
                    is_match = false;
                    break;
                }
            }

            if (!is_match) break;
            result += c;
            i++;
        }

        return result;
    }
};