class Solution {
public:
    bool checkInclusion(string s1, string s2) {
        int size1 = s1.size();
        int size2 = s2.size();

        if (size2 < size1) return false;

        std::array<int, 26> counts_1{};
        for (const char& c : s1) {
            counts_1[c - 'a']++;
        }

        std::array<int, 26> counts_2{};
        int l = 0, r = 0;
        while (r < size2) {
            counts_2[s2[r] - 'a']++;

            if (r - l + 1 > size1) {
                counts_2[s2[l] - 'a']--;
                l++;
            }

            if (r - l + 1 == size1 && matches(counts_1, counts_2, s1)) {
                return true;
            }

            r++;
        }

        return false;
    }

    bool matches(std::array<int, 26>& counts_1, std::array<int, 26>& counts_2, std::string& s1) {
        for (const char& c : s1) {
            if (counts_1[c - 'a'] != counts_2[c - 'a']) return false;
        }

        return true;
    }
};
