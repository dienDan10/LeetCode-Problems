class Solution {
public:
    int maxAreaOfIsland(vector<vector<int>>& grid) {
        int result = 0;
        for (int i = 0; i < grid.size(); i++) {
            for (int j = 0; j < grid[0].size(); j++) {
                if (grid[i][j] == 0) continue;
                int temp = backtrack(grid, i, j);
                if (result < temp) result = temp;
            }
        }

        return result;
    }

    int backtrack(std::vector<std::vector<int>>& grid, int row, int col) {
        if (row < 0 || row == grid.size()) return 0;
        if (col < 0 || col == grid[0].size()) return 0;
        if (grid[row][col] == 0) return 0;

        grid[row][col] = 0;
        int left = backtrack(grid, row, col - 1);
        int right = backtrack(grid, row, col + 1);
        int up = backtrack(grid, row - 1, col);
        int down = backtrack(grid, row + 1, col);

        return left + right + up + down + 1;
    }

};
