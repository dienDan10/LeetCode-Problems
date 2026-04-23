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

        var buckets = new List<int>[nums.Length + 1];
        foreach (var kvp in map) {
            if (buckets[kvp.Value] is null) {
                buckets[kvp.Value] = new List<int>();
            }
            buckets[kvp.Value].Add(kvp.Key);
        }

        var result = new List<int>();
        for (int i = buckets.Length - 1; i >= 0 && result.Count < k; i--){
            if (buckets[i] is not null) result.AddRange(buckets[i]);
        }

        return result.ToArray();
    }
}
