
namespace SponsorManagerSpace
{
    using DataSpace;
    using SponsorSpace;

    public class SponsorManager : DataPersistance
    {
        List<Sponsor> sponsors;
        GameManager manager;
        public SponsorManager(GameManager manager)
        {
            InterfaceFinder.dataPersistanceRegistry.Add(this);
            this.manager = manager;
        }

        public List<SponsorOffer> GetSponsorOffersForTeam(double teamPopularity, int teamSeed, bool isWC, List<int> existingSponsors)
        {
            if (existingSponsors.Count >= 4)
                throw new ArgumentException("Max sponsors is 4 per team this should never execute");

            List<SponsorOffer> sponsorOffers = new List<SponsorOffer>();
            Random rand = new Random(teamSeed);
            //editing sponsor data directly because as long as i dont edit teamsponored they are not bound to anything
            for (int i = 0; i < sponsors.Count; i++)
            {
                for (int j = 0; j < existingSponsors.Count; j++)
                {
                    if (i == j)
                        continue;

                    if (sponsors[i].compnayType == sponsors[existingSponsors[j]].compnayType)
                        continue;


                    //Base pay 1-3 million a month
                    int basePay = rand.Next(20000000, 25000000);

                    //is WC stands for world constructor, it refers to the team who won the world construct championship/best car
                    //200k extra if wcc
                    if (isWC)
                        basePay += (int)(200000 * teamPopularity);

                    double popularityDiff = teamPopularity - sponsors[i].popularity;

                    if (popularityDiff < 0)
                        basePay -= (int)(5000000 * -popularityDiff);
                    else
                    {
                        basePay += (int)(1000000 * (popularityDiff+1));
                    }

                    SponsorOffer sponsorOffer = new SponsorOffer(i, basePay, sponsors[i].popularity, popularityDiff);
                    sponsorOffers.Add(sponsorOffer);

                }
            }
            return sponsorOffers;
        }

        public void SignSponsor(string team, int sponsor, int money)
        {
            sponsors[sponsor].teamSponsored = team;
            sponsors[sponsor].payout = money;
        }

        public void loadData(GameData data)
        {
            sponsors = data.sponsors;
        }

        public void saveData(GameData data)
        {
            data.sponsors = sponsors;
        }
    }
}