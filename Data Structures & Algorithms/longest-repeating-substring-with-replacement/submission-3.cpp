class Solution {
public:
    int characterReplacement(string s, int k) {
        std::array<int, 26> counts{};
        int l = 0, r = 0;
        int max_frequency = 0;
        int result = 0;

        while (r < s.size()) {
            counts[s[r] - 'A']++;
            max_frequency = std::max(max_frequency, counts[s[r] - 'A']);

            while ((r - l + 1) - max_frequency > k) {
                counts[s[l] - 'A']--;
                l++;
            }

            result = std::max(r - l + 1, result);
            r++;
        }

        return result;
    }
};
