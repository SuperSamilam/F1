using System.IO.Compression;
using System.Security.AccessControl;
using CarSpace;
using DriverSpace;
using PeopleManagerSpace;
using SeasonSpace;
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

        public void Upgrade()
        {
            level++;
        }

        public static double[] tranningBoostOnLevel = new double[] { 1.003, 1.006, 1.009, 1.012, 1.015 };
    }

    public class RNDFaccilty : Faccilty
    {
        public List<int> enginners { get; set; }
        public double qualityControll { get; set; } //Chance of faileure

        DevlopmentPlan devlopmentPlan {get; set;}


        public RNDFaccilty() : base()
        {
            upkeep = upkeepOnLevel[level];
            qualityControll = qualityControllOnLevel[level];
            enginners = new List<int>();
        }

        public void Upgrade()
        {
            level++;
            upkeep = upkeepOnLevel[level];
            qualityControll = qualityControllOnLevel[level];
        }

        public void Train(PeopleManager peopleManager)
        {
            for (int i = 0; i < enginners.Count; i++)
            {
                peopleManager.enginners[enginners[i]].devlopmentSpeed *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp((0.98 + (peopleManager.enginners[enginners[i]].development * (1.01 - 0.98))), 1, 1.1);
            }
        }



        public static int[] upgradeCost = new int[] { 500000, 800000, 1000000, 2000000, 5000000 }; //cheepest 500k most expenisve 5million
        public static int[] upkeepOnLevel = new int[] { 50000, 75000, 90000, 110000, 130000 };
        public static int[] maxEmplooyesOnLevel = new int[] { 2, 4, 6, 8, 12 };
        public static double[] qualityControllOnLevel = new double[] { 0.3, 0.28, 0.23, 0.15, 0.1 };

    }

    public class DriverFaccilty : Faccilty
    {
        public int affiliete1 { get; set; }
        public int affiliete2 { get; set; }

        public DriverFaccilty() : base()
        {
            upkeep = upkeepOnLevel[level];
            affiliete1 = -1;
            affiliete2 = -1;
        }

        public void Upgrade()
        {
            level++;
            upkeep = upkeepOnLevel[level];
        }

        public void Train(PeopleManager peopleManager, int driver1, int driver2)
        {

            if (affiliete1 != -1)
            {
                peopleManager.drivers[affiliete1].reactionTime *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[affiliete1].development * (1.01 - 0.98)), 1, 1.1);
                peopleManager.drivers[affiliete1].cornerSkill *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[affiliete1].development * (1.01 - 0.98)), 1, 1.1);
                peopleManager.drivers[affiliete1].defense *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[affiliete1].development * (1.01 - 0.98)), 1, 1.1);
                peopleManager.drivers[affiliete1].overtake *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[affiliete1].development * (1.01 - 0.98)), 1, 1.1);
                peopleManager.drivers[affiliete1].awerness *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[affiliete1].development * (1.01 - 0.98)), 1, 1.1);
            }

            if (affiliete2 != -1)
            {
                peopleManager.drivers[affiliete2].reactionTime *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[affiliete2].development * (1.01 - 0.98)), 1, 1.1);
                peopleManager.drivers[affiliete2].cornerSkill *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[affiliete2].development * (1.01 - 0.98)), 1, 1.1);
                peopleManager.drivers[affiliete2].defense *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[affiliete2].development * (1.01 - 0.98)), 1, 1.1);
                peopleManager.drivers[affiliete2].overtake *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[affiliete2].development * (1.01 - 0.98)), 1, 1.1);
                peopleManager.drivers[affiliete2].awerness *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[affiliete2].development * (1.01 - 0.98)), 1, 1.1);
            }

            peopleManager.drivers[driver1].reactionTime *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[driver1].development * (1.01 - 0.98)), 1, 1.1);
            peopleManager.drivers[driver1].cornerSkill *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[driver1].development * (1.01 - 0.98)), 1, 1.1);
            peopleManager.drivers[driver1].defense *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[driver1].development * (1.01 - 0.98)), 1, 1.1);
            peopleManager.drivers[driver1].overtake *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[driver1].development * (1.01 - 0.98)), 1, 1.1);
            peopleManager.drivers[driver1].awerness *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[driver1].development * (1.01 - 0.98)), 1, 1.1);

            peopleManager.drivers[driver2].reactionTime *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[driver2].development * (1.01 - 0.98)), 1, 1.1);
            peopleManager.drivers[driver2].cornerSkill *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[driver2].development * (1.01 - 0.98)), 1, 1.1);
            peopleManager.drivers[driver2].defense *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[driver2].development * (1.01 - 0.98)), 1, 1.1);
            peopleManager.drivers[driver2].overtake *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[driver2].development * (1.01 - 0.98)), 1, 1.1);
            peopleManager.drivers[driver2].awerness *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.drivers[driver2].development * (1.01 - 0.98)), 1, 1.1);

        }

        public static int[] upgradeCost = new int[] { 400000, 700000, 1000000, 1500000, 2800000 }; //cheepest 400k most expenisve 2.8million
        public static int[] upkeepOnLevel = new int[] { 30000, 40000, 50000, 60000, 70000 };
    }

    public class PitterFacilty : Faccilty
    {
        public List<int> pitters { get; set; } //always 14
        public double speedTrainBoost { get; set; }
        public double faultTrainBoost { get; set; }

        public PitterFacilty() : base()
        {
            upkeep = upkeepOnLevel[level];
            pitters = new List<int>();
        }

        public void Upgrade()
        {
            level++;
            upkeep = upkeepOnLevel[level];
        }

        public void Train(PeopleManager peopleManager)
        {
            for (int i = 0; i < pitters.Count; i++)
            {
                peopleManager.pitters[pitters[i]].tireChangeSpeed *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.pitters[pitters[i]].development * (1.01 - 0.98)), 1, 1.1);
                peopleManager.pitters[pitters[i]].faultChance *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.pitters[pitters[i]].development * (1.01 - 0.98)), 1, 1.1);
            }
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
    }

    public class MarketingFaccilty : Faccilty
    {
        public List<int> marketers { get; set; }

        public MarketingFaccilty() : base()
        {
            upkeep = upkeepOnLevel[level];
            marketers = new List<int>();
        }

        public void Upgrade()
        {
            level++;
            upkeep = upkeepOnLevel[level];
        }

        public void Train(PeopleManager peopleManager)
        {
            for (int i = 0; i < marketers.Count; i++)
            {
                peopleManager.marketers[marketers[i]].fanEngagementSkill *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.marketers[marketers[i]].development * (1.01 - 0.98)), 1, 1.1);
                peopleManager.marketers[marketers[i]].sponsorshipNegotioationSkill *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.marketers[marketers[i]].development * (1.01 - 0.98)), 1, 1.1);
            }
        }

        public static int[] upgradeCost = new int[] { 400000, 700000, 1000000, 1500000, 2800000 }; //cheepest 400k most expenisve 2.8million
        public static int[] upkeepOnLevel = new int[] { 20000, 30000, 40000, 50000, 650000 };
        public static int[] maxEmplooyesOnLevel = new int[] { 2, 3, 4, 5, 6 };
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

        public void Train(PeopleManager peopleManager)
        {
            for (int i = 0; i < scouts.Count; i++)
            {
                peopleManager.scouts[scouts[i]].scoutSkill *= Faccilty.tranningBoostOnLevel[level] * Math.Clamp(0.98 + (peopleManager.scouts[scouts[i]].development * (1.01 - 0.98)), 1, 1.1);
            }
        }

        public static int[] upgradeCost = new int[] { 400000, 700000, 1000000, 1500000, 2800000 }; //cheepest 400k most expenisve 2.8million
        public static int[] upkeepOnLevel = new int[] { 20000, 30000, 40000, 50000, 650000 };
        public static int[] maxEmplooyesOnLevel = new int[] { 2, 3, 4, 5, 6 };
        public static int[] maxProjectsOnLevel = new int[] { 2, 3, 4, 5, 6 };
    }
}