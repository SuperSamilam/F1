using System.Security.Cryptography;
using TeamSpace;

namespace SponsorSpace
{
    public class Sponsor
    {
        public string companyName { get; set; }
        public CompanyType companyType { get; set; }
        public double popularity { get; set; }

        public int paying { get; set; } //The amount they pay each month

        public Team teamSponsored { get; set; }

        public Sponsor(string companyName, CompanyType companyType)
        {
            this.companyName = companyName;
            this.companyType = companyType;
            popularity = new Random().NextDouble();
        }

        public int GenerateOffer(double teamPopularity, bool isWC)
        {
            //max offer is 31 million min is 7 million

            int basePay = (int)Math.Clamp(10000000, 20000000, (20000000 * teamPopularity));

            if (isWC)
                basePay += (int)(5000000 * teamPopularity);

            double popularityDiff = teamPopularity - popularity;

            //The sponsor is more popular
            if (popularityDiff < 0)
                basePay -= (int)(3000000 * -popularityDiff);
            else
            {
                popularityDiff++; //Makes a zero popDiff to 1 meanign x*popDiff = x, if popdiff was already 1 it gets a 2x boost
                basePay += (int)(3000000 * popularityDiff);
            }


            return basePay;
        }



    }

    public enum CompanyType { Retail, OilNGas, Clothes, Mobile, ComputerParts, VideoGames, VideoFilm, SocialMedia, Computers, Toys, Planes, Resturants, Logistics, Travling, Food, Finance }
}

//If signined with unpopular sponsor you will lose popularty
//if signed with popular sposnor you will gain populatrity