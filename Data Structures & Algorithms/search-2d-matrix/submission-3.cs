public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int rows = matrix.Length, cols = matrix[0].Length;
        int left = 0, right = rows * cols - 1;

        while (left <= right) {
            int middle = left + (right - left) / 2;
            if (matrix[middle / cols][middle % cols] == target) return true;

            if (matrix[middle / cols][middle % cols] > target) right = middle - 1;
            else left = middle + 1;
        }

        return false;
    }
}
