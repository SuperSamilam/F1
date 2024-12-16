
namespace SponsorManagerSpace
{
    using DataSpace;
    using SponsorSpace;

    public class SponsorManager : DataPersistance
    {
        List<Sponsor> sponsors;

        public SponsorManager()
        {
            InterfaceFinder.dataPersistanceRegistry.Add(this);
        }

        public List<int> GetSponsorOffersForTeam(double teamPopularity, bool isWC, List<int> existingSponsors)
        {
            if (existingSponsors.Count >= 4)
                throw new ArgumentException("Max sponsors is 4 per team this should never execute");

            List<int> sponsorOffers = new List<int>();

            //editing sponsor data directly because as long as i dont edit teamsponored they are not bound to anything
            for (int i = 0; i < sponsors.Count; i++)
            {
                for (int j = 0; j < existingSponsors.Count; j++)
                {
                    if (i == j)
                        continue;

                    if (sponsors[i].compnayType == sponsors[existingSponsors[j]].compnayType)
                        continue;


                    int basePay = (int)Math.Clamp(10000000, 20000000, (20000000 * teamPopularity));

                    //is WC stands for world constructor, it refers to the team who won the world construct championship/best car
                    if (isWC)
                        basePay += (int)(5000000 * teamPopularity);

                    double popularityDiff = teamPopularity - sponsors[i].popularity;

                    if (popularityDiff < 0)
                        basePay -= (int)(3000000 * -popularityDiff);
                    else
                    {
                        popularityDiff++;
                        basePay += (int)(3000000 * popularityDiff);
                    }

                    sponsors[i].payout = basePay;
                    sponsorOffers.Add(i);

                }
            }
            return sponsorOffers;
        }

        public void SignSponsor(int team, int sponsor)
        {
            sponsors[sponsor].teamSponsored = team;
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