public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        var cars = new (int position, double time)[position.Length];

        for (int i = 0; i < cars.Length; i++) {
            cars[i].position = position[i];
            cars[i].time = (double)(target - position[i]) / speed[i];
        }

        Array.Sort(cars, (a, b) => b.position.CompareTo(a.position));

        int output = 0;
        double maxTime = 0;

        foreach (var car in cars) {
            if (car.time > maxTime) {
                output++;
                maxTime = car.time;
            }
        }

        return output;
    }
}
