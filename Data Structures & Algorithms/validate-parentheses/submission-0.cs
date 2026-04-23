public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();

        foreach (char c in s) {
            if (stack.Count == 0) {
                stack.Push(c);
                continue;
            }
            
            if (c == ')' && stack.Peek() == '(') {
                stack.Pop();
            } else if (c == ']' && stack.Peek() == '[') {
                stack.Pop();
            } else if (c == '}' && stack.Peek() == '{') {
                stack.Pop();
            } else {
                stack.Push(c);
            }
        }

        return stack.Count == 0;
    }
}
