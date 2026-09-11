public class MinStack {
    private List<int> values;
    private List<int> minStack;

    public MinStack() {
        this.values = new List<int>();
        this.minStack = new List<int>();
    }
    
    public void Push(int val) {
        this.values.Add(val);
        if (this.minStack.Count() > 0)
        {
            this.minStack.Add(Math.Min(minStack[minStack.Count() - 1], val));
        }
        else
        {
            this.minStack.Add(val);
        }
    }
    
    public void Pop() {
        if (values.Count() > 0)
        {
            this.values.RemoveAt(values.Count() - 1);
            this.minStack.RemoveAt(minStack.Count() - 1);
        }
    }

    public int Top() {
        return this.values[values.Count() - 1];
    }
    
    public int GetMin() {
        return minStack[minStack.Count() - 1];
    }
}
