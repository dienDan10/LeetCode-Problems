public class MinStack {

    Stack<(int value, int min)> stack;

    public MinStack() {
        stack = new Stack<(int value, int min)>(); 
    }
    
    public void Push(int val) {
        if (stack.Count == 0) {
            stack.Push((val, val));
        } else {
            stack.Push((val, Math.Min(val, stack.Peek().min)));
        }
    }
    
    public void Pop() {
        stack.Pop();
    }
    
    public int Top() {
        return stack.Peek().value;
    }
    
    public int GetMin() {
        return stack.Peek().min;
    }
}
