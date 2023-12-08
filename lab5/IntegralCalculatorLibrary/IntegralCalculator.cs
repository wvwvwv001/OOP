// IntegralCalculator.cs
using System;
using System.Runtime.InteropServices;

namespace IntegralCalculatorLibrary;

public class IntegralCalculator
{
    // Импорт функции из нативной библиотеки
    [DllImport("libintegral", CallingConvention = CallingConvention.Cdecl)]
    private static extern double integrate(double a, double b, int n);

    public static double Calculate(double a, double b, int n)
    {
        return integrate(a, b, n);
    }
}
