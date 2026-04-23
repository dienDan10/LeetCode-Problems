class Solution {
public:
    vector<vector<string>> groupAnagrams(vector<string>& strs) {
        unordered_map<string, vector<string>> umap{};
        array<int, 26> count{};

        for (const string& s : strs) {
            // construct the key
            for (const char& c : s) {
                count.at(c - 'a')++;
            }
            string key{};
            for (int& num : count) {
                key += num;
                num = 0;
            }

            // put the string to map
            umap[key].push_back(s);
        }

        // create and return the result;
        vector<vector<string>> result{};
        for (const auto& p : umap) {
            result.push_back(p.second);
        }

        return result;
    }
};
