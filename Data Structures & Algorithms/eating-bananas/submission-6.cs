public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        var sortedPiles = new List<int>(piles);
        sortedPiles.Sort((p1, p2) => p2 - p1);

        var maximusBananas = sortedPiles[0];

        var l = 1;
        var r = maximusBananas;
        var minRate = maximusBananas;
// rather than only trying the values since we have the upper bound we can scan 0 ~ upper bound so we set r as the upper bound.
        while (l <= r && l >= 0)
        {
            var m = l + (r - l + 1) / 2;

            // list is sorted - can we accumulate t?
            // we can decide on left or right by whether t > h
            var k = m;
            var t = 0;
            // left is bigger, if we can go for slower rate we shift l
            
            for (var i = 0; i < sortedPiles.Count(); i++)
            {
                t += sortedPiles[i] / k;
                t += sortedPiles[i] % k > 0 ? 1 : 0;
            }

            // it took longer than h, so we need to go for a bigger rate so shift l to right of m
            if (t > h)
            {
                l = m + 1;
            }

            // if t is less than or equal to h we continue to shift right so we can record the lowest rate
            if (t <= h)
            {
                minRate = Math.Min(minRate, k);

                r = m - 1;
            }
        }

        return minRate;
    }
}
