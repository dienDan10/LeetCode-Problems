class Solution {
public:
    bool searchMatrix(vector<vector<int>>& matrix, int target) {
        int size = matrix.size() * matrix.at(0).size();

        int l = 0, r = size - 1;
        while (l <= r) {
            int m = l + (r - l) / 2;
            int row = m / matrix.at(0).size();
            int col = m % matrix.at(0).size();

            if (matrix[row][col] == target) return true;

            if (target < matrix[row][col]) r = m - 1;
            else l = m + 1;
        }

        return false;
    }
};
