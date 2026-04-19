class Solution {
public:
    int carFleet(int target, vector<int>& position, vector<int>& speed) {
        std::vector<std::pair<int, int>> cars {};

        for (int i = 0; i < position.size(); i++) {
            cars.push_back(std::make_pair(position[i], speed[i]));
        }

        std::sort(cars.begin(), cars.end(), [](auto& car1, auto& car2) {
            return car1.first > car2.first;
        });
        
        double time = static_cast<double>(target - cars[0].first) / cars[0].second;
        int fleets = 1;
        for (int i = 1; i < cars.size(); i++) {
            double arrived_time = static_cast<double>(target - cars[i].first) / cars[i].second;
            if (arrived_time <= time) continue;

            time = arrived_time;
            fleets++;
        }

        return fleets;
    }
};
