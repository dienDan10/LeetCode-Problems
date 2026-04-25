class Solution {
public:
    vector<vector<string>> partition(string s) {
        std::vector<std::vector<std::string>> result{};
        std::vector<std::string> subset{};
        backtrack(result, subset, s, 0);
        return result;
    }

    void backtrack(std::vector<std::vector<std::string>>& result, std::vector<std::string> subset,
        std::string& s, int start) {
            if (start == s.size()) {
                result.push_back(subset);
                return;
            }

            for (int i = start; i < s.size(); i++) {
                std::string substr = s.substr(start, i - start + 1);
                if (!isPalindrom(substr)) continue;
                subset.push_back(substr);
                backtrack(result, subset, s, i + 1);
                subset.pop_back();
            }
    }

    bool isPalindrom(std::string& s) {
        if (s.size() <= 1) return true;
        int l = 0, r = s.size() - 1;
        while (l < r) {
            if (s[l] != s[r]) return false;
            l++;
            r--;
        }

        return true;
    }
};
