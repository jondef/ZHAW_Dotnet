namespace DN2;

internal class MainClass {
    private const int STEPS = 100;
    private const double EPS = 1E-5;

    public static void Main(string[] args) {
        Console.WriteLine($"Linear fixed [0..10]: {Integrator.Integrate(x => x, 0, 10, STEPS)} steps: {Integrator.Steps}");
        Console.WriteLine($"Linear fixed [5..15]: {Integrator.Integrate(x => x, 5, 15, STEPS)} steps: {Integrator.Steps}");
        Console.WriteLine($"Linear adapt [0..10]: {Integrator.Integrate(x => x, 0, 10, EPS)} steps: {Integrator.Steps}");
        Console.WriteLine($"Square fixed [0..10]: {Integrator.Integrate(x => x * x, 0, 10, STEPS)} steps: {Integrator.Steps}");
        Console.WriteLine($"Square adapt [0..10]: {Integrator.Integrate(x => x * x, 0, 10, EPS)} steps: {Integrator.Steps}");
        Console.ReadLine();
    }
}

public class Integrator {
    public static int Steps;

    public static double Integrate(Func<double, double> f, double start, double end, int steps) {
        Steps = steps;
        double stepSize = (end - start) / steps;
        double integral = 0.0;

        for (int i = 0; i < steps; i++)
        {
            double x1 = start + i * stepSize;
            double x2 = x1 + stepSize;
            integral += (f(x1) + f(x2)) * stepSize / 2;
        }
        return integral;
    }
    
    public static double Integrate(Func<double, double> f, double start, double end, double eps) {
        Steps = 1;
        return AdaptiveIntegrate(f, start, end, eps, f(start), f(end), ref Steps);
    }
    
    private static double AdaptiveIntegrate(Func<double, double> f, double start, double end, double eps, double fStart, double fEnd, ref int steps)
    {
        double mid = (start + end) / 2;
        double fMid = f(mid);

        double trapezoid1 = (fStart + fEnd) * (end - start) / 2;
        double trapezoid2 = (fStart + 2 * fMid + fEnd) * (end - start) / 4;

        steps++;

        if (Math.Abs(trapezoid1 - trapezoid2) < eps)
        {
            return trapezoid2;
        }

        return AdaptiveIntegrate(f, start, mid, eps / 2, fStart, fMid, ref steps) +
               AdaptiveIntegrate(f, mid, end, eps / 2, fMid, fEnd, ref steps);
    }
}