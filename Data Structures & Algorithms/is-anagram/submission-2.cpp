class Solution {
public:
    bool isAnagram(string s, string t) {
        if (s.size() != t.size()) return false;

        array<char, 26> count{};
        for (int i = 0; i < s.size(); i++) {
            count.at(s.at(i) - 'a')++;
            count.at(t.at(i) - 'a')--;
        }

        for (const int& num : count) {
            if (num != 0) return false;
        }

        return true;
    }
};
