public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int result = 0;
        var stack = new Stack<(int index, int height)>();

        for (int i = 0; i < heights.Length; i++) {
            int idx = i;
            while (stack.Count > 0 && heights[i] < stack.Peek().height) {
                var node = stack.Pop();
                result = Math.Max(result, (i - node.index) * node.height);
                idx = node.index;
            }

            stack.Push((idx, heights[i]));
        }

        while (stack.Count > 0) {
            var node = stack.Pop();
            result = Math.Max(result, (heights.Length - node.index) * node.height);
        }

        return result;
    }
}
