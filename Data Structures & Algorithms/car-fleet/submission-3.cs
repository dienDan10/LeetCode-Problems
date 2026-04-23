public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        var heap = new PriorityQueue<int, int>();

        for (int i = 0; i < position.Length; i++) {
            heap.Enqueue(i, -position[i]);
        }

        int output = 0;
        while (heap.Count > 0) {
            output++;
            int idx = heap.Dequeue();
            double time = (double)(target - position[idx]) / speed[idx];

            while (heap.Count > 0) {
                int nextIdx = heap.Peek();
                double nextTime = (double)(target - position[nextIdx]) / speed[nextIdx];

                if (nextTime > time) break;

                heap.Dequeue();
            }
        }

        return output;
    }
}
