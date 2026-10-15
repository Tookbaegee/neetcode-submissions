public class Solution {
    public int CountComponents(int n, int[][] edges) {
        // Tree properties
        // all node is connected to another
        // no cycle
        // undirected edges - meaning we will a -> b

        // contstraints - neglect self loops or repeated edges
        if (n == 0)
        {
            return 0;
        }
        if (n == 1)
        {
            return 1;
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

        // check for disconnection - instead of iterating over all possible n, we start from what's left in the map
        // if all nodes are connected, during traversal all nodes must be visited.
        // caveat: if we only consider what's in the map we don't consider ones without any

        var count = 0;
        var start = treeMap.Keys.FirstOrDefault();
        while (treeMap.Count() > 0)
        {
            this.DFS(treeMap, -1, start, path);
            start = treeMap.Keys.FirstOrDefault();
            count++;
        }

        // add the count of visited graphs
        // then we add unvisited still unvisited
        count += n - path.Count();

        return count; 
    }

    public void DFS(Dictionary<int, List<int>> treeMap, int prev, int node,
                    Dictionary<int, bool> path) {
        if (path.ContainsKey(node)) {
            return;
        }

        if (!treeMap.ContainsKey(node))
        {
            return;
        }

        path[node] = true;

        foreach (var nextNode in treeMap[node]) {
            if (prev != nextNode) {
                this.DFS(treeMap, node, nextNode, path);
            }
        }
        // no need to backtrack here again because we also halt early on cycle and we never reconsider a node
        // because once DFS is done the next run will be on the graph that is not connected
        // guaranteeing we visit different set of numbers
        // path.Remove(node);

        treeMap.Remove(node);

        return;
    }
}
