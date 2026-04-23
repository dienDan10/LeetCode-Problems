public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();

        var map = new Dictionary<char, char>() {
            {')', '('}, {']', '['}, {'}', '{'}
        };

        foreach (char c in s) {
            if (!map.ContainsKey(c)) {
                stack.Push(c);
                continue;
            }

            if (stack.Count == 0 || stack.Pop() != map[c]) return false;
        }

        return stack.Count == 0;
    }
}
