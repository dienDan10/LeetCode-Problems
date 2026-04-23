class Node {
public:
    int key;
    int value;
    Node* next;
    Node* prev;

    Node() : Node(0, 0) {}
    Node(int key, int value) : key{key}, value{value}, next{nullptr}, prev{nullptr} {}
    ~Node() = default;
};

class LRUCache {
    private:
        int size;
        int capacity;
        std::unordered_map<int, Node*> dictionary;
        Node begin;
        Node end;
public:
    LRUCache(int capacity) : capacity{capacity}, size{0} {
        begin.next = &end;
        end.prev = &begin;
    }
    
    int get(int key) {
        auto it = dictionary.find(key);
        if (it == dictionary.end()) return -1;

        // move node to front
        move_to_front(it->second);
        return it->second->value;
    }
    
    void put(int key, int value) {
        auto it = dictionary.find(key);

        if (it != dictionary.end()) {
            it->second->value = value;
            // move node to front
            move_to_front(it->second);
            return;
        }

        if (size == capacity) {
            remove_back_node();
        } else {
            size++;
        }
        Node* node = new Node(key, value);
        dictionary[key] = node;
        // put to front
        put_to_front(node); 
    }

private:
    void put_to_front(Node* node) {
        Node* temp = begin.next;
        begin.next = node;
        node->prev = &begin;
        node->next = temp;
        temp->prev = node;
    }

    void move_to_front(Node* node) {
        // take it out
        Node* prev = node->prev;
        Node* next = node->next;
        prev->next = next;
        next->prev = prev;

        // put to front
        put_to_front(node);
    }

    void remove_back_node() {
        Node* remove_node = end.prev;
        Node* prev = remove_node->prev;
        prev->next = &end;
        end.prev = prev;
        dictionary.erase(remove_node->key);
        delete remove_node;
    }
};
