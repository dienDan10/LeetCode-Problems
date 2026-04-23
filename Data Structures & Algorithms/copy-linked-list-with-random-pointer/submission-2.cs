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
        Node temp = head;
        while (temp != null) {
            map.Add(temp, new Node(temp.val));
            temp = temp.next;
        }

        temp = head;
        while (temp != null) {
            map[temp].next = temp.next != null ? map[temp.next] : null;
            map[temp].random = temp.random != null ? map[temp.random] : null;
            temp = temp.next;
        }

        return map[head];
    }
}
