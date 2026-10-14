public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {

        var subToReq = new Dictionary<int, List<int>>();
        var path = new Dictionary<int, bool>();
        // must take course 1 before taking course 0
        // build a graph and traverse
        for (var i = 0; i < prerequisites.Length; i++) {
            var preReq = prerequisites[i];
            var subject = preReq[0];
            var required = preReq[1];

            if (subject == required)
            {
                return false;
            }

            if (!subToReq.ContainsKey(subject))
            {
                subToReq[subject] = new List<int>();
            }
            subToReq[subject].Add(required);
        }

        for (var i = 0; i < prerequisites.Length; i++) {
            if (!this.DFS(subToReq, prerequisites[i][0], path, numCourses))
            {
                return false;
            }
        }

        return true;
    }

    // we could reduce the memory complexity by checking against the courseNum but we have to run for at least 
    // for the number of courses which at tops at 1000.
    // also with a single int to int map, we only guarante one to one, but pre req could be one to many - we need to map it to int to List<int> and iterate over all the prereqs given int
    public bool DFS(Dictionary<int, List<int>> preReqs, int course, Dictionary<int, bool> path, int numCourses)
    {
        numCourses--;
        if (numCourses < 0 || path.ContainsKey(course))
        {
            return false;
        }

        if (!preReqs.ContainsKey(course))
        {
            return true;
        }

        path[course] = true;

        foreach (var req in preReqs[course])
        {
            if (!this.DFS(preReqs, req, path, numCourses))
            {
                return false;
            }
        }

        path.Remove(course);
        preReqs[course].Clear();
        return true;
    }
}
