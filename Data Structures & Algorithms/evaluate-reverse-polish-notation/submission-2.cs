public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new List<int>();

        for (var i = 0 ; i < tokens.Length; i++)
        {
            if (int.TryParse(tokens[i], out var val))
            {
                stack.Add(val);
            }
            else
            {
                if (stack.Count() > 1)
                {
                    var op2 = stack[stack.Count() - 1];
                    stack.RemoveAt(stack.Count() - 1);

                    var op1 = stack[stack.Count() - 1];
                    stack.RemoveAt(stack.Count() - 1);

                    var nextOp = this.Evaluate(op1, op2, tokens[i]);

                    stack.Add(nextOp);
                }
            }
        }

        return stack[0];
    }

    public int Evaluate(int op1, int op2, string oprtr)
    {
        switch (oprtr)
        {
            case "+":
                return op1 + op2;
            case "-":
                return op1 - op2;
            case "*":
                return op1 * op2;
            case "/":
                return op1 / op2;
        }

        return 0;
    }
}
