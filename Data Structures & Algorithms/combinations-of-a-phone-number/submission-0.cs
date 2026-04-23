public class Solution {
    private char[][] letters = new char[][] {
            new char[] { },                 // 0
            new char[] { },                 // 1
            new char[] { 'a', 'b', 'c' },   // 2
            new char[] { 'd', 'e', 'f' },   // 3
            new char[] { 'g', 'h', 'i' },   // 4
            new char[] { 'j', 'k', 'l' },   // 5
            new char[] { 'm', 'n', 'o' },   // 6
            new char[] { 'p', 'q', 'r', 's' }, // 7
            new char[] { 't', 'u', 'v' },   // 8
            new char[] { 'w', 'x', 'y', 'z' }  // 9
        };

    public List<string> LetterCombinations(string digits) {
        if (digits.Length == 0) return new List<string>();

        List<string> result = new List<string> ();
        StringBuilder combination = new StringBuilder(digits.Length);
        Dfs(digits, 0, result, combination);
        return result;
    }

    private void Dfs(string digits, int index, List<string> result, StringBuilder combination) {
        if (index == digits.Length) {
            result.Add(combination.ToString());
            return;
        }

        int digit = digits[index] - '0';
        for (int i = 0; i < letters[digit].Length; i++) {
            combination.Append(letters[digit][i]);
            Dfs(digits, index + 1, result, combination);
            combination.Remove(combination.Length - 1, 1);
        }
    }
}
