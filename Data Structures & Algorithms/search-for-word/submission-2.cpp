class Solution {
public:
    bool exist(vector<vector<char>>& board, string word) {
        for (int i = 0; i < board.size(); i++) {
            for (int j = 0; j < board[0].size(); j++) {
                if (board[i][j] != word[0]) continue;
                if (search_word(board, i, j, 0, word))
                    return true;
            }
        }

        return false;
    }

    bool search_word(std::vector<std::vector<char>>& board, int row, int col, int index, std::string& word) {
        if (row < 0 || row == board.size()) return false;
        if (col < 0 || col == board[0].size()) return false;
        if (board[row][col] != word[index]) return false;
        if (index == word.size() - 1) return true;

        char c = board[row][col];
        board[row][col] = '#';

        if (search_word(board, row, col - 1, index + 1, word)) return true;
        if (search_word(board, row, col + 1, index + 1, word)) return true;
        if (search_word(board, row - 1, col, index + 1, word)) return true;
        if (search_word(board, row + 1, col, index + 1, word)) return true;

        board[row][col] = c;
        return false;
    }
};
