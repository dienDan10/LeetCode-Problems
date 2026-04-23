class Solution {
public:
    int leastInterval(vector<char>& tasks, int n) {
        std::vector<int> counts (26, 0);
        int max_frequency = 0;
        for (const char& task : tasks) {
            counts[task - 'A']++;
            if (max_frequency < counts[task - 'A']) {
                max_frequency = counts[task - 'A'];
            }
        }

        int max_frequency_count = 0;
        for (const int& count : counts) {
            if (count == max_frequency) max_frequency_count++;
        }

        return std::max((int)tasks.size(), (max_frequency - 1) * (n + 1) + max_frequency_count);
    }
};
