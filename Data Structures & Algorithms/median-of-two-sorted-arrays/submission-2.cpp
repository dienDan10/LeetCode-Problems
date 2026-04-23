class Solution {
public:
    double findMedianSortedArrays(vector<int>& nums1, vector<int>& nums2) {
        if (nums1.size() > nums2.size())
            return findMedianSortedArrays(nums2, nums1);

        int size1 = nums1.size();
        int size2 = nums2.size();
        int l = 0, r = size1;
        while (l <= r) {
            int i = l + (r - l) / 2;
            int j = (size1 + size2 + 1) / 2 - i;
            int left1 = i == 0 ? std::numeric_limits<int>::min() : nums1[i - 1];
            int right1 = i == size1 ? std::numeric_limits<int>::max() : nums1[i];
            int left2 = j == 0 ? std::numeric_limits<int>::min() : nums2[j - 1];
            int right2 = j == size2 ? std::numeric_limits<int>::max() : nums2[j];

            if (left1 <= right2 && left2 <= right1) {
                if ((size1 + size2) % 2 == 1) 
                    return std::max(left1, left2);
                return (std::max(left1, left2) + std::min(right1, right2)) / 2.0;
            }

            if (left1 > right2) {
                r = i - 1;
            } else {
                l = i + 1;
            }
        }

        return 0;
    }
};
