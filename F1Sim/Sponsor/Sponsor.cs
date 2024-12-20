namespace SponsorSpace
{
    public class Sponsor
    {
        public string companyName { get; set; }
        public CompanyType compnayType { get; set; }
        public double popularity { get; set; }
        public int payout { get; set; }
        public string teamSponsored { get; set; }

        public Sponsor(string companyName, CompanyType compnayType)
        {
            this.companyName = companyName;
            this.compnayType = compnayType;

            Random rand = new Random();
            popularity = rand.NextDouble();
            payout = 0;
            teamSponsored = "";
        }
    }

    public struct SponsorOffer
    {
        public int sponsor;
        public int money;
        public double sponsorPopularity;
        public double popularityDiff;

        public SponsorOffer(int sponor, int money, double sponsorPopularity, double popularityDiff)
        {
            this.sponsor = sponor;
            this.money = money;
            this.sponsorPopularity = sponsorPopularity;
            this.popularityDiff = popularityDiff;
        }
    }
    public enum CompanyType { Retail, OilNGas, Clothes, Mobile, ComputerParts, VideoGames, VideoFilm, SocialMedia, Computers, Toys, Planes, Resturants, Logistics, Travling, Food, Finance };
}


//Sponsor logic
//They pay a sum to sponsor
//They can partner with a higher popularity team and they will pay more, but the team will lose poularity
//They can partner with a lower popularity team and they will pay less, but the team will gain popularity

//Ideas
//Sponors can have favorite teams that increase the money they give and reduce the populary loss or increace to populary gain, as well they dont want to sponors the rival teams