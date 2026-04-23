public class Solution {
    public int Trap(int[] height) {
        int l = 0, r = height.Length - 1;
        int maxLeft = 0, maxRight = 0;
        int water = 0;
        while (l <= r) {
            if (maxLeft <= maxRight) {
                water += Math.Max(maxLeft - height[l], 0);
                if (height[l] > maxLeft) maxLeft = height[l];

                l++;
            } else {
                water += Math.Max(maxRight - height[r], 0);
                if (height[r] > maxRight) maxRight = height[r];

                r--;
            }
        }

        return water;
    }
}
