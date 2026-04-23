class Twitter {
private:
    // map contains key value as user id and set of follower
    std::unordered_map<int, std::unordered_set<int>> users{};
    // map contains user id and a vector of tweet with timestamp
    std::unordered_map<int, std::vector<std::pair<int, int>>> tweets{};
    int timestamp{0};
public:
    Twitter() {
        
    }
    
    void postTweet(int userId, int tweetId) {
        users[userId].insert(userId);
        tweets[userId].emplace_back(tweetId, timestamp);
        timestamp++;
    }
    
    vector<int> getNewsFeed(int userId) {
        std::vector<int> result{};
        auto it = users.find(userId);
        if (it == users.end()) return result;

        // tuple will contains followeeId, tweetId, timestamp and index in the current vector
        auto cmp = [] (const std::tuple<int, int, int, int>& a, std::tuple<int, int, int, int>& b) {
            return std::get<2>(a) < std::get<2>(b);
        };
        std::priority_queue<std::tuple<int, int, int, int>, 
            std::vector<std::tuple<int, int, int, int>>, decltype(cmp)> max_heap{};

        for (const int& followeeId : it->second) {
            auto it_tweet = tweets.find(followeeId);
            if (it_tweet == tweets.end()) continue;

            auto followee_tweets = it_tweet->second;
            int lastIdx = followee_tweets.size() - 1;
            max_heap.push(
                std::make_tuple(
                    followeeId,
                    followee_tweets[lastIdx].first, 
                    followee_tweets[lastIdx].second,
                    lastIdx
                )
            );
        }

        while (result.size() < 10 && !max_heap.empty()) {
            auto top = max_heap.top();
            max_heap.pop();

            result.push_back(std::get<1>(top));
            if (std::get<3>(top) > 0) {
                int lastIdx = std::get<3>(top) - 1;
                max_heap.push(
                    std::make_tuple(
                        std::get<0>(top),
                        tweets[std::get<0>(top)][lastIdx].first,
                        tweets[std::get<0>(top)][lastIdx].second,
                        lastIdx
                    )
                );
            }
        }

        return result;
    }
    
    void follow(int followerId, int followeeId) {
        users[followerId].insert(followeeId);
    }
    
    void unfollow(int followerId, int followeeId) {
        if (followerId == followeeId) return; // not allow user to unfollow themself
        users[followerId].erase(followeeId);
    }
};
