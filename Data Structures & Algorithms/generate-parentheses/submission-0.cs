public class Solution {  
    public List<string> GenerateParenthesis(int n) {
        List<string> result = new List<string>();
        StringBuilder subset = new StringBuilder(n * 2);
        Dfs(n, n, result, subset);
        return result;
    }

    private void Dfs(int open, int close, List<string> result, StringBuilder subset) {
        if (open > close || open < 0 || close < 0) return;

        if (open == 0 && close == 0) {
            result.Add(subset.ToString());
            return;
        }

        subset.Append("(");
        Dfs(open - 1, close, result, subset);
        subset.Remove(subset.Length - 1, 1);

        subset.Append(")");
        Dfs(open, close - 1, result, subset);
        subset.Remove(subset.Length - 1, 1);
    }
}
