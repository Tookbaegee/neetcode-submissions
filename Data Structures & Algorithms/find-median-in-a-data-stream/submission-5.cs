public class MedianFinder {
    private PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>(); // minheap for right half of median
    private PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(); // maxheap for left half of median
    // we can keep minHeap up to count / 2 so whatever we peek right away is the medium
    // if count % 2 == 0 we deq 1 and peek 2 and get avg, enq 1 back.

    public MedianFinder() {}

    public void AddNum(int num) {
        if (minHeap.Count > 0 && minHeap.Peek() < num)
        {
            minHeap.Enqueue(num, num);
        }
        else
        {
            maxHeap.Enqueue(num, -num);
        }

        // then rebalance if one gets larger than another (than diff 1 to cover odd count case)
        if (minHeap.Count > maxHeap.Count + 1) {
            var min = minHeap.Dequeue();
            maxHeap.Enqueue(min, -min);
        }
        else if (maxHeap.Count > minHeap.Count + 1)
        {
            var max = maxHeap.Dequeue();
            minHeap.Enqueue(max, max);
        }
    }

    public double FindMedian() {
        if (minHeap.Count == 0 && maxHeap.Count == 0) {
            return 0;
        }

        if (minHeap.Count > maxHeap.Count) {
            return minHeap.Peek();
        }

        if (minHeap.Count < maxHeap.Count)
        {
            return maxHeap.Peek();
        }

        return (minHeap.Peek() + maxHeap.Peek()) / 2.0;
    }
}
