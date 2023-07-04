namespace DesignPatterns.Factories
{
    public class Coordinates
    {
        public class PointFactory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }

        public enum CoordinateSystem
        {
            Cartesian,
            Polar
        }

        public class Point
        {
            private double x, y;

            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public static void Exe()
        {
            var p = new Point(1, Math.PI / 2);
            var point = PointFactory.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);
        }
    }
}