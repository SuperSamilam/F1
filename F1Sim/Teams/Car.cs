namespace CarSpace
{
    public class Car
    {
        public double avarage;

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

        public Car(double acceleration, double drsEffectovness, double downforce, double dirtyAirTolerance, double engineColling, double tyrePreservation)
        {
            this.acceleration = acceleration;
            this.drsEffectovness = drsEffectovness;
            this.downforce = downforce;
            this.dirtyAirTolerance = dirtyAirTolerance;
            this.engineColling = engineColling;
            this.tyrePreservation = tyrePreservation;

            iceDurabilty = 0;
            gearboxDurabilty = 0;
            electricalStorage = 0;

            avarage = (acceleration + drsEffectovness + dirtyAirTolerance + engineColling + tyrePreservation) / 5;
        }

        public static Car CreateNewCar(double partsAvarages)
        {
            Random rand = new Random();
            double min = Math.Max(0, partsAvarages-0.1);
            double max = Math.Max(0, partsAvarages-0.1);

            double acceleration = min + (rand.NextDouble() * (max - min));
            double drsEffectovness = min + (rand.NextDouble() * (max - min));
            double downforce = min + (rand.NextDouble() * (max - min));
            double dirtyAirTolerance = min + (rand.NextDouble() * (max - min));
            double engineColling = min + (rand.NextDouble() * (max - min));
            double tyrePreservation = min + (rand.NextDouble() * (max - min));

            Car car = new Car(acceleration, drsEffectovness, downforce, dirtyAirTolerance, engineColling, tyrePreservation);
            return car;
        }
    }

}