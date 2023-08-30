using ImagingSolution;
using KalmanFilterLib;
using MatrixLib;

class Program
{
    static void Main(string[] args)
    {
        // Matrixのテスト
        Console.WriteLine("Start program");

        double[,] x = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        Matrix mat = new Matrix(x);
        Console.WriteLine("Matrix");
        mat.Print();

        Matrix matT = mat.Transpose();
        Console.WriteLine("Matrix transpose");
        matT.Print();


        Matrix resMat = new Matrix(3, 3);
        Console.WriteLine("Matrix plus");
        resMat.x = mat.Plus(matT);
        resMat.Print();

        Console.WriteLine("Matrix minus");
        resMat.x = mat.Minus(matT);
        resMat.Print();

        Console.WriteLine("Matrix dot");
        resMat.x = mat.Dot(matT);
        resMat.Print();

        Console.WriteLine("Matrix invMat");
        resMat = mat.Inverse();
        resMat.Print();

        Console.WriteLine("Matrix dot");
        Matrix resMat2 = mat * matT; 
        resMat2.Print();

        // カルマンフィルタのテスト
        Matrix A, H, Q, R, P, init_x;
        double dt = 0.1;
        A = new Matrix(new double[,] { { 1, dt }, { 0, 1 } });
        H = new Matrix(new double[,] { { dt * dt / 2, 0 }, { 0, dt } });
        Matrix I = new Matrix();
        I.SetMatrix(I.Eye(2));
        Q = 0.01 * I;
        R = 0.001 * I;
        P = 1.0 * I;
        init_x = new Matrix(new double[,] { { 0 }, { 0 } });

        Matrix obsMat;
        KalmanFilter kf = new KalmanFilter();
        kf.Init(A, H, Q,  R,  P, init_x);
        Console.WriteLine("Start KalmanFilter");
        for (int i = 0; i < 6; i++) 
        {
            obsMat = new Matrix(new double[,] { { 3 }, { 3 } });
            kf.Update(obsMat);
            kf.Print();
        }

        
        return;
    }
}
