using CarSpace;
using DriverSpace;
using FacciltySpace;
using PeopleManagerSpace;
using SponsorManagerSpace;
using SponsorSpace;
using StaffSpace;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using TeamManagerSpace;

namespace TeamSpace
{
    public class Team
    {
        public string name { get; set; }
        public int driver1 { get; set; }
        public int driver2 { get; set; }

        public int teamPrincipal { get; set; }

        public Car car1 { get; set; }
        public Car car2 { get; set; }

        //Facciltys
        public RNDFaccilty rNDFaccilty { get; set; }
        public DriverFaccilty driverFaccilty { get; set; }
        public PitterFacilty pitterFacilty { get; set; }
        public MarketingFaccilty marketingFaccilty { get; set; }
        public ScoutingFaccilty scoutingFaccilty { get; set; }

        public List<int> sponsors { get; set; }

        public double popularity { get; set; }
        public int money { get; set; }
        public int placementLastYear { get; set; }

        public int teamSeed { get; set; } //Used so sponsordeals wont change from season to season

        public Team(string name)
        {
            this.name = name;
            popularity = 0.2;
            money = 10000000;
            placementLastYear = -1;
            Car car = Car.CreateNewCar(0.2);
            car1 = JsonSerializer.Deserialize<Car>(JsonSerializer.Serialize(car));
            car2 = JsonSerializer.Deserialize<Car>(JsonSerializer.Serialize(car));

            rNDFaccilty = new RNDFaccilty();
            driverFaccilty = new DriverFaccilty();
            pitterFacilty = new PitterFacilty();
            marketingFaccilty = new MarketingFaccilty();
            scoutingFaccilty = new ScoutingFaccilty();
            teamSeed = new Random().Next(-10000, 10000);
        }

        public void GetNewSponsors(int sponsorsToGet, SponsorManager sponsorManager, TeamManager teamManager)
        {
            //Sponsors work like this for the AI
            //Depending on the postion finshed last year they decide on what type of sponsor they want
            //They can choose a sponsor with higher popularity and therefor will offer more money, but also a sponsor with lower popularity but will offer more money
            sponsorsToGet = Math.Max(4, sponsorsToGet);

            for (int i = 0; i < sponsorsToGet; i++)
            {
                bool isWC = false;
                if (placementLastYear == 1)
                    isWC = true;

                double sponsorToWant = new Random().NextDouble();
                double chanceOfWantingMoneySponsor = placementLastYear / teamManager.teams.Count;

                List<SponsorOffer> offers = sponsorManager.GetSponsorOffersForTeam(popularity, teamSeed, isWC, sponsors);
                int bestOffer = 0;
                for (int j = 1; j < offers.Count; j++)
                {
                    if (sponsorToWant < chanceOfWantingMoneySponsor)
                    {
                        //FIND THE offer with most money
                        if (offers[j].money > offers[bestOffer].money)
                        {
                            bestOffer = j;
                        }
                    }
                    else
                    {
                        //Find the offer with most populartydiffernce that is negative
                        if (offers[j].popularityDiff < offers[bestOffer].popularityDiff)
                        {
                            bestOffer = j;
                        }
                    }
                }
                sponsorManager.SignSponsor(name, offers[bestOffer].sponsor, offers[bestOffer].money);
                sponsors.Add(offers[bestOffer].sponsor);
            }

        }

        public void HirePitCrew(PeopleManager peopleManager)
        {
            //Hire a new pitter
            List<int> toHire = peopleManager.GetUnemployedPitters(14 - pitterFacilty.pitters.Count);
            pitterFacilty.pitters.AddRange(toHire);
            for (int i = 0; i < toHire.Count; i++)
            {
                peopleManager.pitters[toHire[i]].team = placementLastYear - 1;
                peopleManager.pitters[toHire[i]].teamName = name;
            }
        }

        public void HireEnginner(PeopleManager peopleManager)
        {
            List<int> toHire = peopleManager.GetUnemployedEnginners(RNDFaccilty.maxEmplooyesOnLevel[rNDFaccilty.level] - rNDFaccilty.enginners.Count);
            rNDFaccilty.enginners.AddRange(toHire);
            for (int i = 0; i < toHire.Count; i++)
            {
                peopleManager.enginners[toHire[i]].team = placementLastYear - 1;
                peopleManager.enginners[toHire[i]].teamName = name;
            }
        }

        public void HireScouter(PeopleManager peopleManager)
        {
            List<int> toHire = peopleManager.GetUnemployedEnginners(ScoutingFaccilty.maxEmplooyesOnLevel[scoutingFaccilty.level] - scoutingFaccilty.scouts.Count);
            scoutingFaccilty.scouts.AddRange(toHire);
            for (int i = 0; i < toHire.Count; i++)
            {
                peopleManager.scouts[toHire[i]].team = placementLastYear - 1;
                peopleManager.scouts[toHire[i]].teamName = name;
            }
        }

        public void HireMarketer(PeopleManager peopleManager)
        {
            List<int> toHire = peopleManager.GetUnemployedEnginners(MarketingFaccilty.maxEmplooyesOnLevel[marketingFaccilty.level] - marketingFaccilty.marketers.Count);
            marketingFaccilty.marketers.AddRange(toHire);
            for (int i = 0; i < toHire.Count; i++)
            {
                peopleManager.marketers[toHire[i]].team = placementLastYear - 1;
                peopleManager.marketers[toHire[i]].teamName = name;
            }
        }

        public void HireDrivers(PeopleManager peopleManager, int year)
        {
            List<int> toHire = peopleManager.GetUnemployedDrivers(2);
            driver1 = toHire[0];
            driver2 = toHire[1];
            for (int i = 0; i < toHire.Count; i++)
            {
                peopleManager.drivers[toHire[i]].team = placementLastYear - 1;
                peopleManager.drivers[toHire[i]].contractEndYear = year+1;
                peopleManager.drivers[toHire[i]].teamName = name;
            }
        }
        public void HireTP(PeopleManager peopleManager)
        {
            List<int> toHire = peopleManager.GetUnemployedTeampricnipals(1);
            teamPrincipal = toHire[0];
            for (int i = 0; i < toHire.Count; i++)
            {
                peopleManager.teamPrincipals[toHire[i]].team = placementLastYear - 1;
                peopleManager.teamPrincipals[toHire[i]].teamName = name;
            }
        }

        public static Team CreateTeeamWithName(string name)
        {
            return new Team(name);
        }

        public static Team CreateTeeamWithoutName(TeamManager teamManager)
        {
            Random rand = new Random();

            int trys = 3;

            for (int i = 0; i < trys; i++)
            {
                string[] names = File.ReadAllLines(@"carbrands.txt");
                string name = names[rand.Next(0, names.Length)];

                bool valid = true;
                for (int j = 0; j < teamManager.teams.Count; j++)
                {
                    if (name == teamManager.teams[j].name)
                    {
                        valid = false;
                        continue;
                    }
                }

                if (valid)
                    return new Team(name);

            }

            return null;
        }
    }
}