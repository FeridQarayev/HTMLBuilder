namespace DesignPatternBuilder
{
    #region Items
    public enum CarType
    {
        Sedan,
        Crossover
    }
    public class Car
    {
        public CarType Type;
        public int WheelSize;
    }
    #endregion

    #region Interfaces
    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
    public interface ISpecifyWheelSize
    {
        IBuildCar WithWheels(int size);
    }
    public interface IBuildCar
    {
        public Car Build(bool show);
    }

    #endregion

    public class CarBuilder
    {
        private class Impl :
            ISpecifyCarType,
            ISpecifyWheelSize,
            IBuildCar
        {
            private Car car = new Car();
            public ISpecifyWheelSize OfType(CarType type)
            {
                car.Type = type;
                return this;
            }

            public IBuildCar WithWheels(int size)
            {
                switch (size)
                {
                    case (int)CarType.Crossover when size < 17 || size > 20:
                    case (int)CarType.Sedan when size < 15 || size > 17:
                        throw new ArgumentException($"Wrong size of wheel for {car.Type}.");
                }
                car.WheelSize = size;
                return this;
            }
            public Car Build(bool show)
            {
                if(show) Console.WriteLine($"Car type: {Enum.GetName(car.Type)}, wheel size: {car.WheelSize}");
                return car;
            }
        }
        public static ISpecifyCarType Create()
        {
            return new Impl();
        }
    }
}
