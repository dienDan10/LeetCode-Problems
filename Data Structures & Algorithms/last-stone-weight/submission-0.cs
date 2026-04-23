public class Solution {
    public int LastStoneWeight(int[] stones) {
        var heap = new PriorityQueue<int, int>();

        foreach (int stone in stones) {
            heap.Enqueue(stone, -stone);
        }

        while (heap.Count > 1) {
            int a = heap.Dequeue();
            int b = heap.Dequeue();
            int result = Math.Abs(a - b);

            if (result > 0) {
                heap.Enqueue(result, -result);
            }
        }

        return heap.Count == 0 ? 0 : heap.Peek(); 
    }
}
