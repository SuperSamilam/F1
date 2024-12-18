using DriverSpace;
using PeopleManagerSpace;
using StaffSpace;

namespace FacciltySpace
{
    public class Faccilty
    {
        public bool running { get; set; }
        public int upkeep { get; set; }
        public int level { get; set; } //Max level 5
        public double condition { get; set; }

        public Faccilty()
        {
            level = 0;
            running = true;
            condition = 1;
        }
    }

    public class RNDFaccilty : Faccilty
    {
        public List<int> enginners { get; set; }
        public int maxProjects { get; set; }
        public double costEfficenty { get; set; } //How much money do they need to spend to fix projects
        public double qualityControll { get; set; } //Chance of faileure

        //Wind tunnel explination
        //In F1 the engines are all pretty simlar, the big facotrs that make cars faster then eachother is the aerodynamics, all teams are allowed x hours in an wind tunnel to test their aerodynamics, the lower down in the wcc you are more time you get
        //During an F1 season their are multple "periods". For theese periods they get new wind tunnel hours to allowed devlopment for their cards during the season. Theese hours can also be used for other types of upgrades, such as planning new car parts for the next seaoson
        //Normaly thats not nessecary, but it happends. In 2026 their is a big regulation update witch will require theese types of devlopment to be able to stay ahead, but normaly consttcutrs start to focus on their next car around augsust even though the seaosn ends december
        public double windTunnelDataAccuracy { get; set; }
        public int allowedHoursLeft { get; set; }

        public RNDFaccilty() : base()
        {
            upkeep = upkeepOnLevel[level];
            maxProjects = maxProjectsOnLevel[level];
            costEfficenty = costEfficentyOnLevel[level];
            qualityControll = qualityControllOnLevel[level];
            enginners = new List<int>();
        }

        public void Upgrade()
        {
            level++;
            upkeep = upkeepOnLevel[level];
            maxProjects = maxProjectsOnLevel[level];
            costEfficenty = costEfficentyOnLevel[level];
            qualityControll = qualityControllOnLevel[level];
        }

        public static int[] upgradeCost = new int[] { 500000, 800000, 1000000, 2000000, 5000000 }; //cheepest 500k most expenisve 5million
        public static int[] upkeepOnLevel = new int[] { 50000, 75000, 90000, 110000, 130000 };
        public static int[] maxEmplooyesOnLevel = new int[] { 2, 4, 6, 8, 12 };
        public static int[] maxProjectsOnLevel = new int[] { 1, 2, 3, 4, 5 };
        public static double[] costEfficentyOnLevel = new double[] { 1, 0.99, 0.98, 0.96, 0.935 };
        public static double[] qualityControllOnLevel = new double[] { 0.3, 0.28, 0.23, 0.15, 0.1 };
        public static double[] windTunnelDataAcurracyOnLevel = new double[] { 1, 1.02, 1.05, 1.1, 1.3 };

    }

    public class DriverFaccilty : Faccilty
    {
        public List<int> affiliets { get; set; }
        public double simulatorQuality { get; set; }

        public DriverFaccilty() : base()
        {
            upkeep = upkeepOnLevel[level];
            simulatorQuality = simulatorQualtyOnLevel[level];
            affiliets = new List<int>();
        }

        public void Upgrade()
        {
            level++;
            upkeep = upkeepOnLevel[level];
            simulatorQuality = simulatorQualtyOnLevel[level];
        }

        public static int[] upgradeCost = new int[] { 400000, 700000, 1000000, 1500000, 2800000 }; //cheepest 400k most expenisve 2.8million
        public static int[] upkeepOnLevel = new int[] { 30000, 40000, 50000, 60000, 70000 };
        public static int[] maxEmplooyesOnLevel = new int[] { 0, 1, 2, 3, 5 };
        public static double[] simulatorQualtyOnLevel = new double[] { 1, 1.02, 1.05, 1.1, 1.3 };
    }

