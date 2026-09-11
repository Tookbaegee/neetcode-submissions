public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        // by sorting people

        var peopleList = new List<int>(people);
        peopleList.Sort();

        var l = 0;
        var r = people.Length - 1;

        var numBoat = 0;
        while (l <= r)
        {
            var totalWeight = l == r ? peopleList[l] : peopleList[l] + peopleList[r];
            if (totalWeight <= limit)
            {
                numBoat++;
                l++;
                r--;
            }
            else
            {
                // only shift right to left since we need to look for a smaller sum, if we shift left right then sum only increases.
                numBoat++;
                r--;
            }
        }
        return numBoat;
    }
}