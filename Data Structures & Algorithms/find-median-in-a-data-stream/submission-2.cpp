class MedianFinder {
private: 
    std::priority_queue<int> max_heap{};
    std::priority_queue<int, std::vector<int>, std::greater<int>> min_heap{};
public:
    MedianFinder() {
        max_heap.push(std::numeric_limits<int>::min());
        min_heap.push(std::numeric_limits<int>::max());
    }
    
    void addNum(int num) {
        max_heap.push(num);
        balance();
    }

    void balance() {
        if (max_heap.top() > min_heap.top()) {
            min_heap.push(max_heap.top());
            max_heap.pop();
        }

        if (max_heap.size() - min_heap.size() == 2) {
            min_heap.push(max_heap.top());
            max_heap.pop();
        }

        if (min_heap.size() > max_heap.size()) {
            max_heap.push(min_heap.top());
            min_heap.pop();
        }

    }
    
    double findMedian() {
        if (max_heap.size() > min_heap.size()) 
            return static_cast<double>(max_heap.top());

        return (max_heap.top() + min_heap.top()) / 2.0;
    }
};