    public class PitterFacilty : Faccilty
    {
        public List<int> pitters { get; set; } //always 14
        public double speedTrainBoost { get; set; }
        public double faultTrainBoost { get; set; }

        public PitterFacilty() : base()
        {
            upkeep = upkeepOnLevel[level];
            speedTrainBoost = speedTrainBoostOnLevel[level];
            faultTrainBoost = faultTrainBoostOnLevel[level];
            pitters = new List<int>();
        }

        public void Upgrade()
        {
            level++;
            upkeep = upkeepOnLevel[level];
            speedTrainBoost = speedTrainBoostOnLevel[level];
            faultTrainBoost = faultTrainBoostOnLevel[level];
        }

        public double GetPitStopTime(PeopleManager peopleManager)
        {
            Random rand = new Random();
            double meanPitTime = 0;
            double meanFaultChance = 0;

            for (int i = 0; i < pitters.Count; i++)
            {
                meanPitTime += peopleManager.pitters[pitters[i]].tireChangeSpeed;
                meanFaultChance += peopleManager.pitters[pitters[i]].faultChance;
            }

            meanPitTime /= pitters.Count;
            meanFaultChance /= pitters.Count;

            double pitTime = (meanPitTime - 0.1) + (rand.NextDouble() * meanPitTime);
            if (rand.NextDouble() < meanFaultChance)
            {
                pitTime += 1.5;
            }
            return pitTime;
        }

        public static int[] upgradeCost = new int[] { 400000, 700000, 1000000, 1500000, 2800000 }; //cheepest 400k most expenisve 2.8million
        public static int[] upkeepOnLevel = new int[] { 20000, 30000, 40000, 50000, 60000 };
        public static double[] speedTrainBoostOnLevel = new double[] { 1, 1.02, 1.05, 1.1, 1.3 };
        public static double[] faultTrainBoostOnLevel = new double[] { 1, 1.02, 1.05, 1.1, 1.3 };
    }

    public class MarketingFaccilty : Faccilty
    {
        public List<int> marketers { get; set; }
        public double sponsorshipAttractiom { get; set; } //WHAT IS THIS ONE SUPPOSED TO DO

        public MarketingFaccilty() : base()
        {
            upkeep = upkeepOnLevel[level];
            sponsorshipAttractiom = sponsorShipAttractionOnLevel[level];
            marketers = new List<int>();
        }

        public void Upgrade()
        {
            level++;
            upkeep = upkeepOnLevel[level];
            sponsorshipAttractiom = sponsorShipAttractionOnLevel[level];
        }

        public static int[] upgradeCost = new int[] { 400000, 700000, 1000000, 1500000, 2800000 }; //cheepest 400k most expenisve 2.8million
        public static int[] upkeepOnLevel = new int[] { 20000, 30000, 40000, 50000, 650000 };
        public static int[] maxEmplooyesOnLevel = new int[] { 2, 3, 4, 5, 6 };
        public static double[] sponsorShipAttractionOnLevel = new double[] { 1, 1.02, 1.05, 1.1, 1.3 };
    }

    public class ScoutingFaccilty : Faccilty
    {
        public List<int> scouts { get; set; }
        public int maxScouting { get; set; }

        public ScoutingFaccilty() : base()
        {
            upkeep = upkeepOnLevel[level];
            maxScouting = maxProjectsOnLevel[level];
            scouts = new List<int>();
        }

        public void Upgrade()
        {
            level++;
            upkeep = upkeepOnLevel[level];
            maxScouting = maxProjectsOnLevel[level];
        }

        public static int[] upgradeCost = new int[] { 400000, 700000, 1000000, 1500000, 2800000 }; //cheepest 400k most expenisve 2.8million
        public static int[] upkeepOnLevel = new int[] { 20000, 30000, 40000, 50000, 650000 };
        public static int[] maxEmplooyesOnLevel = new int[] { 2, 3, 4, 5, 6 };
        public static int[] maxProjectsOnLevel = new int[] { 2, 3, 4, 5, 6 };
    }
}