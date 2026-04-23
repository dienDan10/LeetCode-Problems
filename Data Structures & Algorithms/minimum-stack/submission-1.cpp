class MinStack {
private:
    std::stack<std::pair<int, int>> min_stack;
public:
    MinStack() : min_stack{std::stack<std::pair<int, int>>()}{
        
    }
    
    void push(int val) {
        if (min_stack.empty()) {
            min_stack.push(std::make_pair(val, val));
            return;
        }
        
        auto top = min_stack.top();
        int min = top.second < val ? top.second : val;
        min_stack.push(std::make_pair(val, min));
    }
    
    void pop() {
        min_stack.pop();
    }
    
    int top() {
        return min_stack.top().first;
    }
    
    int getMin() {
        return min_stack.top().second;
    }
};
