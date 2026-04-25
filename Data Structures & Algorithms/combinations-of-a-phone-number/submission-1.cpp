class Solution {
public:
    vector<string> letterCombinations(string digits) {
        std::unordered_map<char, std::vector<char>> dictionary {
            {'2', {'a', 'b', 'c'}},
            {'3', {'d', 'e', 'f'}},
            {'4', {'g', 'h', 'i'}},
            {'5', {'j', 'k', 'l'}},
            {'6', {'m', 'n', 'o'}},
            {'7', {'p', 'q', 'r', 's'}},
            {'8', {'t', 'u', 'v'}},
            {'9', {'w', 'x', 'y', 'z'}}
        };

        std::vector<std::string> result{};
        std::string subset{};
        if (digits.size() == 0) return result;
        backtrack(digits, 0, result, subset, dictionary);
        return result;
    }

    void backtrack(std::string& digits, int index, std::vector<std::string>& result,
        std::string& subset, std::unordered_map<char, std::vector<char>>& dictionary) {
            if (index == digits.size()) {
                result.push_back(subset);
                return;
            }

            for (int i = 0; i < dictionary[digits[index]].size(); i++) {
                subset.push_back(dictionary[digits[index]][i]);
                backtrack(digits, index + 1, result, subset, dictionary);
                subset.pop_back();
            }
    }
};
