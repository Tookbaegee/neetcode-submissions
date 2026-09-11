public class TimeMap {

    private Dictionary<string, List<(int, string)>> timeMap;

    public TimeMap() {
        timeMap = new Dictionary<string, List<(int, string)>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if (!timeMap.ContainsKey(key))
        {
            timeMap[key] = new List<(int, string)>();
        }

        // we can't just append since the array needs to be kept sorted. We need to look for the right index to insert.
        // actually no because the constraint is given that the timestamp is strictly sorted
        // var values = this.timeMap[key];
        // var l = 0;
        // var r = values.Count();
        // while (l < r)
        // {
        //     var m = (l + r) / 2;
        //     var cTimestamp = values[m].Item1;

        //     if (cTimestamp < timestamp)
        //     {
        //         l = m + 1;
        //     }
        //     else
        //     {
        //         r = m;
        //     }
        // }

        this.timeMap[key].Add((timestamp, value));
    }
    
    public string Get(string key, int timestamp) {
        var output = "";

        if (!timeMap.ContainsKey(key))
        {
            return output;
        }

        var values = timeMap[key];
        var l = 0;
        var r = values.Count() - 1;
        while (l <= r)
        {
            var m = (l + r) / 2;
            var cTimestamp = values[m].Item1;
            var cValue = values[m].Item2;

            if (cTimestamp <= timestamp)
            {
                output = cValue;
                l = m + 1;
            }
            else
            {
                r = m - 1;
            }
        }

        return output;
    }
}
