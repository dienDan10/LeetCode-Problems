public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        var output = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++) {
            output[i] = i == 0 ? 1 : output[i -1] * nums[i -1];
        }

        int prod = 1;
        for (int i = nums.Length - 1; i >= 0; i--) {
            output[i] *= prod;
            prod *= nums[i];
        }

        return output;
    }
}
