public class Solution {
    public bool hasDuplicate(int[] nums) {
        HashSet<int> mySet = new HashSet<int>(nums);

        if (mySet.Count != nums.Length) return true;
        return false;
    }
}