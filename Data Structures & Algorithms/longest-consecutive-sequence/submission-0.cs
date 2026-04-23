public class Solution {
    public int LongestConsecutive(int[] nums) {
        var set = new HashSet<int>();

        foreach (var num in nums) {
            set.Add(num);
        }

        int length = 0;
        foreach (var num in set) {
            if (set.Contains(num - 1)) continue;
            int temp = num;
            int tempLength = 1;

            while (set.Contains(temp + 1)) {
                tempLength++;
                temp++;
            }

            if (tempLength > length) length = tempLength;
        }

        return length;
    }
}
