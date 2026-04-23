public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();
        foreach (var s in tokens) {
            if (int.TryParse(s, out int number)) {
                stack.Push(number);
            } else {
                int b = stack.Pop();
                int a = stack.Pop();
                stack.Push(Calculate(a, b, s[0]));
            }
        }

        return stack.Pop();
    }

    public int Calculate(int a, int b, char opr) {
        return opr switch {
            '+' => a + b,
            '-' => a - b,
            '*' => a * b,
            '/' => a / b,
            _ => 0
        };
    }
}
