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
        var userTweets = new List<(int tweet, int time)>();
        foreach (int user in followees) {
            if (!tweets.ContainsKey(user)) continue;
            userTweets.AddRange(tweets[user]);
        }

        userTweets.Sort((a, b) => b.time.CompareTo(a.time));
        var result = new List<int>();
        int index = 0;
        while (result.Count < 10 && index < userTweets.Count) {
            result.Add(userTweets[index].tweet);
            index++;
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
