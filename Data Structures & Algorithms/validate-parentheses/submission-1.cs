public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();

        foreach (char c in s) {
            if (c == '(' || c == '[' || c == '{') {
                stack.Push(c);
                continue;
            }

            if (stack.Count == 0) return false;

            char top = stack.Pop();
            if ((c == ')' && top != '(') 
                || (c == ']' && top != '[') 
                || (c == '}' && top != '{')) 
                return false;
        }

        return stack.Count == 0;
    }
}
