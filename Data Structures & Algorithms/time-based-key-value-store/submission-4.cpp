class TimeMap {
    private:
        std::unordered_map<std::string, std::vector<std::pair<std::string, int>>> store {};
public:
    TimeMap() {
        
    }
    
    void set(string key, string value, int timestamp) {
        store[key].push_back(std::make_pair(value, timestamp));
    }
    
    string get(string key, int timestamp) {
        if (store.find(key) == store.end()) return "";
        if (store[key].empty()) return "";

        auto pairs = store[key];
        int index = -1;
        int l = 0, r = pairs.size() - 1;
        while (l <= r) {
            int m = l + (r - l) / 2;
            if (pairs[m].second <= timestamp) {
                index = m;
                l = m + 1;
            } else {
                r = m - 1;
            }
        }

        if (index == -1) return "";
        return pairs[index].first;
    }
};
