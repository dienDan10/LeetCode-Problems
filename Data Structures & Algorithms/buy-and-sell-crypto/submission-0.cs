public class Solution {
    public int MaxProfit(int[] prices) {
        int buy = prices[0];
        int profit = 0;

        for (int i = 0; i < prices.Length; i++) {
            profit = Math.Max(prices[i] - buy, profit);
            buy = Math.Min(prices[i], buy);
        }

        return profit;
    }
}
