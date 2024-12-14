using System.Security.Cryptography;
using TeamSpace;

namespace SponsorSpace
{
    public class Sponsor
    {
        public string companyName { get; set; }
        public CompanyType companyType { get; set; }

        public Team teamSponsored {get; set;}

        public Sponsor(string companyName, CompanyType companyType)
        {
            this.companyName = companyName;
            this.companyType = companyType;
        }

    }

    public enum CompanyType { Retail, OilNGas, Clothes, Mobile, ComputerParts, VideoGames, VideoFilm, SocialMedia, Computers, Toys, Planes, Resturants, Logistics, Travling, Food, Finance }
}

