public class KalmanFilter2
{
    public double x = 0.0;
    public double y = 0.0;
    public double z = 0.0;

    public double filter(double x)
    {
        // ここにfilter処理
        this.x = x;
        return x;
    }
}
