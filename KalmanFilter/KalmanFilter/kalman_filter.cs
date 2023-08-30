using MatrixLib;
namespace KalmanFilterLib;
public class KalmanFilter
{
    private Matrix A, H, Q, R, P, x, I;

    public void Init(Matrix A, Matrix H, Matrix Q, Matrix R, Matrix initial_P, Matrix initial_x)
    {
        this.A = A;
        this.H = H;
        this.Q = Q;
        this.R = R;
        this.P = initial_P;
        this.x = initial_x;
        this.I = new Matrix();
        this.I.SetMatrix(I.Eye(this.P.n));
    }

    public Matrix Update(Matrix y)
    {
        // predict
        Matrix xhatm = this.A * this.x;
        Matrix Pm = (this.A * this.P) * this.A.Transpose() + this.Q;

        // update
        Matrix G = (Pm * this.H) * (this.H.Transpose() * Pm * this.H + this.R).Inverse();
        this.x = xhatm + G * (y - this.H.Transpose() * xhatm);
        this.P = (I - (G * H.Transpose()) * Pm);

        return x;
    }
    public void Print() 
    {
        Console.WriteLine("----------------"); 
        Console.Write("x:"); 
        this.x.Print(); 
        Console.WriteLine("----------------"); 
    }
}