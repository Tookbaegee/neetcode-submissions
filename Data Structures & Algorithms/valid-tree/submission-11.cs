public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        // Tree properties
        // all node is connected to another
        // no cycle
        // undirected edges - meaning we will a -> b

        // contstraints - neglect self loops or repeated edges
        if (n == 0)
        {
            return false;
        }
        if (n == 1)
        {
            return true;
        }

        var treeMap = new Dictionary<int, List<int>>();
        var path = new Dictionary<int, bool>();

        foreach (var edge in edges) {
            if (!treeMap.ContainsKey(edge[0])) {
                treeMap[edge[0]] = new List<int>();
            }

            treeMap[edge[0]].Add(edge[1]);

            if (!treeMap.ContainsKey(edge[1])) {
                treeMap[edge[1]] = new List<int>();
            }

            treeMap[edge[1]].Add(edge[0]);
        }

        // for (var i = 0; i < n; i++)
        // {
        //     if (!treeMap.ContainsKey(i)) {
        //         return false;
        //     }
        // }

        // check for disconnection - instead of iterating over all possible n, we only start from 0 the root
        // if all nodes are connected, during traversal all nodes must be visited.

        if(!this.DFS(treeMap, -1, 0, path))
        {
            return false;
        }

        return treeMap.Count() == 0; // had this condition flipped - return true if 0 means it's exhausted.
    }

    public bool DFS(Dictionary<int, List<int>> treeMap, int prev, int node,
                    Dictionary<int, bool> path) {
        if (path.ContainsKey(node)) {
            return false;
        }

        path[node] = true;

        // don't need this because we don't iterate over all possible n and perform DFS
        // we only reach the node if node was in the map
        if (!treeMap.ContainsKey(node))
        {
            return true;
        }

        foreach (var nextNode in treeMap[node]) {
            if (prev != nextNode) {
                if (!this.DFS(treeMap, node, nextNode, path)) {
                    return false;
                }
            }
        }

        path.Remove(node);
        treeMap.Remove(node);

        return true;
    }
}
