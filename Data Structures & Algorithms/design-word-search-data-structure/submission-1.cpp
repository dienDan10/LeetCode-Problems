class Node {
private:
    bool isEnd;
    std::unordered_map<char, Node*> chars;

public:
    Node() : isEnd{false} {}
    ~Node() {
        for (auto& p : chars) {
            delete p.second;
            p.second = nullptr;
        }
    }

    void add_word(std::string& word, int index) {
        if (index == word.size()) {
            isEnd = true;
            return;
        }

        if (chars.find(word[index]) == chars.end()) {
            chars[word[index]] = new Node();
        }

        chars[word[index]]->add_word(word, index + 1);
    }

    bool search_word(std::string& word, int index) {
        if (index == word.size()) return isEnd;

        if (word[index] == '.') {
            for (const auto& p : chars) {
                bool result = (p.second)->search_word(word, index + 1);
                if (result) return true;
            }
            return false;
        }

        auto it = chars.find(word[index]);
        if (it == chars.end()) return false;

        return (it->second)->search_word(word, index + 1);
    }
};

class WordDictionary {
private:
    Node* root;
public:
    WordDictionary() : root{new Node()} {
        
    }
    ~WordDictionary() {
        delete root;
    }
    
    void addWord(string word) {
        root->add_word(word, 0);
    }
    
    bool search(string word) {
        return root->search_word(word, 0);
    }
};
