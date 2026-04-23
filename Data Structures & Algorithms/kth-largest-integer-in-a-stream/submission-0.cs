public class KthLargest {
    private PriorityQueue<int, int> heap;
    private int k;

    public KthLargest(int k, int[] nums) {
        heap = new PriorityQueue<int, int>();
        this.k = k;
        foreach (int num in nums) {
            heap.Enqueue(num, num);
            if (heap.Count > k) {
                heap.Dequeue();
            }
        }
    }
    
    public int Add(int val) {
        heap.Enqueue(val, val);
        if (heap.Count > k) {
            heap.Dequeue();
        }

        return heap.Peek();
    }
}
