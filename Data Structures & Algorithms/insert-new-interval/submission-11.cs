public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        // no need to revisit intervals prior since they are ordered ascending
        // by the start index
        var newStart = newInterval[0];
        var newEnd = newInterval[1];
        var res = new List<int[]>();

        var i = 0;
        for (i = 0; i < intervals.Length; i++) {
            var start = intervals[i][0];
            var end = intervals[i][1];

            // new interval end is after with interval start
            if (end >= newStart) {
                // new interval end is before start interval overlaps
                if (start <= newEnd) {
                    newStart = Math.Min(start, newStart);
                    newEnd = Math.Max(end, newEnd);
                }
                // no overlap - start was past newEnd so add new interval
                // and flush the rest and end loop
                else {
                    res.Add(new int[] { newStart, newEnd });
                    for (var j = i; j < intervals.Length; j++) {
                        res.Add(intervals[j]);
                    }
                    break;
                }
            }
            // new interval start was strictly after end
            // so there is no overlap
            else {
                res.Add(intervals[i]);
            }
        }

        // at the end of the loop if i is at the end (at length) and new interval was never added
        // (never flushed in the middle to end early)
        // we can safely add it to the end since at both cases the new interval (whether merged or
        // not) lies at the end of the existing intervals
        if (i == intervals.Length) {
            res.Add(new int[] { newStart, newEnd });
        }

        // we cannot handle the newly merged intervals at the end since we need
        // need to insert the inetrval in place first.
        // if (newEnd < start && end >) {
        //     res.Add(new int[] { newStart, newEnd });
        // }

        return res.ToArray();
    }
}
