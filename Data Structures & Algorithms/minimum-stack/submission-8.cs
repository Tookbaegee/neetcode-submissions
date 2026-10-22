public class MinStack {
    private Stack<int> values;
    private Stack<int> minStack;

    public MinStack() {
        this.values = new Stack<int>();
        this.minStack = new Stack<int>();
    }
    
    public void Push(int val) {
        this.values.Push(val);
        if (this.minStack.Count() == 0 || this.minStack.Peek() >= val)
        {
            this.minStack.Push(val);
        }
    }
    
    public void Pop() {
        if (values.Count() > 0)
        {
            var val = this.values.Pop();
            if (val == this.minStack.Peek())
            {
                minStack.Pop();
            }
        }
    }

    public int Top() {
        return this.values.Peek();
    }
    
    public int GetMin() {
        return minStack.Peek();
    }
}
