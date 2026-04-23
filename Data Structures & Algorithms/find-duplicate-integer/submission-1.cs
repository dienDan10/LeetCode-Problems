public class Solution {
    public int FindDuplicate(int[] nums) {
        for (int i = 0; i < nums.Length; i++) {
            int index = Math.Abs(nums[i]);
            if (nums[index] < 0) 
                return index;
            nums[index] *= -1;
        }

        return 0;
    }
}
