public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        // First search for the row
        int row = FindRow(matrix, target);
        if (row == -1) return false;
        // Then search the row for the target
        int left = 0, right = matrix[0].Length - 1;
        while (left <= right) {
            int middle = left + (right - left) / 2;
            if (matrix[row][middle] == target) return true;

            if (matrix[row][middle] > target) right = middle - 1;
            else left = middle + 1;
        }

        return false;
    }

    public int FindRow(int[][] matrix, int target) {
        int left = 0, right = matrix.Length - 1;
        while (left <= right) {
            int middle = left + (right - left) / 2;
            if (matrix[middle][0] <= target && matrix[middle][matrix[0].Length - 1] >= target)
                return middle;
            
            if (matrix[middle][0] > target) right = middle - 1;
            else left = middle + 1;
        }

        return -1;
    }
}
