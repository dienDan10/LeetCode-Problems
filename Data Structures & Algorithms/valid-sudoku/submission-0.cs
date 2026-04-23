public class Solution {
    public bool IsValidSudoku(char[][] board) {
        bool[,] rows = new bool[9,9];
        bool[,] cols = new bool[9,9];
        bool[,] boxes = new bool[9,9];

        for (int r = 0; r < 9; r++) {
            for (int c = 0; c < 9; c++) {
                if (board[r][c] == '.') continue;

                int value = board[r][c] - '1';
                int boxIndex = (r / 3) * 3 + c / 3;
                if (rows[r, value] || cols[c, value] || boxes[boxIndex, value]) {
                    return false;
                }

                rows[r, value] = true;
                cols[c, value] = true;
                boxes[boxIndex, value] = true;
            }
        }

        return true;
    }
}
