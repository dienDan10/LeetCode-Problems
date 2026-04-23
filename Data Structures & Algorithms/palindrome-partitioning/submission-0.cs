public class Solution {
    public List<List<string>> Partition(string s) {
        List<List<string>> result = new List<List<string>>();
        List<string> subset = new List<string>();
        Dfs(s, 0, result, subset);
        return result;
    }

    private void Dfs(string s, int index, List<List<string>> result, List<string> subset) {
        if (index >= s.Length) {
            result.Add(new List<string> (subset));
            return;
        }

        for (int i = index; i < s.Length; i++) {
            string substring = s.Substring(index, i - index + 1);
            if (!IsPalindrom(substring)) continue;
            subset.Add(substring);
            Dfs(s, i + 1, result, subset);
            subset.RemoveAt(subset.Count - 1);
        }
    }



    private bool IsPalindrom(string s) {
        int l = 0, r = s.Length - 1;
        while (l < r) {
            if (s[l] != s[r]) return false;
            l++;
            r--;
        }

        return true;
    }
}
