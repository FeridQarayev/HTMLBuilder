namespace DesignPatternBuilder.DesignPatterns
{
    #region PointExample
    public enum CordinateSystem
    {
        Cartesian,
        Polar
    }
    public class Point
    {
        private double x, y;
        public Point(double a, double b, CordinateSystem system = CordinateSystem.Cartesian)
        {
            switch (system)
            {
                case CordinateSystem.Cartesian:
                    x = a;
                    y = b;
                    break;
                case CordinateSystem.Polar:
                    x = a * Math.Cos(b);
                    y = b * Math.Sin(b);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(system), system, null);
            }
        }
    }

    #endregion

    #region PointExampleForApi
    public class PointExampleForApi
    {
        public static PointExampleForApi NewCartesianPoint(double x, double y)
        {
            return new PointExampleForApi(x, y);
        }
        public static PointExampleForApi NewPolarPoint(double rho, double theta)
        {
            return new PointExampleForApi(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
        private double x, y;
        private PointExampleForApi(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
    #endregion
}
