using PersonSpace;
using CarSpace;
using System.ComponentModel.Design;
using Facility;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using CountrySpace;
using System.Text.Json;

namespace TeamSpace
{
    public class Team
    {
        public string name { get; set; }
        public int money { get; set; }

        //Emplooyes
        public TeamPrincipal teamPrincipal { get; set; }
        public Driver driver1 { get; set; }
        public Driver driver2 { get; set; }

        public Car car1 { get; set; }
        public Car car2 { get; set; }

        //Facciltys
        public ReseachNDevkiopnentFacility rndFaccilty { get; set; }
        public DriverFacility driverFacility { get; set; }
        public PitCrewTranningFacility pitFacility { get; set; }
        public MarketingFacility marketingFacility { get; set; }
        public WindTunnel windTunnel { get; set; }

        //Sponsors
        public double popularity { get; set; }

        public Team(string name, int money, double popularity, TeamPrincipal teamPrincipal, Driver driver1, Driver driver2, Car car, ReseachNDevkiopnentFacility reseachNDevkiopnentFacility, DriverFacility driverFacility, PitCrewTranningFacility pitCrewTranningFacility, MarketingFacility marketingFacility, WindTunnel windTunnel)
        {
            this.name = name;
            this.money = money;
            this.popularity = popularity;
            this.teamPrincipal = teamPrincipal;
            this.driver1 = driver1;
            this.driver2 = driver2;
            this.car1 = JsonSerializer.Deserialize<Car>(JsonSerializer.Serialize(car)); //Make car not references to each other
            this.car2 = JsonSerializer.Deserialize<Car>(JsonSerializer.Serialize(car));
            this.rndFaccilty = reseachNDevkiopnentFacility;
            this.driverFacility = driverFacility;
            this.pitFacility = pitCrewTranningFacility;
            this.marketingFacility = marketingFacility;
            this.windTunnel = windTunnel;
        }

        public static Team MakeNewTeam(string name, int money, double popularity, StaffExperince experince, (int a, int b) driver1Rating, (int a, int b) driver2Rating, double carAvarage, int faciltyLevel, List<Country> countries)
        {

            //Hire a TeamPrincipal
            TeamPrincipal tp = TeamPrincipal.CreateNewTeamPrincipal(experince, countries);

            //Hire a drivers
            Driver driver1 = Driver.CreateNewDriver(driver1Rating.Item1, driver1Rating.Item2, countries);
            Driver driver2 = Driver.CreateNewDriver(driver2Rating.Item1, driver2Rating.Item2, countries);

            //Make a car
            Car car = Car.CreateNewCar(carAvarage);

            //rndFacility
            ReseachNDevkiopnentFacility reseachNDevkiopnentFacility = new ReseachNDevkiopnentFacility(faciltyLevel); //Fix engineers

            for (int i = 0; i < ReseachNDevkiopnentFacility.enginnersOnLevel[reseachNDevkiopnentFacility.level]; i++)
            {
                reseachNDevkiopnentFacility.enginners.Add(Enginner.CreateNewEnginner(experince, countries));
            }

            //driverFacilty
            DriverFacility driverFacility = new DriverFacility(faciltyLevel);

            //pitcrewFacilty
            PitCrewTranningFacility pitCrewTranningFacility = new PitCrewTranningFacility(faciltyLevel); //Fix pit people
            for (int i = 0; i < 14; i++)
            {
                pitCrewTranningFacility.pitcrews[i] = Pitcrew.CreateNewPitcrew(experince, countries);
            }

            //marketingfacilty
            MarketingFacility marketingFacility = new MarketingFacility(faciltyLevel); //Fix mareting people
            for (int i = 0; i < MarketingFacility.marketrsOnLevel[marketingFacility.level]; i++)
            {
                marketingFacility.marketers.Add(Marketer.CreateNewTeamMarketer(experince, countries));
            }


            //windtunnel
            WindTunnel windTunnel = new WindTunnel(faciltyLevel);

            Team team = new Team(name, money, popularity, tp, driver1, driver2, car, reseachNDevkiopnentFacility, driverFacility, pitCrewTranningFacility, marketingFacility, windTunnel);
            return team;
        }
    }

    public class TeamData
    {
        public int wins { get; set; }
        public int wdc { get; set; }
        public int founded { get; set; }

        public TeamData(int founded)
        {
            wins = 0;
            wdc = 0;
            this.founded = founded;
        }

    }
}