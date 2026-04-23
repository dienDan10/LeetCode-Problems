public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var stack = new Stack<(int index, int height)>();
        var output = 0;

        for (int i = 0; i < heights.Length; i++) {
            int idx = i;
            while (stack.Count > 0) {
                var top = stack.Peek();
                if (heights[i] < top.height) {
                    int area = top.height * (i - top.index);
                    output = Math.Max(area, output);
                    stack.Pop();
                    idx = top.index;
                } else {
                    break;
                }
            }

            stack.Push((idx, heights[i]));
        }

        while (stack.Count > 0) {
            var top = stack.Pop();
            int area = top.height * (heights.Length - top.index);
            output = Math.Max(area, output);
        }

        return output;
    }
}
