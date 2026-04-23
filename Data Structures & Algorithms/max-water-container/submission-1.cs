public class Solution {
    public int MaxArea(int[] heights) {
        int l = 0, r = heights.Length - 1;
        int water = 0;

        while (l < r) {
            int temp = Math.Min(heights[l], heights[r]) * (r - l);
            if (temp > water) water = temp;

            if (heights[l] > heights[r]) {
                r--;
            } else {
                l++;
            }
        }

        return water;
    }
}
