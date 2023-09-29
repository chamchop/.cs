namespace DesignPatterns.Proxy
{
    public class ProtectionProxy
    {
        public interface ICar
        {
            void Drive();
        }

        public class Car : ICar
        {
            public void Drive()
            {
                Console.WriteLine("car driving");
            }
        }

        public class Driver
        {
            public int Age { get; set; }

            public Driver(int age)
            {
                this.Age = age;
            }
        }

        public class CarProxy : ICar
        {
            private Driver driver;
            private Car car = new Car();

            public CarProxy(Driver driver)
            {
                this.driver = driver;
            }

            public void Drive()
            {
                if (driver.Age > 20)
                    car.Drive();
                else
                {
                    Console.WriteLine("cannot drive");
                }
            }
        }

        public static void Print()
        {
            ICar car = new CarProxy(new Driver(10));
            car.Drive();
        }
    }
}
