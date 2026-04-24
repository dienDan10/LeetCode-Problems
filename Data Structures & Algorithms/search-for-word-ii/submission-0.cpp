class Solution {
public:
    vector<string> findWords(vector<vector<char>>& board, vector<string>& words) {
        std::vector<std::string> result{};
        for (const auto& word : words) {
            if (!word_exist(board, word)) continue;
            result.push_back(word); 
        }
        return result;
    }

    bool word_exist(std::vector<std::vector<char>>& board, const std::string& word) {
        for (int i = 0; i < board.size(); i++) {
            for (int j = 0; j < board[0].size(); j++) {
                if (board[i][j] != word[0]) continue;
                if (backtrack(board, i, j, word, 0)) return true;
            }
        }

        return false;
    }

    bool backtrack(std::vector<std::vector<char>>& board, int row, int col, 
        const std::string& word, int index) {
            if (index == word.size()) return true;
            if (row < 0 || row == board.size()) return false;
            if (col < 0 || col == board[0].size()) return false;
            if (board[row][col] != word[index]) return false;

            char c = board[row][col];
            board[row][col] = '#';
            bool result = backtrack(board, row, col - 1, word, index + 1) ||
                            backtrack(board, row, col + 1, word, index + 1) ||
                            backtrack(board, row - 1, col, word, index + 1) ||
                            backtrack(board, row + 1, col, word, index + 1);

            board[row][col] = c;
            return result;
    }

};
