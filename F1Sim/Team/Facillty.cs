using System.Dynamic;
using PersonSpace;

namespace Facility
{
    public class Facility
    {
        public bool running { get; set; }
        public int upkeep { get; set; } //Scaled with level baseupkeep * level
        public int level { get; set; }
        public double condition { get; set; }
        int maxLevel = 5;

        public Facility(int level)
        {
            this.level = level;
            running = true;
            condition = 0;
        }
    }

    public class ReseachNDevkiopnentFacility : Facility
    {
        public double researchSpeedMultplier { get; set; }
        public int maxProjects { get; set; }

        public double costEffeincty { get; set; } //The lower the less price you pay
        public double qualityControll { get; set; } //the chance of failure

        public List<Enginner> enginners { get; set; }

        public ReseachNDevkiopnentFacility(int level) : base(level)
        {
            upkeep = upkeepOnLevel[level];
            researchSpeedMultplier = reserachSpeedOnLevel[level];
            maxProjects = maxProjectsOnLevel[level];
            costEffeincty = costEffeinctyOnLevel[level];
            qualityControll = qualityControllONLevel[level];
        }

        public void UpgradeFaccilty()
        {
            upkeep = upkeepOnLevel[level];
            researchSpeedMultplier = reserachSpeedOnLevel[level];
            maxProjects = maxProjectsOnLevel[level];
            costEffeincty = costEffeinctyOnLevel[level];
            qualityControll = qualityControllONLevel[level];
        }

        static int[] upkeepOnLevel = new int[] { 50000, 75000, 90000, 110000, 130000 };
        static double[] reserachSpeedOnLevel = new double[] { 1, 1.1, 1.2, 1.3, 1.6 };
        static int[] maxProjectsOnLevel = new int[] { 1, 2, 2, 3, 4 };
        static double[] costEffeinctyOnLevel = new double[] { 1, 1, 1, 0.9, 0.75 };
        static double[] qualityControllONLevel = new double[] { 0.3, 0.25, 0.2, 0.15, 0.1 };
        static int[] enginnersOnLevel = new int[] { 3, 6, 9, 11, 13 };

    }
    public class DriverFacility : Facility
    {
        public double simulatorQuality { get; set; } //devlopment boost
        public List<Driver> affialiates { get; set; }

        public DriverFacility(int level) : base(level)
        {
            upkeep = upkeepOnLevel[level];
            simulatorQuality = simulatorQuailtyOnLevel[level];
        }

        public void Update()
        {
            upkeep = upkeepOnLevel[level];
            simulatorQuality = simulatorQuailtyOnLevel[level];
        }

        static int[] upkeepOnLevel = new int[] { 30000, 40000, 50000, 60000, 70000 };
        static double[] simulatorQuailtyOnLevel = new double[] { 1, 1.05, 1.1, 1.15, 1.2 };
        static int[] affialitesOnLevel = new int[] { 0, 1, 1, 2, 4 };
    }

    public class PitCrewTranningFacility : Facility
    {
        public double speedTrainer { get; set; }
        public double faultTrainer { get; set; }
        public Pitcrew[] pitcrews { get; set; } //Needs to be 14 at all times

        public PitCrewTranningFacility(int level) : base(level)
        {
            upkeep = upkeepOnLevel[level];
            speedTrainer = speedTrainerOnLevel[level];
            faultTrainer = faultTrainerOnLevel[level];
        }

        public void UpgradeFaccilty()
        {
            upkeep = upkeepOnLevel[level];
            speedTrainer = speedTrainerOnLevel[level];
            faultTrainer = faultTrainerOnLevel[level];
        }

        static int[] upkeepOnLevel = new int[] { 20000, 30000, 40000, 50000, 60000 };
        static double[] speedTrainerOnLevel = new double[] { 1, 1.05, 1.1, 1.15, 1.2 };
        static double[] faultTrainerOnLevel = new double[] { 1, 1.05, 1.1, 1.15, 1.2 };
    }

    public class MarketingFacility : Facility
    {
        public double fanEngagementBoost { get; set; }
        public double sponsorshipAttractionBoost { get; set; }
        public double mediaTranningBoost { get; set; }
        public List<Marketer> marketers { get; set; }

        public MarketingFacility(int level) : base(level)
        {
            upkeep = upkeepOnLevel[level];
            fanEngagementBoost = fanEngagementBoostOnLevel[level];
            sponsorshipAttractionBoost = sponsorshipAttractionBoostOnLevel[level];
            mediaTranningBoost = mediaTranningBoostOnLevel[level];
        }

        public void UpgradeFaccilty()
        {
            upkeep = upkeepOnLevel[level];
            fanEngagementBoost = fanEngagementBoostOnLevel[level];
            sponsorshipAttractionBoost = sponsorshipAttractionBoostOnLevel[level];
            mediaTranningBoost = mediaTranningBoostOnLevel[level];
        }

        static int[] upkeepOnLevel = new int[] { 40000, 45000, 50000, 75000, 100000 };
        static double[] fanEngagementBoostOnLevel = new double[] { 1, 1.05, 1.1, 1.15, 1.2 };
        static double[] sponsorshipAttractionBoostOnLevel = new double[] { 1, 1.05, 1.1, 1.15, 1.2 };
        static double[] mediaTranningBoostOnLevel = new double[] { 1, 1.05, 1.1, 1.15, 1.2 };
        static int[] marketrsOnLevel = new int[] { 2, 3, 4, 5, 6 };
    }

    public class WindTunnel : Facility
    {
        public int hoursLeft { get; set; }
        public double testingSpeedMultplyer { get; set; }
        public double dataAccuracyMultpler { get; set; }

        public WindTunnel(int level) : base(level)
        {
            upkeep = upkeepOnLevel[level];
            testingSpeedMultplyer = testingSpeedMultplyerOnLevel[level];
            dataAccuracyMultpler = dataAccuracyMultplerOnLevel[level];
        }

        public void UpgradeFaccilty()
        {
            upkeep = upkeepOnLevel[level];
            testingSpeedMultplyer = testingSpeedMultplyerOnLevel[level];
            dataAccuracyMultpler = dataAccuracyMultplerOnLevel[level];
        }

        static int[] upkeepOnLevel = new int[] { 80000, 100000, 120000, 150000, 2000000 };
        static double[] testingSpeedMultplyerOnLevel = new double[] { 1, 1.2, 1.3, 1.4, 1.5 };
        static double[] dataAccuracyMultplerOnLevel = new double[] { 1, 1.05, 1.1, 1.15, 1.2 };
    }
}