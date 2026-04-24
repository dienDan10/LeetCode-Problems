class Solution {
public:
    int numIslands(vector<vector<char>>& grid) {
        int result = 0;
        find_islands(grid, result);
        return result;
    }

    void find_islands(std::vector<std::vector<char>>& grid, int& result) {
        for (int i = 0; i < grid.size(); i++) {
            for (int j = 0; j < grid[0].size(); j++) {
                if (grid[i][j] == '0') continue;
                result++;
                mark_as_visited(grid, i, j);
            }
        }
    }

    void mark_as_visited(std::vector<std::vector<char>>& grid, int row, int col) {
        if (row < 0 || row == grid.size()) return;
        if (col < 0 || col == grid[0].size()) return;
        if (grid[row][col] == '0') return;

        grid[row][col] = '0';
        mark_as_visited(grid, row - 1, col);
        mark_as_visited(grid, row + 1, col);
        mark_as_visited(grid, row, col - 1);
        mark_as_visited(grid, row, col + 1);
    }
};
