public class LRUCache {
    private Dictionary<int, ListNode> map;
    private int capacity;
    private ListNode front;
    private ListNode back;

    public LRUCache(int capacity) {
        map = new Dictionary<int, ListNode>();
        this.capacity = capacity;
        front = new ListNode(0, 0);
        back = new ListNode(0, 0);
        front.Next = back;
        back.Prev = front;
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
        ListNode prev = node.Prev;
        ListNode next = node.Next;
        prev.Next = next;
        next.Prev = prev;

        ListNode nextFront = front.Next;
        front.Next = node;
        node.Prev = front;
        node.Next = nextFront;
        nextFront.Prev = node;
    }

    private void RemoveBackNode() {
        map.Remove(back.Prev.Key);
        ListNode prev = back.Prev.Prev;
        prev.Next = back;
        back.Prev = prev;
    }

    private void InsertNodeToFront(ListNode node) {
        ListNode nextFront = front.Next;
        front.Next = node;
        node.Prev = front;
        node.Next = nextFront;
        nextFront.Prev = node;
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
