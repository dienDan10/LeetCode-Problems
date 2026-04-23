public class Twitter {
    private Dictionary<int, HashSet<int>> users;
    private Dictionary<int, List<(int tweet, int time)>> tweets;
    private int timestamp = 0;

    public Twitter() {
        users = new Dictionary<int, HashSet<int>>();
        tweets = new Dictionary<int, List<(int tweet, int time)>>();
    }
    
    public void PostTweet(int userId, int tweetId) {
        if (!tweets.ContainsKey(userId)) {
            tweets.Add(userId, new List<(int tweet, int time)> ());
        }

        if (!users.ContainsKey(userId)) {
            users.Add(userId, new HashSet<int>() { userId });
        }

        tweets[userId].Add((tweetId, timestamp));
        timestamp++;
    }
    
    public List<int> GetNewsFeed(int userId) {
        if (!users.ContainsKey(userId)) return null;

        var followees = users[userId];
        var heap = new PriorityQueue<(int user, int tweet, int index), int>();
        foreach (int user in followees) {
            if (!tweets.ContainsKey(user)) continue;
            int lastIdx = tweets[user].Count - 1;
            var lastest = tweets[user][lastIdx];
            heap.Enqueue((user, lastest.tweet, lastIdx), -lastest.time);
        }

        var result = new List<int>();
        while (result.Count < 10 && heap.Count > 0) {
            var (user, tweet, index) = heap.Dequeue();
            result.Add(tweet);

            if (index - 1 >= 0) {
                var lastest = tweets[user][index - 1];
                heap.Enqueue((user, lastest.tweet, index - 1), -lastest.time);
            }
        }

        return result;
    }
    
    public void Follow(int followerId, int followeeId) {
        if (!users.ContainsKey(followerId)) {
            users.Add(followerId, new HashSet<int> () { followerId });
        }

        users[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if (followerId == followeeId) return;
        if (users.ContainsKey(followerId)) {
            users[followerId].Remove(followeeId);
        }
    }
}
