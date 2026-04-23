class Node {
    private:
        int value;
        Node* left;
        Node* right;

    public:
        Node(int value = -1, Node* left = nullptr, Node* right = nullptr) 
            : value{value}, left{left}, right{right} {}

        void add(int value) {
            if (this->value == value) return;

            if (this->value > value) {
                if (left != nullptr) {
                    left->add(value);
                } else {
                    left = new Node(value);
                }
            } else {
                if (right != nullptr) {
                    right->add(value);
                } else {
                    right = new Node(value);
                }
            }

        }

        Node* remove(int value) {
            if (value > this->value) {
                if (right != nullptr)
                    right = right->remove(value);
                
                return this;
            }

            if (value < this->value) {
                if (left != nullptr)
                    left = left->remove(value);

                return this;
            }

            // no child
            if (left == nullptr && right == nullptr) {
                delete this;
                return nullptr;
            }

            // one child
            if (left == nullptr && right != nullptr) {
                Node* temp = right;
                delete this;
                return temp;
            }

            if (left != nullptr && right == nullptr) {
                Node* temp = left;
                delete this;
                return temp;
            }

            // two child (here we set the max of left sub tree to current node)
            int new_value = left->get_max_value();
            left = left->remove(new_value);
            this->value = new_value;

            return this;
        }

        bool contains(int value) {
            if (value == this->value) return true;
            if (value < this->value && left != nullptr) 
                return left->contains(value);

            if (value > this->value && right != nullptr)
                return right->contains(value);

            return false;
        }

    private:
        int get_max_value() {
            if (right != nullptr)
                return right->get_max_value();

            return value;
        }
};

class BSTree {
    private: 
        Node* root;
    
    public:
        BSTree() : root{nullptr} {}

        void add(int value) {
            if (root == nullptr) {
                root = new Node(value);
                return;
            }

            root->add(value);
        }

        void remove(int value) {
            if (root == nullptr) return;

            root = root->remove(value);
        }

        bool contains(int value) {
            if (root == nullptr) return false;

            return root->contains(value);
        }
};

class MyHashSet {
    private:
        BSTree bstree;
public:
    MyHashSet() : bstree{BSTree{}} {
        
    }
    
    void add(int key) {
        bstree.add(key);
    }
    
    void remove(int key) {
        bstree.remove(key);
    }
    
    bool contains(int key) {
        return bstree.contains(key);
    }
};



/**
 * Your MyHashSet object will be instantiated and called as such:
 * MyHashSet* obj = new MyHashSet();
 * obj->add(key);
 * obj->remove(key);
 * bool param_3 = obj->contains(key);
 */