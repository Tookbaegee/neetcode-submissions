public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        var cars = new List<(int, int)>();
        var fleetStack = new Stack<double>();

        var n = position.Length;

        for (var i = 0; i < n; i++) {
            cars.Add((position[i], speed[i]));
        }
        cars.Sort((c1, c2) => c2.Item1 - c1.Item1);

        for (var i = 0; i < n; i++) {
            var (curPosition, curSpeed) = cars[i];
            var curTime = (double)(target - curPosition) / curSpeed;

            if (fleetStack.Count() == 0 || fleetStack.Peek() < curTime) {
                fleetStack.Push(curTime);
            }
        }

        // we can use the time a car takes to get to target time = (target - position) / speed
        // any car that catches up, (curTime <= peekTime (from stack which is car ahead)) merge it
        // if curTime > peekTime, add to stack a new upper bound for time

        return fleetStack.Count();
    }
}
