class Solution {
public:
    string minWindow(string s, string t) {
        std::unordered_map<char, int> t_count{};
        std::unordered_map<char, int> window_count{};

        for (const char& c : t) {
            t_count[c]++;
        }

        bool found = false;
        int have{};
        int need = t_count.size();
        int start_index = 0;
        int length = s.size();
        int l {};
        for (int i = 0; i < s.size(); i++) {
            window_count[s[i]]++;

            if (t_count.find(s[i]) != t_count.end() 
                && t_count[s[i]] == window_count[s[i]]) {
                have++;
            }

            while (have == need) {
                found = true;
                int window_size = i - l + 1;
                if (window_size < length) {
                    length = window_size;
                    start_index = l;
                }

                window_count[s[l]]--;
                if (t_count.find(s[l]) != t_count.end() 
                    && t_count[s[l]] > window_count[s[l]]) {
                    have--;
                }
                l++;
            }
        }

        return found ? s.substr(start_index, length) : "";
    }
};
