public class Solution {

    public int FindKthLargest(int[] nums, int k) {
        var minHeap = new PriorityQueue<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            minHeap.Enqueue(nums[i], nums[i]);
            while (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }

        return minHeap.Peek();
    }
}
