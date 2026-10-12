/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    private Dictionary<int, Node> nodeSet = new Dictionary<int, Node>();

    public Node CloneGraph(Node node) {
        if (node == null)
        {
            return null;
        }
        // we will be deep cloning each node
        // if neighbor leads to a node that's already visited, we return the same reference from the nodeSet
        if (nodeSet.ContainsKey(node.val))
        {
            return nodeSet[node.val];
        }

        // we have to make sure we set the new node in the set before we recurse into children
        // so that we can return the reference if found although the neighbor may not be complete
        // then as we come out of the frame, we add all the children's reference
        var newNode = new Node(node.val);
        nodeSet[node.val] = newNode;

        var newNeighbors = new List<Node>();
        foreach (var neighbor in node.neighbors)
        {
            newNeighbors.Add(this.CloneGraph(neighbor));
        }

        nodeSet[node.val].neighbors = newNeighbors;
        return newNode;
    }
}
