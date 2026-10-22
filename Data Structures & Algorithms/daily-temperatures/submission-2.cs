public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        // index stack - so we can compare the value and once is less, we can calculate
        // the distance i - popped index & also push to output array using the very same index.
        var stack = new Stack<int>();

        var output = new int[temperatures.Length];
        for (var i = 0 ; i < temperatures.Length; i++)
        {
            while (stack.Count() > 0 && temperatures[stack.Peek()] < temperatures[i])
            {
                // the peeked index in stack is less than the observed temperature at i
                // so output at i is the distance between i and the index in the stack.
                output[stack.Peek()] = i - stack.Peek();
                stack.Pop();
            }
            stack.Push(i);
        }

        // whatever is remaining in the stack at the end has not observed a higher temp -
        // so for those indices we put 0 in output.
        while (stack.Count() > 0)
        {
            output[stack.Pop()] = 0;
        }

        return output;
    }
}
