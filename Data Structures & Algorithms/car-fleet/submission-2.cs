public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        var heap = new PriorityQueue<int, int>();

        for (int i = 0; i < position.Length; i++) {
            heap.Enqueue(i, -position[i]);
        }

        int output = 0;
        while (heap.Count > 0) {
            output += 1;
            double firstCar = (double)(target - position[heap.Peek()]) / speed[heap.Peek()];
            heap.Dequeue();
            while (heap.Count > 0 && firstCar >= (double)(target - position[heap.Peek()]) / speed[heap.Peek()]) {
                heap.Dequeue();
            }
        }

        return output;
    }
}
