public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        var heap = new PriorityQueue<int[], double>();
        foreach (int[] point in points) {
            heap.Enqueue(point, -Distance(point[0], point[1]));
            if (heap.Count > k) {
                heap.Dequeue();
            }
        }

        int[][] output = new int[k][];
        for (int i = 0; i < k; i++) {
            output[i] = heap.Dequeue();
        }

        return output;
    }

    private double Distance(int a, int b) {
        return Math.Sqrt(a * a + b * b);
    }
}
