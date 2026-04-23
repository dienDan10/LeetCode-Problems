/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        if (head == null) return null;
        var map = new Dictionary<Node, Node>();
        Node cur = head;
        while (cur != null) {
            map.Add(cur, new Node(cur.val));
            cur = cur.next;
        }

        cur = head;
        while (cur != null) {
            Node temp = map[cur];
            temp.next = cur.next != null ? map[cur.next] : null;
            temp.random = cur.random != null ? map[cur.random] : null;
            cur = cur.next;
        }

        return map[head];
    }
}
