using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_func_explorer
{
    class FunctionExplorer
    {
        private readonly Func<double, double> _Func;
        public FunctionExplorer(Func<double, double> f)
        {
            _Func = f;
        }
        /*public double GetMinValue (double x1, double x2, double dx)
        {
            double min = double.PositiveInfinity;
            double x = x1;
            while (x <= x2)
            {
                double y = _Func(x);
                if (y < min)
                    min = y;
                x += dx;
            }
            return min;
        }*/
        public double GetMinValue(double x1, double x2, double dx, out double xmin)
        {
            double min = double.PositiveInfinity;
            double x = x1;
            xmin = x1;
            while (x <= x2)
            {
                double y = _Func(x);
                if (y < min)
                {
                    min = y;
                    xmin = x;
                }
                x += dx;
            }
            return min;
        }
        public FunctionValue GetMin(double x1, double x2, double dx)
        {
            double min = double.PositiveInfinity;
            double x = x1;
            var xmin = x1;
            while (x <= x2)
            {
                double y = _Func(x);
                if (y < min)
                {
                    min = y;
                    xmin = x;
                }
                x += dx;
            }
            return new FunctionValue(xmin, min);
        }
    }
    struct FunctionValue
    {
        public readonly double x;
        public readonly double y;
        public FunctionValue(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Programm
    {
        static void Main()
        {
            const double x0 = -5;
            const double y0 = -7;
            Func<double, double> f =
                x => (x - x0)*(x - x0) + y0;
            var explorer = new FunctionExplorer(f);
            /*double x_min;
            var min = explorer.GetMinValue(-10, 10, 0.01, out x_min);
            Console.WriteLine("Min f(x) = {0} where x = {1};", min, x_min);*/
            FunctionValue min = explorer.GetMin(-10, 10, 0.01);
            Console.WriteLine("Min f(x) = {0} where x = {1};", min.y, min.x);
            Console.ReadLine();
        }
    }
}
