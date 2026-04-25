class Solution {
private:
    std::unordered_set<int> left_right{};
    std::unordered_set<int> right_left{};

public:
    vector<vector<string>> solveNQueens(int n) {
        std::vector<std::vector<std::string>> result{};
        std::vector<std::string> subset{};
        std::vector<bool> cols(n, false);
        backtrack(n, 0, result, subset, cols);
        return result; 
    }

    void backtrack(int n, int row, std::vector<std::vector<std::string>>& result, std::vector<std::string> subset, std::vector<bool>& cols) {
        if (row == n) {
            result.push_back(subset);
            return;
        }

        for (int col = 0; col < n; col++) {
            if (!is_valid_position(row, col, cols)) continue;
            subset.push_back(create_row(n, col));
            cols[col] = true;
            left_right.insert(row - col);
            right_left.insert(row + col);
            backtrack(n, row + 1, result, subset, cols);
            subset.pop_back();
            cols[col] = false;
            left_right.erase(row - col);
            right_left.erase(row + col);
        }
    }

    bool is_valid_position(int row, int col, std::vector<bool>& cols) {
        if (cols[col]) return false;
        if (left_right.find(row - col) != left_right.end()) return false;
        if (right_left.find(row + col) != right_left.end()) return false;

        return true;
    }

    std::string create_row(int n, int index) {
        std::string result(n, '.');
        result[index] = 'Q';
        return result;
    }
};
