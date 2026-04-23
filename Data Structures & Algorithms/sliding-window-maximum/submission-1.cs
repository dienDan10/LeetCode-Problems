public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        // priority queue in c# is min heap by default 
        // so we need to negative the priority when push to heap
        var heap = new PriorityQueue<(int value, int index), int>();
        var result = new List<int>();

        for (int i = 0; i < nums.Length; i++) {
            // add the current number to heap
            heap.Enqueue((nums[i], i), -nums[i]);

            // remove max number if it is out of window range
            while (heap.Peek().index <= i - k) heap.Dequeue();

            if (i - k + 1 >= 0) result.Add(heap.Peek().value);
        }

        return result.ToArray();
    }
}
