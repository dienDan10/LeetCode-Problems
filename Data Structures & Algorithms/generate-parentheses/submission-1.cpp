class Solution {
public:
    vector<string> generateParenthesis(int n) {
        std::vector<std::string> result{};
        std::string subset{};
        backtrack(result, subset, n, n);
        return result;
    }

    void backtrack(std::vector<std::string>& result, std::string& subset, int open, int close) {
        if (open > close || open < 0 || close < 0) return;

        if (open == 0 && close == 0) {
            result.push_back(subset);
            return;
        }

        subset.push_back('(');
        backtrack(result, subset, open - 1, close);
        subset.pop_back();

        subset.push_back(')');
        backtrack(result, subset, open, close - 1);
        subset.pop_back();
    }
};
