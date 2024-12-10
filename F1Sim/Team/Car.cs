namespace CarSpace
{
    public class Car
    {
        public double avarage;

        public double topSpeed { get; set; }
        public double acceleration { get; set; }
        public double drsEffectovness { get; set; }
        public double downforce { get; set; }
        public double dirtyAirTolerance { get; set; }
        public double engineColling { get; set; }
        public double tyrePreservation { get; set; }


        //BUY THE DAMM ENGINE DLC
        public double iceDurabilty;
        public double gearboxDurabilty;
        public double electricalStorage;

        public Car(double topSpeed, double acceleration, double drsEffectovness, double downforce, double dirtyAirTolerance, double engineColling, double tyrePreservation)
        {
            this.topSpeed = topSpeed;
            this.acceleration = acceleration;
            this.drsEffectovness = drsEffectovness;
            this.downforce = downforce;
            this.dirtyAirTolerance = dirtyAirTolerance;
            this.engineColling = engineColling;
            this.tyrePreservation = tyrePreservation;

            iceDurabilty = 0;
            gearboxDurabilty = 0;
            electricalStorage = 0;

            avarage = (topSpeed + acceleration + drsEffectovness + dirtyAirTolerance + engineColling + tyrePreservation) / 6;
        }

        public Car CreateNewCar(double partsAvarages)
        {
            Random rand = new Random();
            double min = Math.Max(0, partsAvarages-0.1);
            double max = Math.Max(0, partsAvarages-0.1);

            topSpeed = min + (rand.NextDouble() * (max - min));
            acceleration = min + (rand.NextDouble() * (max - min));
            drsEffectovness = min + (rand.NextDouble() * (max - min));
            downforce = min + (rand.NextDouble() * (max - min));
            engineColling = min + (rand.NextDouble() * (max - min));
            tyrePreservation = min + (rand.NextDouble() * (max - min));

            Car car = new Car(topSpeed, acceleration, drsEffectovness, downforce, dirtyAirTolerance, engineColling, tyrePreservation);
            return car;
        }

    }

}