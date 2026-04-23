public class MedianFinder {
    private PriorityQueue<int, int> leftHeap;
    private PriorityQueue<int, int> rightHeap;

    public MedianFinder() {
        leftHeap = new PriorityQueue<int, int>();
        rightHeap = new PriorityQueue<int, int>();
    }
    
    public void AddNum(int num) {
        leftHeap.Enqueue(num, -num);
        BalanceTwoHeap();
    }
    
    public double FindMedian() {
        if (leftHeap.Count > rightHeap.Count) {
            return (double)leftHeap.Peek();
        }

        return (leftHeap.Peek() + rightHeap.Peek()) / 2.0;
    }

    private void BalanceTwoHeap() {
        if (leftHeap.Count == 1) return;
        int temp = leftHeap.Peek();

        if (leftHeap.Count - 1 > rightHeap.Count) {
            leftHeap.Dequeue();
            rightHeap.Enqueue(temp, temp);
            return;
        }

        if (leftHeap.Peek() > rightHeap.Peek()) {
            leftHeap.Dequeue();
            rightHeap.Enqueue(temp, temp);
            int temp2 = rightHeap.Dequeue();
            leftHeap.Enqueue(temp2, -temp2);
        }
    }
}
