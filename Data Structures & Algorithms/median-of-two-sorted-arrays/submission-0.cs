public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        // Make sure the shorter array will be nums1
        if (nums1.Length > nums2.Length) {
            return FindMedianSortedArrays(nums2, nums1);
        }

        int length1 = nums1.Length;
        int length2 = nums2.Length;

        int left = 0, right = length1;
        while (left <= right) {
            int i = left + (right - left) / 2;
            int j = (length1 + length2 + 1) / 2 - i;

            int left1 = i == 0 ? int.MinValue : nums1[i - 1];
            int left2 = j == 0 ? int.MinValue : nums2[j - 1];
            int right1 = i == length1 ? int.MaxValue : nums1[i];
            int right2 = j == length2 ? int.MaxValue : nums2[j];

            if (left1 <= right2 && left2 <= right1) {
                if ((length1 + length2) % 2 == 0) {
                    return (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.0;
                }
                return Math.Max(left1, left2);
            } 

            if (left1 > right2) {
                right = i - 1;
            } else {
                left = i + 1;
            }
        }

        return 1.0;
    }
}
