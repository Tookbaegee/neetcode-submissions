public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var stack = new List<int>();

        var output = new int[temperatures.Length];
        for (var i = 0 ; i < temperatures.Length; i++)
        {

            while (stack.Count() > 0 && temperatures[stack[stack.Count() - 1]] < temperatures[i])
            {
                output[stack[stack.Count() - 1]] = i - stack[stack.Count() - 1];
                stack.RemoveAt(stack.Count() - 1);
            }
            stack.Add(i);
        }

        for (var i = 0; i < stack.Count(); i++)
        {
            output[stack[i]] = 0;
        }

        return output;
    }
}
