public class Solution {
    public double MyPow(double x, int n) {
        if (n == 0) return 1;

        if (n < 0) return 1 / MyPow(x, -n);

        double temp = MyPow(x, n / 2);
        if (n % 2 == 1) {
            return temp * temp * x;
        } else {
            return temp * temp;
        }
    }
}
