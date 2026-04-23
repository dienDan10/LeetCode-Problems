class KthLargest {
private:
    int k;
    std::priority_queue<int, std::vector<int>, std::greater<int>> min_heap{};
public:
    KthLargest(int k, vector<int>& nums) : k{k}{
        for (const int& num : nums) {
            min_heap.push(num);
            if (min_heap.size() > k) {
                min_heap.pop();
            }
        }
    }
    
    int add(int val) {
        min_heap.push(val);
        if (min_heap.size() > k) {
            min_heap.pop();
        }

        return min_heap.top();
    }
};
