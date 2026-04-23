public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var map = new Dictionary<int, int>();
        foreach (var num in nums) { // O(n)
            if (map.ContainsKey(num)) {
                map[num]++;
            } else {
                map.Add(num, 1);
            }
        }

        var heap = new PriorityQueue<int, int>();
        foreach (var kvp in map) {
            heap.Enqueue(kvp.Key, kvp.Value);
            if (heap.Count > k) {
                heap.Dequeue();
            }
        }

        var result = new List<int>();
        while (heap.Count > 0) {
            result.Add(heap.Dequeue());
        }

        return result.ToArray();
    }
}
