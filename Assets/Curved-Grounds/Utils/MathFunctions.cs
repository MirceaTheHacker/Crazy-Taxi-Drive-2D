using UnityEngine;

public class MathFunctions{

    public static int factorial(int n)
    {
        int fac = 1;
        for (int i = 1; i <= n; i++)
        {
            fac *= i;
        }
        return fac;
    }

    public static int CNKCombination(int n, int k)
    {
        
        return factorial(n) / (factorial(k) * factorial(n - k));
    }

    

}
