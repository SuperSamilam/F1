namespace CarSpace
{
    public class Car
    {
        public double avarage;

        public double speed { get; set; }
        public double downforce { get; set; }


        //BUY THE DAMM ENGINE DLC
        public double iceDurabilty;
        public double gearboxDurabilty;
        public double electricalStorage;

        public Car(double speed, double downforce)
        {
            this.speed = speed;
            this.downforce = downforce;

            iceDurabilty = 0;
            gearboxDurabilty = 0;
            electricalStorage = 0;

            avarage = (speed + downforce) / 2;
        }

        public static Car CreateNewCar(double partsAvarages)
        {
            Random rand = new Random();
            double min = Math.Max(0, partsAvarages-0.1);
            double max = Math.Max(0, partsAvarages-0.1);

            double speed = min + (rand.NextDouble() * (max - min));
            double downforce = min + (rand.NextDouble() * (max - min));


            Car car = new Car(speed, downforce);
            return car;
        }
    }

}