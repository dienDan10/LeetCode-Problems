public class Solution {
    public bool Exist(char[][] board, string word) {
        for (int i = 0; i < board.Length; i++) {
            for (int j = 0; j < board[0].Length; j++) {
                if (board[i][j] != word[0]) continue;
                if (BackTrack(board, i, j, word, 0)) {
                    return true;
                }
            }
        }

        return false;
    }

    private bool BackTrack(char[][] board, int row, int col, string word, int wordIdx) {
        if (row < 0 || row == board.Length) return false;
        if (col < 0 || col == board[0].Length) return false;
        if (board[row][col] == '#') return false;
        if (board[row][col] != word[wordIdx]) return false;

        char c = board[row][col];
        if (wordIdx == word.Length - 1) return true;
        board[row][col] = '#';
        
        // move up
        if (BackTrack(board, row - 1, col, word, wordIdx + 1)) return true;
        // move down
        if (BackTrack(board, row + 1, col, word, wordIdx + 1)) return true;
        // move left
        if (BackTrack(board, row, col - 1, word, wordIdx + 1)) return true;
        // move right
        if (BackTrack(board, row, col + 1, word, wordIdx + 1)) return true;

        // back track value
        board[row][col] = c;
        return false;
    }
}
