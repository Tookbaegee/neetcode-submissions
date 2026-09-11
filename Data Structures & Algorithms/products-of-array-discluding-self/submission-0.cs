public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        // if use division, iterate through to find the common product and divide by nums[i]
        // issue when one of the element is 0 (dividing by 0 will error)
        // so instead let's try tracking products with the map
        
        
        var prefixProducts = new int[nums.Length];
        var prefixes = new int[nums.Length];
        var suffixProducts = new int[nums.Length];
        var suffixes = new int[nums.Length];

        var output = new int[nums.Length];

        for (var i = 0; i < nums.Length; i++)
        {
            if (i == 0)
            {
                prefixes[i] = 1;
                prefixProducts[i] = nums[i];
            }
            else
            {
                prefixes[i] = prefixProducts[i - 1];
                prefixProducts[i] = nums[i] * prefixProducts[i - 1];
            }
        }

        for (var i = nums.Length - 1; i >= 0; i--)
        {

            if (i == nums.Length - 1)
            {
                suffixes[i] = 1;
                suffixProducts[i] = nums[i];
            }
            else
            {
                suffixes[i] = suffixProducts[i + 1];
                suffixProducts[i] = nums[i] * suffixProducts[i + 1];
            }
            
            output[i] = suffixes[i] * prefixes[i];
        }

        return output;
    }
}
