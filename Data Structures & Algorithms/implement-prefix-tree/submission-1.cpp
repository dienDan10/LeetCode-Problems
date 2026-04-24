class Node {
private:
    bool isEnd;
    std::unordered_map<char, Node*> chars;

public:
    Node() : isEnd{false}{}
    ~Node() {
        for (auto& p : chars) {
            delete p.second;
        }
    }

    void insert(std::string& word, int index) {
        if (index == word.size()) {
            isEnd = true;
            return;
        }

        auto it = chars.find(word[index]);
        if (it == chars.end()) {
            chars[word[index]] = new Node();
        }
        chars[word[index]]->insert(word, index + 1);
    }

    bool search(std::string& word, int index) {
        if (index == word.size() && isEnd) return true;

        auto it = chars.find(word[index]);
        if (it == chars.end()) return false;

        return (it->second)->search(word, index + 1);
    }

    bool start_with(std::string& prefix, int index) {
        if (index == prefix.size()) return true;

        auto it = chars.find(prefix[index]);
        if (it == chars.end()) return false;

        return (it->second)->start_with(prefix, index + 1);
    }
};

class PrefixTree {
private:
    Node* root;
public:
    PrefixTree() : root{new Node()} {
        
    }
    ~PrefixTree() {
        delete root;
    }
    
    void insert(string word) {
        if (word.size() == 0) return;

        root->insert(word, 0);
    }
    
    bool search(string word) {
        if (word.size() == 0) return false;

        return root->search(word, 0);
    }
    
    bool startsWith(string prefix) {
        if (prefix.size() == 0) return false;

        return root->start_with(prefix, 0);
    }
};
