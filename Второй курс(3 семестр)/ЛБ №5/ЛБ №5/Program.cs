using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        delegate double fynction(double x);
        delegate double faktorial(int a,int b,int n,fynction f);
        delegate double zadan5(int[] x, int[] y);
        delegate double z_5(int[] x);
        static void Main(string[] args)
        {
        }
        static fynction fynkcia3 = x =>{ 
            if (x < -7)
                return -3 * Math.Sin(2 * x);
            else if (x >= -7 && x < 0)
                return Math.Sqrt(Math.Pow(x, 3) - 5);
            else
                return (1 / x);
        };
        static fynction fynkcia1 = x => {
            if (x < 1)
                return Math.Tan(2 * x);
            else
                return Math.Pow((2 * x + 10), 3);
        };
        static fynction fynkcia2 = x => 
        {
            double s=1;
            for (double i=x; i < x; i++)
            {
                if (i % 2 == 0)
                    s *= i;
            }
            return Math.Pow(x, 2) * s;
        };
        static fynction f1 = x => { return 3 * x - Math.Sin(2 * x); };
        static fynction f2 = x => { return Math.Exp(-2 * x) - 2 * x + 1; };
        static faktorial factarial = (a,b,n,f) =>
         {
             double h = (b - a) / n;
             double sum = 0;
             for (int i= 0; i <= n; i++)
                 sum += f(a + i * h);
             double result = h + sum;
             return result;
         };
        static z_5 symv = x => 
        {
            int s=0;
            for (int i = 0; i <= x.Length; i++)
                s += x[i];
            return s;
        };
        static z_5 znamin = x =>
        {
            double s = 0;
            for (int i = 0; i <= x.Length; i++)
                s += Math.Pow(x[i]- symv(x),2);
            return s;
        };
        static zadan5 ceslitel = (x, y) =>
        {
            double s = 0;
            for (int i = 0; i <= x.Length; i++)
                s += (x[i] - symv(x)) * (y[i] - symv(y));
            return s;
        };
        static zadan5 z5 = (x, y) =>
        {
            return ceslitel(x, y) / znamin(x) * znamin(y);
        };
    }
}
