public class PrefixTree {

    private TrieNode root;

    public PrefixTree() {
        root = new TrieNode();
    }
    
    public void Insert(string word) {
        root.Insert(word, 0);
    }
    
    public bool Search(string word) {
        return root.Search(word, 0);
    }
    
    public bool StartsWith(string prefix) {
        return root.StartsWith(prefix, 0);
    }

    class TrieNode {
        public Dictionary<char, TrieNode> Map {get; private set;}
        public bool IsEnding {get; private set;}

        public TrieNode () {
            Map = new Dictionary<char, TrieNode>();
            IsEnding = false;
        }

        public void Insert(string word, int index) {
            if (index >= word.Length) {
                IsEnding = true;
                return;
            }

            if (!Map.ContainsKey(word[index])) {
                Map.Add(word[index], new TrieNode());
            }

            Map[word[index]].Insert(word, index + 1);
        }

        public bool Search(string word, int index) {
            if (index >= word.Length) {
                return IsEnding;
            }

            if (!Map.ContainsKey(word[index])) return false;
            return Map[word[index]].Search(word, index + 1);
        }

        public bool StartsWith(string word, int index) {
            if (index >= word.Length) return true;

            if (!Map.ContainsKey(word[index])) return false;
            return Map[word[index]].StartsWith(word, index + 1);
        }
    }
}
