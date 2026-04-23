public class Solution {
    private HashSet<int> leftToRight = new HashSet<int>();
    private HashSet<int> rightToLeft = new HashSet<int>();

    public List<List<string>> SolveNQueens(int n) {
        List<List<string>> result = new List<List<string>>();
        List<string> subset = new List<string>();
        bool[] cols = new bool[n];
        Dfs(0, cols, result, subset);
        return result;
    }

    private void Dfs(int row, bool[] cols, List<List<string>> result, List<string> subset) {
        if (subset.Count == cols.Length) {
            result.Add(new List<string>(subset));
            return;
        }

        if (row >= cols.Length) return;

        for (int i = 0; i < cols.Length; i++) {
            if (!IsValidPosition(row, i, cols)) continue;
            cols[i] = true;
            leftToRight.Add(row - i);
            rightToLeft.Add(row + i);
            subset.Add(CreateRowString(i, cols.Length));
            Dfs(row + 1, cols, result, subset);

            // backtrack
            cols[i] = false;
            leftToRight.Remove(row - i);
            rightToLeft.Remove(row + i);
            subset.RemoveAt(subset.Count - 1);
        }
    }

    private bool IsValidPosition(int row, int col, bool[] cols) {
        if (cols[col]) return false;
        // check left to right diagonal
        if (leftToRight.Contains(row - col)) return false;
        // check right to left diagonal
        if (rightToLeft.Contains(row + col)) return false;

        return true;
    }

    private string CreateRowString(int index, int size) {
        StringBuilder sb = new StringBuilder(size);
        for (int i = 0; i < size; i++) {
            if (i == index) {
                sb.Append('Q');
            } else {
                sb.Append('.');
            }
        }

        return sb.ToString();
    }
}