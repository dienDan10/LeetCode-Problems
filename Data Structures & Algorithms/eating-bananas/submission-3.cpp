class Solution {
public:
    int minEatingSpeed(vector<int>& piles, int h) {
        int max {0};
        for (const int& p : piles) {
            if (p > max) max = p;
        }

        int result = max;
        int l = 1, r = max;
        while (l <= r) {
            int m = l + (r - l) / 2;
            int time {0};
            for (const int& p : piles) {
                time += (p + m - 1) / m; // round up;
            }

            if (time > h) {
                l = m + 1;
                continue;
            }

            r = m - 1;
            if (result > m) result = m;
        }

        return result;
    }
};
