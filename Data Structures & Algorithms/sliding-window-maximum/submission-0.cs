public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var deque = new LinkedList<int>();
        var result = new List<int>();

        for (int i = 0; i < nums.Length; i++) {
            // pop the first number in deque if it out of range
            while (deque.Count > 0 && deque.First.Value <= i - k) 
                deque.RemoveFirst();

            // remove all number smaller than current number
            while (deque.Count > 0 && nums[deque.Last.Value] < nums[i])
                deque.RemoveLast();

            // Add the current number to deque as last position
            deque.AddLast(i);

            // check the result
            if (i - k + 1 >= 0) {
                result.Add(nums[deque.First.Value]);
            }
        }
        return result.ToArray();
    }
}
