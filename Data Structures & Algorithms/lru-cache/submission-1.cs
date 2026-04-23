public class LRUCache {
    private Dictionary<int, ListNode> map;
    private int capacity;
    private ListNode front = null;
    private ListNode back = null;

    public LRUCache(int capacity) {
        map = new Dictionary<int, ListNode>();
        this.capacity = capacity;
    }
    
    public int Get(int key) {
        if (!map.ContainsKey(key)) return -1;
        ListNode node = map[key];
        MoveToFront(node);
        return node.Value;
    }
    
    public void Put(int key, int value) {
        if (map.ContainsKey(key)) {
            ListNode existNode = map[key];
            existNode.Value = value;
            MoveToFront(existNode);
            return;
        }

        if (map.Count == capacity)    // Remove Least recently use node
            RemoveBackNode();
        
        // insert new node to front
        ListNode newNode = new ListNode(key, value);
        InsertNodeToFront(newNode);
        map.Add(key, newNode);
    }

    private void MoveToFront(ListNode node) {
        if (node.Prev == null) // this node is the first node
            return; 

        // remove the node and put it to front
        ListNode prevNode = node.Prev;
        ListNode nextNode = node.Next;

        prevNode.Next = nextNode;
        if (nextNode != null) nextNode.Prev = prevNode;
        else back = prevNode;
        
        node.Prev = null;
        node.Next = front;
        front.Prev = node;
        front = node;

    }

    private void RemoveBackNode() {
        map.Remove(back.Key);
        if (front == back) {
            front = null;
            back = null;
        } else {
            ListNode backPrev = back.Prev;
            backPrev.Next = null;
            back = backPrev;
        }
    }

    private void InsertNodeToFront(ListNode node) {
        if (front == null) {
            front = node;
            back = front;
            return;
        }

        node.Next = front;
        front.Prev = node;
        front = node;
    }

    class ListNode {
        public int Key {get; set;}
        public int Value {get; set;}
        public ListNode Prev {get; set;}
        public ListNode Next {get; set;}

        public ListNode (int key, int value) {
            Key = key;
            Value = value;
            Prev = null;
            Next = null;
        }
    }
}
