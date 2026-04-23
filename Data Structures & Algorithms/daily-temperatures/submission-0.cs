public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var stack = new Stack<int>();
        var result = new int[temperatures.Length];

        for (int i = 0; i < temperatures.Length; i++) {
            while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i]) {
                int index = stack.Pop();
                result[index] = i - index;
            }

            stack.Push(i);
        }

       return result;
    }
}
